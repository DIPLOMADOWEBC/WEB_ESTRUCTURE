using System.Threading.Tasks;

namespace Infiniteskills.Service
{
    public interface IUserManager
    {
        Task<ApplicationUser> FindAsync(string userName, string password);
    }
}
