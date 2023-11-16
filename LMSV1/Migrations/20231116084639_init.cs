using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMSV1.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuitionAmount = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetDays = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DepartmentID = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_User_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MaxPoints = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmissionType = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_Assignment_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradePercentage = table.Column<double>(type: "float", nullable: true),
                    PointsEarned = table.Column<double>(type: "float", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_User_StudentID",
                        column: x => x.StudentID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event = table.Column<int>(type: "int", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notification_Assignment_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_User_StudentID",
                        column: x => x.StudentID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Submission",
                columns: table => new
                {
                    SubmissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextSubmission = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Score = table.Column<double>(type: "float", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submission", x => x.SubmissionID);
                    table.ForeignKey(
                        name: "FK_Submission_Assignment_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentID");
                    table.ForeignKey(
                        name: "FK_Submission_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentID", "Name" },
                values: new object[,]
                {
                    { "ART", "Art" },
                    { "CS", "Computer Science" },
                    { "ENGL", "English" },
                    { "HIST", "History" },
                    { "MATH", "Mathematics" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Instructor", "INSTRUCTOR" },
                    { 2, null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address1", "Address2", "Birthdate", "City", "ConcurrencyStamp", "Email", "FirstName", "LastName", "Link1", "Link2", "Link3", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "ProfileImage", "Role", "SecurityStamp", "State", "TuitionAmount", "UserName", "Zip" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "940e7512-e234-4abe-a24d-02c716998a8e", "Instructor1@gmail.com", "John", "Doe", null, null, null, "INSTRUCTOR1@GMAIL.COM", "INSTRUCTOR1@GMAIL.COM", "Abc123!", "AQAAAAIAAYagAAAAEKH/hEeHSxspvKtCYSXFDlCwALnZA2WhTLfxh1f1uffqHMWRZVTnAKdBHYbfb/VZaw==", "/Uploads/stock-profile-image.jpg", "Instructor", "413673e0-f445-4035-958f-6659dff20dad", null, 0L, "Instructor1@gmail.com", null },
                    { 2, null, null, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "a5c57a8b-e126-41b6-9083-bbe3ff2e3a57", "Student1@gmail.com", "John", "Doe", null, null, null, "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "Abc123!", "AQAAAAIAAYagAAAAEPzR/ZIR7/iZbfqCKPvlA0qoHHzHzFGx/YBeyvTgeVjwKi8dQ2Um4SlN3W3+bkWeXQ==", "/Uploads/stock-profile-image.jpg", "Student", "49db656d-05ff-469d-9911-c6c76045718d", null, 400L, "Student1@gmail.com", null },
                    { 3, null, null, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "e300078a-e30d-4451-9161-21e946a801f0", "Instructor2@gmail.com", "John2", "Doe", null, null, null, "INSTRUCTOR2@GMAIL.COM", "INSTRUCTOR2@GMAIL.COM", "Abc123!", "AQAAAAIAAYagAAAAEOZAKX7d0tJHYlrl5ZnmxFtSpkU+JOikoxHGFrpsw1030hQbvdR4p5VWfS0/PZPzJQ==", "/Uploads/stock-profile-image.jpg", "Instructor", "0124c336-4e59-4740-bda3-e53851559940", null, 0L, "Instructor2@gmail.com", null },
                    { 4, null, null, new DateTime(1995, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "9bf8bd34-aab8-41d5-8a69-59074cbfd544", "Student4@gmail.com", "Jane", "Doe", null, null, null, "STUDENT4@GMAIL.COM", "STUDENT4@GMAIL.COM", "Abc123!", "AQAAAAIAAYagAAAAEKXJFcgjzuB3tLsNHsr+GLnW3TpDwPrODAPE8ps/YcITU19GfNNwgBoFhmDjFPDxxg==", "/Uploads/stock-profile-image.jpg", "Student", "12052076-57cb-490d-80ee-5834cb422130", null, 400L, "Student4@gmail.com", null },
                    { 5, null, null, new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "e30a94f1-3064-4264-87dd-4e37aa00d37b", "Student5@gmail.com", "Johnathan", "Doe", null, null, null, "STUDENT5@GMAIL.COM", "STUDENT5@GMAIL.COM", "Abc123!", "AQAAAAIAAYagAAAAEPJodxZTIb3hZHv4w6O/rfgDTfhaXii7kTD1c9YKCVmBtxBx+Xr71PbZba3aDQPTOg==", "/Uploads/stock-profile-image.jpg", "Student", "5b0c045e-d136-4456-bf4b-c9e4e2dc5352", null, 400L, "Student5@gmail.com", null }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseID", "Credits", "DepartmentID", "EndTime", "InstructorID", "Location", "MeetDays", "StartTime", "Title" },
                values: new object[,]
                {
                    { 3750, 4, "CS", new TimeSpan(0, 11, 0, 0, 0), 1, "Weber NB - 324", 5, new TimeSpan(0, 9, 0, 0, 0), "Software Development II" },
                    { 3775, 3, "HIST", new TimeSpan(0, 14, 30, 0, 0), 1, "History Hall - 330", 10, new TimeSpan(0, 13, 0, 0, 0), "Modern World History" },
                    { 4020, 3, "ENGL", new TimeSpan(0, 11, 0, 0, 0), 3, "Literature Dept - 210", 20, new TimeSpan(0, 9, 30, 0, 0), "Shakespearean Literature" },
                    { 4550, 4, "ART", new TimeSpan(0, 17, 0, 0, 0), 3, "Art Studio - 120", 9, new TimeSpan(0, 15, 0, 0, 0), "Contemporary Art Practices" },
                    { 4801, 3, "CS", new TimeSpan(0, 15, 30, 0, 0), 3, "Tech Hall - 101", 10, new TimeSpan(0, 14, 0, 0, 0), "Advanced Algorithms" },
                    { 5302, 4, "MATH", new TimeSpan(0, 11, 15, 0, 0), 1, "Math Building - 205", 21, new TimeSpan(0, 10, 0, 0, 0), "Linear Algebra" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "AssignmentID", "CourseID", "Description", "DueDate", "MaxPoints", "SubmissionType", "Title" },
                values: new object[,]
                {
                    { 1, 3750, "This is a File Upload assignment test that is turned in and graded.", new DateTime(2023, 11, 3, 23, 59, 59, 0, DateTimeKind.Unspecified), 100, 0, "File Assignment 1" },
                    { 2, 3750, "This is a Text entry assignment test that is turned in and graded.", new DateTime(2023, 11, 5, 23, 59, 59, 0, DateTimeKind.Unspecified), 100, 1, "Text Assignment 1" },
                    { 3, 3750, "This is an assignment that is past due, but one student has no submission.", new DateTime(2023, 11, 8, 23, 59, 59, 0, DateTimeKind.Unspecified), 100, 0, "File Assignment 2" },
                    { 4, 3750, "This is an assignment that is past due, but one student has no submission.", new DateTime(2023, 11, 8, 23, 59, 59, 0, DateTimeKind.Unspecified), 100, 1, "Text Assignment 2" },
                    { 5, 3750, "This is an assignment that needs a File Upload and is not yet due.", new DateTime(2023, 11, 17, 23, 59, 59, 0, DateTimeKind.Unspecified), 200, 0, "File Assignment 3" },
                    { 6, 3750, "This is an assignment that needs a Text entry and is not yet due.", new DateTime(2023, 11, 29, 23, 59, 59, 0, DateTimeKind.Unspecified), 150, 1, "Text Assignment 3" }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "EnrollmentID", "CourseID", "EnrollmentDate", "Grade", "GradePercentage", "PointsEarned", "StudentID" },
                values: new object[,]
                {
                    { 1, 3750, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(2193), "A+", 100.0, 400.0, 2 },
                    { 2, 3750, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(2226), "C+", 78.799999999999997, 315.0, 4 },
                    { 3, 3750, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(2227), "E", 18.800000000000001, 75.0, 5 }
                });

            migrationBuilder.InsertData(
                table: "Submission",
                columns: new[] { "SubmissionID", "AssignmentID", "FileName", "Score", "SubmissionDate", "TextSubmission", "UserID" },
                values: new object[,]
                {
                    { 1, 1, "2_test submission.txt", 100.0, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(3399), null, 2 },
                    { 2, 1, "4_test submission.txt", 75.0, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(3411), null, 4 },
                    { 3, 1, "5_test submission.txt", 25.0, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(3413), null, 5 },
                    { 4, 3, "2_test submission2.txt", 100.0, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(3416), null, 2 },
                    { 5, 3, "4_test submission2.txt", 75.0, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(3418), null, 4 },
                    { 6, 2, null, 100.0, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(3421), "Here is some text.", 2 },
                    { 7, 2, null, 90.0, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(3422), "Here is some text.", 4 },
                    { 8, 2, null, 50.0, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(3424), "Here is some text.", 5 },
                    { 9, 4, null, 100.0, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(3426), "Here is some text.", 2 },
                    { 10, 4, null, 75.0, new DateTime(2023, 11, 16, 1, 46, 39, 759, DateTimeKind.Local).AddTicks(3428), "Here is some text.", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_CourseID",
                table: "Assignment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_InstructorID",
                table: "Course",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_AssignmentID",
                table: "Notification",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_StudentID",
                table: "Notification",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_AssignmentID",
                table: "Submission",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_UserID",
                table: "Submission",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Submission");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
