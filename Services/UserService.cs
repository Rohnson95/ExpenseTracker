using ExpenseTracker.Data;

namespace ExpenseTracker.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new ArgumentException("User Not Found");
            }
            return user;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            return user;
        }
        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateUserAsync(user);
            await _userRepository.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(User user)
        {
            _userRepository.UpdateUser(user);
            await _userRepository.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            _userRepository.DeleteUser(user);
            await _userRepository.SaveChangesAsync();
        }

    }
}
