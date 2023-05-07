using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppSales.Data
{
    public interface IOrderService
    {
        Task<Order> GetOrderById(int orderId);
        Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId);
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> PlaceOrderx(Order order);
    }



    public class OrderService : IOrderService
    {
        private readonly DbContextMainData _dbContext = new DbContextMainData();

        /*        public OrderService(DbContextMainData dbContext)
                {
                    _dbContext = dbContext;
                }*/


        public async Task<Order> GetOrderById(int orderId)
        {
            return await _dbContext.Pos_Orders
                .Include(o => o.Customer)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId)
        {
            return await _dbContext.Pos_Orders
                .Include(o => o.Customer)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _dbContext.Pos_Orders
                .Include(o => o.Customer)
                .Include(o => o.Items)


                    .ThenInclude(oi => oi.Product)
                    .Include(o => o.shift).OrderByDescending(o => o.Id)
                .ToListAsync();
        }



        public async Task DeleteOrderAsync(int orderId)
        {
            Order o = _dbContext.Pos_Orders.Include(p => p.Items).Single(a => a.Id == orderId);
            if (o.Items.Count() > 0)
            {
                o.Items.Clear();
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

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            // Return the new order ID
            return order.Id;
        }
    }


 /*   public static class EntityExtensions
    {
        public static void Clearx<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
*/


}
