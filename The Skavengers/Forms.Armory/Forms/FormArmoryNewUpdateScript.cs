using _1_Domain.Armory.Entities;
using _1_Domain.TheSkavengers.Interfaces;
using _2_Application.Armory.Exceptions;
using _2_Application.Armory.Services.Script_Services;
using _2_Application.TheSkavengers.Services;
using _3_Mappers.Armory.Dtos;

namespace Forms.Armory.Forms
{
    public partial class FormArmoryNewUpdateScript : Form
    {
        #region Constructor
        private readonly ConstantsConfigurationService _configuration;
        private readonly ISoundSystem _soundSystem;
        private readonly AddScriptService<ScriptDto> _addScriptService;
        private readonly UpdateScriptService<ScriptDto> _updateScriptService;

        private bool _isEditing = false;
        private ScriptDto _scriptDto = new ScriptDto();

        public FormArmoryNewUpdateScript(ConstantsConfigurationService configuration,
            ISoundSystem soundSystem,
            AddScriptService<ScriptDto> addScriptService,
            UpdateScriptService<ScriptDto> updateScriptService)
        {
            InitializeComponent();
            _configuration = configuration;
            _soundSystem = soundSystem;
            _addScriptService = addScriptService;
            _updateScriptService = updateScriptService;
        }
        #endregion

        private void FormArmoryNewUpdateScript_Load(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_OPEN_CHEST"]);
        }

        public void SetInfo(Script script)
        {
            _isEditing = true;
            _scriptDto.Id = script.Id;
            _scriptDto.Content = script.Content;

            this.Text = "Editar script";
            txt_scriptName.Text = script.Name;
            txt_scriptVersion.Text = script.Version;
            txt_scriptDescription.Text = script.Description;
            txt_scriptWarning.Text = script.Warning;
        }


        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------- FORMATO DE TEXT BOXES -------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        // NAME:
        private void txt_scriptName_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (textBox.Text.Length == _configuration.GetInt("Armory_Constants:_MAX_LENGTH_SCRIPT_NAME_TEXTBOX")
                && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // VERSION:
        private void txt_scriptVersion_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == '.')
                {
                    if (textBox.Text.Contains('.')) { e.Handled = true; }
                }
                else { e.Handled = true; }
            }

            if (textBox.Text.Length == _configuration.GetInt("Armory_Constants:_MAX_LENGTH_SCRIPT_VERSION_TEXTBOX")
                && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // DESCRIPTION:
        private void txt_scriptDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (textBox.Text.Length == _configuration.GetInt("Armory_Constants:_MAX_LENGTH_SCRIPT_DESCRIPTION_TEXTBOX")
                && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // WARNING:
        private void txt_scriptWarning_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (textBox.Text.Length == _configuration.GetInt("Armory_Constants:_MAX_LENGTH_SCRIPT_WARNING_TEXTBOX")
                && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // PASSWORD:
        private void txt_armoryPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (textBox.Text.Length == _configuration.GetInt("Armory_Constants:_MAX_LENGTH_ARMORY_PASSWORD_TEXTBOX")
                && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- CARGAR ARCHIVO ----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_loadFile_Click(object sender, EventArgs e)
        {
            ofd_loadFile.Filter = "Archivos de texto (*.txt)|*.txt";
            ofd_loadFile.Title = "Selecciona un archivo de texto";

            if (ofd_loadFile.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd_loadFile.FileName;

                if (Path.GetExtension(filePath).ToLower() != ".txt")
                {
                    MessageBox.Show("Solo se permiten archivos .txt.");
                    return;
                }

                lbl_loadFileName.Text = ofd_loadFile.SafeFileName;
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- GUARDAR SCRIPT ----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void btn_save_Click(object sender, EventArgs e)
        {
            string filePath = ofd_loadFile.FileName;

            // If file is loaded, always read it. If editing mode is false, always try to read the file.
            if (filePath != "" || _isEditing == false)
            {
                try
                {
                    string content = File.ReadAllText(filePath);
                    _scriptDto.Content = content;
                }
                catch (Exception ex) { MessageBox.Show("Ocurrió un error al leer el archivo."); return; }
            }

            string name = txt_scriptName.Text;
            string version = txt_scriptVersion.Text;
            string description = txt_scriptDescription.Text;
            string warning = txt_scriptWarning.Text;
            string armoryPassword = txt_armoryPassword.Text;

            _scriptDto.Name = name;
            _scriptDto.Version = version;
            _scriptDto.Description = description;
            _scriptDto.Warning = warning;

            try
            {
                if (_isEditing == true) { await _updateScriptService.ExecuteAsync(_scriptDto, armoryPassword); }
                else { await _addScriptService.ExecuteAsync(_scriptDto, armoryPassword); }

                btn_back_Click(sender, e);
            }
            catch (AuthNValidationException ex)
            {
                _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_MAGIC_WORD"]);
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------------- VOLVER --------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_back_Click(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_CLOSE_CHEST"]);

            this.Close();
        }
    }
}
