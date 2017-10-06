using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreVue.Models
{
    public class TimeSheetDetailSignature
    {
        [Key]
        [Column("TimeSheetDetailSignatureId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeSheetDetailSignatureId { get; set; }

        [Column(TypeName = "VARBINARY(MAX)")]
        public byte[] Signature { get; set; }

        public int TimeSheetIDetailId { get; set; }
        public TimeSheetDetail TimeSheetDetail { get; set; }
    }
}
