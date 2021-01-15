using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserComment.BasicAuth
{
    public interface IUserService
    {
        Task<DebugUser> Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private readonly List<DebugUser> _users = new List<DebugUser>
        {
            new DebugUser()
        };

        public async Task<DebugUser> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.UserName == username && x.Password == password));

            // return null if DebugUser not found
            if (user == null)
                return null;

            // authentication successful so return DebugUser details without password
            user.Password = null;
            return user;
        }

    }

}
