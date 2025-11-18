using System.ComponentModel.DataAnnotations;

namespace testAPI.Models
{
    public class Users
    {
        [Key]
        public int id_user { get; set; }
         public string? Name { get; set; }
      
        public string? Password { get; set; }
    }
}
