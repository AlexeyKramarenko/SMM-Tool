namespace SMMSender.DTO
{
    public class FormDto
    {

        public string Body { get; }
        public string ImagePath { get; }

        public FormDto(string body, string imagePath)
        {
            if (string.IsNullOrEmpty(body))
                throw new ArgumentException("Body should not be empty.");

            if (string.IsNullOrEmpty(imagePath))
                throw new ArgumentException("Image should be uploaded.");

            Body = body;
            ImagePath = imagePath;
        }

    }
}
