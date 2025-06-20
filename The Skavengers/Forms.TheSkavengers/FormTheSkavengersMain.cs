using _3_Data.CortezosWorkshop;
using Forms.Armory.Forms;
using Forms.CortezosWorkshop;
using Forms.TheSkavengers.Constants;
using Forms.TheSkavengers.Miscelanea_Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Forms.TheSkavengers
{
    public partial class FormTheSkavengersMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly AppDbContext _context;

        private bool _dbLoaded = false;

        public FormTheSkavengersMain(IServiceProvider serviceProvider,
            AppDbContext context)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _context = context;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- LOAD ---------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void FormTheSkavengersMain_Shown(object sender, EventArgs e)
        {
            LoadDatabase();
        }

        private async void LoadDatabase()
        {
            var loadingForm = _serviceProvider.GetRequiredService<FormLoadingDb>();

            loadingForm.Location = new Point(
                this.Location.X + (this.Width - loadingForm.Width) / 2,
                this.Location.Y + (this.Height - loadingForm.Height) / 2
            );
            loadingForm.Show();
            loadingForm.Refresh();

            _dbLoaded = await WaitForDatabaseAsync();

            loadingForm.Close();

            if (!_dbLoaded)
            {
                MessageBox.Show("No se pudo conectar a la base de datos.");
                Application.Exit();
            }
        }

        private async Task<bool> WaitForDatabaseAsync()
        {
            for (int i = 0; i < LoadDbConstants.MAX_CONNECTION_RETRIES; i++)
            {
                try
                {
                    _context.ShopStats.Take(0).ToList();
                    return true;
                }
                catch (Exception) { }

                await Task.Delay(LoadDbConstants.TIME_BETWEEN_CONNECTION_TRIES);
            }

            return false;
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------------- BOTONES -----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void btn_workshop_Click(object sender, EventArgs e)
        {
            if (!_dbLoaded) { return; }

            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormCortezosWorkshopMain>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_armory_Click(object sender, EventArgs e)
        {
            if (!_dbLoaded) { return; }

            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormArmoryMain>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }
    }
}
