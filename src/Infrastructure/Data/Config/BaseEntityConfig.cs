
namespace Infrastructure.Data.Config;

public class BaseEntityConfig<TEntity, TId> : IEntityTypeConfiguration<TEntity>
where TEntity : BaseEntity<TId>
where TId : struct, IEquatable<TId>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        if (typeof(TId) != typeof(int) && typeof(TId) != typeof(Guid))
            throw new NotSupportedException("TId must be int or Guid");

        builder.HasKey(x => x.Id);

        if (typeof(TId) == typeof(int))
        {
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();
        }
        else
        {
            builder.Property(x => x.Id)
                   .HasConversion<Guid>();
        }
    }
}
