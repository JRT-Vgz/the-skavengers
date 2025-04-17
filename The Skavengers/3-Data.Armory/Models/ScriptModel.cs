
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _3_Data.Armory.Models
{
    public class ScriptModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(35)]
        public string Name { get; set; }

        [StringLength(4)]
        public string Version { get; set; }

        [StringLength(65)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Warning { get; set; }
        public string Content { get; set; }
    }
}
