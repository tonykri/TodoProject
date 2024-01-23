using TodoProject.Data;
using TodoProject.Dto;
using TodoProject.Models;
using TodoProject.Repositories.Interfaces;
using TodoProject.Utils;

namespace TodoProject.Repositories.Classes
{
    public class TodoItemRepo: ITodoItemRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IJwtTokenManager _jwtTokenManager;
        public TodoItemRepo(ApplicationDbContext context, IJwtTokenManager jwtTokenManager)
        {
            _applicationDbContext = context;
            _jwtTokenManager = jwtTokenManager;
        }

        public void Create(Guid id, TodoItemCreateDto todoItemCreateDto)
        {
            Guid userId = Guid.Parse(_jwtTokenManager.GetCurrentUserId());
            var todoList = _applicationDbContext.TodoLists.FirstOrDefault(todo => todo.Id == id && todo.UserId == userId);
            if(todoList is null) throw new Exception("Couldn't find todo list");

            var item = new TodoItem(){
                Title = todoItemCreateDto.Title,
                TodoList = todoList,
                TodoListId = todoList.Id
            };
            _applicationDbContext.Add(item);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Guid id, Guid iid)
        {
            Guid userId = Guid.Parse(_jwtTokenManager.GetCurrentUserId());
            var todoList = _applicationDbContext.TodoLists.FirstOrDefault(todo => todo.Id == id && todo.UserId == userId);
            if(todoList is null) throw new Exception("Couldn't find todo list");

            var todoItem = _applicationDbContext.TodoItems.FirstOrDefault(item => item.Id == iid && item.TodoListId == id);
            if (todoItem is null) throw new Exception("Couldn't find todo item");

            _applicationDbContext.Remove(todoItem);
            _applicationDbContext.SaveChanges();
        }

        public TodoItem Get(Guid id, Guid iid)
        {
            Guid userId = Guid.Parse(_jwtTokenManager.GetCurrentUserId());
            var todoList = _applicationDbContext.TodoLists.FirstOrDefault(todo => todo.Id == id && todo.UserId == userId);
            if(todoList is null) throw new Exception("Couldn't find todo list");

            var todoItem = _applicationDbContext.TodoItems.FirstOrDefault(item => item.Id == iid && item.TodoListId == id);
            if(todoItem is null) throw new Exception("Couldn't find todo item");

            return todoItem;
        }

        public TodoItem Update(Guid id, Guid iid, TodoItemUpdateDto todoItemUpdateDto)
        {
            Guid userId = Guid.Parse(_jwtTokenManager.GetCurrentUserId());
            var todoList = _applicationDbContext.TodoLists.FirstOrDefault(todo => todo.Id == id && todo.UserId == userId);
            if(todoList is null) throw new Exception("Couldn't find todo list");

            var todoItem = _applicationDbContext.TodoItems.FirstOrDefault(item => item.Id == iid && item.TodoListId == id);
            if(todoItem is null) throw new Exception("Couldn't find todo item");

            todoItem.IsCompleted = todoItemUpdateDto.IsCompleted;
            todoItem.Title = todoItemUpdateDto.Title;
            _applicationDbContext.SaveChanges();

            return todoItem;
        }
    }
}