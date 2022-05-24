using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShipmentAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shipments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pickup_point_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pickup_shipper_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pickup_shipper_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_shipper_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delivery_shipper_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pickup_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivery_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "commodities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ShipmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commodities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_commodities_shipments_ShipmentID",
                        column: x => x.ShipmentID,
                        principalTable: "shipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_commodities_ShipmentID",
                table: "commodities",
                column: "ShipmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commodities");

            migrationBuilder.DropTable(
                name: "shipments");
        }
    }
}
