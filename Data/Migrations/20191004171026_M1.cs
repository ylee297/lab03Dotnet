using Microsoft.EntityFrameworkCore.Migrations;

namespace lab03.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceCode = table.Column<string>(nullable: false),
                    ProvinceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceCode);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    Population = table.Column<int>(nullable: false),
                    ProvinceCode = table.Column<string>(nullable: true),
                    ProvinceCode1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Province_ProvinceCode1",
                        column: x => x.ProvinceCode1,
                        principalTable: "Province",
                        principalColumn: "ProvinceCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "CityName", "Population", "ProvinceCode", "ProvinceCode1" },
                values: new object[,]
                {
                    { 1, "Vancouver", 3000000, null, null },
                    { 2, "Burnaby", 4000000, null, null },
                    { 3, "Chicago", 5000000, null, null },
                    { 4, "Anaheim", 3323232, null, null },
                    { 5, "Toronto", 3004000, null, null },
                    { 6, "Calgary", 9090999, null, null },
                    { 7, "Edmonton", 10109922, null, null },
                    { 8, "San Jose", 786600120, null, null }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceCode", "ProvinceName" },
                values: new object[,]
                {
                    { "BC", "British Columbia" },
                    { "AB", "Alberta" },
                    { "ON", "Ontario" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceCode1",
                table: "City",
                column: "ProvinceCode1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
