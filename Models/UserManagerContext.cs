using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models
{
    public class UserManagerContext : DbContext
    {
        public UserManagerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; } 
    }
}
