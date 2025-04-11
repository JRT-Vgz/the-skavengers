using _3_Data.CortezosWorkshop;
using _3_Repository.CortezosWorkshop.QueryObjects.QueryResults;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository.CortezosWorkshop.QueryObjects
{
    public class LogQuery
    {
        private readonly AppDbContext _context;
        public LogQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LogResult>> GetLogsAsync()
        {
            var logs = await _context.Logs
                                  .OrderByDescending(log => log.Date)
                                  .Take(20)
                                  .Select(l => new LogResult { Entry = l.Entry })
                                  .ToListAsync();

            return logs;

        }
    }
}
