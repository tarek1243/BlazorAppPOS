using Microsoft.EntityFrameworkCore;

namespace BlazorAppSales.Data
{
    public interface IShiftService
    {
        Task<List<Shift>> GetShiftsWithOrdersSummary();
    }

    public class ShiftService : IShiftService
    {
        //private readonly DbContextMainData _dbContext;
        private readonly DbContextMainData _dbContext = new DbContextMainData();

        /*        public ShiftService(DbContextMainData dbContext)
                {
                    _dbContext = dbContext;
                }*/
        public ShiftService()
        {
            _dbContext = new DbContextMainData(); 
        }
        public async Task<List<Shift>> GetShiftsWithOrdersSummary()
        {
            var shifts = await _dbContext.Pos_Shifts
                .Include(s => s.Orders)
                .ThenInclude(s => s.Items)
                .ToListAsync();

            foreach (var shift in shifts)
            {
                shift.Orders = shift.Orders.OrderByDescending(o => o.OrderDate).ToList();
            }
            return shifts;
        }
        public async Task<List<Shift>> GetShiftsWithOrdersSummary(string companyName)
        {
            var shifts = await _dbContext.Pos_Shifts
                .Where  (s => s.CompanyName == companyName).OrderByDescending (s=> s.OpenedAt) 
                .Include(s => s.Orders)
                .ThenInclude(s => s.Items)
                .ToListAsync();

            foreach (var shift in shifts)
            {
                shift.Orders = shift.Orders.OrderByDescending(o => o.OrderDate).ToList();
            }
            return shifts;
        }


        public async Task<Shift> GetShiftAsync(int id)
        {
            var shifts = await _dbContext.Pos_Shifts.Where(s => s.Id==id)
                .Include(s => s.Orders)
                .FirstOrDefaultAsync();

/*            foreach (var shift in shifts)
            {
                shift.Orders = shift.Orders.OrderByDescending(o => o.OrderDate).ToList();
            }*/

            return shifts;
        }

    }

}
