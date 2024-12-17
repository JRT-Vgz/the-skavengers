
namespace _2___Servicios.Interfaces
{
    public interface ILogger
    {
        Task WriteLogEntryAsync(string logEntry);
        Task ManageDeleteLogEntriesAsync();
    }
}
