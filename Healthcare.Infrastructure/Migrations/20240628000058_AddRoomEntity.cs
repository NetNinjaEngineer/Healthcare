using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Healthcare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalDepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailabilityStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_MedicalDepartments_MedicalDepartmentId",
                        column: x => x.MedicalDepartmentId,
                        principalTable: "MedicalDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_MedicalDepartmentId",
                table: "Rooms",
                column: "MedicalDepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
