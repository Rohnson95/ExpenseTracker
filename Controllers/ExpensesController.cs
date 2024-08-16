using AutoMapper;
using ExpenseTracker.Data;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;

        public ExpensesController(IExpenseService expenseService, IMapper mapper)
        {
            _expenseService = expenseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetAllExpenses()
        {
            var expenses = await _expenseService.GetAllExpensesAsync();
            var expensesDto = _mapper.Map<IEnumerable<ExpenseReadDto>>(expenses);
            return Ok(expensesDto);
        }
        [HttpGet("{id}", Name = "GetExpenseByIdAsync")]
        public async Task<ActionResult<Expense>> GetExpenseByIdAsync(int id)
        {
            var expenseItem = await _expenseService.GetExpenseByIdAsync(id);
            if (expenseItem == null)
            {
                return NotFound();
            }
            var expenseDto = _mapper.Map<ExpenseReadDto>(expenseItem);
            return Ok(expenseItem);

        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Expense>>> GetUserExpensesAsync(int userId)
        {
            var userExpenses = await _expenseService.GetUserExpensesAsync(userId);
            if (userExpenses == null || !userExpenses.Any())
            {
                return NotFound();
            }
            var userExpensesDto = _mapper.Map<IEnumerable<ExpenseReadDto>>(userExpenses);
            return Ok(userExpensesDto);
        }
        [HttpPost]
        public async Task<ActionResult> CreateExpenseAsync(Expense expenseCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var expense = _mapper.Map<Expense>(expenseCreateDto);
            await _expenseService.CreateExpenseAsync(expense);
            var expenseReadDto = _mapper.Map<ExpenseReadDto>(expense);
            return CreatedAtRoute("GetExpenseByIdAsync", new { id = expenseReadDto.Id }, expenseReadDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExpenseAsync(int id, ExpenseUpdateDto expenseUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingExpense = await _expenseService.GetExpenseByIdAsync(id);
            if (existingExpense == null)
            {
                return NotFound();
            }
            _mapper.Map(expenseUpdateDto, existingExpense);
            await _expenseService.UpdateExpenseAsync(existingExpense);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpenseAsync(int id)
        {
            // Check if the expense exists
            var expense = await _expenseService.GetExpenseByIdAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            // Delete the expense
            await _expenseService.DeleteExpenseAsync(id);

            // Return NoContent to indicate successful deletion
            return NoContent();
        }
    }
}
