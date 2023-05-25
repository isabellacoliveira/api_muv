using System.ComponentModel.DataAnnotations;
using portoApplicationV1.Models;
using setorPortuario.DTOs.Enums;

namespace setorPortuario.Models
{
    public class Container
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Cliente é obrigatório!")]
        public string Cliente { get; set; }
        [Required(ErrorMessage = "O número do container é obrigatório!"), 
        MaxLength(11, ErrorMessage = "O tamanho não pode exceder 11 caracteres.")]
        public string NumeroContainer { get; set; }

        [Required(ErrorMessage = "O tipo do container é obrigatório!")]
        public TipoContainer Tipo { get; set; }

        [Required(ErrorMessage = "O status do container é obrigatório!")]
        public StatusContainer Status { get; set; }

        [Required(ErrorMessage = "A categoria do container é obrigatória!")]
        public CategoriaContainer Categoria { get; set; }
        public virtual ICollection<Movimentacao> Movimentacoes { get; set; }

    }
}