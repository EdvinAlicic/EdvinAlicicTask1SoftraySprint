using AutoMapper;

namespace EdvinAlicicTask1SoftraySprint.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, Models.UserLoginDto>();
        }
    }
}
