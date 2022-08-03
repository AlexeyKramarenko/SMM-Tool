using SMMTool.Constants;
using SMMTool.DTO;

namespace SMMTool.Factories
{
    public interface IViberDependenciesFactory
    {

        ViberControlsCoords CreateViberControlsCoords();
        ProcessDto CreateProcessDto();

    }
}