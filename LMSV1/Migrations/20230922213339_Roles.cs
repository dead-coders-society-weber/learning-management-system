using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMSV1.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2222b869-9279-4a28-8c57-e88f73714e8d", null, "Student", null },
                    { "441de333-1ac1-488c-b8bb-bb1a743a9e7f", null, "Instructor", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address1", "Address2", "Birthdate", "City", "Email", "FirstName", "LastName", "Link1", "Link2", "Link3", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "ProfileImage", "Role", "State", "UserName", "Zip" },
                values: new object[,]
                {
                    { "27ca3aad-3448-4a7d-952a-582a3f90e6fd", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "instructor@email.com", "first", "last", null, null, null, null, null, "Instructor123!", null, null, "Instructor", null, null, null },
                    { "3cdf3458-6516-4c22-b481-6eb89c87d0a7", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "student@email.com", "first", "last", null, null, null, null, null, "Student123!", null, null, "Student", null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "2222b869-9279-4a28-8c57-e88f73714e8d");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "441de333-1ac1-488c-b8bb-bb1a743a9e7f");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "27ca3aad-3448-4a7d-952a-582a3f90e6fd");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "3cdf3458-6516-4c22-b481-6eb89c87d0a7");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
