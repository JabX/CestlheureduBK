using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CestlheureduBK.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    SubCategory = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AddressFull = table.Column<string>(type: "TEXT", nullable: false),
                    Lat = table.Column<double>(type: "REAL", nullable: false),
                    Lng = table.Column<double>(type: "REAL", nullable: false),
                    Departement = table.Column<string>(type: "TEXT", nullable: false),
                    Opened = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Snacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Update",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Restaurants = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Catalogue = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Offers = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Update", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "decimal(4, 2)", nullable: false),
                    PriceL = table.Column<double>(type: "decimal(4, 2)", nullable: true),
                    PriceXL = table.Column<double>(type: "decimal(4, 2)", nullable: true),
                    RestaurantId = table.Column<string>(type: "TEXT", nullable: true),
                    AvailableInCatalogue = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "decimal(4, 2)", nullable: false),
                    Energy = table.Column<double>(type: "decimal(7, 2)", nullable: true),
                    RestaurantId = table.Column<string>(type: "TEXT", nullable: true),
                    AvailableInCatalogue = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    RestaurantId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategorieDbMenuDb",
                columns: table => new
                {
                    CategoriesId = table.Column<string>(type: "TEXT", nullable: false),
                    MenusId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieDbMenuDb", x => new { x.CategoriesId, x.MenusId });
                    table.ForeignKey(
                        name: "FK_CategorieDbMenuDb_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieDbMenuDb_Menus_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorieDbProductDb",
                columns: table => new
                {
                    CategoriesId = table.Column<string>(type: "TEXT", nullable: false),
                    ProductsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieDbProductDb", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategorieDbProductDb_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieDbProductDb_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SnackAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SnackId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuDbId = table.Column<string>(type: "TEXT", nullable: true),
                    ProductDbId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SnackAmounts_Menus_MenuDbId",
                        column: x => x.MenuDbId,
                        principalTable: "Menus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SnackAmounts_Products_ProductDbId",
                        column: x => x.ProductDbId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SnackAmounts_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DefaultProductId = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuDbId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Menus_MenuDbId",
                        column: x => x.MenuDbId,
                        principalTable: "Menus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Steps_Products_DefaultProductId",
                        column: x => x.DefaultProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MenuDbPromotionDb",
                columns: table => new
                {
                    MenusId = table.Column<string>(type: "TEXT", nullable: false),
                    PromotionsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuDbPromotionDb", x => new { x.MenusId, x.PromotionsId });
                    table.ForeignKey(
                        name: "FK_MenuDbPromotionDb_Menus_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuDbPromotionDb_Promotions_PromotionsId",
                        column: x => x.PromotionsId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false),
                    PromotionId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductDbPromotionDb",
                columns: table => new
                {
                    ProductsId = table.Column<string>(type: "TEXT", nullable: false),
                    PromotionsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDbPromotionDb", x => new { x.ProductsId, x.PromotionsId });
                    table.ForeignKey(
                        name: "FK_ProductDbPromotionDb_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDbPromotionDb_Promotions_PromotionsId",
                        column: x => x.PromotionsId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepProducts",
                columns: table => new
                {
                    ProductsId = table.Column<string>(type: "TEXT", nullable: false),
                    StepDbId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepProducts", x => new { x.ProductsId, x.StepDbId });
                    table.ForeignKey(
                        name: "FK_StepProducts_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StepProducts_Steps_StepDbId",
                        column: x => x.StepDbId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepProductsL",
                columns: table => new
                {
                    ProductsLId = table.Column<string>(type: "TEXT", nullable: false),
                    StepDb1Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepProductsL", x => new { x.ProductsLId, x.StepDb1Id });
                    table.ForeignKey(
                        name: "FK_StepProductsL_Products_ProductsLId",
                        column: x => x.ProductsLId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StepProductsL_Steps_StepDb1Id",
                        column: x => x.StepDb1Id,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepProductsXL",
                columns: table => new
                {
                    ProductsXLId = table.Column<string>(type: "TEXT", nullable: false),
                    StepDb2Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepProductsXL", x => new { x.ProductsXLId, x.StepDb2Id });
                    table.ForeignKey(
                        name: "FK_StepProductsXL_Products_ProductsXLId",
                        column: x => x.ProductsXLId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StepProductsXL_Steps_StepDb2Id",
                        column: x => x.StepDb2Id,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieDbMenuDb_MenusId",
                table: "CategorieDbMenuDb",
                column: "MenusId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieDbProductDb_ProductsId",
                table: "CategorieDbProductDb",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuDbPromotionDb_PromotionsId",
                table: "MenuDbPromotionDb",
                column: "PromotionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_RestaurantId",
                table: "Menus",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PromotionId",
                table: "Offers",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDbPromotionDb_PromotionsId",
                table: "ProductDbPromotionDb",
                column: "PromotionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RestaurantId",
                table: "Products",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_RestaurantId",
                table: "Promotions",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_SnackAmounts_MenuDbId",
                table: "SnackAmounts",
                column: "MenuDbId");

            migrationBuilder.CreateIndex(
                name: "IX_SnackAmounts_ProductDbId",
                table: "SnackAmounts",
                column: "ProductDbId");

            migrationBuilder.CreateIndex(
                name: "IX_SnackAmounts_SnackId",
                table: "SnackAmounts",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_StepProducts_StepDbId",
                table: "StepProducts",
                column: "StepDbId");

            migrationBuilder.CreateIndex(
                name: "IX_StepProductsL_StepDb1Id",
                table: "StepProductsL",
                column: "StepDb1Id");

            migrationBuilder.CreateIndex(
                name: "IX_StepProductsXL_StepDb2Id",
                table: "StepProductsXL",
                column: "StepDb2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_DefaultProductId",
                table: "Steps",
                column: "DefaultProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_MenuDbId",
                table: "Steps",
                column: "MenuDbId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieDbMenuDb");

            migrationBuilder.DropTable(
                name: "CategorieDbProductDb");

            migrationBuilder.DropTable(
                name: "MenuDbPromotionDb");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "ProductDbPromotionDb");

            migrationBuilder.DropTable(
                name: "SnackAmounts");

            migrationBuilder.DropTable(
                name: "StepProducts");

            migrationBuilder.DropTable(
                name: "StepProductsL");

            migrationBuilder.DropTable(
                name: "StepProductsXL");

            migrationBuilder.DropTable(
                name: "Update");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Snacks");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
