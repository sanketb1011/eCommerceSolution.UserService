using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RespositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;
        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<ApplicationUser> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();
            string query = "Insert Into public. \"Users\" (\"UserID\", \"Email\", \"PersonName\"," +
                "           \"Gender\", \"Password\") Values (@UserId,@Email,@PersonName, @Gender, @Password)";


            var noOfRowsInserted = await _dbContext.dbConnection.ExecuteAsync(query,user);
            if (noOfRowsInserted > 0)
            {
                return user;
            }
            else 
            {
                return user;
            }            
        }

        public async Task<ApplicationUser?> GetUserByEamilAndPassword(string? email, string? password)
        {
            string query = "Select * from \"Users\" Where \"Email\"= @Email And \"Password\" = @Password";

            var parameters = new { Email = email, Password = password };
            var user =await _dbContext.dbConnection
                            .QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

            return user;
        }
    }
}
