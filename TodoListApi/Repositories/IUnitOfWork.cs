using TodoListApi.DataModels;

namespace TodoList.Repositories
{
    public interface IUnitOfWork
    {
        ITodoTaskRepository TodoTaskRepository { get; }
        int Complete();
        void Update(TodoTask updatedTodoTask);
    }
}
