
namespace Infrastructure.Data.Config;

public class BaseEntityConfig : IEntityTypeConfiguration<BaseEntity>
{
    public virtual void Configure(EntityTypeBuilder<BaseEntity> builder)
    {

        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.DomainEvents);


        builder.Property(x => x.Id)
               .ValueGeneratedNever();

    }
}
