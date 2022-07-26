using static SMMSender.Utils.WindowsApi.WinApi;

namespace SMMSender.Utils.WindowsApi
{
    public class WinApiWrapper
    {
        public WinApiWrapper SendKeys(VirtualKeyStates holdKey, VirtualKeyStates pressKey)
        {
            SendKeyDown(holdKey);
            SendKey(pressKey);
            SendKeyUp(holdKey);
            return this;
        }

        public WinApiWrapper SendKey(VirtualKeyStates key)
        {
            SendKeyDown(key);
            SendKeyUp(key);
            return this;
        }

        public WinApiWrapper SendKeyDown(VirtualKeyStates key)
        {
            WinApi.keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY | 0, UIntPtr.Zero);
            return this;
        }

        public WinApiWrapper SendKeyUp(VirtualKeyStates key)
        {
            WinApi.keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, UIntPtr.Zero);
            return this;
        }

        public bool KeyIsPressed(VirtualKeyStates key) =>
            (WinApi.GetAsyncKeyState((int)key) & 0x8000) != 0;

        public bool KeysArePressed(VirtualKeyStates key1, VirtualKeyStates key2) =>
            KeyIsPressed(key1) && KeyIsPressed(key2);

        public bool KeysArePressed(VirtualKeyStates key1, VirtualKeyStates key2, VirtualKeyStates key3) =>
            KeysArePressed(key1, key2) && KeyIsPressed(key3);

        public WinApiWrapper SendText(IntPtr programHandle, string text)
        {
            // SendMessageW(programHandle, WM_SETTEXT, 0, text);
            System.Windows.Forms.SendKeys.Send(text);
            return this;
        }

        public WinApiWrapper MouseLeftClick(POINT p) =>
            MouseLeftClick(p.X, p.Y);

        public WinApiWrapper MouseLeftClick(int x, int y) =>
            MouseClick(x, y, MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP);

        public WinApiWrapper MouseRightClick(POINT p) =>
            MouseRightClick(p.X, p.Y);

        public WinApiWrapper MouseRightClick(int x, int y) =>
            MouseClick(x, y, MOUSEEVENTF_RIGHTDOWN, MOUSEEVENTF_RIGHTUP);

        public int GetWindowBottomY(IntPtr hwnd) => GetWindowRect(hwnd).Bottom;
        public int GetWindowTopY(IntPtr hwnd) => GetWindowRect(hwnd).Top;
        public int GetWindowLeftX(IntPtr hwnd) => GetWindowRect(hwnd).Left;
        public int GetWindowRightY(IntPtr hwnd) => GetWindowRect(hwnd).Right;

        public WinApiWrapper SetWindowPos(IntPtr hwnd, POINT topLeftAppWindowCorner, int width, int height)
        {
            WinApi.SetWindowPos(hwnd, IntPtr.Zero, 
                topLeftAppWindowCorner.X, 
                topLeftAppWindowCorner.Y,
                topLeftAppWindowCorner.X + width, 
                topLeftAppWindowCorner.Y + height, 
                SetWindowPosFlags.ShowWindow);

            return this;
        }

        public WinApiWrapper Wait(int milliSeconds = 0)
        {
            Thread.Sleep(milliSeconds);
            return this;
        }

        #region Private Methods

        private WinApiWrapper MouseClick(int x, int y, uint down, uint up)
        {
            int sx = GetSystemMetrics(SM_CXSCREEN);
            int sy = GetSystemMetrics(SM_CYSCREEN);
            int dx = x * 65536 / sx;
            int dy = y * 65536 / sy;
            WinApi.mouse_event(down | MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, dx, dy, 0, UIntPtr.Zero);
            Thread.Sleep(400);
            WinApi.mouse_event(up | MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, dx, dy, 0, UIntPtr.Zero);
            return this;
        }

        private Rect GetWindowRect(IntPtr hwnd)
        {
            var rect = new WinApi.Rect();
            WinApi.GetWindowRect(hwnd, ref rect);
            return rect;
        }

        #endregion 
    }
}
