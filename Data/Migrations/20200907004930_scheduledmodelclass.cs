using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PartsInventory.Data.Migrations
{
    public partial class scheduledmodelclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scheduleds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkOrder = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    TimeIn = table.Column<DateTime>(nullable: false),
                    TimeOut = table.Column<DateTime>(nullable: false),
                    ThemeColor = table.Column<string>(nullable: true),
                    IsFullDay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheduleds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scheduleds");
        }
    }
}
