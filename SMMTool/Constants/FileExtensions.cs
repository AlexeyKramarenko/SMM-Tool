namespace SMMTool.Constants
{
    public static class FileExtensions
    {
        public const string Jpeg = ".jpeg";
        public const string Jpg = ".jpg";
        public const string Xls = ".xls";
        public const string Xlsx = ".xlsx";

        public static IEnumerable<string> GetList()
           => new List<string> { Jpeg, Jpg, Xls, Xlsx };
    }
}
