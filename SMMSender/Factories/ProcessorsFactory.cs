using SMMSender.DTO;
using SMMSender.Constants;
using SMMSender.Processor;
using SMMSender.Processors;
using SMMSender.Utils.WindowsApi;

namespace SMMSender.Factories
{
    public class ProcessorFactories : IProcessorFactories
    {
        private readonly WinApiWrapper _winApi;
        private readonly FormDto _formDto;

        public ProcessorFactories(WinApiWrapper winApi, FormDto formDto)
        {
            _winApi = winApi;
            _formDto = formDto;
        }

        public IProcessor CreateTelegramProcessor() =>
            new TelegramProcessor(_winApi, _formDto,
                 new TelegramControlsCoords());

        public IProcessor CreateViberProcessor() =>
            new ViberProcessor(_winApi, _formDto,
                 new ViberControlsCoords(_winApi,
                     WinApi.FindWindowA(WindowClass.Viber.Name, null)));

        public IProcessor CreateFacebookProcessor() =>
            new FacebookProcessor(_winApi, _formDto);

        public IProcessor CreateEmailProcessor(MailMessageDto dto) =>
            new EmailProcessor(dto);
    }
}
