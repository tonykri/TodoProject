using Microsoft.EntityFrameworkCore;
using TodoProject.Models;

namespace TodoProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.TodoLists)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId)
                .IsRequired();

            modelBuilder.Entity<TodoList>()
                .HasMany(l => l.TodoItems)
                .WithOne(i => i.TodoList)
                .HasForeignKey(i => i.TodoListId)
                .IsRequired();
        }


        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TokenBlackList> TokenBlackList { get; set; }
    }
}
