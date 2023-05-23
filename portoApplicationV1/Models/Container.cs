using System.ComponentModel.DataAnnotations;
using setorPortuario.DTOs.Container;
using setorPortuario.DTOs.Enums;

namespace setorPortuario.Models
{
    public class Container
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Cliente é obrigatório!")]
        public string Cliente { get; set; }
        [Required(ErrorMessage = "O número do container é obrigatório!"), 
        MaxLength(11, ErrorMessage = "O tamanho não pode exceder 11 caracteres.")]
        public string NumeroContainer { get; set; }

        [Required(ErrorMessage = "O tipo do container é obrigatório!")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O status do container é obrigatório!")]
        public string Status { get; set; }

        [Required(ErrorMessage = "A categoria do container é obrigatória!")]
        public string Categoria { get; set; }
    }
}