using TodoListApi.Data;
using TodoListApi.DataModels;

namespace TodoList.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoTaskDbContext _dbContext;

        public ITodoTaskRepository TodoTaskRepository { get; private set; }

        public UnitOfWork(TodoTaskDbContext dbContext)
        {
            _dbContext = dbContext;
            TodoTaskRepository = new TodoTaskRepository(_dbContext);
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Update(TodoTask updatedTodoTask)
        {
            _dbContext.TodoList.Update(updatedTodoTask);
        }
    }
}
