using TodoProject.Dto;
using TodoProject.Models;

namespace TodoProject.Repositories.Interfaces
{
    public interface ITodoItemRepo
    {
        public TodoItem Get(Guid id, Guid iid);
        public void Create(Guid id, TodoItemCreateDto todoItemCreateDto);
        public TodoItem Update(Guid id, Guid iid, TodoItemUpdateDto todoItemUpdateDto);
        public void Delete(Guid id, Guid iid);
    }
}