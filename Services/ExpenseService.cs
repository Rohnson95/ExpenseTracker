using ExpenseTracker.Data;

namespace ExpenseTracker.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpensesRepository _expensesRepository;
        private readonly IUserRepository _userRepository;

        public ExpenseService(IExpensesRepository expensesRepository, IUserRepository userRepository)
        {
            _expensesRepository = expensesRepository;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _expensesRepository.GetAllExpensesAsync();
        }
        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            return await _expensesRepository.GetExpenseByIdAsync(id);
        }
        public async Task<IEnumerable<Expense>> GetUserExpensesAsync(int userId)
        {
            if (!await _userRepository.UserExistsAsync(userId))
            {
                throw new ArgumentException("User Not Found");
            }
            return await _expensesRepository.GetExpensesByUserAsync(userId);
        }
        public async Task CreateExpenseAsync(Expense expense)
        {
            await _expensesRepository.CreateNewExpenseAsync(expense);
            await _expensesRepository.SaveChangesAsync();
        }
        public async Task UpdateExpenseAsync(Expense expense)
        {
            _expensesRepository.UpdateExpense(expense);
            await _expensesRepository.SaveChangesAsync();
        }
        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _expensesRepository.GetExpenseByIdAsync(id);
            if (expense == null)
            {
                throw new ArgumentException("Expense not found");
            }

            _expensesRepository.DeleteExpense(expense);
            await _expensesRepository.SaveChangesAsync();
        }

    }
}
