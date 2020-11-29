using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Olimpia.Stadium.Api.Migrations
{
    public partial class Script : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Migrations\Scripts\olimpia.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
