using System.Threading.Tasks;
using _01_Learning_Core_Structure.Infra.Database.Model;

namespace _01_Learning_Core_Structure.Repository {
    public interface IUser {
        Task<User> Create(User user);
        Task<User?> FindByEmail(string email);
        Task<User?> FindById(long id);

        Task<List<User>> FindAll();

        Task<User> Update(User user);

        void Delete(long id);
    }
}