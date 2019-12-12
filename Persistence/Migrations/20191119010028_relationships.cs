using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_customer_order_customer_id",
                table: "customer_order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_id",
                table: "customer_order",
                column: "item_id");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_order_customer_customer_id",
                table: "customer_order",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customer_order_item_item_id",
                table: "customer_order",
                column: "item_id",
                principalTable: "item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_order_customer_customer_id",
                table: "customer_order");

            migrationBuilder.DropForeignKey(
                name: "FK_customer_order_item_item_id",
                table: "customer_order");

            migrationBuilder.DropIndex(
                name: "IX_customer_order_customer_id",
                table: "customer_order");

            migrationBuilder.DropIndex(
                name: "IX_customer_order_item_id",
                table: "customer_order");
        }
    }
}
