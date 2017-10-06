using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreVue.Models
{
    public class CustomerAccount
    {
        public CustomerAccount() => AccountRates = new List<AccountRate>();

        [Key]
        [Column("CustomerAccountId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerAccountId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("AccountName")]
        public string AccountName { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        [Required]
        [Column("IsVisible")]
        public bool? IsVisible { get; set; }

        public DateTime CreatedAt { get; set; }
        public int CreatedById { get; set; }
        public UserInfo CreatedBy { get; set; }
        public int UpdatedById { get; set; }
        public DateTime UpdatedAt { get; set; }
        public UserInfo UpdatedBy { get; set; }

        public ICollection<InstructorAccount> InstructorAccounts { get; set; }
        public ICollection<AccountDetail> AccountDetails { get; set; }
        public ICollection<AccountRate> AccountRates { get; set; }
    }
}
