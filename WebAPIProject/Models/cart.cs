using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProject.Models
{
    [Table("Cart")]
    public class cart
    {
        [Key]
        public int Cart_id { get; set; }
        [ForeignKey("p_id")]
        public int p_id { get; set; }
        [ForeignKey("Rid")]
        public int Rid { get; set; }
        public int Qty { get; set; }

        [NotMapped]
        public string? p_name { get; set; }
        [NotMapped]

        public decimal Price { get; set; }
        [NotMapped]

        public string? Image { get; set; }
    }
} 
