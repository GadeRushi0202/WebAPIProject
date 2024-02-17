using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProject.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        
        public int c_id {  get; set; }
        public string? c_name { get; set; }
    }
}
