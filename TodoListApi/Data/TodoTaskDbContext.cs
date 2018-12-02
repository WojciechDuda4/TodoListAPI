using Microsoft.EntityFrameworkCore;
using TodoListApi.DataModels;

namespace TodoListApi.Data
{
    public class TodoTaskDbContext : DbContext
    {
        public TodoTaskDbContext(DbContextOptions<TodoTaskDbContext> options) : base(options)
        {

        }

        public DbSet<TodoTask> TodoList { get; set; }
    }
}
