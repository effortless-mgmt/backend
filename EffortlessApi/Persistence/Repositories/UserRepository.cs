using System.Threading.Tasks;
using EffortlessApi.Core.Models;
using EffortlessApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EffortlessApi.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public EffortlessContext EffortlessContext 
        {
            get { return _context as EffortlessContext; }
        }

        public async Task<User> GetByUsernameAsync(string userName)
        {
            return await _context.Set<User>().SingleOrDefaultAsync(user => user.UserName == userName);
        }

        public async Task UpdateAsync(string userName, User newUser)
        {
            var userToEdit = await GetByUsernameAsync(userName);

            userToEdit.UserName = newUser.UserName;
            userToEdit.FirstName = newUser.FirstName;
            userToEdit.LastName = newUser.LastName;
            userToEdit.Email = newUser.Email;
            userToEdit.Password = newUser.Password;

            _context.Set<User>().Update(userToEdit);
        }
    }
}