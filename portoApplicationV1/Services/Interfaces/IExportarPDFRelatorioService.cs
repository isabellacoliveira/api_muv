using portoApplicationV1.DTOs.Relatorio;

namespace portoApplicationV1.Services.Interfaces
{
    public interface IExportarPDFRelatorioService
    {
        Task<byte[]> ExportarPDFRelatorio(FiltroRelatorioDTO parametros);
    }
}