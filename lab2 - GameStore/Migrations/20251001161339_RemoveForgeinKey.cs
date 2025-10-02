using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2___GameStore.Migrations
{
    /// <inheritdoc />
    public partial class RemoveForgeinKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Stores_StoreId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_StoreId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "People");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_People_StoreId",
                table: "People",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Stores_StoreId",
                table: "People",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
