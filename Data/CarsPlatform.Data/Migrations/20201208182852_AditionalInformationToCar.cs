namespace CarsPlatform.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AditionalInformationToCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AditionalInformation",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AditionalInformation",
                table: "Cars");
        }
    }
}
