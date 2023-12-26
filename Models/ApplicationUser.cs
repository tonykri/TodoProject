using System.ComponentModel.DataAnnotations;

namespace TodoProject.Models
{
    public class ApplicationUser
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<TodoList> TodoLists { get; set; }
    }
}
