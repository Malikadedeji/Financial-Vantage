using System.ComponentModel.DataAnnotations;

namespace FinancialVantage.Application.DTO
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and the confirmation password doesn't match")]
        public string ConfirmPassword { get; set; }

        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth {  get; set; }
        public string Address {  get; set; }
    }
}
