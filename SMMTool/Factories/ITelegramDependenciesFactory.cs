using SMMTool.Constants;
using SMMTool.DTO;
using SMMTool.Utils.WindowsApi;

namespace SMMTool.Factories
{
    public interface ITelegramDependenciesFactory
    {

        FormDto CreateFormObject();
        WinApiWrapper CreateWinApiObject();
        TelegramControlsCoords CreateTelegramControlsCoords();
        ProcessDto CreateProcessDto();

    }
}