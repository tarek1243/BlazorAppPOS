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
                .Where  (s => s.CompanyName == companyName).OrderByDescending (s=> s.created_Date) 
                .Include(s => s.Orders)
                .ThenInclude(s => s.OrderLines).ThenInclude(i => i.Product)
                .ToListAsync();

            foreach (var shift in customers)
            {
                shift.Orders = shift.Orders.OrderByDescending(o => o.OrderDate).ToList();
            }
            return customers;
        }


        public async Task<Shift> GetShiftAsync(int id)
        {
            var shifts = await _dbContext.Pos_Shifts.Where(s => s.Id==id)
                .Include(s => s.Orders)
                .FirstOrDefaultAsync();

            return shifts;
        }

    }

}
