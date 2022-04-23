using _01_Learning_Core_Structure.Repository;
using _01_Learning_Core_Structure.Infra.Database.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _01_Learning_Core_Structure.Repository.Implementation {
    public class UserArray : IUser {
        private long Id = 1;
        private List<User> users = new List<User>();
        public async Task<User> create(User user ) {
            user.Id = this.Id;
            this.SetId(this.Id + 1);

            this.users.Add(user);

            return user;
        }

        public Task<User?> findByEmail(string _email){
            return Task.Run(() => {
                return this.users.Find(x => x.Email.Equals(_email));
            });
        }

        public async Task<List<User>> findAll() {
            return await Task.Run(() => {
                return this.users;
            });
        }

        private void SetId(long _id) {
            this.Id = _id;
        }
    }
}