using portoApplicationV1.DTOs.Enums;

namespace portoApplicationV1.DTOs.Movimentacao
{
    public class FiltroMovimentacaoDTO
    {
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}