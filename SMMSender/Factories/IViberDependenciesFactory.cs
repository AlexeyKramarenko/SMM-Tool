using SMMSender.Constants;
using SMMSender.DTO;

namespace SMMSender.Factories
{
    public interface IViberDependenciesFactory
    {

        ViberControlsCoords CreateViberControlsCoords();
        ProcessDto CreateProcessDto();

    }
}