using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskiePet.Domain.Entities;

namespace TaskiePet.Infrastructure.Database.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();

        // default value
        builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
        builder.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
        builder.Property(x => x.LastModifiedDate).HasDefaultValueSql("getutcdate()");

        builder.HasData(
            new User
            {
                Id = Guid.Parse("019a6d2f-5e4a-713f-8ff5-6b87315cc15b"),
                Email = "user@example.com",
                PasswordHash = "YNVlhNyvL0xKNyE8GTr6a5s+F47FkuYYqCaawJxGn0lBgN0j", //password123
                CreatedDate = new DateTime(2024, 11, 10),
                LastModifiedDate = new DateTime(2024, 11, 10),
            }
        );
    }
}
