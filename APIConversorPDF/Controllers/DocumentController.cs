using APIConversorPDF.ViewModels;
using InteropWindows2;
using Microsoft.AspNetCore.Mvc;
using PDFsharpWindows;
using ITextSharpProj;

namespace APIConversorPDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        [HttpPost("ConvertFileToPdf")]
        public IActionResult ConvertFileToPdf([FromForm] ConvertWordToPdfViewModel model)
        {
            try
            {
                var pathFile = Utils.CopyFile(model.Documento);

                if (Path.GetExtension(pathFile).ToUpper() == ".DOCX")
                {
                    var pathHtml = $"C:\\Users\\STPUSR10\\Desktop\\TestesConvertAPI\\{Path.GetFileNameWithoutExtension(model.Documento.FileName)}.html";
                    OpenXml.ConvertDocxToHtml(pathFile, pathHtml);

                    return Ok($"Arquivo Word convertido para PDF em: {pathHtml}");
                }

                //if (Path.GetExtension(pathFile).ToUpper() == ".DOCX")
                //{
                //    var pathPdf = $"C:\\Users\\STPUSR10\\Desktop\\TestesConvertAPI\\{Path.GetFileNameWithoutExtension(model.Documento.FileName)}.pdf";
                //    ConvertInterop.WordToPdf(pathFile, pathPdf);

                //    return Ok($"Arquivo Word convertido para PDF em: {pathPdf}");
                //}

                if (Path.GetExtension(pathFile).ToUpper() == ".PNG")
                {
                    var pathPdf = $"C:\\Users\\STPUSR10\\Desktop\\TestesConvertAPI\\{Path.GetFileNameWithoutExtension(model.Documento.FileName)}.pdf";

                    ITextSharp.SaveImageAsPdf(pathFile, pathPdf);

                    //SpirePdf.SaveImageAsPdf(pathFile, pathPdf);
                    //PdfHelper.SaveImageAsPdf(pathFile, pathPdf);

                    return Ok($"Imagem png convertida para PDF em: {pathPdf}");
                }

                if (Path.GetExtension(pathFile).ToUpper() == ".JPG")
                {
                    var pathPdf = $"C:\\Users\\STPUSR10\\Desktop\\TestesConvertAPI\\{Path.GetFileNameWithoutExtension(model.Documento.FileName)}.pdf";
                    
                    ITextSharp.SaveImageAsPdf(pathFile, pathPdf);

                    //SpirePdf.SaveImageAsPdf(pathFile, pathPdf);
                    //PdfHelper.SaveImageAsPdf(pathFile, pathPdf);

                    return Ok($"Imagem jpg convertida para PDF em: {pathPdf}");
                }

                return BadRequest($"A conversão do formato {pathFile} para PDF não é suportada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
