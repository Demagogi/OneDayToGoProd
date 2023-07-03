using Microsoft.EntityFrameworkCore;
using OneDayToGoProd.DAL.Data;
using OneDayToGoProd.Domain.Interfaces.Repository;
using OneDayToGoProd.Domain.Models;

namespace OneDayToGoProd.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserProfile> CreateUserProfileAsync(int userId, UserProfile profile)
        {
            var user = await _context.Users.Include(x=>x.profile).SingleOrDefaultAsync(u=>u.Id == userId);

            if (user == null) 
            {
                return null;
            }

            _context.UserProfiles.Add(profile);
            await _context.SaveChangesAsync();

            return profile;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<UserProfile> DeleteUserProfileAsync(int userId, int id)
        {
            var profile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == id && x.userId == userId);

            if (profile == null)
            {
                return null;
            }

            _context.UserProfiles.Remove(profile);
            await _context.SaveChangesAsync();

            return profile;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<UserProfile> GetUserProfileByIdAsync(int userId, int id)
        {
            var profile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Id == id && u.userId==userId);

            if (profile == null)
            {
                return null;
            }

            return profile;

        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            if (user == null)
            {
                return null;
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<UserProfile> UpdateUserProfileAsync(int userId, UserProfile profile)
        {
            var user = await _context.Users.Include(x => x.profile).FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            _context.UserProfiles.Update(profile);
            await _context.SaveChangesAsync();

            return user.profile;
        }
    }
}
