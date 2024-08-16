using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Data
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [MaxLength(500)]
        public string? Notes { get; set; }

        public bool IsRecurrent { get; set; } = false;

        [MaxLength(3)]
        public string Currency { get; set; } = "SEK";

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
