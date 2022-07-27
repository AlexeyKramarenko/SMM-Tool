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

        public static WindowClass Telegram { get; } = new WindowClass("Qt5154QWindowIcon");
        public static WindowClass Viber { get; } = new WindowClass("Qt624QWindowOwnDCIcon");
        public static WindowClass OpenFileDialog { get; } = new WindowClass("#32770 (Dialog)");
    }
}
