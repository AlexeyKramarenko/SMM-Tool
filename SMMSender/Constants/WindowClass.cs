namespace SMMSender.Constants
{
    internal class WindowClass
    {
        public string Name { get; }

        private WindowClass(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        public static WindowClass Telegram = new WindowClass("Qt5154QWindowIcon");
        public static WindowClass Viber = new WindowClass("Qt624QWindowOwnDCIcon");
        public static WindowClass OpenFileDialog = new WindowClass("#32770 (Dialog)");
    }
}
