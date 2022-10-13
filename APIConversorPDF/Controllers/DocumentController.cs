using APIConversorPDF.ViewModels;
using InteropWindows2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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
                var pathFile = Utils.CopyFile(model.DocumentoWord);

                if (Path.GetExtension(pathFile) == ".docx")
                {
                    var pathPdf = $"C:\\Users\\Guilherme\\Desktop\\TestesConvertAPI\\{Path.GetFileNameWithoutExtension(model.DocumentoWord.FileName)}.pdf";
                    ConvertInterop.WordToPdf(pathFile, pathPdf);

                    return Ok($"Arquivo Word convertido para PDF em: {pathPdf}");
                }

                if (Path.GetExtension(pathFile) == ".png")
                {
                    return Ok($"Imagem png convertida para PDF em: ");
                }

                if (Path.GetExtension(pathFile) == ".jpg")
                {
                    return Ok($"Imagem jpg convertida para PDF em: ");
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
