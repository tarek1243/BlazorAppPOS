using Microsoft.EntityFrameworkCore;

namespace BlazorAppSales.Data
{
    public interface IOrderService
    {
        Task<Order> GetOrderById(int orderId);
        Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId);
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> PlaceOrderx(Order order);
        int CalculateLoyaltyPointsEarned(decimal totalAmount);
    }

    public interface ILoyaltyProgramService
    {
        int CalculateLoyaltyPointsEarned(decimal totalAmount);
    }

    public class LoyaltyProgramService : ILoyaltyProgramService
    {
        public int CalculateLoyaltyPointsEarned(decimal totalAmount)
        {
            return (int)(totalAmount / 100);
        }
    }

    public class OrderService : IOrderService
    {
        private readonly DbContextMainData _dbContext = new DbContextMainData();
        private readonly ILoyaltyProgramService _loyaltyProgramService;

        public int CalculateLoyaltyPointsEarned(decimal totalAmount)
        {
            return (int)(totalAmount / 100);
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _dbContext.Pos_Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderLines)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId)
        {
            return await _dbContext.Pos_Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderLines)
                    .ThenInclude(oi => oi.Product)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _dbContext.Pos_Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderLines)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.shift).OrderByDescending(o => o.Id)
               .ToListAsync();
        }



        public async Task DeleteOrderAsync(int orderId)
        {
            Order o = _dbContext.Pos_Orders.Include(p => p.OrderLines).Single(a => a.Id == orderId);
            if (o.OrderLines.Count() > 0)
            {
                o.OrderLines.Clear();
                //o.Items.RemoveRange(0, o.Items.Count() - 1);
                _dbContext.Pos_Orders.Attach(o);
                _dbContext.SaveChanges();
            }
            _dbContext.Remove(o);
            _dbContext.SaveChanges();
            /*
                        var order = await _dbContext.Pos_Orders.FindAsync(orderId);

                        if (order == null)
                        {
                            throw new Exception($"Order with ID {orderId} not found.");
                        }
                        _dbContext.Pos_Orders.Remove(order);
                        await _dbContext.SaveChangesAsync();*/
        }



        public async Task<Order> PlaceOrderx(Order order)
        {
            _dbContext.Pos_Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<int> PlaceOrder(Order order)
        {
            // Get the company for the customer
            // var customer = await _dbContext.Customers.FindAsync(order.CustomerId);
            var company = await _dbContext.Pos_Companies.FindAsync(order.CompanyId);

            // Get the last invoice number used for the company and increment it
            var companyInvoiceNumber = await _dbContext.CompanyInvoiceNumbers
                .Where(c => c.CompanyId == company.Id)
                .FirstOrDefaultAsync();

            companyInvoiceNumber.LastInvoiceNumber++;

            // Assign the invoice number to the order
            order.InvoiceNumber = companyInvoiceNumber.LastInvoiceNumber;



            // Calculate the total amount of the order
            /*           decimal totalAmount = 0;
                       foreach (var orderLine in order.OrderLines)
                       {
                           //var product = _productService.GetProductById(orderLine.Product.Id);
                           totalAmount += orderLine.Total;// * orderLine.Quantity;
                       }*/
            //order.OrderLines.ForEach(s => sum)
            // Calculate the loyalty points earned by the customer for this order
            int loyaltyPointsEarned = _loyaltyProgramService.CalculateLoyaltyPointsEarned(order.Total);
            order.LoyaltyPointsEarned = loyaltyPointsEarned;
            order.Customer.LoyaltyPoints += loyaltyPointsEarned;




            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            // Return the new order ID
            return order.Id;
        }

        public async Task<Order> UpdateOrderPayment(int orderId, List<Pos_OrderPayment> payments)
        {
            var order = await _dbContext.Pos_Orders.Include(o => o.Pos_OrderPayments).FirstOrDefaultAsync(o => o.Id == orderId);
            if (order == null)
            {
                throw new ArgumentException($"Order with ID {orderId} does not exist.");
            }

            if (order.IsPaid)
            {
                throw new InvalidOperationException($"Order with ID {orderId} has already been paid.");
            }

            var totalPaidAmount = payments.Sum(p => p.Amount);
            if (totalPaidAmount > order.Total_With_VAT)
            {
                throw new InvalidOperationException("The total paid amount cannot be greater than the order total amount.");
            }

            order.Pos_OrderPayments.Clear();
            foreach (var payment in payments)
            {
                order.Pos_OrderPayments.Add(payment);
            }

            if (totalPaidAmount == order.Total)
            {
                order.IsPaid = true;
                order.PaidAt = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync();

            return order;
        }
    }
}
