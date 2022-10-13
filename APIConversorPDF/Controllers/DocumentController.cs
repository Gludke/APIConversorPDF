using APIConversorPDF.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace APIConversorPDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        [HttpPost("ConvertWordToPdf")]
        public IActionResult ConvertWordToPdf([FromForm] ConvertWordToPdfViewModel model)
        {
            var docStream = model.DocumentoWord.OpenReadStream();



            return Ok("Arquivo convertido para PDF");
        }
    }
}
