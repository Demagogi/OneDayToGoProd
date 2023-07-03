using OneDayToGoProd.Domain.Models;

namespace OneDayToGoProd.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(int id);

        Task<UserProfile> GetUserProfileByIdAsync(int userId, int id);
        Task<UserProfile> CreateUserProfileAsync(int userId, UserProfile profile);
        Task<UserProfile> UpdateUserProfileAsync(int userId, UserProfile profile);
        Task<UserProfile> DeleteUserProfileAsync(int userId, int id);
    }
}
