using System.ComponentModel.DataAnnotations;

namespace AssetManagement.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }

        [Required, MaxLength(100)]
        public string AssetName { get; set; }

        [MaxLength(50)]
        public string AssetType { get; set; }

        [MaxLength(100)]
        public string MakeModel { get; set; }

        [MaxLength(100)]
        public string SerialNumber { get; set; }

        public DateTime? PurchaseDate { get; set; }
        public DateTime? WarrantyExpiryDate { get; set; }

        public AssetCondition Condition { get; set; } = AssetCondition.New;
        public AssetStatus Status { get; set; } = AssetStatus.Available;
        public bool IsSpare { get; set; } = false;

        [MaxLength(500)]
        public string Specifications { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }

        // Navigation property
        public ICollection<AssetAssignment> AssetAssignments { get; set; }
    }
}
