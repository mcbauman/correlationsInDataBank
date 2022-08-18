using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseCorrelations.Migrations
{
    public partial class realtionAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_UserClassId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_UserClassId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UserClassId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UserIds",
                table: "Item");

            migrationBuilder.CreateTable(
                name: "UserToItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToItem_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserToItem_ItemId",
                table: "UserToItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToItem_UserId",
                table: "UserToItem",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserToItem");

            migrationBuilder.AddColumn<Guid>(
                name: "UserClassId",
                table: "Item",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "UserIds",
                table: "Item",
                type: "uuid[]",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Item_UserClassId",
                table: "Item",
                column: "UserClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_UserClassId",
                table: "Item",
                column: "UserClassId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
