using MemoriKeeper.Model.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MemoriKeeper.Model.DatabaseContect
{
    public class MemoriKeeperContext : IdentityDbContext<ApplicationUser>
    {
        public MemoriKeeperContext()
        {
            
        }

        public MemoriKeeperContext(DbContextOptions<MemoriKeeperContext> options) : base(options)
        {
            
        }

        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Diaryentry> Diaryentries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}