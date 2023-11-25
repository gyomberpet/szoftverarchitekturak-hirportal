using NewsPortal.WebAppApi.Models;

namespace NewsPortal.WebAppApi.Repositories
{
    public interface IUsersRepository
    {
        public Task<IEnumerable<User>> ListUsers();
        public Task<User> GetUser(string id);
        public Task<User> GetUserByEmail(string email);
		public Task<User> AddUser(User user);
        public Task<User> UpdateUser(User user);
        public Task<bool> DeleteUser(string id);
        public Task<User> PromoteUser(string id);

    }
}
