
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _3___Data.Models
{
    public class GenericProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdMaterial { get; set; }
        public int QuantityCrafted { get; set; }
        public int MaterialUsed { get; set; }

        [ForeignKey("IdMaterial")]
        public MaterialModel Material { get; set; }
    }
}
