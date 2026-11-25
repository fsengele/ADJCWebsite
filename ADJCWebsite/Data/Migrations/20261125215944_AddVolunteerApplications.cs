using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADJCWebsite.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVolunteerApplications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VolunteerApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ParticipationType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SkillsExperience = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Motivation = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ConsentGiven = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerApplications", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteerApplications");
        }
    }
}
