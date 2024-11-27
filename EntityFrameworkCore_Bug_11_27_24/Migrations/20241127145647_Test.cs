using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkSteps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    LastModifiedDateUtc = table.Column<long>(type: "bigint", nullable: false),
                    LastClientModifiedDateUtc = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSteps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckListInstances",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    WorkStepId = table.Column<string>(type: "varchar(36)", nullable: true),
                    LastModifiedDateUtc = table.Column<long>(type: "bigint", nullable: false),
                    LastClientModifiedDateUtc = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckListInstances_WorkSteps_WorkStepId",
                        column: x => x.WorkStepId,
                        principalTable: "WorkSteps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Defects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    LastModifiedDateUtc = table.Column<long>(type: "bigint", nullable: false),
                    LastClientModifiedDateUtc = table.Column<long>(type: "bigint", nullable: true),
                    WorkStepId = table.Column<string>(type: "varchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Defects_WorkSteps_WorkStepId",
                        column: x => x.WorkStepId,
                        principalTable: "WorkSteps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    LastModifiedDateUtc = table.Column<long>(type: "bigint", nullable: false),
                    LastClientModifiedDateUtc = table.Column<long>(type: "bigint", nullable: true),
                    WorkStepId = table.Column<string>(type: "varchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_WorkSteps_WorkStepId",
                        column: x => x.WorkStepId,
                        principalTable: "WorkSteps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "CheckListInstances_WorkStepId",
                table: "CheckListInstances",
                column: "WorkStepId");

            migrationBuilder.CreateIndex(
                name: "Defects_WorkStepId",
                table: "Defects",
                column: "WorkStepId");

            migrationBuilder.CreateIndex(
                name: "Expenses_WorkStepId",
                table: "Expenses",
                column: "WorkStepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckListInstances");

            migrationBuilder.DropTable(
                name: "Defects");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "WorkSteps");
        }
    }
}
