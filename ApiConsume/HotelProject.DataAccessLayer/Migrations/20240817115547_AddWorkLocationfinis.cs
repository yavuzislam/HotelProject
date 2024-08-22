using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class AddWorkLocationfinis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocation_WorkLocationID",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkLocation",
                table: "WorkLocation");

            migrationBuilder.RenameTable(
                name: "WorkLocation",
                newName: "WorkLocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkLocations",
                table: "WorkLocations",
                column: "WorkLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationID",
                table: "AspNetUsers",
                column: "WorkLocationID",
                principalTable: "WorkLocations",
                principalColumn: "WorkLocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationID",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkLocations",
                table: "WorkLocations");

            migrationBuilder.RenameTable(
                name: "WorkLocations",
                newName: "WorkLocation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkLocation",
                table: "WorkLocation",
                column: "WorkLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkLocation_WorkLocationID",
                table: "AspNetUsers",
                column: "WorkLocationID",
                principalTable: "WorkLocation",
                principalColumn: "WorkLocationID");
        }
    }
}
