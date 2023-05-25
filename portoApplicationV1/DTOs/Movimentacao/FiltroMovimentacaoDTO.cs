using portoApplicationV1.DTOs.Enums;

namespace portoApplicationV1.DTOs.Movimentacao
{
    public class FiltroMovimentacaoDTO
    {
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public int totalMovimentacao { get; set; }
        public string Cliente { get; set; }
    }
}