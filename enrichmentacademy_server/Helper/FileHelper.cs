namespace EnrichmentAcademy.Helper
{
    public class FileHelper
    {
        public static string GenerateFilename(string filename)
        {
            var name = Guid.NewGuid().ToString().Replace("-", "");
            var lastIndex = filename.LastIndexOf('.');
            var ext = filename.Substring(lastIndex);
            return name + ext;
        }
    }
}
