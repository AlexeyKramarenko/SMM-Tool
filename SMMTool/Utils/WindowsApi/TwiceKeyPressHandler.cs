using static SMMTool.Utils.WindowsApi.WinApi;

namespace SMMTool.Utils.WindowsApi
{
    internal class TwiceKeyPressHandler
    {
        private readonly WinApiWrapper _winApiWrapper;

        public TwiceKeyPressHandler(WinApiWrapper winApiWrapper)
        {
            _winApiWrapper = winApiWrapper;
        }

        private DateTime PrevDataTime = DateTime.MinValue;

        public void OnKeyPressedTwice(
                            VirtualKeyStates onKey,
                            Action<VirtualKeyStates> action,
                            VirtualKeyStates virtualKey)
        {
            if (_winApiWrapper.KeyIsPressed(onKey))
            {
                if (PrevDataTime == DateTime.MinValue)
                {
                    PrevDataTime = DateTime.Now;
                    return;
                }

                int intervalBetweenTwoPresses = (DateTime.Now - PrevDataTime).Seconds;

                if (intervalBetweenTwoPresses <= 1.1)
                {
                    action(virtualKey);
                }

                PrevDataTime = DateTime.MinValue;
            }
        }
    }
}
