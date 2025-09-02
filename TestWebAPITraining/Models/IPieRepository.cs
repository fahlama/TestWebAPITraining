namespace TestWebAPITraining.Models
{
    public interface IPieRepository
    {
        Task<IEnumerable<Pie>> AllPiesAsync();
        Task<IEnumerable<Pie>> PiesOfTheWeekAsync(); 
        Task<Pie?> GetPieByIdAsync(int pieId);
        
    }
}
