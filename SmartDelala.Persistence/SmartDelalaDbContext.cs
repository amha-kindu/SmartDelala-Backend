using System.Reflection;
using SmartDelala.Domain.Common;
using SmartDelala.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SmartDelala.Persistence;

public class SmartDelalaDbContext: IdentityDbContext<ApplicationUser,ApplicationRole,string>
{
	public SmartDelalaDbContext() {}
	public SmartDelalaDbContext(DbContextOptions<SmartDelalaDbContext> options)
		: base(options)
	{
		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
		AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmartDelalaDbContext).Assembly);

		modelBuilder.Entity<ApplicationUser>()
			.HasIndex(u => u.PhoneNumber)
			.IsUnique();

		modelBuilder.Entity<ApplicationUser>()
			.Property<DateTime>("CreatedAt")
			.HasColumnType("timestamp with time zone");

		modelBuilder.Entity<ApplicationUser>()
			.Property<DateTime?>("LastLogin")
			.HasColumnType("timestamp with time zone");
		
		modelBuilder.Entity<ApplicationUser>()
			.Property<DateTime?>("RefreshTokenExpiryTime")
			.HasColumnType("timestamp with time zone");
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{

		foreach (var entry in ChangeTracker.Entries<BaseEntity>())
		{
			entry.Entity.LastModifiedDate = DateTime.UtcNow;

			if (entry.State == EntityState.Added)
			{
				entry.Entity.DateCreated = DateTime.UtcNow;
			}
		}

		return base.SaveChangesAsync(cancellationToken);
	}
}
