using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSV1.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 2,
                column: "EnrollmentDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 3,
                column: "EnrollmentDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 3,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(4133));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 4,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 5,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 6,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 7,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(4152));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 8,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(4156));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 9,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 10,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 22, 24, 27, 676, DateTimeKind.Local).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b34399f4-0590-4633-8a14-76d545966ea5", "AQAAAAIAAYagAAAAEDhMkcj37yWulYU1MGoc/Mts+xIR9wJf6A2m7WLfhgno7NB8jQghjCdSCcQDT0IRMw==", "b0aae66f-0aa8-48d5-b7b7-40311def66ad" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bf70a71-9d7c-430b-aaaf-892f740033af", "AQAAAAIAAYagAAAAEOUQUhxsKe+3ptsRGkEsiBnVQyaj0GMK9BmHepvW9mB2jn/QzBxWRhl9ex8iYeKKbA==", "8dcdc12d-b390-42cb-acd0-02a4eb786c23" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cddcac2f-20f8-4919-9a91-42578abfe702", "AQAAAAIAAYagAAAAEPxbkyJHEB5FET0qbu4qp903CHKCjt9PE+r+KqccU8OXHx6sTm20v82dIESDOjeG4Q==", "2ede3b9c-a108-4eb3-b39a-9ae72750ab26" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "251aab2a-b165-44f8-99b3-371f880fd077", "AQAAAAIAAYagAAAAEPy/TAnJnyI3nRzv2WdMCV8Lz0uVTd6dOSiQ/bVmZgErVqgtU0XCdhnQv3muAkyqQQ==", "219f4b7b-bca2-44e6-a02d-0cb771e964b4" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2bac67d-ecd0-4ef4-a404-425c8d77b67d", "AQAAAAIAAYagAAAAEFTMJGLTnEBViF/e8QYvRlinp1ofzx83IMVRHssusc/Vx0aZETVRPtR8zrdHVt9/Fw==", "427fe218-b184-4a75-b6e8-383a2dd1aa4f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 2,
                column: "EnrollmentDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Enrollment",
                keyColumn: "EnrollmentID",
                keyValue: 3,
                column: "EnrollmentDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 1,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 2,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(2263));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 3,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 4,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(2268));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 5,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 6,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 7,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 8,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 9,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Submission",
                keyColumn: "SubmissionID",
                keyValue: 10,
                column: "SubmissionDate",
                value: new DateTime(2023, 11, 15, 9, 37, 35, 485, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1379b280-e9c2-4967-84a4-893dc67bd246", "AQAAAAIAAYagAAAAEMNLuDobDab/FTFvucQBWUdPjmQPzPApmqzVOxfNiwMfQKPzmYWaxeebLhTJDGtelg==", "d8154887-2aa9-4693-bcfe-07b18259d5e4" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26660ef9-a205-43c9-99ec-80701a0647ac", "AQAAAAIAAYagAAAAEFBj0A+Bh+pk5AKjOW+3wt/QY6pWgz9JaiPdAbOcwnNVnYWY8+g/6hnImrl3liuCMA==", "d098e732-b3c0-4797-9c23-bc17b17f8b99" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84ff7fa9-c14e-4f33-a144-87dfd3349d40", "AQAAAAIAAYagAAAAENB/DkgvfpjZGiK44030RPSt5vxRmG0XOtsZkHbR/OuXXDnx3WoJx2omBBPP94mNeg==", "8b0f8023-a9fe-4ef4-8a63-5ea21f81713c" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf1f6357-6968-4e52-9b9c-8343cea3f97f", "AQAAAAIAAYagAAAAEJDTvGcqyyeXxpPd7DHpO+3uGzg0CF0BldYi1Ia0WafgRQLDpo4ythAmTZ0ynrf42w==", "b2127f17-ddfd-4dab-ba82-d2ec4929231c" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea1c20e5-e369-4785-8cbe-f64883f0dc58", "AQAAAAIAAYagAAAAENwgeYyid6jf1LSIu9lOa0pLHN7HUdRX5C5oMZ7EV8DEUZ2mw14Q+xklzGQEqozluA==", "5209dc5c-3fa9-4aee-a618-ea35e16bfb91" });
        }
    }
}
