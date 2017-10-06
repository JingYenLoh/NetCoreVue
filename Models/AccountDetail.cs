using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreVue.Models
{
    public class AccountDetail
    {
        [Key]
        [Column("AccountDetailId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountDetailId { get; set; }

        public int DayOfWeekNumber { get; set; }

        [Required]
        [Column("StartTimeInMinutes")]
        public int StartTimeInMinutes { get; set; }

        [Required]
        public int EndTimeInMinutes { get; set; }

        [Required]
        [Column("EffectiveStartDate")]
        public DateTime EffectiveStartDate { get; set; }

        [Column("EffectiveEndDate")]
        public DateTime? EffectiveEndDate { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool? IsVisible { get; set; }

        public int CustomerAccountId { get; set; }
        public CustomerAccount CustomerAccount { get; set; }
        public ICollection<TimeSheetDetail> TimeSheetDetails { get; set; }
 
    }
}
