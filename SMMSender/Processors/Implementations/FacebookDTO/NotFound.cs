namespace SMMSender.Processors.Implementations.FacebookDTO
{
    public class NotFound : IResult
    {
        public string Error { get; }

        public NotFound(string error)
        {
            Error = error;
        }
    }
}
