using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSV1.Migrations
{
    /// <inheritdoc />
    public partial class UserRolesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Instructor",
                table: "User",
                newName: "Role");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "User",
                newName: "Instructor");
        }
    }
}
