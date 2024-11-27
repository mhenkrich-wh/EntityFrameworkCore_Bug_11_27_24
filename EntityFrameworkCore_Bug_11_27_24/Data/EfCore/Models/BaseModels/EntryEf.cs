using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EfCore.Models.BaseModels
{
    public abstract class EntryEf : ClientModifiablePersistedEntityEf
    {
        public Guid? WorkStepId { get; set; }
    }

    public class EntryEfConfigurations<TEntity> : ClientModifiablePersistedEntityConfigurations<TEntity> where TEntity : EntryEf
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.WorkStepId).HasColumnType("varchar(36)")
                .HasConversion(
                    v => v.ToString(),
                    v => new Guid(v));
        }
    }
}
