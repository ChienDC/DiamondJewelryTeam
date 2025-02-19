using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiamondJewelry.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminLogins",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogins", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Brand_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Brand_ID);
                });

            migrationBuilder.CreateTable(
                name: "CartLists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Cat_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cat_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Cat_ID);
                });

            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    Certify_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Certify_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Certify_ID);
                });

            migrationBuilder.CreateTable(
                name: "DiamondInfos",
                columns: table => new
                {
                    DimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DimSubType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DimCrt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DimPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DimImg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiamondInfos", x => x.DimID);
                });

            migrationBuilder.CreateTable(
                name: "DiamondQualities",
                columns: table => new
                {
                    DimQlty_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimQlty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiamondQualities", x => x.DimQlty_ID);
                });

            migrationBuilder.CreateTable(
                name: "DiamondSubQualities",
                columns: table => new
                {
                    DimSubType_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimQlty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiamondSubQualities", x => x.DimSubType_ID);
                });

            migrationBuilder.CreateTable(
                name: "GoldCarats",
                columns: table => new
                {
                    GoldType_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gold_Crt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoldCarats", x => x.GoldType_ID);
                });

            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JewelTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jewellery_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JewelTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Prod_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prod_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Prod_ID);
                });

            migrationBuilder.CreateTable(
                name: "StoneQualities",
                columns: table => new
                {
                    StoneQlty_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoneQlty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoneQualities", x => x.StoneQlty_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Style_Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pairs = table.Column<int>(type: "int", nullable: false),
                    Brand_ID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Cat_ID = table.Column<int>(type: "int", nullable: false),
                    Prod_Quality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Certify_ID = table.Column<int>(type: "int", nullable: false),
                    Prod_ID = table.Column<int>(type: "int", nullable: false),
                    GoldType_ID = table.Column<int>(type: "int", nullable: false),
                    Gold_Wt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stone_Wt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Net_Gold = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tot_Gross_Wt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MRP = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Style_Code);
                    table.ForeignKey(
                        name: "FK_Items_Brands_Brand_ID",
                        column: x => x.Brand_ID,
                        principalTable: "Brands",
                        principalColumn: "Brand_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Categories_Cat_ID",
                        column: x => x.Cat_ID,
                        principalTable: "Categories",
                        principalColumn: "Cat_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Certifications_Certify_ID",
                        column: x => x.Certify_ID,
                        principalTable: "Certifications",
                        principalColumn: "Certify_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_GoldCarats_GoldType_ID",
                        column: x => x.GoldType_ID,
                        principalTable: "GoldCarats",
                        principalColumn: "GoldType_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Products_Prod_ID",
                        column: x => x.Prod_ID,
                        principalTable: "Products",
                        principalColumn: "Prod_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiamondDetails",
                columns: table => new
                {
                    Style_Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DimQlty_ID = table.Column<int>(type: "int", nullable: false),
                    DimSubType_ID = table.Column<int>(type: "int", nullable: false),
                    Dim_Crt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dim_Pcs = table.Column<int>(type: "int", nullable: false),
                    Dim_Gm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dim_Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dim_Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dim_Amt = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiamondDetails", x => new { x.Style_Code, x.DimQlty_ID, x.DimSubType_ID });
                    table.ForeignKey(
                        name: "FK_DiamondDetails_DiamondQualities_DimQlty_ID",
                        column: x => x.DimQlty_ID,
                        principalTable: "DiamondQualities",
                        principalColumn: "DimQlty_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiamondDetails_DiamondSubQualities_DimSubType_ID",
                        column: x => x.DimSubType_ID,
                        principalTable: "DiamondSubQualities",
                        principalColumn: "DimSubType_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiamondDetails_Items_Style_Code",
                        column: x => x.Style_Code,
                        principalTable: "Items",
                        principalColumn: "Style_Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stones",
                columns: table => new
                {
                    Style_Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StoneQlty_ID = table.Column<int>(type: "int", nullable: false),
                    Stone_Gm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stone_Pcs = table.Column<int>(type: "int", nullable: false),
                    Stone_Crt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stone_Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stone_Amt = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stones", x => new { x.Style_Code, x.StoneQlty_ID });
                    table.ForeignKey(
                        name: "FK_Stones_Items_Style_Code",
                        column: x => x.Style_Code,
                        principalTable: "Items",
                        principalColumn: "Style_Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stones_StoneQualities_StoneQlty_ID",
                        column: x => x.StoneQlty_ID,
                        principalTable: "StoneQualities",
                        principalColumn: "StoneQlty_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiamondDetails_DimQlty_ID",
                table: "DiamondDetails",
                column: "DimQlty_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DiamondDetails_DimSubType_ID",
                table: "DiamondDetails",
                column: "DimSubType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Brand_ID",
                table: "Items",
                column: "Brand_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Cat_ID",
                table: "Items",
                column: "Cat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Certify_ID",
                table: "Items",
                column: "Certify_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_GoldType_ID",
                table: "Items",
                column: "GoldType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Prod_ID",
                table: "Items",
                column: "Prod_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Stones_StoneQlty_ID",
                table: "Stones",
                column: "StoneQlty_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminLogins");

            migrationBuilder.DropTable(
                name: "CartLists");

            migrationBuilder.DropTable(
                name: "DiamondDetails");

            migrationBuilder.DropTable(
                name: "DiamondInfos");

            migrationBuilder.DropTable(
                name: "Inquiries");

            migrationBuilder.DropTable(
                name: "JewelTypes");

            migrationBuilder.DropTable(
                name: "Stones");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DiamondQualities");

            migrationBuilder.DropTable(
                name: "DiamondSubQualities");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "StoneQualities");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "GoldCarats");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
