using System.ComponentModel.DataAnnotations;

namespace TodoProject.Dto
{
    public class TodoItemUpdateDto
    {
        [MinLength(1)]
        public required string Title { get; set; }
        public required bool IsCompleted { get; set; }
    }
}
