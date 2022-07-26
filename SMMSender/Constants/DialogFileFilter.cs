namespace SMMSender.Constants
{
    internal class DialogFileFilter
    {
        public string Filter { get; }

        private DialogFileFilter(string filter)
        {
            Filter = filter;
        }

        public static DialogFileFilter Excel = new DialogFileFilter("Excel Worksheets|*.xls;*xlsx;");
        public static DialogFileFilter Image = new DialogFileFilter("Image Files (*.jpg;*.jpeg;)|*.jpg;*.jpeg;");
    }
}
