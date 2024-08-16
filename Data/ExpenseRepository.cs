using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
    public class ExpenseRepository : IExpensesRepository
    {
        private readonly ExpenseTrackerDbContext _context;

        public ExpenseRepository(ExpenseTrackerDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _context.Expenses.ToListAsync();
        }
        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }
        public async Task<IEnumerable<Expense>> GetExpensesByUserAsync(int userId)
        {
            return await _context.Expenses.Where(e => e.UserId == userId).ToListAsync();
        }
        public async Task CreateNewExpenseAsync(Expense exp)
        {
            await _context.Expenses.AddAsync(exp);
        }
        public void UpdateExpense(Expense exp)
        {
            _context.Entry(exp).State = EntityState.Modified;
        }
        public void DeleteExpense(Expense exp) => _context.Expenses.Remove(exp);
    }
}
