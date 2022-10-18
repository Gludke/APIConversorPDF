using System.Drawing;
using Spire.Pdf;
using Spire.Pdf.Graphics;

/// <summary>
/// Instruções de uso da lib:
/// 1- No console do Nuget> Install-Package Spire.PDF
/// 2- Fim
/// </summary>

namespace SpirePDFProj
{
    public class SpirePdf
    {
        public static void SaveImageAsPdf(string PathInput, string PathOutput)
        {
            //Create a PdfDocument object
            PdfDocument doc = new PdfDocument();

            //Set the margins
            doc.PageSettings.SetMargins(0);

            //Add a page
            PdfPageBase page = doc.Pages.Add();

            //Load an image
            Image image = Image.FromFile(PathInput);

            //Get the image width and height
            float width = image.PhysicalDimension.Width;
            float height = image.PhysicalDimension.Height;

            //Declare a PdfImage variable
            PdfImage pdfImage;

            //If the image width is larger than page width
            if (width > page.Canvas.ClientSize.Width)
            {
                //Resize the image to make it to fit to the page width
                float widthFitRate = width / page.Canvas.ClientSize.Width;

                Size size = new Size((int)(width / widthFitRate), (int)(height / widthFitRate));

                Bitmap scaledImage = new Bitmap(image, size);

                //Load the scaled image to the PdfImage object
                pdfImage = PdfImage.FromImage(scaledImage);
            }
            else
            {
                //Load the original image to the PdfImage object
                pdfImage = PdfImage.FromImage(image);
            }

            //Draw image at (0, 0)
            page.Canvas.DrawImage(pdfImage, 0, 0, pdfImage.Width, pdfImage.Height);

            //Save to file
            doc.SaveToFile(PathOutput);
        }
    }
}

