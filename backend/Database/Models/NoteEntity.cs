using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Database.Models;

public class NoteEntity
{
    public Guid Id { get; private set; }

    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }

    public Guid DirectoryId { get; set; }
    public DirectoryEntity? Directory { get; set; }

    public required string Title { get; set; }

    public required string Content { get; set; }

    public DateTime CreatedAt { get; private set; }
}

public class NoteEntityConfiguration : IEntityTypeConfiguration<NoteEntity>
{
    public void Configure(EntityTypeBuilder<NoteEntity> builder)
    {
        builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
        builder.Property(e => e.UserId).IsRequired();
        builder.Property(e => e.DirectoryId).IsRequired();
        builder.Property(e => e.Title).HasMaxLength(64);
        builder.Property(e => e.Content).HasMaxLength(4096);
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

        builder.HasOne(e => e.User).WithMany(e => e.Projects).HasForeignKey(e => e.UserId);
        builder.HasOne(e => e.Directory).WithMany(e => e.Notes).HasForeignKey(e => e.DirectoryId);

        builder.Navigation(e => e.Directory).AutoInclude();
    }
}
