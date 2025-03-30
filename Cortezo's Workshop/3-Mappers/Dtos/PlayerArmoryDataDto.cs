
namespace _3_Mappers.Dtos
{
    public class PlayerArmoryDataDto
    {
        public string PlayerName { get; set; }
        public List<string> PlayerAlterEgos { get; set; }
        public string TemplateName { get; set; }
        public string EchoSkillName { get; set; }
        public double EchoSkillLevel { get; set; }

        public bool ActivarAspecto { get; set; }
        public bool ActivarAspectoArma { get; set; }
        public bool ActivarAspectoLibro { get; set; }
        public bool ActivarAspectoArmadura { get; set; }
        public int IdAspectoArma { get; set; }
        public int IdAspectoLibro { get; set; }
        public int IdAspectoArmadura { get; set; }

        public List<ArmorPieceDataDto> ArmorPieces { get; set; }

        public PlayerArmoryDataDto(string playerName, List<string> playerAlterEgos, string templateName, string echoSkillName, 
            double echoSkillLevel, bool activarAspecto, bool activarAspectoArma, bool activarAspectoLibro, bool activarAspectoArmadura,
            int idAspectoArma, int idAspectoLibro, int idAspectoArmadura, List<ArmorPieceDataDto> armorPieces) 
        { 
            PlayerName = playerName;
            PlayerAlterEgos = playerAlterEgos;
            TemplateName = templateName;
            EchoSkillName = echoSkillName;
            EchoSkillLevel = echoSkillLevel;
            ActivarAspecto = activarAspecto;
            ActivarAspectoArma = activarAspectoArma;
            ActivarAspectoLibro = activarAspectoLibro;
            ActivarAspectoArmadura = activarAspectoArmadura;
            IdAspectoArma = idAspectoArma;
            IdAspectoLibro = idAspectoLibro;
            IdAspectoArmadura = idAspectoArmadura;
            ArmorPieces = armorPieces;
        }
    }
}
