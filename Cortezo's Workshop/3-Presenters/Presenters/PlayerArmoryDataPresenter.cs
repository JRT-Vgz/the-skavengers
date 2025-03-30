
using _2___Servicios.Interfaces;
using _3_Mappers.Dtos;

namespace _3_Presenters.Presenters
{
    public class PlayerArmoryDataPresenter : IPresenter<PlayerArmoryDataDto, string>
    {
        public string Present(PlayerArmoryDataDto playerArmoryDataDto)
        {
            string autoEquipScript = string.Empty;

            // ENCABEZADO
            autoEquipScript += "#######################################################################################################\n" +
                $"#                                            {playerArmoryDataDto.PlayerName.ToUpper()} - {playerArmoryDataDto.TemplateName.ToUpper()}\n" +
                "#######################################################################################################\n";

            // PERSONAJE Y SKILL DE ECHO. CREACIÓN DE LA LISTA.
            autoEquipScript += $"if name = '{playerArmoryDataDto.PlayerName}' ";

            if (playerArmoryDataDto.PlayerAlterEgos.Count > 0)
            {
                foreach (var alterEgo in playerArmoryDataDto.PlayerAlterEgos)
                {
                    autoEquipScript += $"or name = '{alterEgo}' ";
                }
            }
            autoEquipScript += $"and skill {playerArmoryDataDto.EchoSkillName.ToLower()} = {playerArmoryDataDto.EchoSkillLevel}\n" +



                $"\tremovelist '{playerArmoryDataDto.PlayerName}-{playerArmoryDataDto.TemplateName}'\n" +
                $"\tcreatelist '{playerArmoryDataDto.PlayerName}-{playerArmoryDataDto.TemplateName}'\n" +
                "\n";

            // VARIABLES
            autoEquipScript += "########################## VARIABLES: ##########################\n" +
                "\t# Los hues genéricos se tienen que configurar manualmente si quieres usarlos. No son imprescindibles. Pregunta a Vargath.\n" +
                $"\tsetvar! HUE_ARMADURA 0\n" +
                $"\tsetvar! HUE_ARMA 0\n" +
                $"\tsetvar! HUE_ESCUDO 0\n" +
                "\n" +
                "\t# 1 = activar, 0 = no activar\n" +
                $"\tsetvar! ACTIVAR_ASPECTO {Convert.ToInt32(playerArmoryDataDto.ActivarAspecto)}\n" +
                "\n" +
                $"\tsetvar! ACTIVAR_ASPECTO_ARMA {Convert.ToInt32(playerArmoryDataDto.ActivarAspectoArma)}\n" +
                $"\tsetvar! ACTIVAR_ASPECTO_LIBRO {Convert.ToInt32(playerArmoryDataDto.ActivarAspectoLibro)}\n" +
                $"\tsetvar! ACTIVAR_ASPECTO_ARMADURA {Convert.ToInt32(playerArmoryDataDto.ActivarAspectoArmadura)}\n" +
                "\n" +
                $"\tsetvar! ID_ASPECTO_ARMA {playerArmoryDataDto.IdAspectoArma}\n" +
                $"\tsetvar! ID_ASPECTO_LIBRO {playerArmoryDataDto.IdAspectoLibro}\n" +
                $"\tsetvar! ID_ASPECTO_ARMADURA {playerArmoryDataDto.IdAspectoArmadura}\n" +
                "\n" +
                "\n";

            // ITEMS
            foreach (var armorPiece in playerArmoryDataDto.ArmorPieces)
            {
                if (armorPiece.LayerName == "Hair") { continue; }

                autoEquipScript += $"########################## {armorPiece.LayerName}: ##########################\n";

                if (armorPiece.LayerName == "Talisman") 
                {
                    autoEquipScript += $"\twhile findtype {armorPiece.Graphic} backpack {armorPiece.Hue} as item\n";
                }
                else 
                {
                    autoEquipScript += $"\twhile findtype '{armorPiece.ItemName}' backpack {armorPiece.Hue} as item\n"; 
                }

                autoEquipScript += "\t\tgetlabel item descripcion\n" +
                    $"\tif '{armorPiece.ItemQuality}' in descripcion\n" +
                    $"\t\tpushlist '{playerArmoryDataDto.PlayerName}-{playerArmoryDataDto.TemplateName}' item\n" +
                    "\tendif\n" +
                    "\tignore item\n" +
                    "\tendwhile\n";
            }
            
            // FINAL
            autoEquipScript += "\n####################################\n" +
                $"\tforeach 'item' in '{playerArmoryDataDto.PlayerName}-{playerArmoryDataDto.TemplateName}'\n" +
                $"\t\tpushlist 'Lista' 'item'\n" +
                $"\tendfor\n" +
                $"endif\n";

            return autoEquipScript;
        }
    }
}
