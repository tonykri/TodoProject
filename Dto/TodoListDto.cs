using System.ComponentModel.DataAnnotations;
using TodoProject.Models;

namespace TodoProject.Dto
{
    public class TodoListDto
    {
        [MinLength(1)]
        public required string Name { get; set; }
        public string Description { get; set; } = String.Empty;
    }
}
