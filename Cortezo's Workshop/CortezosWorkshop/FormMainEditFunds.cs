using _1___Entities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services;
using _2___Servicios.Services.ShopStatServices;
using _3_Presenters.ViewModels;

namespace CortezosWorkshop
{
    public partial class FormMainEditFunds : Form
    {
        private readonly ConfigurationService _configuration;
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly IPresenter<ShopStat, FundsViewModel> _presenter;
        private readonly SumToCajaFuerteService _sumToCajaFuerteService;

        public FormMainEditFunds(ConfigurationService configuration,
            IRepository<ShopStat> shopStatsRepository,
            IPresenter<ShopStat, FundsViewModel> presenter,
            SumToCajaFuerteService sumToCajaFuerteService)
        {
            InitializeComponent();
            _configuration = configuration;
            _shopStatsRepository = shopStatsRepository;
            _presenter = presenter;
            _sumToCajaFuerteService = sumToCajaFuerteService;
        }

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormMainEditFunds_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X + 350, this.Location.Y + 165);
            await Load_Funds();
        }
        private async Task Load_Funds()
        {
            var shopStatCajaFuerte = await _shopStatsRepository.GetByNameAsync(
                _configuration.Configuration["Constants:_SHOPSTAT_CAJA_FUERTE"]);
            var fundsViewModel = _presenter.Present(shopStatCajaFuerte);
            lbl_Oro.Text = fundsViewModel.Funds;
        }

        private void FormMainEditFunds_Shown(object sender, EventArgs e)
        {
            Reset_TextBox();
        }

        private void Reset_TextBox()
        {
            txtBox.Text = "";
            txtBox.Focus();
        }

        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------- RELLENAR TEXTBOX NUMERICO ---------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (e.KeyChar == (char)13) 
            { 
                if (textBox.Text.Length == 0) { btn_Back_Click(sender, e); }
                btn_Save_Click(sender, e); 
            }
           
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == '-' && textBox.SelectionStart == 0) { return; }

                e.Handled = true;
            }

            if (textBox.Text.Length == 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------- GUARDAR EN BASE DE DATOS ---------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (txtBox.Text.Length == 0 || (txtBox.Text.Length == 1 && txtBox.Text == "-"))
            {
                Reset_TextBox();
                return;
            }

            var txtBoxQuantity = int.Parse(txtBox.Text);  
            
            await _sumToCajaFuerteService.ExecuteAsync(txtBoxQuantity);

            Reset_TextBox();
            await Load_Funds();
        }

        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------------- CERRAR ------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
