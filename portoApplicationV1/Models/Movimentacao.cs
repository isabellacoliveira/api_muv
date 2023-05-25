using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using portoApplicationV1.DTOs.Enums;
using setorPortuario.Models;

namespace portoApplicationV1.Models
{
    public class Movimentacao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Tipo de movimentação é obrigatório!")]
        public TipoMovimentacao TipoMovimentacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        [ForeignKey("Container")]
        public int ContainerId { get; set; } // Chave estrangeira

        public virtual Container Container { get; set; } 
    }
}