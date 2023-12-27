using System.ComponentModel.DataAnnotations;

namespace TodoProject.Models
{
    public class TokenBlackList
    {
        [Key]
        public string Token { get; set; } 
    }
}
