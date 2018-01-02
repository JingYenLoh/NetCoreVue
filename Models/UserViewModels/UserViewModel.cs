using System.ComponentModel.DataAnnotations;

namespace NetCoreVue.Models.UserViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Staff Id")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public bool EmailConfirmed { get; set; }

        [Required]
        public string RoleName { get; set; }

    }
}
