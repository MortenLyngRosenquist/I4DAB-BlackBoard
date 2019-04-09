using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackBoard.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseName = table.Column<string>(nullable: false),
                    CourseContentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseName);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    AUID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    EnrollmentDate = table.Column<DateTime>(nullable: false),
                    GraduationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.AUID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    AUID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.AUID);
                });

            migrationBuilder.CreateTable(
                name: "CourseContents",
                columns: table => new
                {
                    CourseContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseContents", x => x.CourseContentId);
                    table.ForeignKey(
                        name: "FK_CourseContents_Courses_CourseName",
                        column: x => x.CourseName,
                        principalTable: "Courses",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudents",
                columns: table => new
                {
                    CourseName = table.Column<string>(nullable: false),
                    StudentAUID = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudents", x => new { x.CourseName, x.StudentAUID });
                    table.ForeignKey(
                        name: "FK_CourseStudents_Courses_CourseName",
                        column: x => x.CourseName,
                        principalTable: "Courses",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseStudents_Students_StudentAUID",
                        column: x => x.StudentAUID,
                        principalTable: "Students",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HandinDeadline = table.Column<DateTime>(nullable: false),
                    Attempt = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    ParticipantsAllowed = table.Column<int>(nullable: false),
                    TeacherAUID = table.Column<int>(nullable: false),
                    CourseName = table.Column<string>(nullable: false),
                    StudentAUID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseName",
                        column: x => x.CourseName,
                        principalTable: "Courses",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Students_StudentAUID",
                        column: x => x.StudentAUID,
                        principalTable: "Students",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Teachers_TeacherAUID",
                        column: x => x.TeacherAUID,
                        principalTable: "Teachers",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    TeacherAUID = table.Column<int>(nullable: false),
                    CourseName = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => new { x.CourseName, x.TeacherAUID });
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseName",
                        column: x => x.CourseName,
                        principalTable: "Courses",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_TeacherAUID",
                        column: x => x.TeacherAUID,
                        principalTable: "Teachers",
                        principalColumn: "AUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    FolderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FolderName = table.Column<string>(nullable: false),
                    CourseContentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.FolderId);
                    table.ForeignKey(
                        name: "FK_Folders_CourseContents_CourseContentId",
                        column: x => x.CourseContentId,
                        principalTable: "CourseContents",
                        principalColumn: "CourseContentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentAreas",
                columns: table => new
                {
                    ContentAreaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TextBlock = table.Column<string>(nullable: true),
                    CourseContentId = table.Column<int>(nullable: false),
                    FolderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentAreas", x => x.ContentAreaId);
                    table.ForeignKey(
                        name: "FK_ContentAreas_CourseContents_CourseContentId",
                        column: x => x.CourseContentId,
                        principalTable: "CourseContents",
                        principalColumn: "CourseContentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentAreas_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "FolderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseName", "CourseContentId" },
                values: new object[,]
                {
                    { "F19-I4DAB", 0 },
                    { "F19-I4GUI", 0 },
                    { "F19-I4SWD", 0 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "AUID", "BirthDate", "EnrollmentDate", "GraduationDate", "Name" },
                values: new object[,]
                {
                    { 111111, new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morten" },
                    { 222222, new DateTime(1995, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andreas" },
                    { 333333, new DateTime(1996, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Troels" },
                    { 444444, new DateTime(1997, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frederik" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "AUID", "BirthDate", "Name" },
                values: new object[,]
                {
                    { 999999, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Henrik" },
                    { 888888, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poul" },
                    { 777777, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael" }
                });

            migrationBuilder.InsertData(
                table: "CourseContents",
                columns: new[] { "CourseContentId", "CourseName" },
                values: new object[,]
                {
                    { 1, "F19-I4DAB" },
                    { 2, "F19-I4GUI" },
                    { 3, "F19-I4SWD" }
                });

            migrationBuilder.InsertData(
                table: "CourseStudents",
                columns: new[] { "CourseName", "StudentAUID", "Grade", "Status" },
                values: new object[,]
                {
                    { "F19-I4SWD", 444444, 0, "Aktiv" },
                    { "F19-I4GUI", 444444, 0, "Aktiv" },
                    { "F19-I4DAB", 444444, 0, "Aktiv" },
                    { "F19-I4SWD", 333333, 0, "Aktiv" },
                    { "F19-I4GUI", 333333, 0, "Aktiv" },
                    { "F19-I4DAB", 333333, 0, "Aktiv" },
                    { "F19-I4GUI", 222222, 0, "Aktiv" },
                    { "F19-I4DAB", 222222, 0, "Aktiv" },
                    { "F19-I4SWD", 111111, 0, "Aktiv" },
                    { "F19-I4GUI", 111111, 0, "Aktiv" },
                    { "F19-I4DAB", 111111, 0, "Aktiv" },
                    { "F19-I4SWD", 222222, 0, "Aktiv" }
                });

            migrationBuilder.InsertData(
                table: "TeacherCourses",
                columns: new[] { "CourseName", "TeacherAUID", "Role" },
                values: new object[,]
                {
                    { "F19-I4GUI", 888888, "Primær" },
                    { "F19-I4DAB", 999999, "Primær" },
                    { "F19-I4SWD", 999999, "Primær" },
                    { "F19-I4SWD", 777777, "Primær" }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "FolderId", "CourseContentId", "FolderName" },
                values: new object[,]
                {
                    { 1, 1, "Assignments" },
                    { 2, 1, "0 Pre-Course" },
                    { 3, 1, "1.1 Introduction" },
                    { 4, 2, "Introduktion" },
                    { 5, 2, "Lektionsplan" },
                    { 6, 2, "01 Intro and .Net architecture" },
                    { 7, 3, "Week -1   : Optional: Self study of C#" },
                    { 8, 3, "Week 0    : Interfaces(Self-study)" },
                    { 9, 3, "Week 01.1 : Introduction to the course and agile software development" }
                });

            migrationBuilder.InsertData(
                table: "ContentAreas",
                columns: new[] { "ContentAreaId", "CourseContentId", "FolderId", "TextBlock" },
                values: new object[,]
                {
                    { -1, 1, 1, "1Random content text (1,1)" },
                    { -2, 1, 1, "2Random content text (1,1)" },
                    { -3, 1, 1, "3Random content text (1,1)" },
                    { -4, 1, 2, "Random content text (1,2)" },
                    { -5, 1, 3, "1Random content text (1,3)" },
                    { -6, 1, 3, "2Random content text (1,3)" },
                    { -7, 2, 4, "Random content text (2,4)" },
                    { -8, 2, 5, "1Random content text (2,5)" },
                    { -9, 2, 6, "2Random content text (2,6)" },
                    { -10, 3, 7, "Random content text (3,7)" },
                    { -11, 3, 8, "1Random content text (3,8)" },
                    { -12, 3, 9, "2Random content text (3,9)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseName",
                table: "Assignments",
                column: "CourseName");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_StudentAUID",
                table: "Assignments",
                column: "StudentAUID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherAUID",
                table: "Assignments",
                column: "TeacherAUID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentAreas_CourseContentId",
                table: "ContentAreas",
                column: "CourseContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentAreas_FolderId",
                table: "ContentAreas",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseContents_CourseName",
                table: "CourseContents",
                column: "CourseName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_StudentAUID",
                table: "CourseStudents",
                column: "StudentAUID");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_CourseContentId",
                table: "Folders",
                column: "CourseContentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_TeacherAUID",
                table: "TeacherCourses",
                column: "TeacherAUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "ContentAreas");

            migrationBuilder.DropTable(
                name: "CourseStudents");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "CourseContents");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
