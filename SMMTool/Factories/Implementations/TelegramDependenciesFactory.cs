using SMMTool.DTO;
using SMMTool.Constants;

namespace SMMTool.Factories.Implementations
{
    public class TelegramDependenciesFactory : ProcessorDependenciesFactory, ITelegramDependenciesFactory
    {

        public TelegramControlsCoords CreateTelegramControlsCoords() =>
            new TelegramControlsCoords();

        public ProcessDto CreateProcessDto() =>
            new ProcessDto(
                 processName: "telegram",
                filePath: $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming\\Telegram Desktop\\Telegram.exe");

    }
}
