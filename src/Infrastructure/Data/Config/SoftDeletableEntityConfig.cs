
namespace Infrastructure.Data.Config;

public class SoftDeletableEntityConfig<TEntity, TId> : BaseEntityConfig<TEntity, TId>
where TEntity : SoftDeletableEntity<TId>
where TId : struct, IEquatable<TId>
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);// Do NOT remove it

        builder.Property(x => x.DeletedBy)
               .HasColumnType("CHAR(36)")
               .IsRequired(false);

        builder.Property(x => x.IsDeleted)
               .IsRequired();

        builder.Property(x => x.DeletedAtUtc)
               .IsRequired(false);
    }
}
