using System.Threading.Tasks;
using eCommerceAssessment.Models;

namespace eCommerceAssessment.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<bool> UserExists(string email);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

    }
}