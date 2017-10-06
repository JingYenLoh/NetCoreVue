using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreVue.Models
{
    public class TimeSheetDetail
    {
        [Key]
        [Column("TimeSheetDetailId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeSheetDetailId { get; set; }

        public TimeSheetDetailSignature TimeSheetDetailSignature { get; set; }

        public int TimeSheetId { get; set; }
        public TimeSheet TimeSheet { get; set; }

        public int AccountDetailId { get; set; }
        public AccountDetail AccountDetail { get; set; }

        [Required]
        [MaxLength(300)]
        public string SessionSynopsisNames { get; set; }

        public int TimeInInMinutes { get; set; }
        public int TimeOutInMinutes { get; set; }
        public DateTime DateOfLesson { get; set; }

        [Required]
        public bool? IsReplacementInstructor { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(6,2)")]
        public decimal WageRatePerHour { get; set; }

        [Required]
        public int OfficialTimeInMinutes { get; set; }

        [Required]
        public int OfficialTimeOutMinutes { get; set; }
 
    }
}
