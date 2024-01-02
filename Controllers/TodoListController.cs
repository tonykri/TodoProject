using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using TodoProject.Data;
using TodoProject.Dto;
using TodoProject.Models;
using TodoProject.Repositories.Interfaces;

namespace TodoProject.Controllers
{
    [Route("todos")]
    [ApiController]
    [Authorize]
    public class TodoListController : ControllerBase
    {
        //GET /todos
        //POST /todos
        //GET /todos/:id
        //PUT /todos/:id
        //DELETE /todos/:id

        ITodoRepo _todoRepo;

        public TodoListController(ITodoRepo todoRepo) { 
            _todoRepo = todoRepo;
        }

        [HttpGet]
        public ActionResult<List<TodoList>> GetTodos() {
            try
            {
                return Ok(_todoRepo.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AddTodo(TodoListDto todoList) {
            try
            {
                _todoRepo.Insert(todoList);
                return Ok("List added succesfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public ActionResult<TodoList> GetTodoById(Guid id) 
        {
            try
            {
                return Ok(_todoRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public ActionResult<TodoList> Update(Guid id, TodoListDto updatedList)
        {
            try
            {
                return Ok(_todoRepo.Update(id, updatedList));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _todoRepo.Delete(id);
                return Ok($"List with id: {id} ,has been succesfully deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
