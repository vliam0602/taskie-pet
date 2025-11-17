using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskiePet.Domain.Entities;

namespace TaskiePet.Infrastructure.Database.Configuration;

public class DailyTaskConfiguration : IEntityTypeConfiguration<DailyTask>
{
	public void Configure(EntityTypeBuilder<DailyTask> builder)
	{
		builder.ToTable("DailyTask");

		// default value
		builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
		builder.Property(x => x.CreatedAt).HasDefaultValueSql("getutcdate()");
		builder.Property(x => x.UpdatedAt).HasDefaultValueSql("getutcdate()");

		// Relationships
		builder.HasOne<User>()
			   .WithMany(u => u.DailyTasks)
			   .HasForeignKey(x => x.UserId)
			   .OnDelete(DeleteBehavior.Cascade);
	}
}
