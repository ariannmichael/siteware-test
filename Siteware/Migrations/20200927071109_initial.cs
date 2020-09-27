using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Siteware.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    saletype = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    quantity = table.Column<int>(nullable: false),
                    cartId = table.Column<int>(nullable: false),
                    productId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_cartId",
                        column: x => x.cartId,
                        principalTable: "Carts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                column: "id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "name", "price", "saletype" },
                values: new object[,]
                {
                    { 1, "Sabonete", 5.0, 1 },
                    { 2, "Sabão", 7.0, 1 },
                    { 3, "Shampoo", 10.0, 2 },
                    { 4, "Condicionador", 12.0, 2 },
                    { 5, "Hidratante", 15.0, 0 },
                    { 6, "Esfoliante", 8.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "id", "cartId", "productId", "quantity" },
                values: new object[,]
                {
                    { 4, 1, 1, 5 },
                    { 1, 1, 2, 1 },
                    { 3, 1, 3, 3 },
                    { 2, 1, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_cartId",
                table: "CartItems",
                column: "cartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_productId",
                table: "CartItems",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
