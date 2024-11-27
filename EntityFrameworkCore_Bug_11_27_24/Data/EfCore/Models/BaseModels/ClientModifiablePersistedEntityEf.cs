using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EfCore.Models.BaseModels
{
    public abstract class ClientModifiablePersistedEntityEf : PersistedEntityEf
    {
        public DateTime? LastClientModifiedDateUtc { get; set; }
    }

    public class ClientModifiablePersistedEntityConfigurations<TEntity> : PersistedEntityConfigurations<TEntity> where TEntity : ClientModifiablePersistedEntityEf
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {

            base.Configure(builder);

            builder.Property(e => e.LastClientModifiedDateUtc)
                .HasColumnType("bigint")
                .IsRequired(false)
                .HasConversion(
                    v => v.Value.Ticks,
                    v => new DateTime(v));

        }
    }
}
