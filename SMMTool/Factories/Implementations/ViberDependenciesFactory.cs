using SMMTool.DTO;
using SMMTool.Constants;
using SMMTool.Utils.WindowsApi;

namespace SMMTool.Factories.Implementations
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
