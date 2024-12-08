using _1___Entities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services;
using _2___Servicios.Services.ShopStatServices;
using _3_Presenters.ViewModels;

namespace CortezosWorkshop
{
    public partial class FormMainBeneficio : Form
    {
        private ConfigurationService _configuration;
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly IPresenter<ShopStat, FundsViewModel> _presenter;
        private readonly SumToBeneficio _sumToBeneficio;
        private readonly SumToOroTotal _sumToOroTotal;

        public FormMainBeneficio(ConfigurationService configuration,
            IRepository<ShopStat> shopStatsRepository,
            IPresenter<ShopStat, FundsViewModel> presenter,
            SumToBeneficio sumToBeneficio,
            SumToOroTotal sumToOroTotal)
        {
            InitializeComponent();
            _configuration = configuration;
            _shopStatsRepository = shopStatsRepository;
            _presenter = presenter;
            _sumToBeneficio = sumToBeneficio;
            _sumToOroTotal = sumToOroTotal;
        }

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormMainEditFunds_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X - 350, this.Location.Y + 165);
            await Load_Beneficio();
        }
        private async Task Load_Beneficio()
        {
            var shopStatBeneficio = await _shopStatsRepository.GetByNameAsync(_configuration.Configuration["Constants:_SHOPSTAT_BENEFICIO"]);
            var fundsViewModel = _presenter.Present(shopStatBeneficio);
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

            await _sumToBeneficio.ExecuteAsync(txtBoxQuantity);
            await _sumToOroTotal.ExecuteAsync(txtBoxQuantity);

            Reset_TextBox();
            await Load_Beneficio();
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
