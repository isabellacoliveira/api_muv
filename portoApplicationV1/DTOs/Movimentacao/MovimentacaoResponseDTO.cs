using portoApplicationV1.DTOs.Enums;
using portoApplicationV1.Models;

namespace portoApplicationV1.DTOs.Movimentacao
{
    public class MovimentacaoResponseDTO
    {
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int ContainerId { get; set; }
        
    }
}