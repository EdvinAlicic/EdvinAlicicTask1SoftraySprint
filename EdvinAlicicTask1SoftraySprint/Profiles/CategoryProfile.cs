using AutoMapper;

namespace EdvinAlicicTask1SoftraySprint.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, Models.CategoryDto>();
        }
    }
}
