using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Core.Data.EfCore.Models.BaseModels;
using Core.Data.EfCore.Models.Entries;
using Core.Data.EfCore.Models.WorkObjects;
using Core.Data.EfCore.Models.CheckList;

namespace Core.Data
{
    public partial class MainDataContext : DbContext
    {
        public virtual DbSet<Defect> Defects { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<WorkStep> WorkSteps { get; set; }
        public virtual DbSet<CheckListInstance> CheckListInstances { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite().UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
            modelBuilder.ApplyConfiguration(CheckListInstance.Configuration);
            modelBuilder.ApplyConfiguration(WorkStep.Configuration);
            modelBuilder.ApplyConfiguration(Defect.Configuration);
            modelBuilder.ApplyConfiguration(Expense.Configuration);

            // ignore the abstract base classes (no table for them)
            modelBuilder.Ignore<PersistedEntityEf>();
            modelBuilder.Ignore<ClientModifiablePersistedEntityEf>();
            modelBuilder.Ignore<EntryEf>();
        }
    }
}
