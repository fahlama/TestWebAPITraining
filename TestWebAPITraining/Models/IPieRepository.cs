namespace TestWebAPITraining.Models
{
    public interface IPieRepository
    {
        Task<IEnumerable<Pie>> AllPiesAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Pie>> PiesOfTheWeekAsync(); 
        Task<Pie?> GetPieByIdAsync(int pieId);

        Task<int> AddPieAsync(Pie pie);
        Task<int> UpdatePieAsync(Pie pie);
        Task<int> DeletePieAsync(int id);

    }
}
