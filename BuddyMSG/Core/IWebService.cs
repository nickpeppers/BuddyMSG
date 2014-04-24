using System;
using System.Threading.Tasks;

namespace BuddyMSG
{
	public class IWebService
	{
        public async Task<Buddy.AuthenticatedUser> Login(string username, string password)
		{
            var User = await BuddyService.BuddyClientService.LoginAsync(username, password);
            return User;
		}

        public async Task<Buddy.AuthenticatedUser> CreateUser(string name, string password, string email)
        {
            var User = await BuddyService.BuddyClientService.CreateUserAsync(name, password, Buddy.UserGender.Any, 0, email, Buddy.UserStatus.Any, false, false, string.Empty);
            return User;
        }
	}
}

