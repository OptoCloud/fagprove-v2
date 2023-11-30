using backend.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AuthTokenEntity> AuthTokens { get; set; }
    public DbSet<NoteEntity> Notes { get; set; }
    public DbSet<DirectoryEntity> Directories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AuthTokenEntityConfiguration());
        modelBuilder.ApplyConfiguration(new NoteEntityConfiguration());
        modelBuilder.ApplyConfiguration(new DirectoryEntityConfiguration());
    }
}
