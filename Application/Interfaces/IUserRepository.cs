using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        // Task<List<User>> GetAllUsersAsync();
        // Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        // Task<User> UpdateUserAsync(User user);
        // Task<User> DeleteUserAsync(int id);
    }
}