using Microsoft.EntityFrameworkCore.Migrations;

namespace BatchProcessor.Data.Migrations
{
    public partial class Changeindatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_Batches_BatchId",
                table: "Numbers");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "BatchGroups");

            migrationBuilder.DropIndex(
                name: "IX_Numbers_BatchId",
                table: "Numbers");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Numbers");

            migrationBuilder.AddColumn<int>(
                name: "BatchSequence",
                table: "Numbers",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Execution",
                table: "Numbers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Numbers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchSequence",
                table: "Numbers");

            migrationBuilder.DropColumn(
                name: "Execution",
                table: "Numbers");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Numbers");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Numbers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BatchGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batches_BatchGroups_BatchGroupId",
                        column: x => x.BatchGroupId,
                        principalTable: "BatchGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Numbers_BatchId",
                table: "Numbers",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_BatchGroupId",
                table: "Batches",
                column: "BatchGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_Batches_BatchId",
                table: "Numbers",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
