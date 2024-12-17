
using _2___Servicios.Services.StatisticsServices;
using _3_Presenters.ViewModels;
using Microsoft.Extensions.DependencyInjection;


namespace CortezosWorkshop.Estadisticas
{
    public partial class FormEstadisticasMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly CreateStatisticsService<StatisticsViewModel> _createStatisticsService;
        public FormEstadisticasMain(IServiceProvider serviceProvider,
        CreateStatisticsService<StatisticsViewModel> createStatisticsService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _createStatisticsService = createStatisticsService;
        }

        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- CARGAR ESTADISTICAS -----------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormEstadisticasMain_Load(object sender, EventArgs e)
        {
            var statisticsViewModel = await _createStatisticsService.ExecuteAsync();

            lbl_oroTotal.Text = statisticsViewModel.OroTotal;
            lbl_cajafuerte.Text = statisticsViewModel.CajaFuerte;
            lbl_beneficio.Text = statisticsViewModel.Beneficio;
            lbl_oroGastado.Text = statisticsViewModel.OroGastado;
            lbl_mapasCompletados.Text = statisticsViewModel.MapasCompletados;
            lbl_recursosExtraidos.Text = statisticsViewModel.RecursosExtraidos;
        }

        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------- IR A FORMULARIO DE LOGS ---------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_log_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormLog>();
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
                Application.Exit();
            }
        }

        private void btn_menu_principal_Click(object sender, EventArgs e)
        {
            var frmMain = Application.OpenForms.OfType<FormMain>().FirstOrDefault();
            frmMain.Location = new Point(this.Location.X, this.Location.Y); ;

            this.Hide();
        }
    }
}
