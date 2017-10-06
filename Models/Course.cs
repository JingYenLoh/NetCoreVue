using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreVue.Models
{
    public class Course
    {
        [Key]
        [Column("CourseId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        public string CourseAbbreviation { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("CourseName")]
        public string CourseName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public int CreatedById { get; set; } //Foreign key 
        public int UpdatedById { get; set; }
        public int? DeletedById { get; set; }

        public UserInfo CreatedBy { get; set; } // navigation property
        public UserInfo UpdatedBy { get; set; }
        public UserInfo DeletedBy { get; set; }
    }
}
