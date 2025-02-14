
namespace _2___Servicios.Interfaces
{
    public interface ILogger
    {
        Task<IEnumerable<string>> GetLogEntriesAsync();
        Task WriteLogEntryAsync(string logEntry);
        Task ManageDeleteLogEntriesAsync();
        string GenerateLogWarning(string logEntry, decimal actualData, decimal newData);
    }
}
