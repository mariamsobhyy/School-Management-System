using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "Capacity", "GradeLevel", "Name" },
                values: new object[,]
                {
                    { 1, 30, 10, "Class A" },
                    { 2, 25, 11, "Class B" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Computer Science Department", "Computer Science" },
                    { 2, "Mathematics Department", "Mathematics" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassRoomId", "DateOfBirth", "Email", "FristName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2009, 5, 15), "mariam@student.com", "Mariam", "Mohamed", "01212345678" },
                    { 2, 2, new DateOnly(2008, 8, 20), "omar@student.com", "Omar", "Ahmed", "01098765432" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "DepartmentId", "Email", "FristName", "LastName", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "ahmed@school.com", "Ahmed", "Mohamed", "01012345678", 15000m },
                    { 2, 2, "sara@school.com", "Sara", "Ali", "01112345678", 14000m }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Description", "MaxGrade", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Programming Fundamentals", 100, "Programming", 1 },
                    { 2, "Basic Mathematics", 100, "Mathematics", 2 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "EnrollmentDate", "Grade", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95m, 1, 1 },
                    { 2, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88m, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
