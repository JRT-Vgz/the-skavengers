
using _2___Servicios.Interfaces;
using _2___Servicios.Services;
using _3___Data;
using _3___Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _3_Loggers
{
    public class Logger : ILogger
    {
        private readonly AppDbContext _context;
        private readonly ConfigurationService _configuration;

        public Logger(AppDbContext context, 
            ConfigurationService configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task WriteLogEntryAsync(string logEntry)
        {
            var logModel = new LogModel 
            { 
                Entry = logEntry,
                Date = DateTime.Now
            };

            await _context.Logs.AddAsync(logModel);

            await ManageDeleteLogEntriesAsync();

            await _context.SaveChangesAsync();
        }

        public async Task ManageDeleteLogEntriesAsync()
        {
            var logs = await _context.Logs.ToListAsync();

            var _LOG_MAX_ENTRIES = _configuration.GetInt("Constants:_LOG_MAX_ENTRIES");
            var _NUMBER_OF_ENTRIES_TO_DELETE = _configuration.GetInt("Constants:_LOG_DELETE_ENTRIES_WHEN_MAX_REACHED");

            if (logs.Count >= _LOG_MAX_ENTRIES)
            {
                var logsToDelete = logs.OrderBy(log => log.Date)
                                       .Take(_NUMBER_OF_ENTRIES_TO_DELETE);

               _context.Logs.RemoveRange(logsToDelete);
            }
        }
    }
}
