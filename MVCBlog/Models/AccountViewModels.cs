using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCBlog.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Електронна поща")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Електронна поща")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Въведи електронна поща")]
        [Display(Name = "Електронна поща")]
        [EmailAddress(ErrorMessage = "Виж кво си написал")]        
        public string Email { get; set; }

        [Required(ErrorMessage = "Въведи парола")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Въведи електронна поща")]
        [EmailAddress(ErrorMessage = "Виж кво си написал")]
        [Display(Name = "Електронна поща")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Въведи парола")]
        [StringLength(100, ErrorMessage = "Въведи поне {2} символа.", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Паролата отново")]
        [Compare("Password", ErrorMessage = "Паролите не пасват.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Пълно име")]
        public string FullName { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Електронна поща")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Въведи поне {2} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Паролата отново")]
        [Compare("Password", ErrorMessage = "Паролите не пасват.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Електронна поща")]
        public string Email { get; set; }
    }
}
