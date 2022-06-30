using AutoMapper;
using EdvinAlicicTask1SoftraySprint.DbContexts;
using EdvinAlicicTask1SoftraySprint.Entities;
using EdvinAlicicTask1SoftraySprint.Models;
using Microsoft.EntityFrameworkCore;

namespace EdvinAlicicTask1SoftraySprint.Services
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly SongInfoContext _songInfoContext;
        private readonly IMapper _mapper;
        public UserInfoRepository(SongInfoContext songInfoContext, IMapper mapper)
        {
            _songInfoContext = songInfoContext ?? throw new ArgumentNullException(nameof(songInfoContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserLoginDto> Login(string email, string password)
        {
            var user = await _songInfoContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            _songInfoContext.Update(user);
            await _songInfoContext.SaveChangesAsync();
            return new UserLoginDto()
            {
                Name = user.Name,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };

            return null;
        }

        public async Task Registration(string name, string lastName, string username, string email, string password)
        {
            User user = new User();
            user.Name = name;
            user.LastName = lastName;
            user.Username = username;
            user.Email = email;
            user.Password = password;

            await _songInfoContext.Users.AddAsync(user);
            await _songInfoContext.SaveChangesAsync();
        }
    }
}
