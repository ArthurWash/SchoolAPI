using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseSections",
                columns: table => new
                {
                    CourseSectionID = table.Column<Guid>(nullable: false),
                    CourseID = table.Column<string>(maxLength: 10, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSections", x => x.CourseSectionID);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    CourseManagementID = table.Column<Guid>(nullable: false),
                    CourseTitle = table.Column<string>(maxLength: 60, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.CourseManagementID);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentID = table.Column<Guid>(nullable: false),
                    AssignmentTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CourseSectionID = table.Column<Guid>(nullable: false),
                    CourseID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_Assignments_CourseSections_CourseSectionID",
                        column: x => x.CourseSectionID,
                        principalTable: "CourseSections",
                        principalColumn: "CourseSectionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    SystemRoleID = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    SectionEnrollmentManagementId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "SectionEnrollment",
                columns: table => new
                {
                    SectionEnrollmentID = table.Column<Guid>(nullable: false),
                    SectionID = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionEnrollment", x => x.SectionEnrollmentID);
                    table.ForeignKey(
                        name: "FK_SectionEnrollment_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CourseSections",
                columns: new[] { "CourseSectionID", "CourseID", "CreatedDate", "EndDate", "StartDate", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479814"), "IS690", new DateTime(2021, 7, 13, 18, 19, 26, 879, DateTimeKind.Local).AddTicks(5549), new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 13, 18, 19, 26, 879, DateTimeKind.Local).AddTicks(6087) },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479815"), "IS601", new DateTime(2021, 7, 13, 18, 19, 26, 879, DateTimeKind.Local).AddTicks(6815), new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 13, 18, 19, 26, 879, DateTimeKind.Local).AddTicks(6843) }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "CourseManagementID", "CourseTitle", "CreatedDate", "Description", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479812"), "Web Services and Middleware", new DateTime(2021, 7, 13, 18, 19, 26, 874, DateTimeKind.Local).AddTicks(9882), "Web services enable integration of web-based applications and feature sets to any other web-based system in a modular way. Middleware is a set of functionality positioned in between and enabling interoperability among different, distributed enterprise and other computing applications. This course provides an introduction to web services and middleware in the context of digital libraries - large scale multimedia information repositories. Students will gain hands on experience in developing their own web services managing a complex distributed computing platform.", new DateTime(2021, 7, 13, 18, 19, 26, 875, DateTimeKind.Local).AddTicks(558) },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479813"), "Web Systems Development", new DateTime(2021, 7, 13, 18, 19, 26, 875, DateTimeKind.Local).AddTicks(1201), "Students will gain experience in open source web development through an intensive hands-on project, applying real-world problem-solving skills to meeting information systems requirements. Students will learn Web development principles, as well as professionally relevant skills including industry standards, conventions, and procedures within large-scale programming projects. Also covered are the communication tools, technologies, and practices that individuals use to coordinate and collaborate within the open source software development community.", new DateTime(2021, 7, 13, 18, 19, 26, 875, DateTimeKind.Local).AddTicks(1230) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedDate", "Email", "SectionEnrollmentManagementId", "Status", "SystemRoleID", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new DateTime(2021, 7, 13, 18, 19, 26, 880, DateTimeKind.Local).AddTicks(5269), "ajw53@njit.edu", null, true, "student", new DateTime(2021, 7, 13, 18, 19, 26, 880, DateTimeKind.Local).AddTicks(5762), "awash" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new DateTime(2021, 7, 13, 18, 19, 26, 880, DateTimeKind.Local).AddTicks(6290), "tjhupchick24@njit.edu", null, false, "student", new DateTime(2021, 7, 13, 18, 19, 26, 880, DateTimeKind.Local).AddTicks(6319), "thupchick" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2021, 7, 13, 18, 19, 26, 880, DateTimeKind.Local).AddTicks(6339), "keith.a.williams@njit.edu", null, true, "profesor", new DateTime(2021, 7, 13, 18, 19, 26, 880, DateTimeKind.Local).AddTicks(6344), "kwilliams" }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentID", "AssignmentTitle", "CourseID", "CourseSectionID", "Description" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479816"), "Module 1", "IS690", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479814"), "Create a website that can receive user input" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479830"), "Module 1", "IS601", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479815"), "Create a website that can receive user input" }
                });

            migrationBuilder.InsertData(
                table: "SectionEnrollment",
                columns: new[] { "SectionEnrollmentID", "CreatedDate", "EndDate", "SectionID", "StartDate", "UpdatedDate", "UserID", "UserName" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479820"), new DateTime(2021, 7, 13, 18, 19, 26, 881, DateTimeKind.Local).AddTicks(4370), new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "IS690-001", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 13, 18, 19, 26, 881, DateTimeKind.Local).AddTicks(4823), new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "awash" },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479821"), new DateTime(2021, 7, 13, 18, 19, 26, 881, DateTimeKind.Local).AddTicks(6255), new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "IS601-001", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 13, 18, 19, 26, 881, DateTimeKind.Local).AddTicks(6285), new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "thupchick" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseSectionID",
                table: "Assignments",
                column: "CourseSectionID");

            migrationBuilder.CreateIndex(
                name: "IX_SectionEnrollment_UserID",
                table: "SectionEnrollment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SectionEnrollmentManagementId",
                table: "Users",
                column: "SectionEnrollmentManagementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SectionEnrollment_SectionEnrollmentManagementId",
                table: "Users",
                column: "SectionEnrollmentManagementId",
                principalTable: "SectionEnrollment",
                principalColumn: "SectionEnrollmentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SectionEnrollment_Users_UserID",
                table: "SectionEnrollment");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "CourseSections");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SectionEnrollment");
        }
    }
}
