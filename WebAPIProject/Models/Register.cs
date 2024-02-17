using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace WebAPIProject.Models
{
    [Table("Registration")]
    public class Register
    {
        [Key]
        public int Rid { get; set; }

        
        public string? UserName { get; set; }
       
        public string? Email { get; set; }
       
        public string? Gender { get; set; }
        
        public string? PhoneNumber { get; set; }

        public string? City { get; set; }
       
        public string? Password { get; set; }
        
        public int Roleid { get; set; }

        [NotMapped]
        public string? token { get; set;}
    }
}
