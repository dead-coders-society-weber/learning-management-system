using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSV1.Migrations
{
    /// <inheritdoc />
    public partial class update_assignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubmissionType",
                table: "Assignment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2023, 10, 11, 21, 16, 54, 194, DateTimeKind.Local).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2141e74c-6fac-462f-a815-621d58306e2a", "AQAAAAIAAYagAAAAENr6YtEvRw06yi69IbUZCB8u1mqw/sRdHhD/u3RWovodS5Kvp4fymWU+RnSwa38SPw==", "60281203-a040-4d10-9e8f-d4e3f1c63f3f" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64a257c7-7464-4961-9bed-13075348b65b", "AQAAAAIAAYagAAAAEK1YyJc9CXMo/1EGWLt9VbiYmpY9nQpHHSfR3mMRO6uYg3HMoPqJQqqO4wMhrP442Q==", "5e674265-5987-4b3c-ba45-19d4ee974992" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmissionType",
                table: "Assignment");

            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2023, 10, 11, 17, 59, 1, 701, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "796164b2-eb3b-46e7-b793-8864ee6dcb3b", "AQAAAAIAAYagAAAAEDILKW+0g5i1kgKS4+herPyShCCW3og9iUpzP8yB6HXjeQ8Z5gp8mxyRxM3R27KZhA==", "194805ee-f799-4cd3-9019-212aa9e6de69" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9855fa45-10ee-4112-9e68-fc1be713932e", "AQAAAAIAAYagAAAAELs7iUpUGigBHJT3NLBZyUpxT4Hg95KhncKMbkvCIAyt0GmnE+CsWTQefK++/DlT9w==", "445feaa5-085a-4962-b1ea-7dc3d0db8be8" });
        }
    }
}
