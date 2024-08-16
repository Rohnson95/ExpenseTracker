public class ExpenseReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }  // You may or may not include this based on your needs
}
