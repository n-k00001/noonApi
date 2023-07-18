using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace noon.Context.Migrations
{
    /// <inheritdoc />
    public partial class addDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "Addresss");
        }
    }
}
