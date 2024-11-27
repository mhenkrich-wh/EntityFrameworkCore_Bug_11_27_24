using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EfCore.Models.BaseModels
{
    public abstract class PersistedEntityEf
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime LastModifiedDateUtc { get; set; } = DateTime.UtcNow;
    }
    public class PersistedEntityConfigurations<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : PersistedEntityEf
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.Id)
                    .HasColumnType("varchar(36)")
                    .ValueGeneratedNever()
                    .HasConversion(
                        v => v.ToString(),
                        v => new Guid(v));

            builder.Property(e => e.LastModifiedDateUtc).HasColumnType("bigint")
                    .HasConversion(
                        v => v.Ticks,
                        v => new DateTime(v));
        }
    }
}
