
using Microsoft.EntityFrameworkCore;

namespace TestWebAPITraining.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly ShopDBContext _dbContext;
        public PieRepository(ShopDBContext context)
        {
            _dbContext = context;
        }
        
        public async Task<IEnumerable<Pie>> AllPiesAsync()
        {
            return await _dbContext.pies.Include(c => c.Category)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Pie>> PiesOfTheWeekAsync()
        {
            return await _dbContext.pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek)
                .ToListAsync();
        }
        public async Task<Pie?> GetPieByIdAsync(int pieId)
        {
            return await _dbContext.pies.FirstOrDefaultAsync(c=>c.PieId == pieId); 
        }

       
    }
}
