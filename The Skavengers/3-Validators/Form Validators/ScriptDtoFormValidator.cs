
using _1_Domain.Armory.Interfaces;
using _2_Application.TheSkavengers.Services;
using _3_Encrypters.TheSkavengers;
using _3_Mappers.Armory.Dtos;
using System.Text.RegularExpressions;

namespace _3_Validators.Armory.Form_Validators
{
    public class ScriptDtoFormValidator : IFormValidator<ScriptDto>
    {
        private readonly ConstantsConfigurationService _configuration;
        public string Error { get; set; }

        public ScriptDtoFormValidator(ConstantsConfigurationService configuration)
        {
            _configuration = configuration;
        }

        public bool Validate(ScriptDto scriptDto)
        {
            // NAME:
            if (scriptDto.Name == "")
            {
                Error = "Escribe un nombre para el script.";
                return false;
            }

            if (scriptDto.Name.Length > _configuration.GetInt("Armory_Constants:_MAX_LENGTH_SCRIPT_NAME_TEXTBOX"))
            {
                Error = "El nombre del script solo puede tener un máximo de " +
                    $"{_configuration.GetInt("Armory_Constants:_MAX_LENGTH_SCRIPT_NAME_TEXTBOX")} caracteres.";
                return false;
            }

            // VERSION:
            if (scriptDto.Version == "")
            {
                Error = "Escribe la versión del script.";
                return false;
            }

            if (scriptDto.Version.Length > _configuration.GetInt("Armory_Constants:_MAX_LENGTH_SCRIPT_VERSION_TEXTBOX"))
            {
                Error = "La versión del script solo puede tener un máximo de " +
                    $"{_configuration.GetInt("Armory_Constants:_MAX_LENGTH_SCRIPT_VERSION_TEXTBOX")} caracteres.";
                return false;
            }

            if (!Regex.IsMatch(scriptDto.Version, @"^\d{1,2}\.\d{1,2}$"))
            {
                Error = "La versión del script debe tener un formato válido (ej: 1.3).";
                return false;
            }

            // DESCRIPTION:
            if (scriptDto.Description == "")
            {
                Error = "Escribe una breve descripción del script.";
                return false;
            }

            if (scriptDto.Description.Length > _configuration.GetInt("Armory_Constants:_MAX_LENGTH_SCRIPT_DESCRIPTION_TEXTBOX"))
            {
                Error = "La descripción del script solo puede tener un máximo de " +
                    $"{_configuration.GetInt("Armory_Constants:_MAX_LENGTH_SCRIPT_DESCRIPTION_TEXTBOX")} caracteres.";
                return false;
            }

            // WARNING:
            if (scriptDto.Warning.Length > _configuration.GetInt("Armory_Constants:_MAX_LENGTH_SCRIPT_WARNING_TEXTBOX"))
            {
                Error = "La advertencia del script solo puede tener un máximo de " +
                    $"{_configuration.GetInt("Armory_Constants:_MAX_LENGTH_SCRIPT_WARNING_TEXTBOX")} caracteres.";
                return false;
            }

            // CONTENT:
            if (scriptDto.Content == "")
            {
                Error = "El archivo que has cargado no tiene ningún contenido.";
                return false;
            }

            return true;
        }
    }
}
