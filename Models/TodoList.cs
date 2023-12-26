using System.ComponentModel.DataAnnotations;

namespace TodoProject.Models
{
    public class TodoList
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TodoItem> TodoItems { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
