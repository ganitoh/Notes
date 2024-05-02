using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain.Models;

namespace Notes.Persistance.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u=>u.Id);

            builder.Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(52);

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(52);
        }
    }
}
