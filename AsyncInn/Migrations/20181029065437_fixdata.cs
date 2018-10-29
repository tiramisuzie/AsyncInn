using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class fixdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenity_Amenity_AmenityID",
                table: "RoomAmenity");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenity_AmenityID",
                table: "RoomAmenity");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenity_AmenitiesID",
                table: "RoomAmenity",
                column: "AmenitiesID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenity_Amenity_AmenitiesID",
                table: "RoomAmenity",
                column: "AmenitiesID",
                principalTable: "Amenity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenity_Amenity_AmenitiesID",
                table: "RoomAmenity");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenity_AmenitiesID",
                table: "RoomAmenity");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenity_AmenityID",
                table: "RoomAmenity",
                column: "AmenityID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenity_Amenity_AmenityID",
                table: "RoomAmenity",
                column: "AmenityID",
                principalTable: "Amenity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
