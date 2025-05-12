using _1_Domain.Armory.Entities;
using _1_Domain.TheSkavengers.Interfaces;
using _2_Application.Armory.Services.Armory_AuthN_Services;
using _2_Application.Armory.Services.Script_Services;
using _2_Application.TheSkavengers.Services;
using Microsoft.Extensions.DependencyInjection;
namespace Forms.Armory.Forms
{
    public partial class FormArmoryMain : Form
    {
        #region Constructor
        private readonly IServiceProvider _serviceProvider;
        private readonly GetAllScriptsService _getAllScriptsService;
        private readonly DeleteScriptService _deleteScriptService;
        private readonly ConstantsConfigurationService _configuration;
        private readonly ArmoryAuthNService _armoryAuthNService;
        private readonly ISoundSystem _soundSystem;

        private IEnumerable<Script> _scripts;

        public FormArmoryMain(IServiceProvider serviceProvider,
            GetAllScriptsService getAllScriptsService,
            DeleteScriptService deleteScriptService,
            ConstantsConfigurationService configuration,
            ArmoryAuthNService armoryAuthNService,
            ISoundSystem soundSystem)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _getAllScriptsService = getAllScriptsService;
            _deleteScriptService = deleteScriptService;
            _configuration = configuration;
            _armoryAuthNService = armoryAuthNService;
            _soundSystem = soundSystem;
        }
        #endregion

        private async void FormArmoryMain_Load(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_OPEN_DOOR"]);
            CreateColumns();
            await RefreshColumns();

        }

        private void CreateColumns()
        {
            dgv_scripts.AutoGenerateColumns = false;
            dgv_scripts.Columns.Clear();
            dgv_scripts.DefaultCellStyle.SelectionBackColor = dgv_scripts.DefaultCellStyle.BackColor;
            dgv_scripts.DefaultCellStyle.SelectionForeColor = dgv_scripts.DefaultCellStyle.ForeColor;

            dgv_scripts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Name",
                Name = "colName",
                Width = 165
            });

            var versionColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Versión",
                DataPropertyName = "Version",
                Name = "colVersion",
                Width = 55,
            };
            versionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_scripts.Columns.Add(versionColumn);

            dgv_scripts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Descripción",
                DataPropertyName = "Description",
                Name = "colDescription",
                Width = 380
            });

            var copyButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colCopy",
                Text = "Copiar",
                UseColumnTextForButtonValue = true,
                Width = 65
            };
            copyButtonColumn.DefaultCellStyle.BackColor = Color.LimeGreen;
            copyButtonColumn.DefaultCellStyle.SelectionBackColor = Color.LimeGreen;
            dgv_scripts.Columns.Add(copyButtonColumn);

            var editButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colEdit",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                Width = 65
            };
            editButtonColumn.DefaultCellStyle.BackColor = Color.GreenYellow;
            editButtonColumn.DefaultCellStyle.SelectionBackColor = Color.GreenYellow;
            dgv_scripts.Columns.Add(editButtonColumn);

            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "colDelete",
                Text = "Borrar",
                UseColumnTextForButtonValue = true,
                Width = 65
            };
            deleteButtonColumn.DefaultCellStyle.BackColor = Color.PaleVioletRed;
            deleteButtonColumn.DefaultCellStyle.SelectionBackColor = Color.PaleVioletRed;
            dgv_scripts.Columns.Add(deleteButtonColumn);

        }

        private async Task RefreshColumns()
        {
            var unsortedScripts = (await _getAllScriptsService.ExecuteAsync()).ToList();
            _scripts = unsortedScripts.OrderBy(s => s.Name).ToList();

            AdjustTableSize();

            dgv_scripts.DataSource = _scripts;
        }

        private void AdjustTableSize()
        {
            if (_scripts.Count() > 14) { this.Width = 833; }
            else { this.Width = 816; }
        }


        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------ COPIAR, EDITAR Y BORRAR ------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void dgv_scripts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            // COPIAR:
            if (dgv_scripts.Columns[e.ColumnIndex].Name == "colCopy")
            {
                var scriptName = dgv_scripts.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                var script = _scripts.FirstOrDefault(s => s.Name == scriptName);

                if (script == null) { MessageBox.Show("Ha ocurrido un error copiando el script. Avisa a Vargath."); return; }

                Clipboard.SetText(script.Content);
                _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_MARK_RUNE"]);

                if (script.Warning != "") { MessageBox.Show(script.Warning, "Advertencia"); }
            }

            // EDITAR:
            else if (dgv_scripts.Columns[e.ColumnIndex].Name == "colEdit")
            {
                var scriptName = dgv_scripts.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                var script = _scripts.FirstOrDefault(s => s.Name == scriptName);

                if (script == null) { MessageBox.Show("Ha ocurrido un error editando el script. Avisa a Vargath."); return; }

                var frm = _serviceProvider.GetRequiredService<FormArmoryNewUpdateScript>();
                frm.SetInfo(script);
                frm.ShowDialog();

                await RefreshColumns();
            }

            // BORRAR:
            else if (dgv_scripts.Columns[e.ColumnIndex].Name == "colDelete")
            {

                var frm = _serviceProvider.GetRequiredService<FormArmoryPasswordInputBox>();
                frm.ShowDialog();

                if (frm.PasswordSet == null) { return; }

                bool passwordAuthorize = _armoryAuthNService.Execute(frm.PasswordSet);
                if (!passwordAuthorize)
                {
                    _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_MAGIC_WORD"]);
                    MessageBox.Show(_armoryAuthNService.invalidAuthNMessage);
                    return;
                }

                var scriptName = dgv_scripts.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                var script = _scripts.FirstOrDefault(s => s.Name == scriptName);

                try
                {
                    await _deleteScriptService.ExecuteAsync(script);
                }
                catch (KeyNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                await RefreshColumns();
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------------- NAVEGACIÓN ------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void btn_newScript_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormArmoryNewUpdateScript>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            await RefreshColumns();
        }

        private void btn_createAutoEquipTemplate_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormAutoEquipTemplate>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }



        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------------- VOLVER --------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormArmoryMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btn_menu_principal_Click(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_CLOSE_DOOR"]);

            Hide();
        }
    }
}
