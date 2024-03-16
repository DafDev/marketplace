using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassifiedAds",
                columns: table => new
                {
                    ClassifiedAdId = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    ApprovedBy_Value = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId_Value = table.Column<Guid>(type: "uuid", nullable: false),
                    Price_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Price_Currency_CurrencyCode = table.Column<string>(type: "text", nullable: false),
                    Price_Currency_DecimalPlaces = table.Column<int>(type: "integer", nullable: false),
                    Price_Currency_InUse = table.Column<bool>(type: "boolean", nullable: false),
                    Text_Value = table.Column<string>(type: "text", nullable: false),
                    Title_Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedAds", x => x.ClassifiedAdId);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    PictureId = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ClassifiedAdId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    ClassifiedAdId_Value = table.Column<Guid>(type: "uuid", nullable: false),
                    Size_Height = table.Column<double>(type: "double precision", nullable: false),
                    Size_Width = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_Picture_ClassifiedAds_ClassifiedAdId1",
                        column: x => x.ClassifiedAdId1,
                        principalTable: "ClassifiedAds",
                        principalColumn: "ClassifiedAdId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ClassifiedAdId1",
                table: "Picture",
                column: "ClassifiedAdId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "ClassifiedAds");
        }
    }
}
