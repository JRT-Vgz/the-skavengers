using _1_Domain.Armory.Entities;
using _1_Domain.Armory.Interfaces;
using _3_Data.Armory;
using _3_Data.Armory.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _3_Repository.Armory
{
    public class ScriptRepository : IArmoryRepository<Script>
    {
        private readonly ArmoryDbContext _context;
        private readonly IMapper _mapper;

        public ScriptRepository(ArmoryDbContext context,
            IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Script>> GetAllAsync()
        {
            var scriptModels = await _context.Scripts.ToListAsync();

            return scriptModels.Select(s => _mapper.Map<Script>(s));
        }

        public async Task AddAsync(Script script)
        {
            var scriptModel = _mapper.Map<ScriptModel>(script);

            await _context.Scripts.AddAsync(scriptModel);
            await _context.SaveChangesAsync();  
        }

        public async Task UpdateAsync(Script script)
        {
            var scriptModel = await _context.Scripts.FirstOrDefaultAsync(s => s.Id == script.Id);

            if (scriptModel == null) { throw new KeyNotFoundException($"No se ha encontrado el script con Id {script.Id} en la base de datos."); }

            _mapper.Map(script, scriptModel);

            _context.Scripts.Attach(scriptModel);
            _context.Scripts.Entry(scriptModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Script script)
        {
            var scriptModel = await _context.Scripts.FirstOrDefaultAsync(s => s.Id == script.Id);

            if (scriptModel == null) { throw new KeyNotFoundException($"No se ha encontrado el script con Id {script.Id} en la base de datos."); }

            _context.Scripts.Remove(scriptModel);
            await _context.SaveChangesAsync();
        }
    }
}
