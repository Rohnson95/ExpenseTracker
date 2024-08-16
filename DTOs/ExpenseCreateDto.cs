using System.ComponentModel.DataAnnotations;

public class ExpenseCreateDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public decimal Amount { get; set; }

    [Required]
    [MaxLength(50)]
    public string Category { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int UserId { get; set; }  // Assuming you need to specify the user when creating an expense
}
