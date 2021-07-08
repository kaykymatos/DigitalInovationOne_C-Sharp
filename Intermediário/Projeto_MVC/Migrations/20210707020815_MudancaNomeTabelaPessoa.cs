﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Projeto_MVC.Migrations
{
    public partial class MudancaNomeTabelaPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Endereco_Endereco_Id",
                table: "Pessoa");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_Endereco_Id",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Endereco_Id",
                table: "Pessoa");

            migrationBuilder.CreateTable(
                name: "UsuarioEndereco",
                columns: table => new
                {
                    Endereco_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Enredeco_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Localidade = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Uf = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEndereco", x => x.Endereco_Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEndereco_Pessoa_Enredeco_Id",
                        column: x => x.Enredeco_Id,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEndereco_Enredeco_Id",
                table: "UsuarioEndereco",
                column: "Enredeco_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioEndereco");

            migrationBuilder.AddColumn<Guid>(
                name: "Endereco_Id",
                table: "Pessoa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Endereco_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Uf = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Endereco_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Endereco_Id",
                table: "Pessoa",
                column: "Endereco_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Endereco_Endereco_Id",
                table: "Pessoa",
                column: "Endereco_Id",
                principalTable: "Endereco",
                principalColumn: "Endereco_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
