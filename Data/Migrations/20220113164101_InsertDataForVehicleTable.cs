using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InsertDataForVehicleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Vehicle VALUES('S40', 'WAULT68')");
            migrationBuilder.Sql("INSERT INTO Vehicle VALUES('Lumina', '2G4GZ5G')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
