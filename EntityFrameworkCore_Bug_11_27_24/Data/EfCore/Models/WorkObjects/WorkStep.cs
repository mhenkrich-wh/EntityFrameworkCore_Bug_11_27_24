using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.EfCore.Models.BaseModels;
using Core.Data.EfCore.Models.CheckList;
using Core.Data.EfCore.Models.Entries;

namespace Core.Data.EfCore.Models.WorkObjects
{
	public partial class WorkStep : ClientModifiablePersistedEntityEf
	{
		public WorkStep()
		{
			Defects = new List<Defect>();
			Expenses = new List<Expense>();
			ChecklistInstances = new List<CheckListInstance>();
		}

		public List<CheckListInstance> ChecklistInstances { get; set; }
		public List<Defect> Defects { get; set; }
		public List<Expense> Expenses { get; set; }

		[NotMapped]
		public IEnumerable<EntryEf> Entries => Defects.Cast<EntryEf>().Concat(Expenses);
		public static WorkStepConfigurations Configuration => new WorkStepConfigurations();

		public class WorkStepConfigurations : ClientModifiablePersistedEntityConfigurations<WorkStep>
		{
			public override void Configure(EntityTypeBuilder<WorkStep> builder)
			{
				base.Configure(builder);
			}
		}
	}
}
