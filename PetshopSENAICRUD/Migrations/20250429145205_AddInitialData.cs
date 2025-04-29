using Microsoft.EntityFrameworkCore.Migrations;

namespace PetshopSENAICRUD.Migrations
{
    public partial class AddInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserir dados na tabela PreferenciaDeNotificacao
            migrationBuilder.Sql(@"INSERT INTO PreferenciaDeNotificacao (descricao)
                                   VALUES
                                       ('E-mail'),
                                       ('Telefone'),
                                       ('SMS'),
                                       ('Aplicativo');");

            // Inserir dados na tabela StatusConsulta
            migrationBuilder.Sql(@"INSERT INTO StatusConsulta (descricao)
                                   VALUES
                                       ('Agendada'),
                                       ('Realizada'),
                                       ('Cancelada'),
                                       ('Adiada'),
                                       ('Pendente'),
                                       ('Concluida'),
                                       ('EmAndamento');");

            // Inserir dados na tabela FormaDePagamento
            migrationBuilder.Sql(@"INSERT INTO FormaDePagamento (Descricao)
                                   VALUES
                                       ('Dinheiro'),
                                       ('Cartão de Crédito'),
                                       ('Cartão de Débito'),
                                       ('Cheque'),
                                       ('Transferência Bancária'),
                                       ('Pix'),
                                       ('Boleto Bancário');");

            // Inserir dados na tabela TipoFeedback
            migrationBuilder.Sql(@"INSERT INTO TipoFeedback (descricao)
                                   VALUES
                                       ('Positivo'),
                                       ('Negativo'),
                                       ('Sugestão'),
                                       ('Reclamação');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Você pode reverter os dados inseridos se necessário
            migrationBuilder.Sql(@"DELETE FROM TipoFeedback;");
            migrationBuilder.Sql(@"DELETE FROM FormaDePagamento;");
            migrationBuilder.Sql(@"DELETE FROM StatusConsulta;");
            migrationBuilder.Sql(@"DELETE FROM PreferenciaDeNotificacao;");
        }
    }
}
