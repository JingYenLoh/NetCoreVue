using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreVue.Models
{
    public class SessionSynopsis
    {
        [Key]
        [Column("SessionSynopsisId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionSynopsisId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SessionSynopsisName { get; set; }
        public int CreatedById { get; set; }
        public UserInfo CreatedBy { get; set; }
        public int UpdatedById { get; set; }
        public UserInfo UpdatedBy { get; set; }

        [Required]
        [Column("IsVisible")]
        public bool? IsVisible { get; set; }
    }
}
