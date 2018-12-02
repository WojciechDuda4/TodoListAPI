using System.Collections.Generic;
using TodoListApi.Data;
using TodoListApi.DataModels;
using TodoListApi.Enums;

namespace TodoList.Repositories
{
    public class TodoTaskRepository : Repository<TodoTask>, ITodoTaskRepository
    {
        private TodoTaskDbContext todoTaskDbContext
        {
            get { return dbContext as TodoTaskDbContext; }
        }

        public TodoTaskRepository(TodoTaskDbContext dbContext) : base(dbContext)
        {
        }

        public List<TodoTask> GetTasksByStatus(TodoTaskStatus todoTaskStatus)
        {
            return Find(a => a.Status == todoTaskStatus);
        }
    }
}
