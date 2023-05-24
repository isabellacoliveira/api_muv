using setorPortuario.DTOs.Enums;

namespace portoApplicationV1.DTOs.Container
{
    public class UpdateContainerDTO
    {
       public string Cliente {get; set;} 
       public string NumeroContainer {get; set;} 
       public TipoContainer Tipo {get; set;} 
       public StatusContainer Status {get; set;} 
       public CategoriaContainer Categoria {get; set;} 
    }
}