using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMSV1.Migrations
{
    /// <inheritdoc />
    public partial class _9232023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "0a6646d4-fa56-4512-8bfa-5cd0c62240ac");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1bcd7cd9-e6ca-43be-83e7-a844ab12f3c8");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "6a575023-22d1-444d-b4be-bb40022a09ef");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8bbb03b3-cfe1-4900-ae61-479ebabc5c9b");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d52cdbb4-b8d0-4e5d-a10c-397a78700016", "8d71a39a-99c8-4637-8372-d3d501ca371b" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "254db178-db08-4c31-875e-ceed0fd3e820", "fcabe186-153f-48e2-9faa-00e4dae84fbb" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "254db178-db08-4c31-875e-ceed0fd3e820");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "d52cdbb4-b8d0-4e5d-a10c-397a78700016");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8d71a39a-99c8-4637-8372-d3d501ca371b");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "fcabe186-153f-48e2-9faa-00e4dae84fbb");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40dfd555-a1d0-4bd0-8b26-c37eb358fee6", null, "Instructor", null },
                    { "5009f788-07d4-4471-8ddb-a6b4e173833d", null, "Instructor", null },
                    { "509130d4-46a3-45ac-a31f-4188172a9a7a", null, "Student", null },
                    { "fb7d8fbe-3fb9-41fc-9fb0-79060c91fb2e", null, "Student", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address1", "Address2", "Birthdate", "City", "Email", "FirstName", "LastName", "Link1", "Link2", "Link3", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "ProfileImage", "Role", "State", "UserName", "Zip" },
                values: new object[,]
                {
                    { "18a6041c-c9ab-4eff-a611-eaa636eb5139", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "student@email.com", "first", "last", null, null, null, null, null, "Student123!", null, null, "Student", null, null, null },
                    { "1bc9f6d4-8c68-4bb4-81df-3683030e9d4b", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "student@email.com", "first", "last", null, null, null, null, null, "Student123!", null, null, "Student", null, null, null },
                    { "48947c6f-6589-462a-827b-d3c991e6eee0", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "instructor@email.com", "first", "last", null, null, null, null, null, "Instructor123!", null, null, "Instructor", null, null, null },
                    { "a6ab736a-da7e-46fa-b692-2d42d579fadc", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "instructor@email.com", "first", "last", null, null, null, null, null, "Instructor123!", null, null, "Instructor", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "509130d4-46a3-45ac-a31f-4188172a9a7a", "1bc9f6d4-8c68-4bb4-81df-3683030e9d4b" },
                    { "40dfd555-a1d0-4bd0-8b26-c37eb358fee6", "48947c6f-6589-462a-827b-d3c991e6eee0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "5009f788-07d4-4471-8ddb-a6b4e173833d");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "fb7d8fbe-3fb9-41fc-9fb0-79060c91fb2e");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "18a6041c-c9ab-4eff-a611-eaa636eb5139");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "a6ab736a-da7e-46fa-b692-2d42d579fadc");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "509130d4-46a3-45ac-a31f-4188172a9a7a", "1bc9f6d4-8c68-4bb4-81df-3683030e9d4b" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "40dfd555-a1d0-4bd0-8b26-c37eb358fee6", "48947c6f-6589-462a-827b-d3c991e6eee0" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "40dfd555-a1d0-4bd0-8b26-c37eb358fee6");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "509130d4-46a3-45ac-a31f-4188172a9a7a");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1bc9f6d4-8c68-4bb4-81df-3683030e9d4b");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "48947c6f-6589-462a-827b-d3c991e6eee0");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a6646d4-fa56-4512-8bfa-5cd0c62240ac", null, "Student", null },
                    { "1bcd7cd9-e6ca-43be-83e7-a844ab12f3c8", null, "Instructor", null },
                    { "254db178-db08-4c31-875e-ceed0fd3e820", null, "Instructor", null },
                    { "d52cdbb4-b8d0-4e5d-a10c-397a78700016", null, "Student", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address1", "Address2", "Birthdate", "City", "Email", "FirstName", "LastName", "Link1", "Link2", "Link3", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "ProfileImage", "Role", "State", "UserName", "Zip" },
                values: new object[,]
                {
                    { "6a575023-22d1-444d-b4be-bb40022a09ef", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "student@email.com", "first", "last", null, null, null, null, null, "Student123!", null, null, "Student", null, null, null },
                    { "8bbb03b3-cfe1-4900-ae61-479ebabc5c9b", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "instructor@email.com", "first", "last", null, null, null, null, null, "Instructor123!", null, null, "Instructor", null, null, null },
                    { "8d71a39a-99c8-4637-8372-d3d501ca371b", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "student@email.com", "first", "last", null, null, null, null, null, "Student123!", null, null, "Student", null, null, null },
                    { "fcabe186-153f-48e2-9faa-00e4dae84fbb", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "instructor@email.com", "first", "last", null, null, null, null, null, "Instructor123!", null, null, "Instructor", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d52cdbb4-b8d0-4e5d-a10c-397a78700016", "8d71a39a-99c8-4637-8372-d3d501ca371b" },
                    { "254db178-db08-4c31-875e-ceed0fd3e820", "fcabe186-153f-48e2-9faa-00e4dae84fbb" }
                });
        }
    }
}
