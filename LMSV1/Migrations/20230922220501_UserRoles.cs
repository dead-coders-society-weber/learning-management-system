using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMSV1.Migrations
{
    /// <inheritdoc />
    public partial class UserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f6ee5d4-3ef0-40b1-ba0b-e16cb47363b2", null, "Instructor", null },
                    { "5634f105-3c18-41b3-bfa4-875b22989796", null, "Instructor", null },
                    { "8d47c07f-8da5-42b4-9267-b389fdf9f514", null, "Student", null },
                    { "ae4922d8-50e9-4ee9-b0cc-df19eff929c0", null, "Student", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address1", "Address2", "Birthdate", "City", "Email", "FirstName", "LastName", "Link1", "Link2", "Link3", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "ProfileImage", "Role", "State", "UserName", "Zip" },
                values: new object[,]
                {
                    { "4ada56bf-9a34-4fb0-b452-f0cbd7831be1", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "student@email.com", "first", "last", null, null, null, null, null, "Student123!", null, null, "Student", null, null, null },
                    { "9e443383-1fae-4588-a234-0425f36aff3a", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "student@email.com", "first", "last", null, null, null, null, null, "Student123!", null, null, "Student", null, null, null },
                    { "b767c71b-f16a-4ed5-83af-eef426873945", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "instructor@email.com", "first", "last", null, null, null, null, null, "Instructor123!", null, null, "Instructor", null, null, null },
                    { "e9894624-1c27-4480-9dac-fb6cfd0c54e9", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "instructor@email.com", "first", "last", null, null, null, null, null, "Instructor123!", null, null, "Instructor", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8d47c07f-8da5-42b4-9267-b389fdf9f514", "4ada56bf-9a34-4fb0-b452-f0cbd7831be1" },
                    { "1f6ee5d4-3ef0-40b1-ba0b-e16cb47363b2", "e9894624-1c27-4480-9dac-fb6cfd0c54e9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "5634f105-3c18-41b3-bfa4-875b22989796");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ae4922d8-50e9-4ee9-b0cc-df19eff929c0");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "9e443383-1fae-4588-a234-0425f36aff3a");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "b767c71b-f16a-4ed5-83af-eef426873945");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d47c07f-8da5-42b4-9267-b389fdf9f514", "4ada56bf-9a34-4fb0-b452-f0cbd7831be1" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1f6ee5d4-3ef0-40b1-ba0b-e16cb47363b2", "e9894624-1c27-4480-9dac-fb6cfd0c54e9" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1f6ee5d4-3ef0-40b1-ba0b-e16cb47363b2");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8d47c07f-8da5-42b4-9267-b389fdf9f514");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "4ada56bf-9a34-4fb0-b452-f0cbd7831be1");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "e9894624-1c27-4480-9dac-fb6cfd0c54e9");

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
    }
}
