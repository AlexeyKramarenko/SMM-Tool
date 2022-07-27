using SMMSender.DTO;
using SMMSender.Utils.WindowsApi;

namespace SMMSender.Factories.Implementations
{
    public class ProcessorDependenciesFactory
    {

        public WinApiWrapper CreateWinApiObject() =>
            new WinApiWrapper();

        public FormDto CreateFormObject() =>
            new SmmForm().GetFormDto();

    }
}
