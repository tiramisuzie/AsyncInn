using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class anotherDataFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenity",
                table: "RoomAmenity");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenity_AmenitiesID",
                table: "RoomAmenity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.DropColumn(
                name: "AmenityID",
                table: "RoomAmenity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenity",
                table: "RoomAmenity",
                columns: new[] { "AmenitiesID", "RoomID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenity_RoomID",
                table: "RoomAmenity",
                column: "RoomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenity",
                table: "RoomAmenity");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenity_RoomID",
                table: "RoomAmenity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms");

            migrationBuilder.AddColumn<int>(
                name: "AmenityID",
                table: "RoomAmenity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenity",
                table: "RoomAmenity",
                columns: new[] { "RoomID", "AmenityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelRooms",
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomID" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenity_AmenitiesID",
                table: "RoomAmenity",
                column: "AmenitiesID");
        }
    }
}
