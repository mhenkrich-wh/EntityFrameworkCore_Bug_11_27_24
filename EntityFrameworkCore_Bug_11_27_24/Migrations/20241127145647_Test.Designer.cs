﻿// <auto-generated />
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core.Migrations
{
    [DbContext(typeof(MainDataContext))]
    [Migration("20241127145647_Test")]
    partial class Test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Core.Data.EfCore.Models.CheckList.CheckListInstance", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<long?>("LastClientModifiedDateUtc")
                        .HasColumnType("bigint");

                    b.Property<long>("LastModifiedDateUtc")
                        .HasColumnType("bigint");

                    b.Property<string>("WorkStepId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("WorkStepId")
                        .HasDatabaseName("CheckListInstances_WorkStepId");

                    b.ToTable("CheckListInstances");
                });

            modelBuilder.Entity("Core.Data.EfCore.Models.Entries.Defect", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<long?>("LastClientModifiedDateUtc")
                        .HasColumnType("bigint");

                    b.Property<long>("LastModifiedDateUtc")
                        .HasColumnType("bigint");

                    b.Property<string>("WorkStepId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("WorkStepId")
                        .HasDatabaseName("Defects_WorkStepId");

                    b.ToTable("Defects");
                });

            modelBuilder.Entity("Core.Data.EfCore.Models.Entries.Expense", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<long?>("LastClientModifiedDateUtc")
                        .HasColumnType("bigint");

                    b.Property<long>("LastModifiedDateUtc")
                        .HasColumnType("bigint");

                    b.Property<string>("WorkStepId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("WorkStepId")
                        .HasDatabaseName("Expenses_WorkStepId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Core.Data.EfCore.Models.WorkObjects.WorkStep", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<long?>("LastClientModifiedDateUtc")
                        .HasColumnType("bigint");

                    b.Property<long>("LastModifiedDateUtc")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("WorkSteps");
                });

            modelBuilder.Entity("Core.Data.EfCore.Models.CheckList.CheckListInstance", b =>
                {
                    b.HasOne("Core.Data.EfCore.Models.WorkObjects.WorkStep", "WorkStep")
                        .WithMany("ChecklistInstances")
                        .HasForeignKey("WorkStepId");

                    b.Navigation("WorkStep");
                });

            modelBuilder.Entity("Core.Data.EfCore.Models.Entries.Defect", b =>
                {
                    b.HasOne("Core.Data.EfCore.Models.WorkObjects.WorkStep", null)
                        .WithMany("Defects")
                        .HasForeignKey("WorkStepId");
                });

            modelBuilder.Entity("Core.Data.EfCore.Models.Entries.Expense", b =>
                {
                    b.HasOne("Core.Data.EfCore.Models.WorkObjects.WorkStep", null)
                        .WithMany("Expenses")
                        .HasForeignKey("WorkStepId");
                });

            modelBuilder.Entity("Core.Data.EfCore.Models.WorkObjects.WorkStep", b =>
                {
                    b.Navigation("ChecklistInstances");

                    b.Navigation("Defects");

                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}