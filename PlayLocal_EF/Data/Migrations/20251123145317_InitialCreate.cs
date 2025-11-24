using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayLocal_EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerID);
                });

            migrationBuilder.CreateTable(
                name: "SportsTypes",
                columns: table => new
                {
                    SportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsTypes", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    GoogleMapsLink = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    MainContactPhone = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    HasEquipmentRental = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    OpenTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    CloseTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    CloseDay = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    OwnerID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueID);
                    table.ForeignKey(
                        name: "FK_Venues_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "OwnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    CourtID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PricePerHour = table.Column<decimal>(type: "money", nullable: false),
                    Is_Available = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Environment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surface = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    VenueID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.CourtID);
                    table.ForeignKey(
                        name: "FK_Courts_Venues_VenueID",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "VenueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueServices",
                columns: table => new
                {
                    ServiceID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    VenueID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueServices", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_VenueServices_Venues_VenueID",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "VenueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourtPhotos",
                columns: table => new
                {
                    PhotoID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CourtID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtPhotos", x => x.PhotoID);
                    table.ForeignKey(
                        name: "FK_CourtPhotos_Courts_CourtID",
                        column: x => x.CourtID,
                        principalTable: "Courts",
                        principalColumn: "CourtID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourtSports",
                columns: table => new
                {
                    CourtsCourtID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SportsTypesSportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtSports", x => new { x.CourtsCourtID, x.SportsTypesSportId });
                    table.ForeignKey(
                        name: "FK_CourtSports_Courts_CourtsCourtID",
                        column: x => x.CourtsCourtID,
                        principalTable: "Courts",
                        principalColumn: "CourtID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourtSports_SportsTypes_SportsTypesSportId",
                        column: x => x.SportsTypesSportId,
                        principalTable: "SportsTypes",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourtPhotos_CourtID",
                table: "CourtPhotos",
                column: "CourtID");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_VenueID",
                table: "Courts",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_CourtSports_SportsTypesSportId",
                table: "CourtSports",
                column: "SportsTypesSportId");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_OwnerID",
                table: "Venues",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_VenueServices_VenueID",
                table: "VenueServices",
                column: "VenueID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourtPhotos");

            migrationBuilder.DropTable(
                name: "CourtSports");

            migrationBuilder.DropTable(
                name: "VenueServices");

            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "SportsTypes");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
