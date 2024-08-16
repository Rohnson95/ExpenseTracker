using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.DTOs
{
    public class UserUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
