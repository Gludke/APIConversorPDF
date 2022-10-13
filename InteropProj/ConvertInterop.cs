using Microsoft.Office.Interop.Word;

namespace InteropWindows2
{
    public class ConvertInterop
    {
        public static string WordToPdf(string docOrigem, string pdfSaida)
        {
            Microsoft.Office.Interop.Word.Document wordDocument;

            // Utiliza as próprias dll do word para realizar a conversão
            Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
            wordDocument = appWord.Documents.Open(docOrigem);
            wordDocument.ExportAsFixedFormat(pdfSaida, WdExportFormat.wdExportFormatPDF);

            // Fecha a aplicação e o documento
            wordDocument.Close();
            appWord.Quit();

            return pdfSaida;
        }
    }
}

