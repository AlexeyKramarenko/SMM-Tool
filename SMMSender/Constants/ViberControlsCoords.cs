using SMMSender.Utils.WindowsApi;
using static SMMSender.Utils.WindowsApi.WinApi;

namespace SMMSender.Constants
{
    public class ViberControlsCoords
    {

        public POINT FirstChat { get; }
        public POINT UploadImageBtn { get; }
        public POINT TextContent { get; }

        public ViberControlsCoords(IntPtr hwnd)
        {
            if (hwnd == IntPtr.Zero)
                throw new ArgumentException($"Argument '{nameof(hwnd)}' should have value, that cannot be Zero.");

            var winApi = new WinApiWrapper();
            FirstChat = new POINT(100, 170);
            UploadImageBtn = new POINT(415, winApi.GetWindowBottomY(hwnd) - 40);
            TextContent = new POINT(800, winApi.GetWindowBottomY(hwnd) - 200);
        }

    }
}
