using Microsoft.EntityFrameworkCore;

namespace BlazorAppSales.Data
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomersWithOrdersSummary();
    }

    public class CustomerService : ICustomerService
    {
        private readonly DbContextMainData _dbContext = new DbContextMainData();
        public CustomerService()
        {
            _dbContext = new DbContextMainData(); 
        }
        public async Task<List<Customer>> GetCustomersWithOrdersSummary()
        {
            var shifts = await _dbContext.Pos_Customers
                .Include(s => s.Orders)
                .ThenInclude(s => s.OrderLines)
                .ToListAsync();

            foreach (var shift in shifts)
            {
                shift.Orders = shift.Orders.OrderByDescending(o => o.OrderDate).ToList();
            }
            return shifts;
        }
        public async Task<List<Customer>> GetCustomersWithOrdersSummary(string companyName)
        {
            var customers = await _dbContext.Pos_Customers
                .Where(s => s.CompanyName == companyName).OrderByDescending(s => s.created_Date)
                .Include(s => s.Orders)
                .ThenInclude(s => s.OrderLines).ThenInclude(i => i.Product).Include(x => x.Orders).ThenInclude(o=> o.Pos_OrderPayments).ThenInclude(p=> p.pos_MethodOfPayment)
                .ToListAsync();

            foreach (var shift in customers)
            {
                shift.Orders = shift.Orders.OrderByDescending(o => o.OrderDate).ToList();
            }
            return customers;
        }
        public async Task<List<Pos_MethodOfPayment>> GetPos_MethodOfPayment_list(string companyName)
        {
            var Pos_MethodOfPayments = await _dbContext.Pos_MethodOfPayments   
                .Where  (s => s.CompanyName == companyName || s.CompanyName == "" || s.CompanyName == null) 
                .ToListAsync();
            return Pos_MethodOfPayments;
        }
         

    }

}
