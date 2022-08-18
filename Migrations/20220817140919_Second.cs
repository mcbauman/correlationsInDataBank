using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseCorrelations.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_UserClassId",
                table: "User");

            migrationBuilder.DropTable(
                name: "ItemClassUserClass");

            migrationBuilder.DropIndex(
                name: "IX_User_UserClassId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserClassId",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "UserClassId",
                table: "ItemClass",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "UserIds",
                table: "ItemClass",
                type: "uuid[]",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_ItemClass_UserClassId",
                table: "ItemClass",
                column: "UserClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemClass_User_UserClassId",
                table: "ItemClass",
                column: "UserClassId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemClass_User_UserClassId",
                table: "ItemClass");

            migrationBuilder.DropIndex(
                name: "IX_ItemClass_UserClassId",
                table: "ItemClass");

            migrationBuilder.DropColumn(
                name: "UserClassId",
                table: "ItemClass");

            migrationBuilder.DropColumn(
                name: "UserIds",
                table: "ItemClass");

            migrationBuilder.AddColumn<Guid>(
                name: "UserClassId",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemClassUserClass",
                columns: table => new
                {
                    ItemsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemClassUserClass", x => new { x.ItemsId, x.UsedById });
                    table.ForeignKey(
                        name: "FK_ItemClassUserClass_ItemClass_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "ItemClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemClassUserClass_User_UsedById",
                        column: x => x.UsedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserClassId",
                table: "User",
                column: "UserClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemClassUserClass_UsedById",
                table: "ItemClassUserClass",
                column: "UsedById");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_UserClassId",
                table: "User",
                column: "UserClassId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
