using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseCorrelations.Migrations
{
    public partial class realtionAdded3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToItem_Item_ItemId",
                table: "UserToItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToItem_User_UserId",
                table: "UserToItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserToItem",
                table: "UserToItem");

            migrationBuilder.RenameTable(
                name: "UserToItem",
                newName: "UserToItems");

            migrationBuilder.RenameIndex(
                name: "IX_UserToItem_UserId",
                table: "UserToItems",
                newName: "IX_UserToItems_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserToItem_ItemId",
                table: "UserToItems",
                newName: "IX_UserToItems_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserToItems",
                table: "UserToItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToItems_Item_ItemId",
                table: "UserToItems",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToItems_User_UserId",
                table: "UserToItems",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToItems_Item_ItemId",
                table: "UserToItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToItems_User_UserId",
                table: "UserToItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserToItems",
                table: "UserToItems");

            migrationBuilder.RenameTable(
                name: "UserToItems",
                newName: "UserToItem");

            migrationBuilder.RenameIndex(
                name: "IX_UserToItems_UserId",
                table: "UserToItem",
                newName: "IX_UserToItem_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserToItems_ItemId",
                table: "UserToItem",
                newName: "IX_UserToItem_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserToItem",
                table: "UserToItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToItem_Item_ItemId",
                table: "UserToItem",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToItem_User_UserId",
                table: "UserToItem",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
