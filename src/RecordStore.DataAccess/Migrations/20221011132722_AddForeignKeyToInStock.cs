using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordStore.DataAccess.Migrations
{
    public partial class AddForeignKeyToInStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InStocks_AlbumId",
                table: "InStocks",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_InStocks_Albums_AlbumId",
                table: "InStocks",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InStocks_Albums_AlbumId",
                table: "InStocks");

            migrationBuilder.DropIndex(
                name: "IX_InStocks_AlbumId",
                table: "InStocks");
        }
    }
}
