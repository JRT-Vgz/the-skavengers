
using _1_Domain.CortezosWorkshop.Interfaces;
using _1_Domain.TheSkavengers.Interfaces;
using _2_Application.CortezosWorkshop.Services.ShopStatServices;
using _2_Application.TheSkavengers.Services;
using _3_Presenters.CortezosWorkshop.ViewModels;
using Forms.CortezosWorkshop.Forms.Configuration;
using Forms.CortezosWorkshop.Forms.Maps;
using Forms.CortezosWorkshop.Forms.Prices;
using Forms.CortezosWorkshop.Forms.Statistics;
using Microsoft.Extensions.DependencyInjection;
using System.Media;

namespace Forms.CortezosWorkshop
{
    public partial class FormCortezosWorkshopMain : Form
    {
        #region Constructor

        private readonly IServiceProvider _serviceProvider;
        private readonly ConfigurationService _configuration;
        private readonly GetFundsByNameService<FundsViewModel> _getFundsByNameService;
        private readonly ISoundSystem _soundSystem;
        private readonly ILogger _logger;

        private IEnumerable<string> _logEntries;
        public FormCortezosWorkshopMain(IServiceProvider serviceProvider,
            ConfigurationService configuration,
            GetFundsByNameService<FundsViewModel> getFundsByNameService,
            ISoundSystem soundSystem,
            ILogger logger)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            _getFundsByNameService = getFundsByNameService;
            _soundSystem = soundSystem;
            _logger = logger;
        }
        #endregion

        #region CargarDatos

        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------------- CARGAR DATOS --------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormMain_Load(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_OPEN_DOOR"]);

            await CheckForLogWarnings();
            await Load_Funds();
        }

        private async Task CheckForLogWarnings()
        {
            _logEntries = await _logger.GetLogEntriesAsync();

            if (_logEntries.Any(entry => entry.Contains("WRN:")))
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Se ha encontrado una entrada de datos sospechosamente sospechosa. Avisa a Vargath para que revise los logs. " +
                    "\n\nPuedes continuar usando el programa sin miedo.", "- - -  AVISO  - - -");
            }
        }

        private async Task Load_Funds()
        {
            var fundsViewModel = await _getFundsByNameService.ExecuteAsync(
                _configuration.Configuration["Constants:_SHOPSTAT_CAJA_FUERTE"]);
            UpdateLabelText(lbl_Oro, fundsViewModel.Funds, lbl_Tesoreria);
        }

        private void UpdateLabelText(Label label, string funds, Label referenceLabel)
        {
            label.Text = funds;
            label.Left = referenceLabel.Left + (referenceLabel.Width - label.Width) / 2;
        }

        #endregion

        #region NavegacionBotones

        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------------- BOTONES -----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_mapas_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormCortezosWorkshopMaps>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (!frm.IsClosing)
            {
                Load_Funds();
            }
            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_precios_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormCortezosWorkshopPrices>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (!frm.IsClosing)
            {
                Load_Funds();
            }
            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_config_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormCortezosWorkshopConfig>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (!frm.IsClosing)
            {
                Load_Funds();
            }
            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_estadisticas_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormCortezosWorkShopStatistics>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            if (!frm.IsClosing)
            {
                Load_Funds();
            }
            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_addFunds_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormCortezosWorkshopEditFunds>();
            lbl_Oro.Text = "???";
            frm.ShowDialog();

            Load_Funds();
        }

        private void btn_beneficio_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormCortezosWorkshopBenefit>();
            lbl_Oro.Text = "???";
            frm.ShowDialog();

            Load_Funds();
        }
        #endregion

        private void btn_portapapeles_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_configuration.Configuration["Constants:_NOMBRE_RUNA_TIENDA"]);

            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_MARK_RUNE"]);
        }

        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------- VOLVER A MENU PRINCIPAL ---------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btn_menu_principal_Click(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_CLOSE_DOOR"]);

            this.Hide();
        }
    }
}
