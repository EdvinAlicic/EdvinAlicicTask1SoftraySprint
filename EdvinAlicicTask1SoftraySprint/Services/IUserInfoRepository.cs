using EdvinAlicicTask1SoftraySprint.Models;

namespace EdvinAlicicTask1SoftraySprint.Services
{
    public interface IUserInfoRepository
    {
        Task<UserLoginDto> Login(string email, string password);
        Task Registration(string name, string lastName, string username, string email, string password);
    }
}
