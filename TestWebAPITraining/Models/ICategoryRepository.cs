namespace TestWebAPITraining.Models
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();//Async

        //IEnumerable<Category>> GetAllCategories();//SYnc
    }
}
