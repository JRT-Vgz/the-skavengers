
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _3___Data.Models
{
    public class IngotResourceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public int IdMaterial { get; set; }
        public string MapName { get; set; }
        public int MapQuantity { get; set; }
        public int MapTotalOre { get; set; }
        public string MapRecommendedPrice { get; set; }
        public string CommodityName { get; set; }
        public int FullPlatePrice { get; set; }
        public int ToolPrice { get; set; }
        [ForeignKey("IdMaterial")]
        public MaterialModel Material { get; set; }
    }
}
