using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Navigation property to represent the Relationship between Expense/User
        public List<Expense> Expenses { get; set; }

    }
}
