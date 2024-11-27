using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Data.EfCore.Models.BaseModels;
using Core.Data.EfCore.Models.WorkObjects;

namespace Core.Data.EfCore.Models.CheckList
{
    public class CheckListInstance : ClientModifiablePersistedEntityEf  {
  
        public Guid? WorkStepId { get; set; }
        public WorkStep WorkStep { get; set; }

        public static CheckListInstanceConfigurations Configuration => new CheckListInstanceConfigurations();

        public class CheckListInstanceConfigurations : ClientModifiablePersistedEntityConfigurations<CheckListInstance>
        {
            public override void Configure(EntityTypeBuilder<CheckListInstance> builder)
            {
                base.Configure(builder);

                builder.HasIndex(e => e.WorkStepId)
                    .HasDatabaseName("CheckListInstances_WorkStepId");

                builder.Property(e => e.WorkStepId).HasColumnType("varchar(36)")
                    .HasConversion(
                        v => v.ToString(),
                        v => new Guid(v));
            }
        }
    }
}

