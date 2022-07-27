namespace SMMSender.Constants
{
    internal class DialogFileFilter
    {
        public string Filter { get; }

        private DialogFileFilter(string filter)
        {
            Filter = filter;
        }

        public static DialogFileFilter Excel { get; } = new DialogFileFilter("Excel Worksheets|*.xls;*xlsx;");
        public static DialogFileFilter Image { get; } = new DialogFileFilter("Image Files (*.jpg;*.jpeg;)|*.jpg;*.jpeg;");
    }
}
