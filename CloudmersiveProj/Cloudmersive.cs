using Cloudmersive.APIClient.NETCore.DocumentAndDataConvert.Api;
using Cloudmersive.APIClient.NETCore.DocumentAndDataConvert.Client;

namespace CloudmersiveProj
{
    public class Cloudmersive : ICloudmersive
    {
        public Cloudmersive()
        {
            Configuration.Default.AddApiKey("Apikey", "555244a3-2b5d-4b8a-9e87-76fcd9786da7");
        }

        public void Convert(string pathFile, string pathPdf)
        {
            var apiInstance = new ConvertDocumentApi();
            var inputFile = new System.IO.FileStream(pathFile, System.IO.FileMode.Open); // System.IO.Stream | Input file to perform the operation on.

            try
            {
                // Word DOCX to PDF
                var fileBytes = apiInstance.ConvertDocumentDocxToPdf(inputFile);

                File.WriteAllBytes(pathPdf, fileBytes);
            }
            catch (Exception e)
            {
                throw new Exception("Exception when calling ConvertDocumentApi.ConvertDocumentDocxToPdf: " + e.Message);
            }
        }

    }
}
