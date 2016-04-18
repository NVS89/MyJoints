using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace MyJoints.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false),
                    Birthday = table.Column(type: "datetime2", nullable: false),
                    Email = table.Column(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column(type: "nvarchar(max)", nullable: true),
                    Login = table.Column(type: "nvarchar(max)", nullable: true),
                    Password = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropSequence("DefaultSequence");
            migration.DropTable("User");
        }
    }
}
