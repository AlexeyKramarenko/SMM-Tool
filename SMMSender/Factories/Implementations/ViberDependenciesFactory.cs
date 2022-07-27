using SMMSender.DTO;
using SMMSender.Constants;
using SMMSender.Utils.WindowsApi;

namespace SMMSender.Factories.Implementations
{
    public class ViberDependenciesFactory : ProcessorDependenciesFactory, IViberDependenciesFactory
    {

        public ViberControlsCoords CreateViberControlsCoords() =>
            new ViberControlsCoords(
                WinApi.FindWindowA(WindowClass.Viber.Name, null));

        public ProcessDto CreateProcessDto() =>
            new ProcessDto(
                processName: "viber",
                filePath: $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\Viber\\Viber.exe");

    }
}
