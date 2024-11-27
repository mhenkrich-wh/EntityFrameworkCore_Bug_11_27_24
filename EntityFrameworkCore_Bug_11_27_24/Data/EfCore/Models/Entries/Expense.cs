using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Data.EfCore.Models.BaseModels;

namespace Core.Data.EfCore.Models.Entries
{
    public partial class Expense : EntryEf
    {
        public static ExpenseConfigurations Configuration => new ExpenseConfigurations();

        public class ExpenseConfigurations : EntryEfConfigurations<Expense>
        {
            public override void Configure(EntityTypeBuilder<Expense> builder)
            {
                base.Configure(builder);

                builder.HasIndex(e => e.WorkStepId)
                    .HasDatabaseName("Expenses_WorkStepId");
            }
        }
    }
}
