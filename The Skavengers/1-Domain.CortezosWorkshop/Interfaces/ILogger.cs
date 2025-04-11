
namespace _1_Domain.CortezosWorkshop.Interfaces
{
    public interface ILogger
    {
        Task<IEnumerable<string>> GetLogEntriesAsync();
        Task WriteLogEntryAsync(string logEntry);
        string GenerateLogWarning(string logEntry, decimal actualData, decimal newData);
    }
}
