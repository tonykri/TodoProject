using System.ComponentModel.DataAnnotations;

namespace TodoProject.Dto
{
    public class TodoItemCreateDto
    {
        [MinLength(1)]
        public required string Title { get; set; }
    }
}
