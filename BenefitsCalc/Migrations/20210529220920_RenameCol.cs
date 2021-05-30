using Microsoft.EntityFrameworkCore.Migrations;

namespace BenefitsCalc.Migrations
{
    public partial class RenameCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultBenefitsCost",
                table: "Config",
                newName: "BaseBenefitsCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BaseBenefitsCost",
                table: "Config",
                newName: "DefaultBenefitsCost");
        }
    }
}
