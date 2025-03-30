using _2___Servicios.Interfaces;
using _2___Servicios.Services;
using _2___Servicios.Services.ArmoryServices;
using _3_Mappers.Dtos;
using System.Text.Json;

namespace CortezosWorkshop.Armeria
{
    public partial class FormArmeriaMain : Form
    {
        #region Constructor

        private readonly IServiceProvider _serviceProvider;
        private readonly ConfigurationService _configuration;
        private readonly CreateAutoEquipScriptTemplateService<PlayerArmoryDataDto> _createAutoEquipScriptTemplateService;
        private readonly ISoundSystem _soundSystem;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        private Dictionary<string, int> _aspects;
        private string _portaPapeles;
        private List<ArmorPieceDataDto> _armorPieceDataDtos;
        private List<string> _alterEgos;

        private bool _textEchoSkillClick = false;

        public FormArmeriaMain(IServiceProvider serviceProvider,
            ConfigurationService configuration,
            CreateAutoEquipScriptTemplateService<PlayerArmoryDataDto> createAutoEquipScriptTemplateService,
            ISoundSystem soundSystem)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            _createAutoEquipScriptTemplateService = createAutoEquipScriptTemplateService;
            _soundSystem = soundSystem;

            _jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            _armorPieceDataDtos = new List<ArmorPieceDataDto>();
            _alterEgos = new List<string>();
            _aspects = new Dictionary<string, int>();
        }
        #endregion


        private void FormArmeriaMain_Load(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_OPEN_DOOR"]);

            InitializeAspectComboboxes();
            ApplyDefaultSettings();
            ActivateDeactivateAspectForm();
        }

        private void InitializeAspectComboboxes()
        {
            _aspects.Add("Air", 0);
            _aspects.Add("Arcane", 1);
            _aspects.Add("Artisan", 2);
            _aspects.Add("Blood", 3);
            _aspects.Add("Command", 4);
            _aspects.Add("Death", 5);
            _aspects.Add("Discipline", 6);
            _aspects.Add("Earth", 7);
            _aspects.Add("Eldritch", 8);
            _aspects.Add("Fire", 9);
            _aspects.Add("Fortune", 10);
            _aspects.Add("Frost", 11);
            _aspects.Add("Gadget", 12);
            _aspects.Add("Harvest", 13);
            _aspects.Add("Holy", 14);
            _aspects.Add("Lightning", 15);
            _aspects.Add("Lyric", 16);
            _aspects.Add("Madness", 17);
            _aspects.Add("Poison", 18);
            _aspects.Add("Shadow", 19);
            _aspects.Add("Void", 20);
            _aspects.Add("War", 21);
            _aspects.Add("Water", 22);

            cbo_weaponAspect.DataSource = new BindingSource(_aspects, null);
            cbo_weaponAspect.DisplayMember = "Key";
            cbo_weaponAspect.ValueMember = "Value";

            cbo_spellbookAspect.DataSource = new BindingSource(_aspects, null);
            cbo_spellbookAspect.DisplayMember = "Key";
            cbo_spellbookAspect.ValueMember = "Value";

            cbo_armorAspect.DataSource = new BindingSource(_aspects, null);
            cbo_armorAspect.DisplayMember = "Key";
            cbo_armorAspect.ValueMember = "Value";
        }
        private void ApplyDefaultSettings()
        {
            txt_echoSkillLevel.Text = "0";
            chk_activateAspect.Checked = true;
            chk_activateArmorAspect.Checked = true;
            chk_shoulders.Checked = true;
            chk_chest.Checked = true;
            chk_legs.Checked = true;
        }

        private void AlterEgoDataLoad()
        {
            var labels = new Label[]
            {
                lbl_alterEgo1, lbl_alterEgo2, lbl_alterEgo3, lbl_alterEgo4, lbl_alterEgo5,
                lbl_alterEgo6, lbl_alterEgo7, lbl_alterEgo8, lbl_alterEgo9, lbl_alterEgo10,
                lbl_alterEgo11, lbl_alterEgo12, lbl_alterEgo13, lbl_alterEgo14, lbl_alterEgo15
            };

            int length = Math.Min(labels.Length, _alterEgos.Count);

            for (int i = 0; i < length; i++)
            {
                labels[i].Text = _alterEgos[i];
            }
        }

        private void ActivateDeactivateAspectForm()
        {
            bool aspectActivated = chk_activateAspect.Checked;

            if (aspectActivated)
            {
                chk_activateWeaponAspect.Enabled = true;
                chk_activateSpellbookAspect.Enabled = true;
                chk_activateArmorAspect.Enabled = true;
            }
            else
            {
                chk_activateWeaponAspect.Enabled = false;
                chk_activateSpellbookAspect.Enabled = false;
                chk_activateArmorAspect.Enabled = false;
            }
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- FORMULARIO INICIAL ------------------------------------------
        // -------------------------------------------------------------------------------------------------------

        private void txt_playerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter
            {
                e.Handled = true;
                this.SelectNextControl((Control)sender, true, true, true, true); // Mover al siguiente control (simular Tab)
            }
        }

        private void txt_templateName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter
            {
                e.Handled = true;
                this.SelectNextControl((Control)sender, true, true, true, true); // Mover al siguiente control (simular Tab)
            }
        }

        private void txt_echoSkillName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // Enter
            {
                e.Handled = true;
                this.SelectNextControl((Control)sender, true, true, true, true); // Mover al siguiente control (simular Tab)
            }
        }

        private void txt_echoSkillLevel_Enter(object sender, EventArgs e)
        {
            if (!_textEchoSkillClick)
            {
                _textEchoSkillClick = true;
                txt_echoSkillLevel.Text = "";
            }
        }

        private void txt_echoSkillLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);

            if (e.KeyChar == (char)13) // Enter
            {
                e.Handled = true;
                this.SelectNextControl((Control)sender, true, true, true, true); // Mover al siguiente control (simular Tab)
            }

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == '.' && textBox.SelectionStart != 0 && !textBox.Text.Contains(".")) { return; }

                e.Handled = true;
            }

            if (textBox.Text.Length > 5 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (textBox.Text.Contains("."))
            {
                int indexOfDot = textBox.Text.IndexOf(".");

                if (textBox.Text.Length - indexOfDot > 2 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- FORMULARIO ALTER EGOS -----------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_addAlterEgo_Click(object sender, EventArgs e)
        {
            string alterEgoName = txt_alterEgo.Text;

            if (alterEgoName != null && alterEgoName != "")
            {
                if (_alterEgos.Count() == 15) { MessageBox.Show("No puedes tener más alter egos."); return; }

                if (_alterEgos.Contains(alterEgoName)) { return; }

                _alterEgos.Add(alterEgoName);
                AlterEgoDataLoad();
            }
        }

        private void txt_alterEgo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            if (!IsBasicLetter(keyChar) && !char.IsControl(keyChar)) { e.Handled = true; }
            if (e.KeyChar == (char)13) // Enter
            {
                btn_addAlterEgo_Click(sender, e);
                txt_alterEgo.Text = "";
                e.Handled = true;
            }
        }
        private bool IsBasicLetter(char c)
        {
            // Comprobar si el carácter es una letra del alfabeto básico sin acento ni diéresis
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == ' ';
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- ACTIVAR ASPECTO ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------

        private void chk_activateAspect_CheckedChanged(object sender, EventArgs e)
        {
            bool weaponActive = chk_activateWeaponAspect.Checked;
            bool spellbookActive = chk_activateSpellbookAspect.Checked;
            bool armorActive = chk_activateArmorAspect.Checked;

            bool aspectActive = chk_activateAspect.Checked;

            if (weaponActive) { chk_activateSpellbookAspect.Checked = false; }
            else if (spellbookActive) { chk_activateWeaponAspect.Checked = false; }

            ActivateDeactivateAspectForm();
        }

        private void chk_activateWeaponAspect_CheckedChanged(object sender, EventArgs e)
        {
            bool weaponActive = chk_activateWeaponAspect.Checked;
            if (weaponActive) { chk_activateSpellbookAspect.Checked = false; }
        }

        private void chk_activateSpellbookAspect_CheckedChanged(object sender, EventArgs e)
        {
            bool spellbookActive = chk_activateSpellbookAspect.Checked;
            if (spellbookActive) { chk_activateWeaponAspect.Checked = false; }
        }



        // -------------------------------------------------------------------------------------------------------
        // ------------------------- PEGAR EQUIPO DEL PORTAPAPELES Y COPIAR PLANTILLA ----------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_pegarDatos_Click(object sender, EventArgs e)
        {
            _portaPapeles = Clipboard.GetText();

            try
            {
                _armorPieceDataDtos = JsonSerializer.Deserialize<List<ArmorPieceDataDto>>(_portaPapeles, _jsonSerializerOptions);
                chk_itemsLoaded.Checked = true;
            }
            catch (Exception)
            {
                chk_itemsLoaded.Checked = false;
                MessageBox.Show("Los datos no se han pegado correctamente.\nVuelve a cogerlos del juego.");
                return;
            }

            ApplyItemQualityPropertyToPieces();
        }

        private void ApplyItemQualityPropertyToPieces()
        {
            foreach (var armorPiece in _armorPieceDataDtos)
            {
                if (armorPiece.LayerName == "OneHanded" && armorPiece.Hue == 2606) { armorPiece.ItemQuality = "potent"; }
                else if (armorPiece.LayerName == "OneHanded") { armorPiece.ItemQuality = "exceptional"; armorPiece.GenericHue = "HUE_1H"; }
                else if (armorPiece.LayerName == "TwoHanded") { armorPiece.ItemQuality = "exceptional"; armorPiece.GenericHue = "HUE_2H"; }
                else if (armorPiece.LayerName == "Outerbody") { armorPiece.ItemQuality = "exceptional"; armorPiece.GenericHue = "HUE_SATCHEL"; }
                else if (armorPiece.LayerName == "Quiver") { armorPiece.ItemQuality = "exceptional"; armorPiece.GenericHue = "HUE_QUIVER"; }
                else if (armorPiece.LayerName == "ArmorHelm" && chk_helm.Checked) { armorPiece.ItemQuality = "exceptional"; armorPiece.GenericHue = "HUE_ARMADURA"; }
                else if (armorPiece.LayerName == "ArmorNeck" && chk_gorget.Checked) { armorPiece.ItemQuality = "exceptional"; armorPiece.GenericHue = "HUE_ARMADURA"; }
                else if (armorPiece.LayerName == "ArmorGloves" && chk_gloves.Checked) { armorPiece.ItemQuality = "exceptional"; armorPiece.GenericHue = "HUE_ARMADURA"; }
                else if (armorPiece.LayerName == "ArmorArms" && chk_shoulders.Checked) { armorPiece.ItemQuality = "exceptional"; armorPiece.GenericHue = "HUE_ARMADURA"; }
                else if (armorPiece.LayerName == "ArmorChest" && chk_chest.Checked) { armorPiece.ItemQuality = "exceptional"; armorPiece.GenericHue = "HUE_ARMADURA"; }
                else if (armorPiece.LayerName == "ArmorLegs" && chk_legs.Checked) { armorPiece.ItemQuality = "exceptional"; armorPiece.GenericHue = "HUE_ARMADURA"; }
                else { armorPiece.ItemQuality = "blessed"; }
            }
        }

        private void btn_crearPlantilla_Click(object sender, EventArgs e)
        {
            string playerName = txt_playerName.Text;
            string templateName = txt_templateName.Text;
            string echoSkillName = txt_echoSkillName.Text;

            double echoSkillLevel = 0d;
            try { echoSkillLevel = double.Parse(txt_echoSkillLevel.Text); }
            catch (FormatException) { }

            bool activarAspecto = chk_activateAspect.Checked;
            bool activarAspectoArma = chk_activateWeaponAspect.Checked;
            bool activarAspectoLibro = chk_activateSpellbookAspect.Checked;
            bool activarAspectoArmadura = chk_activateArmorAspect.Checked;
            int idAspectoArma = cbo_weaponAspect.SelectedIndex;
            int idAspectoLibro = cbo_spellbookAspect.SelectedIndex;
            int idAspectoArmadura = cbo_armorAspect.SelectedIndex;

            bool validationSuccess = ValidateItemsLoadedCorrectly();
            if (!validationSuccess) { return; }

            validationSuccess = ValidateInitialFormData(playerName, templateName, echoSkillName, echoSkillLevel);
            if (!validationSuccess) { return; }

            var playerArmoryDataDto = new PlayerArmoryDataDto(playerName, _alterEgos, templateName, echoSkillName, echoSkillLevel,
                activarAspecto, activarAspectoArma, activarAspectoLibro, activarAspectoArmadura,
                idAspectoArma, idAspectoLibro, idAspectoArmadura, _armorPieceDataDtos);
            playerArmoryDataDto.ConfigurePlayerGenericHueData();

            string scriptTemplate = _createAutoEquipScriptTemplateService.Execute(playerArmoryDataDto);
            Clipboard.SetText(scriptTemplate);

            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_COPY_ALL_PRICES"]);
        }

        private bool ValidateItemsLoadedCorrectly()
        {
            if (!chk_itemsLoaded.Checked)
            {
                MessageBox.Show("Pega el inventario de tu personaje desde el portapapeles.");
                return false;
            }
            return true;
        }

        private bool ValidateInitialFormData(string playerName, string templateName, string echoSkillName, double echoSkillLevel)
        {
            if (playerName == null || playerName == "")
            {
                MessageBox.Show("Escribe el nombre del personaje.");
                return false;
            }

            if (templateName == null || templateName == "")
            {
                MessageBox.Show("Escribe un nombre para la plantilla.");
                return false;
            }

            if (echoSkillName == null || echoSkillName == "")
            {
                MessageBox.Show("Escribe el nombre de una skill representativa del Echo.");
                return false;
            }

            if (echoSkillLevel == 0)
            {
                MessageBox.Show("Asigna un valor correcto para la skill representativa del Echo.");
                return false;
            }

            if (_armorPieceDataDtos.Count <= 0)
            {
                MessageBox.Show("Falta pegar el equipo desde el portapapeles.");
                return false;
            }
            return true;
        }



        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------------- NAVEGACIÓN ------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormArmeriaMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btn_menu_principal_Click(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_CLOSE_DOOR"]);

            var frmTheSkavengersMain = Application.OpenForms.OfType<FormTheSkavengersMain>().FirstOrDefault();
            frmTheSkavengersMain.Location = new Point(this.Location.X, this.Location.Y); ;

            this.Hide();
        }
    }

}

