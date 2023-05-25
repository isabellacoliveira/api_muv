using portoApplicationV1.DTOs.Enums;
using setorPortuario.DTOs.Enums;

namespace portoApplicationV1.DTOs.Relatorio
{
    public class FiltroRelatorioDTO
    {
        public string? Cliente { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public int totalMovimentacao { get; set; }
        public CategoriaContainer Categoria { get; set; }
    }
}