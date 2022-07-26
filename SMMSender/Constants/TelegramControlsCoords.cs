using static SMMSender.Utils.WindowsApi.WinApi;

namespace SMMSender.Constants
{
    public class TelegramControlsCoords
    {
        public POINT FirstChat { get; private set; }

        public TelegramControlsCoords()
        {
            InitControls();
        }

        private void InitControls()
        {
            FirstChat = new POINT(200, 120);
        }
    }
}
