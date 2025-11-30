

using Infrastructure.Data.JoinEntities;

namespace Infrastructure.Data;

public sealed class AppDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRoles, UserLoginProvider, RoleClaim, UserToken, UserPasskey>, IAppDbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public AppDbContext()
    {
    }

    public override async Task<int> SaveChangesAsync(CancellationToken ct)
    {

        return await base.SaveChangesAsync(ct);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Softdelete configuration for all Entities implementing ISofDeletable
        ConfigurePropertiesForInterface<ISofDeletable>(builder, (b, type) =>
        {
            b.Property(nameof(ISofDeletable.DeletedAt))
             .IsRequired(false);

            b.Property(nameof(ISofDeletable.DeletedBy))
             .HasColumnType("CHAR(36)")
             .IsRequired(false);
        });
    }


    private static void ConfigurePropertiesForInterface<TInterface>(ModelBuilder builder, Action<EntityTypeBuilder, Type> configure)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(TInterface).IsAssignableFrom(entityType.ClrType))
            {
                builder.Entity(entityType.ClrType, b => configure(b, entityType.ClrType));
            }
        }
    }
}
