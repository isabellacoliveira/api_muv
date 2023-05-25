using portoApplicationV1.DTOs.Movimentacao;
using setorPortuario.DTOs.Container;
using setorPortuario.DTOs.Enums;


namespace portoApplicationV1.DTOs.Container
{
    public class ContainerResponseDTO
    {
       public string Cliente {get; set;} 
       public string NumeroContainer {get; set;} 
       public TipoContainer Tipo {get; set;} 
       public StatusContainer Status {get; set;} 
       public CategoriaContainer Categoria {get; set;} 
       public ICollection<MovimentacaoResponseDTO> Movimentacoes { get; set; }
    }
}

