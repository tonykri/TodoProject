using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoProject.Dto;
using TodoProject.Repositories.Interfaces;

namespace TodoProject.Controllers
{
    [Route("todos/{id:guid}")]
    [ApiController]
    [Authorize]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemRepo _todoItemRepo;
        public TodoItemController(ITodoItemRepo todoItemRepo){
            _todoItemRepo = todoItemRepo;
        }

        [HttpGet("items/{iid:guid}")]
        public IActionResult Get(Guid id, Guid iid){
            try{
                var item = _todoItemRepo.Get(id, iid);
                return Ok(item);
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("items")]
        public IActionResult Create(Guid id, [FromBody] TodoItemCreateDto todoItemCreateDto){
            try{
                _todoItemRepo.Create(id, todoItemCreateDto);
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("items/{iid:guid}")]
        public IActionResult Update(Guid id, Guid iid, [FromBody] TodoItemUpdateDto todoItemUpdateDto){
            try{
                var item = _todoItemRepo.Update(id, iid, todoItemUpdateDto);
                return Ok(item);
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("items/{iid:guid}")]
        public IActionResult Delete(Guid id, Guid iid){
            try{
                _todoItemRepo.Delete(id, iid);
                return Ok();
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
    }
}