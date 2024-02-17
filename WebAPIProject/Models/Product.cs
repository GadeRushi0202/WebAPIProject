using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAPIProject.Models
{
    [Table("Product2")]
    public class Product
    {

        [Key]  
        public int P_id { get; set; }
        [Required]
        public string? P_name { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public string? Image { get; set; }

        [ForeignKey("c_id")]
        public int c_id { get; set; }
        [NotMapped]
        public string? c_name { get; set; }
       
    }
}
