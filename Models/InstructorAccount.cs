using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreVue.Models
{
    public class InstructorAccount
    {
        [Key]
        [Column("InstructorAccountId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstructorAccountId { get; set; }

        [Required]
        public int InstructorId { get; set; }

        public UserInfo Instructor { get; set; }

        [Required]
        public int CustomerAccountId { get; set; }

        [Column(TypeName = "NVARCHAR(4000)")]
        public string Comments { get; set; }

        public CustomerAccount CustomerAccount { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(5,2)")]
        public decimal WageRate { get; set; }

        [Required]
        [Column("RequiredStartDate")]
        public DateTime EffectiveStartDate { get; set; }

        [Column("RequiredEndDate")]
        public DateTime? EffectiveEndDate { get; set; }

        [Required]
        [Column(TypeName = "BIT")]
        public bool? IsCurrent { get; set; }
    }
}
