using System.ComponentModel.DataAnnotations;

namespace TodoProject.Models
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public bool IsCompleted {  get; set; }

        public Guid TodoListId { get; set; }
        public TodoList TodoList { get; set; }
    }
}
