using System.Collections.Generic;
using TodoListApi.DataModels;
using TodoListApi.Enums;

namespace TodoList.Repositories
{
    public interface ITodoTaskRepository : IRepository<TodoTask>
    {
        List<TodoTask> GetTasksByStatus(TodoTaskStatus todoTaskStatus);
    }
}
