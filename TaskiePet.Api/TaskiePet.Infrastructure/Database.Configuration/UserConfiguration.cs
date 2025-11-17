using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskiePet.Domain.Entities;

namespace TaskiePet.Infrastructure.Database.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasIndex(x => x.Email).IsUnique();

        // default value
        builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.UpdatedAt).HasDefaultValueSql("getutcdate()");

        builder.HasData(
            new User
            {
                Id = Guid.Parse("019a6d2f-5e4a-713f-8ff5-6b87315cc15b"),
                Email = "user@example.com",
                PasswordHash = "wMn+rPq2Ffj9KJkzl8+ErLXpL8CE9mDeErGJD+kJGOo2gKRa", //password123
                CreatedAt = new DateTime(2024, 11, 10),
                UpdatedAt = new DateTime(2024, 11, 10),
            }
        );
    }
}
