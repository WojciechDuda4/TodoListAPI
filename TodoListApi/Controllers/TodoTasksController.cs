using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoList.Repositories;
using TodoListApi.DataModels;
using TodoListApi.Enums;

namespace TodoListApi.Controllers
{
    [Route("api/TodoList")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public TodoTasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<List<TodoTask>> GetAllTasks(TodoTaskStatus todoTaskStatus)
        {
            return _unitOfWork.TodoTaskRepository.GetTasksByStatus(todoTaskStatus);
        }

        [HttpGet("{id}", Name = "GetTodoTask")]
        public ActionResult<TodoTask> GetById(int id)
        {
            var todoTask = _unitOfWork.TodoTaskRepository.Get(id);

            if (todoTask == null)
            {
                return NotFound();
            }

            return todoTask;
        }

        [HttpPost]
        public IActionResult AddNewTodoTask(TodoTask newTodoTask)
        {
           _unitOfWork.TodoTaskRepository.Add(newTodoTask);
            _unitOfWork.Complete();

            return CreatedAtRoute("GetTodoTask", new { id = newTodoTask.Id }, newTodoTask);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            var todoTaskToUpdate = _unitOfWork.TodoTaskRepository.Get(id);

            if (todoTaskToUpdate == null)
            {
                return NotFound();
            }

            _unitOfWork.Update(todoTaskToUpdate);
            _unitOfWork.Complete();

            return NoContent();
        }

        [HttpDelete("{id}")]
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