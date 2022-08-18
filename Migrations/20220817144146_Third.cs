using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseCorrelations.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemClass_User_UserClassId",
                table: "ItemClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemClass",
                table: "ItemClass");

            migrationBuilder.RenameTable(
                name: "ItemClass",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_ItemClass_UserClassId",
                table: "Item",
                newName: "IX_Item_UserClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_UserClassId",
                table: "Item",
                column: "UserClassId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_UserClassId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "ItemClass");

            migrationBuilder.RenameIndex(
                name: "IX_Item_UserClassId",
                table: "ItemClass",
                newName: "IX_ItemClass_UserClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemClass",
                table: "ItemClass",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemClass_User_UserClassId",
                table: "ItemClass",
                column: "UserClassId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
