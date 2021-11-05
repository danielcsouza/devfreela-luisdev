using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    public partial class AddMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProvidedServiceMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    IdProvidedService = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidedServiceMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvidedServiceMessage_ProvidedServices_IdProvidedService",
                        column: x => x.IdProvidedService,
                        principalTable: "ProvidedServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProvidedServiceMessage_IdProvidedService",
                table: "ProvidedServiceMessage",
                column: "IdProvidedService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvidedServiceMessage");
        }
    }
}
