using Cloudmersive.APIClient.NETCore.DocumentAndDataConvert.Api;
using Cloudmersive.APIClient.NETCore.DocumentAndDataConvert.Client;

namespace CloudmersiveProj
{
    public class Cloudmersive : ICloudmersive
    {
        public Cloudmersive()
        {
            Configuration.Default.AddApiKey("Apikey", "Apikey");
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
