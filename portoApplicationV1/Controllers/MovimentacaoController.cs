using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using portoApplicationV1.Data;
using portoApplicationV1.DTOs.Movimentacao;
using portoApplicationV1.Models;

namespace portoApplicationV1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacaoController : ControllerBase
    {
           private PortoContext _context;
            private IMapper _mapper;
        private static List<Movimentacao> Movimentacoes = new List<Movimentacao>();

        public MovimentacaoController(PortoContext context, IMapper mapper)
        {
               
            _context = context;
            _mapper = mapper;
        }

    [HttpPost]
    public IActionResult adicionaMovimentacao([FromBody] CreateMovimentacaoDTO movimentacaoDTO)
    {
        Movimentacao movimentacao = _mapper.Map<Movimentacao>(movimentacaoDTO);
        _context.Movimentacoes.Add(movimentacao); 
        _context.SaveChanges();
        return CreatedAtAction(nameof(buscarMovimentacaoPorId), new { id = movimentacao.Id }, movimentacao);

    }

    [HttpGet]
    public IEnumerable<MovimentacaoResponseDTO> buscarMovimentacao([FromQuery] int skip = 0, 
                                                              [FromQuery] int take = 50)
    {
        return _mapper.Map<List<MovimentacaoResponseDTO>>(_context.Movimentacoes.Skip(skip).Take(take));
    }

        [HttpGet("{containerId}")]
        public IActionResult buscarMovimentacaoPorId(int containerId)
        {
            Movimentacao movimentacao = _context.Movimentacoes.FirstOrDefault(movimentacao => movimentacao.ContainerId == containerId);
            if (movimentacao != null)
            {
                MovimentacaoResponseDTO movimentacaoDto = _mapper.Map<MovimentacaoResponseDTO>(movimentacao);
                return Ok(movimentacaoDto);
            }
            return NotFound();
        }


    [HttpPut("{id}")]
        public IActionResult AtualizaMovimentacao(int id, 
                [FromBody] UpdateMovimentacaoDTO movimentacaoDTO)
        {
            var movimentacao = _context.Movimentacoes.FirstOrDefault(
                movimentacao => movimentacao.Id == id);
                if(movimentacao == null) return NotFound();
                _mapper.Map(movimentacaoDTO, movimentacao);
                _context.SaveChanges();
            return NoContent(); 
        }

    [HttpDelete("{id}")]
        public IActionResult DeletaMovimentacao(int id)
        {
            var movimentacao = _context.Movimentacoes.FirstOrDefault(
            movimentacao => movimentacao.Id == id);
            if(movimentacao == null) return NotFound();

            _context.Remove(movimentacao); 
            _context.SaveChanges();
            return NoContent();
        }

    }
}