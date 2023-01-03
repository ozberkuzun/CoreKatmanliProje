using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreKatmanliProje.Data.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmanlars",
                columns: table => new
                {
                    DepartmanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplamCalisan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmanlars", x => x.DepartmanId);
                });

            migrationBuilder.CreateTable(
                name: "Calisanlars",
                columns: table => new
                {
                    CalisanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalisanAd = table.Column<int>(type: "int", nullable: false),
                    CalisanYas = table.Column<int>(type: "int", nullable: false),
                    DepartmanId = table.Column<int>(type: "int", nullable: false),
                    Fotograf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlars", x => x.CalisanId);
                    table.ForeignKey(
                        name: "FK_Calisanlars_Departmanlars_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlars",
                        principalColumn: "DepartmanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlars_DepartmanId",
                table: "Calisanlars",
                column: "DepartmanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calisanlars");

            migrationBuilder.DropTable(
                name: "Departmanlars");
        }
    }
}
