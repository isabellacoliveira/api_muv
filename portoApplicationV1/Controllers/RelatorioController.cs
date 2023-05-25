using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using portoApplicationV1.Data;
using portoApplicationV1.DTOs.Relatorio;
using portoApplicationV1.Services.Interfaces;

namespace portoApplicationV1.Controllers
{
[ApiController]
[Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
    private PortoContext _context;
    private readonly IMediator _mediatorHandler;
    private IExportarPDFRelatorioService _exportarPDFRelatorioService;

    private IMapper _mapper;

        public RelatorioController(PortoContext context, IMapper mapper, IExportarPDFRelatorioService exportarPDFRelatorioService)
        {
            _context = context;
            _mapper = mapper;
            _exportarPDFRelatorioService = exportarPDFRelatorioService;
        }

         [HttpGet("exportarPDFMovimentacao")]
        public async Task<byte[]> ExportarPDFRelatorio(
            [FromQuery] FiltroRelatorioDTO query
        )
        {
            var resultado = await _exportarPDFRelatorioService.ExportarPDFRelatorio(query);
            return resultado;
        }

    }
}


