using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSV1.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 2,
                column: "EnrollmentDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 3,
                column: "EnrollmentDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 3,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(8996));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 4,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 5,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 6,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 7,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 8,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 9,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(9017));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 10,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 56, 20, 52, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbb5375a-80b2-49af-b709-95da46086a74", "AQAAAAIAAYagAAAAEOtDe0+k/qI6IvQ0D9FmGjBH1V4h255fIBCMSSVQDigMxcap46WB2VR6ovUjvo0mPw==", "5b886244-6dd3-47b1-9bfc-828e3c4faa87" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af68ff6b-1b08-4a0c-ab07-8a0b5147c5f7", "AQAAAAIAAYagAAAAENbgiNNNEh2ZL+bJuZNe2wxobW3eDnXImE7a32hXqe1xTh7Ih8pfqcDPxuFrWpTA6w==", "678613f4-27ed-4643-a705-7f661c470059" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43d21b89-c1f7-4f4f-9ddf-11435d67bcde", "AQAAAAIAAYagAAAAELNcZIitZeGmA+WzAOsZm83HeK/ZbW+rBnlMZkXdY29bDC3mSeEfz2LH8LQYJY++Rw==", "be336854-e2cc-4ca9-bd7e-3c3f0fa3d0b9" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e632fcea-9515-4d8e-a707-986e2d916d18", "AQAAAAIAAYagAAAAEPWgDxIiaowJfGFsyuwxR7gtl3I11Z4mGoOG93paBtTZfzBCHLldWaCxPWDivgfx3g==", "c9c54ddd-dce4-40c7-82c0-2a1311033b77" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9fbb1896-83df-4b2f-bb91-9a0ec9384a6a", "AQAAAAIAAYagAAAAELGv+bRdgXVfmZYaSv2+zLOhHUuDLK96NvgG76duyGaj2gooarEsTLNuqssTBQrZww==", "7a3871fb-a5b0-43e9-93e4-2f72661cb97b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(3700));

            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 2,
                column: "EnrollmentDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 3,
                column: "EnrollmentDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(5024));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(5035));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 3,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 4,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 5,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 6,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 7,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 8,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(5065));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 9,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 10,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 14, 21, 23, 41, 919, DateTimeKind.Local).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15be1cdd-203b-4bf9-bec7-461b8933103d", "AQAAAAIAAYagAAAAEHNlS+DRqXKgPH4CgKow+DO9nsH01UD/Div+T8vTUNx9pQmJnE7YVqDQCt2j3Cwv7w==", "37458cf7-5ee1-4197-b8b7-afb726c203df" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2822b6e9-3fa9-479d-9c8d-a8dbf5cfbc65", "AQAAAAIAAYagAAAAEDFOjlIX5WcHFT5flqsfZkRFKuq0pL5K0G3kVWaT59j7V7KzDzdwKXGrs/6snc2WCA==", "708f47d3-80fd-48d1-b5f3-ad2367315069" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2cc6c7d-c258-4551-9326-46f93f674e71", "AQAAAAIAAYagAAAAEHH9BErObyxIZYOrsn8/va7Cgi/j1UMyewGVfEzi6HATlXaMhmAbJFWMxUHYEGxafg==", "310e45c4-e4b9-4239-8836-d20e19cdc48d" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d96451e-b2b1-4c42-9d2d-0f0b2396f57a", "AQAAAAIAAYagAAAAEM/3tKsrtEFhtStM1sb6wBint5FLoQmOkHtvC9qMnnCphwy3IMHpgawTt+cT15KXoQ==", "f756aca9-4d13-4365-b183-eb4de8529462" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b86ef5d8-a330-48ee-8784-14bf5351c2f1", "AQAAAAIAAYagAAAAEFYZDB+Z3E9u9xv6Tuv0A5CZiowBcYqVBGgKGli7TTk9PxhUrEAxXSD408wMCyox/g==", "928b0e46-f600-489e-b0ce-66018feecff5" });
        }
    }
}
