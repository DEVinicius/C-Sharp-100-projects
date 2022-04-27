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
        public async Task<User?> FindByEmail(string email)
        {
            return await this.context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> FindById(long id)
        {
            return await this.context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> FindAll() {
            var users = await this.context.Users.AsNoTracking().ToListAsync();

            return users;
        }

        public Task<User> Update(User user)
        {
            var checkUser = this.FindById(user.Id);
            return Task.Run(() =>
            {
                return new User();
            });
        }

        public void Delete(long id)
        {
            this.context.Users.Remove(this.FindById(id).Result);
            this.context.SaveChanges();
        }
    }
}