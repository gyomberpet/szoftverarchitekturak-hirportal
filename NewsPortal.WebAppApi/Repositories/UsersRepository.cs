using Microsoft.EntityFrameworkCore;
using NewsPortal.WebAppApi.Data;
using NewsPortal.WebAppApi.Models;

namespace NewsPortal.WebAppApi.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext context;

        public UsersRepository(DataContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<User>> ListUsers()
        {
            var users = await context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetUser(string id)
        {
            var user = await context.Users.FindAsync(id);

            return user;
        }
		public async Task<User> GetUserByEmail(string email)
		{
			var user = await context.Users
                .FirstOrDefaultAsync(u => u.EmailAddress == email);

			return user;
		}


		public async Task<User> AddUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return user;
        }


        public async Task<User> UpdateUser(User user)
        {
            if (user == null) return user;

            context.Users.Update(user);
            await context.SaveChangesAsync();

            return user;
        }
        public async Task<User> PromoteUser(string id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null) return user;

            user.IsAdmin = !user.IsAdmin;

            context.Users.Update(user);
            await context.SaveChangesAsync();

            return user;
        }
        public async Task<bool> DeleteUser(string id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
