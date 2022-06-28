using AutoMapper;

namespace EdvinAlicicTask1SoftraySprint.Profiles
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Entities.Song, Models.SongDto>();
        }
    }
}
