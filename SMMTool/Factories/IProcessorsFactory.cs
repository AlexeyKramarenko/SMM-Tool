using SMMTool.DTO;
using SMMTool.Processors;

namespace SMMTool.Factories
{
    public interface IProcessorFactories
    {

        IProcessor CreateEmailProcessor(MailMessageDto dto);
        IProcessor CreateFacebookProcessor();
        IProcessor CreateTelegramProcessor();
        IProcessor CreateViberProcessor();

    }
}