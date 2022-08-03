namespace SMMTool.DTO
{
    public class ProcessDto
    {

        public string ProcessName { get; }
        public string FilePath { get; }

        public ProcessDto(string processName, string filePath)
        {
            if (string.IsNullOrEmpty(processName))
                throw new ArgumentException($"'{nameof(processName)}' cannot be null or empty.", nameof(processName));

            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException($"'{nameof(filePath)}' cannot be null or empty.", nameof(filePath));

            ProcessName = processName;
            FilePath = filePath;
        }

    }
}
