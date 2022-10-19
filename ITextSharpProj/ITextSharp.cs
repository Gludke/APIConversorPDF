using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

/// <summary>
/// Instruções de uso da lib:
/// 1- No Nuget> Pesquisar por "iTextSharp.LGPLv2.Core" e instalar a última versão
/// 2- Fim
/// </summary>

namespace ITextSharpProj
{
    public class ITextSharp
    {
        public static void SaveImageAsPdf(string pathFile, string pathPdf)
        {
            var pdfDoc = new Document(PageSize.A4);
            var stream = new FileStream(pathPdf, FileMode.Create);

            PdfWriter.GetInstance(pdfDoc, stream);

            pdfDoc.Open();

            pdfDoc.Add(createImage(pathFile));

            pdfDoc.Close();
            stream.Dispose();
        }

        private static Image createImage(string pathFile)
        {
            Image img = Image.GetInstance(pathFile);

            if (img.ScaledWidth >= PageSize.A4.Width || img.ScaledHeight >= PageSize.A4.Height)
            {
                //Estamos definindo a largura máxima da imagem como sendo a largura do A4 (595 px) menos 10, para dar margem de 5 pra cada lado.
                img.ScaleToFit(585, 585);
            }

            img.SetAbsolutePosition(5, PageSize.A4.Height - (img.ScaledHeight + 5));// widht and height

            return img;
        }
    }
}


//Para centralizar a imagem:

//img.SetAbsolutePosition(
//  (PageSize.A4.Width - img.ScaledWidth) / 2,
//  (PageSize.A4.Height - img.ScaledHeight) / 2
//);
