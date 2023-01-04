using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InsertDataForBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Book VALUES('Beyaz Diş', 150, 0)");
            migrationBuilder.Sql("INSERT INTO Book VALUES('Ölü Canlar', 220, 0)");
            migrationBuilder.Sql("INSERT INTO Book VALUES('Sefiller', 250, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
