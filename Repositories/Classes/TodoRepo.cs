using System.IdentityModel.Tokens.Jwt;
using TodoProject.Data;
using TodoProject.Dto;
using TodoProject.Models;
using TodoProject.Repositories.Interfaces;
using TodoProject.Utils;

namespace TodoProject.Repositories.Classes
{
    public class TodoRepo: ITodoRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IJwtTokenManager _jwtTokenManager;
        public TodoRepo(ApplicationDbContext context, IJwtTokenManager jwtTokenManager)
        {
            _applicationDbContext = context;
            _jwtTokenManager = jwtTokenManager;
        }

        public List<TodoList> GetAll()
        {
            // grab user id
            var userId = _jwtTokenManager.GetCurrentUserId();

            // grab todo lists based on the current user id
            return _applicationDbContext.TodoLists.Where(t => t.UserId == Guid.Parse(userId))!.ToList();

        }

        public TodoList GetById(Guid id)  // TODO: maybe do one more get for name since it makes more sense?
        {
            var userId = _jwtTokenManager.GetCurrentUserId();
            var list = _applicationDbContext.TodoLists
                .Where(l => l.UserId == Guid.Parse(userId))
                .FirstOrDefault(l => l.Id == id);

            if (list != null)
                return list;
            else
                throw new Exception($"List with id {id} doesnt exist");
        }

        public void Insert(TodoListDto todoListData)
        {
            var userId = _jwtTokenManager.GetCurrentUserId();

            if (_applicationDbContext.TodoLists.Where(l => l.UserId == Guid.Parse(userId)).Any(l => l.Name == todoListData.Name))
                throw new Exception("You already have a list with this name. Please consider changing it.");

            TodoList list = new TodoList
            {
                Name = todoListData.Name,
                Description = todoListData.Description,
                UserId = Guid.Parse(userId)
            };

            _applicationDbContext.TodoLists.Add(list);
            _applicationDbContext.SaveChanges();
        }
        
        public TodoList Update(Guid id, TodoListDto updatedList)
        {
            var userId = _jwtTokenManager.GetCurrentUserId();
            var list = _applicationDbContext.TodoLists
                .Where(l => l.UserId == Guid.Parse(userId))
                .FirstOrDefault(l => l.Id == id);

            if (list != null)
            {
                list.Name = updatedList.Name;
                list.Description = updatedList.Description;
                _applicationDbContext.SaveChanges();

                return list;
            }
            else
                throw new Exception($"List with id {id} doesnt exist");

        }
        
        public void Delete(Guid id)
        {
            var userId = _jwtTokenManager.GetCurrentUserId();
            Console.WriteLine(userId);
            var list = _applicationDbContext.TodoLists
                .Where(l => l.UserId == Guid.Parse(userId))
                .FirstOrDefault(l => l.Id == id);

            if (list != null)
            {
                _applicationDbContext.TodoLists.Remove(list);
                _applicationDbContext.SaveChanges();
            }
            else
                throw new Exception($"List with id {id} doesnt exist, therefore cant be deleted");
        }


    }
}
