using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class AddWorkLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkLocationID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkLocation",
                columns: table => new
                {
                    WorkLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkLocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkLocationCity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLocation", x => x.WorkLocationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkLocationID",
                table: "AspNetUsers",
                column: "WorkLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkLocation_WorkLocationID",
                table: "AspNetUsers",
                column: "WorkLocationID",
                principalTable: "WorkLocation",
                principalColumn: "WorkLocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocation_WorkLocationID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WorkLocation");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkLocationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkLocationID",
                table: "AspNetUsers");
        }
    }
}
