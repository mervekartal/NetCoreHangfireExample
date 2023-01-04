using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InsertDataForContainerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Container VALUES('Staneland', 79.533579, 9.519577, 2)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Gookey', 82.471253, 20.121246, 2)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Hammill', 58.197755, 94.864757, 2)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('McGenn', 55.367016, 26.515424, 1)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Drayton', 35.230951, 22.224519, 2)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Keneforde', 96.819121, 74.34800, 1)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Amy', 3.767346, 69.912561, 1)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Booth', 78.090185, 94.464113, 1)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Cellone', 19.554525, 74.083890, 2)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Riccelli', 82.357749, 90.171410, 1)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('MacKellar', 72.281991, 74.927197, 2)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Maplestone', 26.412889, 22.896025, 1)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Bedenham', 28.261111, 86.514097, 1)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Brundle', 53.928621, 84.188820, 2)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Harrald', 45.772195, 78.747847, 1)");
            migrationBuilder.Sql("INSERT INTO Container VALUES('Ghidoni', 62.876531, 10.593043, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
