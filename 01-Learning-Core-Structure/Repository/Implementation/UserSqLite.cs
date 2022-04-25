using _01_Learning_Core_Structure.Repository;
using _01_Learning_Core_Structure.Infra.Database.EntityFramework;
using _01_Learning_Core_Structure.Infra.Database.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _01_Learning_Core_Structure.Repository.Implementation {
    public class UserSqLite : IUser {

        private EntityContext context = new EntityContext();

        public Task<User> Create(User user)
        {
            this.context.Add(user);
            this.context.SaveChanges();

            return Task.Run(() => user);
        }
        public async Task<User?> FindByEmail(string _email)
        {
            return await this.context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == _email);
        }

        public Task<User?> FindById(long _id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> FindAll() {
            var users = await this.context.Users.AsNoTracking().ToListAsync();

            return users;
        } 
    }
}