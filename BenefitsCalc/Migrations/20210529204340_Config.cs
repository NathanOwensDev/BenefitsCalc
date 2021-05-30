using Microsoft.EntityFrameworkCore.Migrations;

namespace BenefitsCalc.Migrations
{
    public partial class Config : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefaultSalary = table.Column<int>(type: "int", nullable: false),
                    PayPeriods = table.Column<int>(type: "int", nullable: false),
                    BaseBenefitsCost = table.Column<int>(type: "int", nullable: false),
                    DependentCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Config");
        }
    }
}
