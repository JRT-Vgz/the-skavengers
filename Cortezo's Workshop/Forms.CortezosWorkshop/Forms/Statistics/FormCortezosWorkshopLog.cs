using _1_Domain.TheSkavengers.Interfaces;
using _2_Application.TheSkavengers.Services;
using _3_Repository.CortezosWorkshop.QueryObjects;

namespace Forms.CortezosWorkshop.Forms.Statistics
{
    public partial class FormCortezosWorkshopLog : Form
    {
        private readonly ConfigurationService _configuration;
        private readonly ISoundSystem _soundSystem;
        private readonly LogQuery _logQuery;
        public FormCortezosWorkshopLog(ConfigurationService configuration,
            ISoundSystem soundSystem,
            LogQuery logQuery)
        {
            InitializeComponent();
            _configuration = configuration;
            _soundSystem = soundSystem;
            _logQuery = logQuery;
        }

        private async void FormLogs_Load(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_OPEN_DOOR"]);

            await LoadLogs();
        }

        private async Task LoadLogs()
        {
            var logs = await _logQuery.GetLogsAsync();
            var logsList = logs.ToList();

            var logLabelsArray = new Label[]
            {
                lbl_log1, lbl_log2, lbl_log3, lbl_log4, lbl_log5, lbl_log6, lbl_log7, lbl_log8, lbl_log9, lbl_log10,
                lbl_log11, lbl_log12, lbl_log13, lbl_log14, lbl_log15, lbl_log16, lbl_log17, lbl_log18, lbl_log19, lbl_log20
            };

            for (int i = 0; i < logsList.Count; i++)
            {
                logLabelsArray[i].Text = $"{i + 1} - {logsList[i].Entry}";
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------- VOLVER A ESTADISTICAS ----------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_CLOSE_DOOR"]);

            var frmMain = Application.OpenForms.OfType<FormCortezosWorkShopStatistics>().FirstOrDefault();
            frmMain.Location = new Point(this.Location.X, this.Location.Y); ;

            this.Hide();
        }
    }
}
