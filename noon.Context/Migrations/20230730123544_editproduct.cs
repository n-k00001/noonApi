using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace noon.Context.Migrations
{
    /// <inheritdoc />
    public partial class editproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_WishLists_WishListid",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_WishListid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WishListid",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "productsku",
                table: "WishLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_productsku",
                table: "WishLists",
                column: "productsku");

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Products_productsku",
                table: "WishLists",
                column: "productsku",
                principalTable: "Products",
                principalColumn: "sku",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Products_productsku",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_productsku",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "productsku",
                table: "WishLists");

            migrationBuilder.AddColumn<int>(
                name: "WishListid",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_WishListid",
                table: "Products",
                column: "WishListid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_WishLists_WishListid",
                table: "Products",
                column: "WishListid",
                principalTable: "WishLists",
                principalColumn: "id");
        }
    }
}
