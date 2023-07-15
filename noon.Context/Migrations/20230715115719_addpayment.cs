using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace noon.Context.Migrations
{
    /// <inheritdoc />
    public partial class addpayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserPaymentMethods_PaymentMethodID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodID",
                table: "Orders",
                newName: "paymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PaymentMethodID",
                table: "Orders",
                newName: "IX_Orders_paymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserPaymentMethods_paymentMethodId",
                table: "Orders",
                column: "paymentMethodId",
                principalTable: "UserPaymentMethods",
                principalColumn: "PaymentMethodID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserPaymentMethods_paymentMethodId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "paymentMethodId",
                table: "Orders",
                newName: "PaymentMethodID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_paymentMethodId",
                table: "Orders",
                newName: "IX_Orders_PaymentMethodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserPaymentMethods_PaymentMethodID",
                table: "Orders",
                column: "PaymentMethodID",
                principalTable: "UserPaymentMethods",
                principalColumn: "PaymentMethodID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
