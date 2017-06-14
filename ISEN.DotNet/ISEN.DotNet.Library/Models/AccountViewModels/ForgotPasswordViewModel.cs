using System.ComponentModel.DataAnnotations;

namespace ISEN.DotNet.Library.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
