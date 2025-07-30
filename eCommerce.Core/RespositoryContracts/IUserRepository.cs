using eCommerce.Core.Entities;

namespace eCommerce.Core.RespositoryContracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser> AddUser(ApplicationUser user);
        Task<ApplicationUser?> GetUserByEamilAndPassword(string? email, string? password);
    }
}
