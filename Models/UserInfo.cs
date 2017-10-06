using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreVue.Models
{
    public class UserInfo
    {
        [Key]
        [Column("UserInfoId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserInfoId { get; set; }

        [Required]
        [MaxLength(10)]
        public string LoginUserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public bool? IsActive { get; set; }

        public ICollection<InstructorAccount> InstructorAccounts { get; set; }
        public ICollection<TimeSheet> TimeSheets { get; set; }
 
    }
}
