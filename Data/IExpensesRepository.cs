namespace ExpenseTracker.Data
{
    public interface IExpensesRepository
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<IEnumerable<Expense>> GetExpensesByUserAsync(int userId);
        Task<Expense> GetExpenseByIdAsync(int id);
        Task CreateNewExpenseAsync(Expense exp);
        void UpdateExpense(Expense exp);
        void DeleteExpense(Expense exp);
    }
}
