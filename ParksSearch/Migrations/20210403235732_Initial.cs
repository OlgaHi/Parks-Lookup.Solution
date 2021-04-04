using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksSearch.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NationalParks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Address = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    WheelchairAccess = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalParks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateParks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Address = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    WheelchairAccess = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateParks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NationalParks",
                columns: new[] { "Id", "Address", "Name", "WheelchairAccess" },
                values: new object[,]
                {
                    { 1, "3002 Mt Angeles Rd, Port Angeles, WA", "Olympic Park", true },
                    { 2, "55210 238th Avenue East, Ashford, WA", "Mountain Rainier Park", false },
                    { 3, "3256 Road, Paradise, WA", "Paradise", true }
                });

            migrationBuilder.InsertData(
                table: "StateParks",
                columns: new[] { "Id", "Address", "Name", "WheelchairAccess" },
                values: new object[,]
                {
                    { 1, "5300 116th Ave NE, Kirkland, WA", "Bridle Trails", true },
                    { 2, "555 NE, Kenmore, WA", "Saint Edward", true },
                    { 3, "1111 NE 136 St, Poulsbo, WA", "Kitsap Memorial", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NationalParks");

            migrationBuilder.DropTable(
                name: "StateParks");
        }
    }
}
