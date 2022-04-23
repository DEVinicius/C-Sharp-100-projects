using System.Threading.Tasks;
using _01_Learning_Core_Structure.Infra.Database.Model;

namespace _01_Learning_Core_Structure.Repository {
    public interface IUser {
        Task<User> create(User user);
        Task<User?> findByEmail(string _email);

        Task<List<User>> findAll(); 
    }
}