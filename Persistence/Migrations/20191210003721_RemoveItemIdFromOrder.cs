using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RemoveItemIdFromOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "item_id",
                table: "customer_order");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_order_id",
                table: "order_item",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_item_id",
                table: "order_item",
                column: "item_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_item_customer_order_order_id",
                table: "order_item",
                column: "order_id",
                principalTable: "customer_order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_order_item_customer_order_order_id",
                table: "order_item");

            migrationBuilder.DropForeignKey(
                name: "FK_order_item_item_item_id",
                table: "order_item");

            migrationBuilder.DropIndex(
                name: "IX_order_item_order_id",
                table: "order_item");

            migrationBuilder.DropIndex(
                name: "IX_order_item_item_id",
                table: "order_item");

            migrationBuilder.AddColumn<long>(
                name: "item_id",
                table: "customer_order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
            
        }
    }
}
