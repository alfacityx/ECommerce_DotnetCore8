using System.ComponentModel.DataAnnotations;

namespace ETicaret.WebUI.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress),Required(ErrorMessage ="Email Alanı Boş Geçilemez!")]
        public string Email { get; set; }
        [Display(Name = "Şifre"), Required(ErrorMessage = "Şifre Alanı Boş Geçilemez!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }

    }
}
