using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseCorrelations.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemClass",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserClassId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_UserClassId",
                        column: x => x.UserClassId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

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
                name: "IX_ItemClassUserClass_UsedById",
                table: "ItemClassUserClass",
                column: "UsedById");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserClassId",
                table: "User",
                column: "UserClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemClassUserClass");

            migrationBuilder.DropTable(
                name: "ItemClass");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
