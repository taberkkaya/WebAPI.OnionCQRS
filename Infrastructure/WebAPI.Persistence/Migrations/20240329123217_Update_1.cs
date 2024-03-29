using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 3, 29, 15, 32, 17, 62, DateTimeKind.Local).AddTicks(1241), "Books" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 3, 29, 15, 32, 17, 62, DateTimeKind.Local).AddTicks(1335), "Outdoors & Beauty" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 3, 29, 15, 32, 17, 62, DateTimeKind.Local).AddTicks(1401), "Home" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 15, 32, 17, 62, DateTimeKind.Local).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 15, 32, 17, 62, DateTimeKind.Local).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 15, 32, 17, 62, DateTimeKind.Local).AddTicks(4439));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 29, 15, 32, 17, 62, DateTimeKind.Local).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 3, 29, 15, 32, 17, 66, DateTimeKind.Local).AddTicks(1185), "Ex qui perspiciatis et esse.", "Dolorem." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 3, 29, 15, 32, 17, 66, DateTimeKind.Local).AddTicks(1306), "Nulla impedit accusantium esse est.", "İure nobis." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 3, 29, 15, 32, 17, 66, DateTimeKind.Local).AddTicks(1367), "Natus deleniti est praesentium sit.", "Sunt." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Price", "Title" },
                values: new object[] { new DateTime(2024, 3, 29, 15, 32, 17, 70, DateTimeKind.Local).AddTicks(7127), "At qui distinctio est totam.", 702.326810039779000m, "Est." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Price", "Title" },
                values: new object[] { new DateTime(2024, 3, 29, 15, 32, 17, 70, DateTimeKind.Local).AddTicks(7166), "İure et dolor magnam distinctio.", 778.590374330809000m, "Voluptas." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Price", "Title" },
                values: new object[] { new DateTime(2024, 3, 29, 15, 32, 17, 70, DateTimeKind.Local).AddTicks(7198), "Asperiores qui repellat sit architecto.", 761.297291317154000m, "Ab." });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProuctsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProuctsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProuctsId",
                        column: x => x.ProuctsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 3, 28, 12, 16, 46, 445, DateTimeKind.Local).AddTicks(5763), "Home, Kids & Baby" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 3, 28, 12, 16, 46, 445, DateTimeKind.Local).AddTicks(5847), "Movies & Movies" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 3, 28, 12, 16, 46, 445, DateTimeKind.Local).AddTicks(5857), "Shoes, Tools & Books" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 12, 16, 46, 445, DateTimeKind.Local).AddTicks(7116));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 12, 16, 46, 445, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 12, 16, 46, 445, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 3, 28, 12, 16, 46, 445, DateTimeKind.Local).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 3, 28, 12, 16, 46, 447, DateTimeKind.Local).AddTicks(12), "Qui sunt sunt adipisci neque.", "Numquam." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 3, 28, 12, 16, 46, 447, DateTimeKind.Local).AddTicks(37), "Molestias perspiciatis iste distinctio deleniti.", "Facilis explicabo." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 3, 28, 12, 16, 46, 447, DateTimeKind.Local).AddTicks(59), "Excepturi et molestiae est nisi.", "Fugiat." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Price", "Title" },
                values: new object[] { new DateTime(2024, 3, 28, 12, 16, 46, 448, DateTimeKind.Local).AddTicks(2358), "Asperiores id commodi odit et.", 767.025188969371000m, "Excepturi." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Price", "Title" },
                values: new object[] { new DateTime(2024, 3, 28, 12, 16, 46, 448, DateTimeKind.Local).AddTicks(2386), "Excepturi quisquam incidunt tempore qui.", 292.726256686096000m, "Adipisci." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Price", "Title" },
                values: new object[] { new DateTime(2024, 3, 28, 12, 16, 46, 448, DateTimeKind.Local).AddTicks(2410), "Sint minima distinctio numquam nihil.", 723.716960993157000m, "Consequatur." });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProuctsId",
                table: "CategoryProduct",
                column: "ProuctsId");
        }
    }
}
