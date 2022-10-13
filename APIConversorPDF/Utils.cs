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

        public static byte[] ConvertToBytes(Stream stream)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return bytes;
        }

        public static string CopyFile(IFormFile file)
        {
            var fileStream = file.OpenReadStream();

            byte[] fileBytes = ConvertToBytes(fileStream);

            var pathFile = $"C:\\Users\\STPUSR10\\Desktop\\TestesConvertAPI\\{file.FileName}";

            File.WriteAllBytes(pathFile, fileBytes);

            return pathFile;
        }
    }
}
