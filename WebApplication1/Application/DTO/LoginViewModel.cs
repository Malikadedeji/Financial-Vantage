using System.ComponentModel.DataAnnotations;

namespace FinancialVantage.Application.DTO
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email {  get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //indicates whether the user wants to remain logged in after closing the browser
        public bool RememberMe { get; set; }
    }
}
