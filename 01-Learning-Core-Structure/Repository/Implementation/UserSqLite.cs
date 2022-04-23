using _01_Learning_Core_Structure.Repository;
using _01_Learning_Core_Structure.Infra.Database.EntityFramework;
using _01_Learning_Core_Structure.Infra.Database.Model;
using System.Threading.Tasks;

namespace _01_Learning_Core_Structure.Repository.Implementation {
    public class UserSqLite : IUser {

        private EntityContext context;

        public Task<User> create(User user) {
            
        }
        public Task<User?> findByEmail(string _email) {

        }

        public async Task<List<User>> findAll() {
            var users = await context.Users.ToListAsync();

            return users;
        } 
    }
}