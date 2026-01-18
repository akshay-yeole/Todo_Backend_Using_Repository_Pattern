using Microsoft.AspNetCore.Mvc;
using Todo.Contracts;
using Todo.Entities;

namespace Todo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController(IRepositoryWrapper repository) : ControllerBase
{
    private readonly IRepositoryWrapper _repository = repository;

    [HttpGet("GetAllTodoItems")]
    public IActionResult GetAllTodoItems()
    {
        var todos = _repository.Todo.GetAllTodoItems();
        return Ok(todos);
    }

    [HttpGet("{id}", Name = "TodoItemById")]
    public IActionResult GetTodoItemById(int id)
    {
        var todoItem = _repository.Todo.GetTodoItemById(id);
        return Ok(todoItem);
    }

    [HttpPost]
    public IActionResult CreateTodoItem([FromBody] TodoItem model)
    {
        _repository.Todo.CreateTodoItem(model);
        _repository.Save();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTodoItem(int id, [FromBody] TodoItem model)
    {
        var todoItem = _repository.Todo.GetTodoItemById(id);

        if (todoItem != null)
        {
            _repository.Todo.UpdateTodoItem(model);
            _repository.Save();
            return Ok();
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTodoItem(int id)
    {
        var todoItem = _repository.Todo.GetTodoItemById(id);

        if (todoItem != null) {
            _repository.Todo.DeleteTodoItem(todoItem);
            _repository.Save();
            return Ok();
        }

        return NotFound();
    }
}
