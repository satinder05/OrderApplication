using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class OrderItemRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_order_item_item_id",
                table: "customer_order");

            migrationBuilder.DropIndex(
                name: "IX_customer_order_item_id",
                table: "customer_order");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_item_id",
                table: "order_item",
                column: "item_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_item_item_item_id",
                table: "order_item",
                column: "item_id",
                principalTable: "item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_item_item_item_id",
                table: "order_item");

            migrationBuilder.DropIndex(
                name: "IX_order_item_item_id",
                table: "order_item");

            migrationBuilder.CreateIndex(
                name: "IX_customer_order_item_id",
                table: "customer_order",
                column: "item_id");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_order_item_item_id",
                table: "customer_order",
                column: "item_id",
                principalTable: "item",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
