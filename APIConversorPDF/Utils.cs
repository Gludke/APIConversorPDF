namespace APIConversorPDF
{
    public class Utils
    {
        public static string ConvertToBase64(Stream stream)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return Convert.ToBase64String(bytes);
            //return new MemoryStream(Encoding.UTF8.GetBytes(base64));
        }

        public static void CriarArquivo(IFormFile file)
        {
            var stream = file.OpenReadStream();

            using (var reader = new StreamReader(stream))
            using (var writer = new StreamWriter($"C:\\Users\\Guilherme\\Desktop\\TestesConvertAPI\\{file.Name}"))
            {
                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    writer.WriteLine(linha);
                }
            }
        }
    }
}
