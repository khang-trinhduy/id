using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity_API.infrastructure.Migrations
{
    public partial class initializesqldatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "contact_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "identity_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "product_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    AuthorizedBy = table.Column<string>(nullable: false),
                    AuthorizedDate = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    ContactId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    HomeTown = table.Column<string>(nullable: true),
                    Residence = table.Column<string>(nullable: true),
                    EthnicGroup = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    CountryOfPassport = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    FamiliName = table.Column<string>(nullable: true),
                    GivenName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identity_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ContactId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    View = table.Column<string>(nullable: true),
                    Floor = table.Column<int>(nullable: true),
                    Area = table.Column<double>(nullable: true),
                    StudioApartment_Price = table.Column<double>(nullable: true),
                    StudioApartment_Direction = table.Column<string>(nullable: true),
                    StudioApartment_View = table.Column<string>(nullable: true),
                    StudioApartment_Floor = table.Column<int>(nullable: true),
                    StudioApartment_Area = table.Column<double>(nullable: true),
                    ThreeBedroomApartment_Price = table.Column<double>(nullable: true),
                    ThreeBedroomApartment_Direction = table.Column<string>(nullable: true),
                    ThreeBedroomApartment_View = table.Column<string>(nullable: true),
                    ThreeBedroomApartment_Floor = table.Column<int>(nullable: true),
                    ThreeBedroomApartment_Area = table.Column<double>(nullable: true),
                    TwoBedroomApartment_Price = table.Column<double>(nullable: true),
                    TwoBedroomApartment_Direction = table.Column<string>(nullable: true),
                    TwoBedroomApartment_View = table.Column<string>(nullable: true),
                    TwoBedroomApartment_Floor = table.Column<int>(nullable: true),
                    TwoBedroomApartment_Area = table.Column<double>(nullable: true),
                    TwoBedroomPlusApartment_Price = table.Column<double>(nullable: true),
                    TwoBedroomPlusApartment_Direction = table.Column<string>(nullable: true),
                    TwoBedroomPlusApartment_View = table.Column<string>(nullable: true),
                    TwoBedroomPlusApartment_Floor = table.Column<int>(nullable: true),
                    TwoBedroomPlusApartment_Area = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Identity_ContactId",
                table: "Identity",
                column: "ContactId",
                unique: true,
                filter: "[ContactId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ContactId",
                table: "Product",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Identity");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropSequence(
                name: "contact_hilo");

            migrationBuilder.DropSequence(
                name: "identity_hilo");

            migrationBuilder.DropSequence(
                name: "product_hilo");
        }
    }
}
