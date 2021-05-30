using Microsoft.EntityFrameworkCore.Migrations;

namespace BenefitsCalc.Migrations
{
    public partial class discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPct",
                table: "Config",
                type: "decimal(4,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPct",
                table: "Config");
        }
    }
}
