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

        ITodoRepo _todoRepo;

        public TodoListController(ITodoRepo todoRepo) { 
            _todoRepo = todoRepo;
        }

        [HttpGet]
        public IActionResult GetTodos() {
            try
            {
                return Ok(_todoRepo.GetAll());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddTodo(TodoListDto todoList) {
            try
            {
                _todoRepo.Insert(todoList);
                return Ok("List added succesfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetTodoById(Guid id) 
        {
            try
            {
                return Ok(_todoRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, TodoListDto updatedList)
        {
            try
            {
                return Ok(_todoRepo.Update(id, updatedList));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _todoRepo.Delete(id);
                return Ok($"List with id: {id} ,has been succesfully deleted");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
