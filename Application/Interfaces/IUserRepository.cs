using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByNameAsync(string firstName);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(UserUpdateDTO user);
        Task<User> DeleteUserAsync(Guid id);
    }
}