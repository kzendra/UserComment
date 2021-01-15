using Microsoft.EntityFrameworkCore;
using UserComment.DB.Model;

namespace UserComment.DB
{
    public class Data : DbContext
    {
        public Data(DbContextOptions<Data> options)
                    : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
