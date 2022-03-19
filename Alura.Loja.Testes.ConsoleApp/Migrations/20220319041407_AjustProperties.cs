using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    public partial class AjustProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Produtos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Produtos",
                newName: "Category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Produtos",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Produtos",
                newName: "Categoria");
        }
    }
}
