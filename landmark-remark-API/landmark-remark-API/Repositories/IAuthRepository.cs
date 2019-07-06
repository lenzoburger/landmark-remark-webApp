using System.Threading.Tasks;
using landmark_remark_API.Models;

namespace landmark_remark_API.Repositories
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User user, string password);

        Task<User> Login(string username, string password);

        Task<bool> UsernameExistsAsync(string username);

        Task<bool> EmailExistsAsync(string email);
    }
}