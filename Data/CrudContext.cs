using crud.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.Data
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {
            
        }

        public DbSet<Item> Items { get; set; }
    }
}
