using System.Data;
using portoApplicationV1.Queries.Interfaces;
using Queries.Base;
using portoApplicationV1.DTOs.Relatorio;
using MySqlConnector;

namespace portoApplicationV1.Queries
{
    public class MovimentacaoQuery : IMovimentacaoQuery
    {
        private readonly IConfiguration _config;
        private readonly ILogger<MovimentacaoQuery> _logger;
        public MovimentacaoQuery(IConfiguration config,
                                   ILogger<MovimentacaoQuery> logger)
        {
            _config = config;
            _logger = logger;
        }

        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("PortoConnection"));
            }
        }
        public Task<List<FiltroRelatorioDTO>> ObterMovimentacao(FiltroRelatorioDTO filtros)
        {

            try
            {
                using (IDbConnection conexao = Connection)
                {
                    var from = @$"FROM movimentacoes m
                                    INNER JOIN containers g ON g.id = m.containerId";

                    var sql = @$"SELECT
                                    m.tipoMovimentacao as TipoMovimentacao,
                                    COUNT(*) as totalMovimentacao,
                                    g.cliente as Cliente,
                                    g.categoria as Categoria
                                    {from}
                                    GROUP BY g.cliente, m.tipoMovimentacao, g.categoria
                                    ORDER BY g.cliente, m.tipoMovimentacao, g.categoria;";

                    var filtrosFechamentos = new
                    {
                        TipoMovimentacao = filtros.TipoMovimentacao,
                        Cliente = filtros.Cliente,
                        totalMovimentacao = filtros.totalMovimentacao
                    };

                    var query = new Dictionary<string, object>() { { sql, filtrosFechamentos } };
                    var result = conexao.PesquisarSlapper<FiltroRelatorioDTO, MovimentacaoQuery>(query, _logger);
                    var resultadoFinal = new List<FiltroRelatorioDTO>(result.ToList());

                    return Task.FromResult(resultadoFinal);
                }

            }
            catch
            {
                throw;
            }
        }
    }
}