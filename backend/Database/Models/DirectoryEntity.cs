using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Database.Models;

public class DirectoryEntity
{
    public Guid Id { get; private set; }

    public required string Title { get; set; }

    public DateTime CreatedAt { get; private set; }

    public ICollection<NoteEntity> Notes { get; set; }
}

public class DirectoryEntityConfiguration : IEntityTypeConfiguration<DirectoryEntity>
{
    public void Configure(EntityTypeBuilder<DirectoryEntity> builder)
    {
        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        builder.Property(e => e.Title).HasMaxLength(32);
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
    }
}