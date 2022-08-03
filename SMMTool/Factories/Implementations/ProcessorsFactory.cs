using SMMTool.DTO;
using SMMTool.Processors;
using SMMTool.Processors.Implementations;

namespace SMMTool.Factories.Implementations
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
