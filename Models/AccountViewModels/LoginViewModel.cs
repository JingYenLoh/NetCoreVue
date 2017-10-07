using System.ComponentModel.DataAnnotations;

namespace NetCoreVue.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Staff Id")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
