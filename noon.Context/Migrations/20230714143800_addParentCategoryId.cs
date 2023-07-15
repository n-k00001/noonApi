using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace noon.Context.Migrations
{
    /// <inheritdoc />
    public partial class addParentCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_userId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategorys_ProductCategorys_parentCategoryid",
                table: "ProductCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Address_AddressId",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_Address_userId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "UserAddress",
                newName: "AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_AddressId",
                table: "UserAddress",
                newName: "IX_UserAddress_AddressID");

            migrationBuilder.RenameColumn(
                name: "parentCategoryid",
                table: "ProductCategorys",
                newName: "parentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategorys_parentCategoryid",
                table: "ProductCategorys",
                newName: "IX_ProductCategorys_parentCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "UserAddress",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_userId",
                table: "UserAddress",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategorys_ProductCategorys_parentCategoryId",
                table: "ProductCategorys",
                column: "parentCategoryId",
                principalTable: "ProductCategorys",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Address_AddressID",
                table: "UserAddress",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_AspNetUsers_userId",
                table: "UserAddress",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategorys_ProductCategorys_parentCategoryId",
                table: "ProductCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_Address_AddressID",
                table: "UserAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_AspNetUsers_userId",
                table: "UserAddress");

            migrationBuilder.DropIndex(
                name: "IX_UserAddress_userId",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "UserAddress");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "UserAddress",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_AddressID",
                table: "UserAddress",
                newName: "IX_UserAddress_AddressId");

            migrationBuilder.RenameColumn(
                name: "parentCategoryId",
                table: "ProductCategorys",
                newName: "parentCategoryid");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategorys_parentCategoryId",
                table: "ProductCategorys",
                newName: "IX_ProductCategorys_parentCategoryid");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Address",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Address_userId",
                table: "Address",
                column: "userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_userId",
                table: "Address",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategorys_ProductCategorys_parentCategoryid",
                table: "ProductCategorys",
                column: "parentCategoryid",
                principalTable: "ProductCategorys",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_Address_AddressId",
                table: "UserAddress",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
