using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketplace.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassifiedAds",
                columns: table => new
                {
                    ClassifiedAdId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title_Title = table.Column<string>(type: "text", nullable: true),
                    Text_Value = table.Column<string>(type: "text", nullable: true),
                    Price_Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    Price_Currency_CurrencyCode = table.Column<string>(type: "text", nullable: true),
                    Price_Currency_InUse = table.Column<bool>(type: "boolean", nullable: true),
                    Price_Currency_DecimalPlaces = table.Column<int>(type: "integer", nullable: true),
                    ApprovedBy_Value = table.Column<Guid>(type: "uuid", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    OwnerId_Value = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedAds", x => x.ClassifiedAdId);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName_Value = table.Column<string>(type: "text", nullable: false),
                    DisplayName_Value = table.Column<string>(type: "text", nullable: false),
                    PhotoUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassifiedAdId = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Size_Height = table.Column<double>(type: "double precision", nullable: false),
                    Size_Width = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_Pictures_ClassifiedAds_ClassifiedAdId",
                        column: x => x.ClassifiedAdId,
                        principalTable: "ClassifiedAds",
                        principalColumn: "ClassifiedAdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ClassifiedAdId",
                table: "Pictures",
                column: "ClassifiedAdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "ClassifiedAds");
        }
    }
}
