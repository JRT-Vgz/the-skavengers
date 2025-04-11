
using _1_Domain.TheSkavengers.Interfaces;
using _2_Application.CortezosWorkshop.Services.StatisticsServices;
using _2_Application.TheSkavengers.Services;
using _3_Presenters.CortezosWorkshop.ViewModels;
using Microsoft.Extensions.DependencyInjection;


namespace Forms.CortezosWorkshop.Forms.Statistics
{
    public partial class FormCortezosWorkShopStatistics : Form
    {
        private readonly ConstantsConfigurationService _configuration;
        private readonly IServiceProvider _serviceProvider;
        private readonly CreateStatisticsService<StatisticsViewModel> _createStatisticsService;
        private readonly ISoundSystem _soundSystem;

        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        public FormCortezosWorkShopStatistics(ConstantsConfigurationService configuration,
            IServiceProvider serviceProvider,
            CreateStatisticsService<StatisticsViewModel> createStatisticsService,
            ISoundSystem soundSystem)
        {
            InitializeComponent();
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            _createStatisticsService = createStatisticsService;
            _soundSystem = soundSystem;
        }

        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- CARGAR ESTADISTICAS -----------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormEstadisticasMain_Load(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_SHOW_STATISTICS"]);

            var statisticsViewModel = await _createStatisticsService.ExecuteAsync();

            lbl_oroTotal.Text = statisticsViewModel.OroTotal;
            lbl_cajafuerte.Text = statisticsViewModel.CajaFuerte;
            lbl_beneficio.Text = statisticsViewModel.Beneficio;
            lbl_oroGastado.Text = statisticsViewModel.OroGastado;
            lbl_mapasCompletados.Text = statisticsViewModel.MapasCompletados;
            lbl_recursosExtraidos.Text = statisticsViewModel.RecursosExtraidos;
            lbl_armadurasCrafteadas.Text = statisticsViewModel.ArmadurasCrafteadas;
            lbl_herramientasCrafteadas.Text = statisticsViewModel.HerramientasCrafteadas;
            lbl_lockpicksCrafteados.Text = statisticsViewModel.LockpicksCrafteados;
        }

        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------- IR A FORMULARIO DE LOGS ---------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_log_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormCortezosWorkshopLog>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            this.Show();
        }

        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------- VOLVER A MENU PRINCIPAL ---------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                _isClosing = true;
                Application.Exit();
            }
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_CLOSE_DOOR"]);

            this.Hide();
        }
    }
}
