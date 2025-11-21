
namespace Infrastructure.Data;

public class AppDbContext : IdentityDbContext<AppUser>, IAppDbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected AppDbContext()
    {
    }

    public override async Task<int> SaveChangesAsync(CancellationToken ct)
    {

        return await base.SaveChangesAsync(ct);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);



        ConfigurePropertiesForInterface<IAuditable>(builder, (b, type) =>
        {
            b.Property(nameof(IAuditable.CreatedAt)).IsRequired();
            b.Property(nameof(IAuditable.CreatedBy)).HasColumnType("CHAR(36)");
            b.Property(nameof(IAuditable.LastModifiedAt)).IsRequired();
            b.Property(nameof(IAuditable.LastModifiedBy)).HasColumnType("CHAR(36)");
        });

        ConfigurePropertiesForInterface<ISofDeletable>(builder, (b, type) =>
        {
            b.Property(nameof(ISofDeletable.DeletedAt)).IsRequired(false);
            b.Property(nameof(ISofDeletable.DeletedBy)).HasColumnType("CHAR(36)").IsRequired(false);
        });
    }


    private void ConfigurePropertiesForInterface<TInterface>(ModelBuilder builder, Action<EntityTypeBuilder, Type> configure)
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
