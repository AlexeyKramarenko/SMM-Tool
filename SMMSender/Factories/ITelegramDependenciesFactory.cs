using SMMSender.Constants;
using SMMSender.DTO;
using SMMSender.Utils.WindowsApi;

namespace SMMSender.Factories
{
    public interface ITelegramDependenciesFactory
    {

        FormDto CreateFormObject();
        WinApiWrapper CreateWinApiObject();
        TelegramControlsCoords CreateTelegramControlsCoords();
        ProcessDto CreateProcessDto();

    }
}