using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;
namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController:Controller
    {
        private readonly TodoContext _context;
        public TodoController(TodoContext context){
            _context=context;
            if(_context.TodoItem.Count()==0){
                _context.TodoItem.Add(new TodoItem{Name="Item1"});
                _context.SaveChanges();
            }
        }

    }

    [HttpGet]
    public IEnumerable<TodoItem>GetAll(){
       return _context.TodoItem.ToList();
    }

    [HttpGet("{id}",Name="GetTodo")]
    public IActionResult GetById(long id){
        var item=_context.TodoItem.FirstOrDefault(t=>t.Id==id);
        if (item==null)
        {
            return NotFound();
        }
        return new ObjectResult(item);
    }
    
}