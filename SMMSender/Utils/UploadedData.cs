using IronXL;
using SMMSender.Constants;

namespace SMMSender.Utils
{
    public static class UploadedData
    {
        public const string FolderPath = "C:\\Users";
        public const string FileName = "UploadedFile";

        public static readonly string JpgFile = Path.Combine(FolderPath, string.Concat(FileName, FileExtensions.Jpg));
        public static readonly string XlsFile = Path.Combine(FolderPath, string.Concat(FileName, FileExtensions.Xls));

        public static IEnumerable<string> GetEmailListFromXls()
        {
            WorkBook workbook = WorkBook.Load(XlsFile);

            WorkSheet sheet = workbook.WorkSheets.First();

            return sheet[$"A1:A{sheet.RowCount}"]
                            .Where(a => !string.IsNullOrEmpty(a.Text))
                            .Select(a => a.Text);
        }

        public static void RemoveAllUploadedFiles() =>
            FileExtensions
                .GetList()
                .ForEach(ext =>
                {
                    var path = Path.Combine(FolderPath, string.Concat(FileName, ext));

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                });
    }
}
