using System.Threading.Tasks;
using landmark_remark_API.Models;

namespace landmark_remark_API.Repositories
{
    // interface for Registration and authenticion repository
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User user, string password);

        Task<User> LoginAsync(string username, string password);

        Task<bool> UsernameExistsAsync(string username);

        Task<bool> EmailExistsAsync(string email);
    }
}