
namespace Infrastructure.Data.Config;

public sealed class AuditableEntityConfig : IEntityTypeConfiguration<AuditableEntity>
{
    public void Configure(EntityTypeBuilder<AuditableEntity> builder)
    {
        builder.Property(x => x.CreatedBy)
               .HasColumnType("CHAR(36)")
               .IsRequired();

        builder.Property(x => x.LastModifiedBy)
               .HasColumnType("CHAR(36)")
               .IsRequired();

        builder.Property(x => x.LastModifiedAt)
                .IsRequired();

        builder.Property(x => x.CreatedAt)
               .IsRequired();

    }
}
