using portoApplicationV1.DTOs.Movimentacao;
using portoApplicationV1.DTOs.Relatorio;

namespace portoApplicationV1.Queries.Interfaces
{
    public interface IMovimentacaoQuery
    {
        Task<List<FiltroRelatorioDTO>> ObterMovimentacao(FiltroRelatorioDTO filtros);
    }
}