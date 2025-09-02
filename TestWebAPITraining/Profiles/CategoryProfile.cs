using AutoMapper;

namespace TestWebAPITraining.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Models.Category, Models.CategoryWithoutPies>();
           
        }
    }
}
