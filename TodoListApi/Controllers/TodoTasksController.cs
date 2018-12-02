using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoList.Repositories;
using TodoListApi.DataModels;
using TodoListApi.Enums;

namespace TodoListApi.Controllers
{
    [Route("api/TodoTasks")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public TodoTasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public ActionResult<List<TodoTask>> Get(TodoTaskStatus todoTaskStatus)
        {
            return _unitOfWork.TodoTaskRepository.GetTasksByStatus(todoTaskStatus);
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public ActionResult<TodoTask> Get(int id)
        {
            var todoTask = _unitOfWork.TodoTaskRepository.Get(id);

            if (todoTask == null)
            {
                return NotFound();
            }

            return todoTask;
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public IActionResult Create(TodoTask todoTask)
        {
           _unitOfWork.TodoTaskRepository.Add(todoTask);
            _unitOfWork.Complete();

            return CreatedAtRoute("GetTaskById", new { id = todoTask.Id }, todoTask);
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult Update(TodoTask todoTaskToUpdate)
        {
            _unitOfWork.Update(todoTaskToUpdate);
            _unitOfWork.Complete();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult Delete(int id)
        {
            var todoTaskToDelete = _unitOfWork.TodoTaskRepository.Get(id);

            if (todoTaskToDelete == null)
            {
                return NotFound();
            }

            _unitOfWork.TodoTaskRepository.Remove(todoTaskToDelete);
            return NoContent();
        }
    }
}