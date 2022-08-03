using SMMTool.DTO;
using SMMTool.Utils.WindowsApi;

namespace SMMTool.Factories.Implementations
{
    public class ProcessorDependenciesFactory
    {

        public WinApiWrapper CreateWinApiObject() =>
            new WinApiWrapper();

        public FormDto CreateFormObject() =>
            new SmmForm().GetFormDto();

    }
}
