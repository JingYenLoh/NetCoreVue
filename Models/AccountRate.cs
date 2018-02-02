using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NetCoreVue.Models
{
    public class AccountRate
    {
        [Key]
        [Column("AccountRateId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountRateId { get; set; }

        public int CustomerAccountId { get; set; }

        [IgnoreDataMember]
        public CustomerAccount CustomerAccount { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(6,2)")]
        public decimal RatePerHour { get; set; }

        [Required]
        [Column("EffectiveStartDate")]
        public DateTime EffectiveStartDate { get; set; }

        [Column("EffectiveEndDate")]
        public DateTime? EffectiveEndDate { get; set; }
 
    }
}
