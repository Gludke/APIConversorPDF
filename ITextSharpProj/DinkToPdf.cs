using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WkHtmlToPdfDotNet;

/// Para converter html em PDF:
/// 1- Instalar a lib "Haukcode.WkHtmlToPdfDotNet" pelo nuget

namespace ITextSharpProj
{
    public class DinkToPdf
    {
        private readonly static SynchronizedConverter _converter = new SynchronizedConverter(new PdfTools());

        public static string ConvertHtmlToPdf(string pathHtml, string pathPdf)
        {
            HtmlDocument dochtml = new HtmlDocument();
            dochtml.Load(pathHtml);

            HtmlNode bodyNode = dochtml.DocumentNode.SelectSingleNode("/html/body");

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 10 },
                    Out = pathPdf,
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = dochtml.ParsedText,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        //HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                    }
                }
            };

            _converter.Convert(doc);

            return pathPdf;
        }



        //public static string BuildTemplate(EmployeeDetails employessDetails, string id, string name)
        //{
        //    var html = File.ReadAllText(Path.Combine(GetCurrentFolder(), @"EMPLOYEE\Template.Pdf.Employee.html")); //create the folder in current Assembly
        //    html = html.Replace(ID_PLACEHOLDER, string.IsNullOrWhiteSpace(id) ? "---" : id);
        //    html = html.Replace(NAME_PLACEHOLDER, string.IsNullOrWhiteSpace(name) ? "---" : name);
        //    html = html.Replace(REPORT_DATE, DateTime.UtcNow.ToString());
        //    html = html.Replace(REPORT_YEAR, DateTime.UtcNow.Year.ToString());
        //    var template = Handlebars.Compile(html);
        //    return template(employessDetails);
        //}
    }
}

