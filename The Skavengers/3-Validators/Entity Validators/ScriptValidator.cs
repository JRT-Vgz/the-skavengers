
using _1_Domain.Armory.Entities;
using _1_Domain.Armory.Interfaces;
using _3_Data.Armory;
using Microsoft.EntityFrameworkCore;

namespace _3_Validators.Armory.Entity_Validators
{
    public class ScriptValidator : IEntityValidator<Script>
    {
        private readonly ArmoryDbContext _context;
        public string Error { get; set; }

        public ScriptValidator(ArmoryDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidateAddEntityAsync(Script script)
        {
            var scriptModel = await _context.Scripts.FirstOrDefaultAsync(s => s.Name == script.Name);
            if (scriptModel != null)
            {
                Error = "Ya existe un script con ese nombre.";
                return false;
            }

            return true;
        }

        public async Task<bool> ValidateUpdateEntityAsync(Script script)
        {
            var scriptModel = await _context.Scripts.FirstOrDefaultAsync(s => s.Id == script.Id);
            if (scriptModel == null)
            {
                Error = $"No se ha encontrado el script con Id {script.Id} en la base de datos.";
                return false;
            }

            return true;
        }
    }
}
