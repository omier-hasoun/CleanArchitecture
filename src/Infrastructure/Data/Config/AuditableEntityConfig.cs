
namespace Infrastructure.Data.Config;

public class AuditableEntityConfig<TEntity, TId> : SoftDeletableEntityConfig<TEntity, TId>
where TEntity : AuditableEntity<TId>
where TId : struct, IEquatable<TId>
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);// Do NOT remove it

        builder.Property(x => x.CreatedBy)
               .HasColumnType("CHAR(36)")
               .IsRequired();

        builder.Property(x => x.LastModifiedBy)
               .HasColumnType("CHAR(36)")
               .IsRequired();

        builder.Property(x => x.CreatedAtUtc)
               .IsRequired();

        builder.Property(x => x.LastModifiedAtUtc)
               .IsRequired();
    }
}
