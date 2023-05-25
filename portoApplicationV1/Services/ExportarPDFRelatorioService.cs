using System;
using System.IO;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using portoApplicationV1.DTOs.Relatorio;
using portoApplicationV1.Queries.Interfaces;
using portoApplicationV1.Services.Interfaces;

namespace Application.Service
{
    public class ExportarPDFRelatorioService : IExportarPDFRelatorioService
    {
        private readonly IMovimentacaoQuery _movimentacaoQuery;

        public ExportarPDFRelatorioService(IMovimentacaoQuery movimentacaoQuery)
        {
            _movimentacaoQuery = movimentacaoQuery ?? throw new ArgumentNullException(nameof(movimentacaoQuery));
        }

        public async Task<byte[]> ExportarPDFRelatorio(FiltroRelatorioDTO parametros)
        {
            var resultados = await _movimentacaoQuery.ObterMovimentacao(parametros);

            using (var ms = new MemoryStream())
            {
                var document = new Document(PageSize.A4.Rotate());
                var writer = PdfWriter.GetInstance(document, ms);

                document.Open();

                var table = new PdfPTable(9);
                table.WidthPercentage = 100;

                var boldFont = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);

                table.AddCell(CreateCell("Cliente", boldFont));
                table.AddCell(CreateCell("Tipo Movimentacao", boldFont));
                table.AddCell(CreateCell("Total Movimentacao", boldFont));
                table.AddCell(CreateCell("Categoria", boldFont));

                foreach (var objeto in resultados)
                {
                    table.AddCell(objeto.Cliente);
                    table.AddCell(objeto.TipoMovimentacao.ToString());
                    table.AddCell(objeto.totalMovimentacao.ToString());
                    table.AddCell(objeto.Categoria.ToString());
                }

                document.Add(new Paragraph("Relatorio de Movimentacao", new Font(Font.FontFamily.HELVETICA, 16, Font.BOLD)));
                document.Add(Chunk.NEWLINE);
                document.Add(table);

                document.Close();
                writer.Close();

                return ms.ToArray();
            }
        }

        private PdfPCell CreateCell(string text, Font font)
        {
            var cell = new PdfPCell(new Phrase(text, font));
            cell.Padding = 5;
            return cell;
        }
    }
}
