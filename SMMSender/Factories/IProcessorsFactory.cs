using SMMSender.DTO;
using SMMSender.Processors;

namespace SMMSender.Factories
{
    public interface IProcessorFactories
    {

        IProcessor CreateEmailProcessor(MailMessageDto dto);
        IProcessor CreateFacebookProcessor();
        IProcessor CreateTelegramProcessor();
        IProcessor CreateViberProcessor();

    }
}