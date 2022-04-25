using _01_Learning_Core_Structure.Repository;
using _01_Learning_Core_Structure.Infra.Database.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _01_Learning_Core_Structure.Repository.Implementation {
    public class UserArray : IUser {
        private long Id = 1;
        private List<User> users = new List<User>();
        public Task<User> Create(User user ) {
            user.Id = this.Id;
            this.SetId(this.Id + 1);

            this.users.Add(user);

            return Task.Run(() => user);
        }

        public Task<User?> FindByEmail(string email){
            return Task.Run(() => {
                return this.users.Find(x => x.Email.Equals(email));
            });
        }

        public Task<User?> FindById(long id)
        {
            return Task.Run(() =>
            {
                return this.users.Find(x => x.Id == id);
            });
        }

        public async Task<List<User>> FindAll() {
            return await Task.Run(() => {
                return this.users;
            });
        }

        private void SetId(long id) {
            this.Id = id;
        }
    }
}