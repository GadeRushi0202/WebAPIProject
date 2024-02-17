using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIProject.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int Orderid { get; set; }
        [ForeignKey("p_id")]

        public int Id { get; set; }
        [ForeignKey("Rid")]
        public int Rid { get; set; }
        public int Qty { get; set; }

        public DateTime ordate { get; set; }
        [NotMapped]
        public string? p_name { get; set; }
        [NotMapped]

        public decimal Price { get; set; }
        [NotMapped]

        public string? Image { get; set; }

    }
}
