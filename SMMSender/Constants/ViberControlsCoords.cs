using SMMSender.Utils.WindowsApi;
using static SMMSender.Utils.WindowsApi.WinApi;

namespace SMMSender.Constants
{
    public class ViberControlsCoords
    {
        private readonly WinApiWrapper _winApi;
        private readonly IntPtr _hwnd;

        public POINT FirstChat { get; private set; }
        public POINT UploadImageBtn { get; private set; }
        public POINT TextContent { get; private set; }

        public ViberControlsCoords(WinApiWrapper winApi, IntPtr hwnd)
        {
            _winApi = winApi;
            _hwnd = hwnd;
            InitControls();
        }

        private void InitControls()
        {
            FirstChat = new POINT(100, 170);
            UploadImageBtn = new POINT(415, _winApi.GetWindowBottomY(_hwnd) - 40);
            TextContent = new POINT(800, _winApi.GetWindowBottomY(_hwnd) - 200);
        }
    }
}
