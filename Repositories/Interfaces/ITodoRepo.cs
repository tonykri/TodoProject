using TodoProject.Dto;
using TodoProject.Models;

namespace TodoProject.Repositories.Interfaces
{
    public interface ITodoRepo
    {
        public List<TodoList> GetAll();
        public TodoList GetById(Guid id);
        public void Insert(TodoListDto todoList);
        public void Delete(Guid id);
        public TodoList Update(Guid id, TodoListDto updatedList);

    }
}
