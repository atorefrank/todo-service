using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Persistence
{   
    public class TodoContext : DbContext 
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) 
        {
        }

        // DB Infrastructure logic to persist and retrieve todo items
        public DbSet<TodoItem> TodoItems {get; set; } = null!;
        
    }
}