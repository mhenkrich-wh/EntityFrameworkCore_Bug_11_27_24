using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Data.EfCore.Models.BaseModels;

namespace Core.Data.EfCore.Models.Entries
{
	public partial class Defect : EntryEf
	{
		public static DefectConfigurations Configuration => new DefectConfigurations();

		public class DefectConfigurations : EntryEfConfigurations<Defect>
		{
			public override void Configure(EntityTypeBuilder<Defect> builder)
			{
				base.Configure(builder);

				_ = builder.HasIndex(e => e.WorkStepId)
					.HasDatabaseName("Defects_WorkStepId");
			}
		}
	}
}
