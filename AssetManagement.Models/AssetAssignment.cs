using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Models
{
    public class AssetAssignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        public int AssetId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime AssignedDate { get; set; } = DateTime.Now;

        public DateTime? ReturnedDate { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        // Navigation properties
        [ForeignKey("AssetId")]
        public Asset Asset { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
