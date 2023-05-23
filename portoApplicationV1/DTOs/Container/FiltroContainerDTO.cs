using setorPortuario.DTOs.Enums;

namespace setorPortuario.DTOs.Container
{
    public class FiltroContainerQuery
    {
       public string Cliente {get; set;} 
       public string NumeroContainer {get; set;} 
       public TipoContainer Tipo {get; set;} 
       public StatusContainer Status {get; set;} 
       public CategoriaContainer Categoria {get; set;} 
    }
}