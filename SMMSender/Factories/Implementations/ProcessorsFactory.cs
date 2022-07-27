using SMMSender.DTO;
using SMMSender.Processors;
using SMMSender.Processors.Implementations;

namespace SMMSender.Factories.Implementations
{
    public class ProcessorFactories : IProcessorFactories
    {

        public IProcessor CreateTelegramProcessor() =>
            new TelegramProcessor(
                new TelegramDependenciesFactory());

        public IProcessor CreateViberProcessor() =>
            new ViberProcessor(
                new ViberDependenciesFactory());

        public IProcessor CreateFacebookProcessor() =>
            new FacebookProcessor(
                new FacebookDependenciesFactory());

        public IProcessor CreateEmailProcessor(MailMessageDto dto) =>
            new EmailProcessor(dto);

    }
}
