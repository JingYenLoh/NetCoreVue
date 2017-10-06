using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreVue.Models
{
    public class TimeSheet
    {
        [Key]
        [Column("TimeSheetId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeSheetId { get; set; }

        [Required]
        public DateTime MonthAndYear { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(6,2)")]
        public decimal RatePerHour { get; set; }

        public ICollection<TimeSheetDetail> TimeSheetDetails { get; set; }

        public int InstructorId { get; set; }

        public UserInfo Instructor { get; set; }

        public int CreatedById { get; set; }
        public UserInfo CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UpdatedById { get; set; }

        public UserInfo UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DateTime? VerifiedAndSubmittedAt { get; set; }

        [Required]
        public int CheckedById { get; set; }

        public UserInfo ApprovedBy { get; set; }
        public int? ApprovedById { get; set; }
        public DateTime? ApprovedAt { get; set; }
    }
}
