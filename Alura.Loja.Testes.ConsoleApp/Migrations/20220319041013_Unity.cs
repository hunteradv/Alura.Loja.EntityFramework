using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    public partial class Unity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Produtos",
                newName: "UnityValue");

            migrationBuilder.AddColumn<string>(
                name: "Unity",
                table: "Produtos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unity",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "UnityValue",
                table: "Produtos",
                newName: "Preco");
        }
    }
}
