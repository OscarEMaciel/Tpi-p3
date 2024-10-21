using Domain.Entities;
using Domain.Interfaces;
namespace Domain.Interfaces;


public interface IUserRepository : IBaseRepository<User>
{
    User? GetUserByUserName(string userName);
}
