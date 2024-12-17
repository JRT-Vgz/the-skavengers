
using _2___Servicios.Interfaces;
using _3___Data;
using _3___Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _3_Loggers
{
    public class Logger : ILogger
    {
        private readonly AppDbContext _context;
        public Logger(AppDbContext context)
        {
            _context = context;
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

            if (logs.Count >= 200)
            {
                var logsToDelete = logs.OrderBy(log => log.Date)
                                       .Take(100);

               _context.Logs.RemoveRange(logsToDelete);
            }
        }
    }
}
