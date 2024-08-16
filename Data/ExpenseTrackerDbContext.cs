using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
    public class ExpenseTrackerDbContext : DbContext
    {
        public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the relationship between User and Expenses
            modelBuilder.Entity<User>()
                .HasMany(u => u.Expenses)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "johndoe",
                    Email = "johndoe@example.com",
                    Password = "hashedpassword1",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    UserName = "janedoe",
                    Email = "janedoe@example.com",
                    Password = "hashedpassword2",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new User
                {
                    Id = 3,
                    UserName = "bobsmith",
                    Email = "bobsmith@example.com",
                    Password = "hashedpassword3",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            // Seed Expenses
            modelBuilder.Entity<Expense>().HasData(
                new Expense
                {
                    Id = 1,
                    Name = "Groceries",
                    Amount = 150.75m,
                    Category = "Food",
                    Date = DateTime.Now.AddDays(-10),
                    UserId = 1
                },
                new Expense
                {
                    Id = 2,
                    Name = "Electricity Bill",
                    Amount = 80.50m,
                    Category = "Utilities",
                    Date = DateTime.Now.AddDays(-5),
                    UserId = 1
                },
                new Expense
                {
                    Id = 3,
                    Name = "Gym Membership",
                    Amount = 45.00m,
                    Category = "Health",
                    Date = DateTime.Now.AddMonths(-1),
                    UserId = 2
                },
                new Expense
                {
                    Id = 4,
                    Name = "Internet Bill",
                    Amount = 60.00m,
                    Category = "Utilities",
                    Date = DateTime.Now.AddDays(-3),
                    UserId = 2
                },
                new Expense
                {
                    Id = 5,
                    Name = "Coffee",
                    Amount = 5.50m,
                    Category = "Food",
                    Date = DateTime.Now.AddDays(-1),
                    UserId = 3
                },
                new Expense
                {
                    Id = 6,
                    Name = "Movie Ticket",
                    Amount = 12.00m,
                    Category = "Entertainment",
                    Date = DateTime.Now.AddDays(-2),
                    UserId = 3
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
