using MemoriKeeper.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoriKeeper.Model.DatabaseContect
{
    public class MemoriKeeperContext : DbContext
    {
        public MemoriKeeperContext(DbContextOptions<MemoriKeeperContext> options) : base(options)
        {
            
        }

        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}