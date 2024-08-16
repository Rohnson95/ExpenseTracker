namespace ExpenseTracker.Data
{
    public interface IUserRepository
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task<bool> UserExistsAsync(int id);
    }
}
