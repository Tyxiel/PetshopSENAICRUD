using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetshopSENAICRUD.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CopiaDeSeguranca",
                columns: table => new
                {
                    IdBackup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataExecucao = table.Column<DateTime>(type: "date", nullable: false),
                    HoraExecucao = table.Column<TimeSpan>(type: "time", nullable: false),
                    TamanhoBackup = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TipoBackup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StatusIntegridade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopiaDeSeguranca", x => x.IdBackup);
                });

            migrationBuilder.CreateTable(
                name: "FormaDePagamento",
                columns: table => new
                {
                    IdFormaDePagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaDePagamento", x => x.IdFormaDePagamento);
                });

            migrationBuilder.CreateTable(
                name: "PreferenciaDeNotificacao",
                columns: table => new
                {
                    IdPreferencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenciaDeNotificacao", x => x.IdPreferencia);
                });

            migrationBuilder.CreateTable(
                name: "StatusConsulta",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusConsulta", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "TipoFeedback",
                columns: table => new
                {
                    IdTipoFeedback = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFeedback", x => x.IdTipoFeedback);
                });

            migrationBuilder.CreateTable(
                name: "Veterinario",
                columns: table => new
                {
                    IdVeterinario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CRMV = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinario", x => x.IdVeterinario);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    IdPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    IdFormaDePagamento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.IdPagamento);
                    table.ForeignKey(
                        name: "FK_Pagamento_IdFormaDePagamento",
                        column: x => x.IdFormaDePagamento,
                        principalTable: "FormaDePagamento",
                        principalColumn: "IdFormaDePagamento");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    IdPreferencia = table.Column<int>(type: "int", nullable: true),
                    PreferenciaDeNotificacaoIdPreferencia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_PreferenciaDeNotificacao",
                        column: x => x.IdPreferencia,
                        principalTable: "PreferenciaDeNotificacao",
                        principalColumn: "IdPreferencia");
                    table.ForeignKey(
                        name: "FK_Cliente_PreferenciaDeNotificacao_PreferenciaDeNotificacaoIdPreferencia",
                        column: x => x.PreferenciaDeNotificacaoIdPreferencia,
                        principalTable: "PreferenciaDeNotificacao",
                        principalColumn: "IdPreferencia");
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    IdAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    especie = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    raca = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    idade = table.Column<byte>(type: "tinyint", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.IdAnimal);
                    table.ForeignKey(
                        name: "FK_Animal_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    IdFeedback = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<byte>(type: "tinyint", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: true),
                    IdTipoFeedback = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.IdFeedback);
                    table.ForeignKey(
                        name: "FK_Feedback_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Feedback_IdTipoFeedback",
                        column: x => x.IdTipoFeedback,
                        principalTable: "TipoFeedback",
                        principalColumn: "IdTipoFeedback");
                });

            migrationBuilder.CreateTable(
                name: "Notificacao",
                columns: table => new
                {
                    IdNotificacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    data_envio = table.Column<DateTime>(type: "date", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacao", x => x.IdNotificacao);
                    table.ForeignKey(
                        name: "FK_Notificacao_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<DateTime>(type: "date", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: true),
                    IdAnimal = table.Column<int>(type: "int", nullable: true),
                    IdVeterinario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_Consulta_IdAnimal",
                        column: x => x.IdAnimal,
                        principalTable: "Animal",
                        principalColumn: "IdAnimal");
                    table.ForeignKey(
                        name: "FK_Consulta_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "StatusConsulta",
                        principalColumn: "IdStatus");
                    table.ForeignKey(
                        name: "FK_Consulta_IdVeterinario",
                        column: x => x.IdVeterinario,
                        principalTable: "Veterinario",
                        principalColumn: "IdVeterinario");
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    IdReceita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IdConsulta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.IdReceita);
                    table.ForeignKey(
                        name: "FK_Receita_IdConsulta",
                        column: x => x.IdConsulta,
                        principalTable: "Consulta",
                        principalColumn: "IdConsulta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_IdCliente",
                table: "Animal",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_email",
                table: "Cliente",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdPreferencia",
                table: "Cliente",
                column: "IdPreferencia");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PreferenciaDeNotificacaoIdPreferencia",
                table: "Cliente",
                column: "PreferenciaDeNotificacaoIdPreferencia");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_telefone",
                table: "Cliente",
                column: "telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdAnimal",
                table: "Consulta",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdStatus",
                table: "Consulta",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdVeterinario",
                table: "Consulta",
                column: "IdVeterinario");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_IdCliente",
                table: "Feedback",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_IdTipoFeedback",
                table: "Feedback",
                column: "IdTipoFeedback");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_IdCliente",
                table: "Notificacao",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_IdFormaDePagamento",
                table: "Pagamento",
                column: "IdFormaDePagamento");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_IdConsulta",
                table: "Receita",
                column: "IdConsulta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CopiaDeSeguranca");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Notificacao");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "TipoFeedback");

            migrationBuilder.DropTable(
                name: "FormaDePagamento");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "StatusConsulta");

            migrationBuilder.DropTable(
                name: "Veterinario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "PreferenciaDeNotificacao");
        }
    }
}
