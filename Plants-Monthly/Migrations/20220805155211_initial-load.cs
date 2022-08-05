using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

namespace Plants_Monthly.Migrations
{
    public partial class initialload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string migration = File.ReadAllText($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/Migrations/Scripts/initial-load/UP.sql");
            migrationBuilder.Sql(migration);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string migration = File.ReadAllText($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/Migrations/Scripts/initial-load/DOWN.sql");
            migrationBuilder.Sql(migration);
        }
    }
}
