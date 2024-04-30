using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain.Models;

namespace Notes.Persistance.EntityConfiguration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Name)
                .IsRequired(false)
                .HasMaxLength(120);

            builder.Property(n => n.Text)
                .IsRequired(false)
                .HasMaxLength(512);
        }
    }
}
