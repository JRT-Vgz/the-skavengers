
using _1_Domain.TheSkavengers.Interfaces;
using _2_Application.CortezosWorkshop.Exceptions;
using _2_Application.CortezosWorkshop.Services.ShopStatServices;
using _2_Application.TheSkavengers.Services;
using _3_Presenters.CortezosWorkshop.ViewModels;

namespace Forms.CortezosWorkshop
{
    public partial class FormCortezosWorkshopBenefit : Form
    {
        #region Constructor

        private ConfigurationService _configuration;
        private readonly GetFundsByNameService<FundsViewModel> _getFundsByNameService;
        private readonly SumToBeneficioService _sumToBeneficioService;
        private readonly ISoundSystem _soundSystem;

        private const int _MAX_LENGTH_TEXTBOX = 8;

        public FormCortezosWorkshopBenefit(ConfigurationService configuration,
            GetFundsByNameService<FundsViewModel> getFundsByNameService,
            SumToBeneficioService sumToBeneficioService,
            ISoundSystem soundSystem)
        {
            InitializeComponent();
            _configuration = configuration;
            _getFundsByNameService = getFundsByNameService;
            _sumToBeneficioService = sumToBeneficioService;
            _soundSystem = soundSystem;
        }
        #endregion

        #region CargarDatos
        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormMainEditFunds_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X + 350, this.Location.Y + 165);

            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_OPEN_DRAWER"]);

            await Load_CajaFuerte();
        }
        private async Task Load_CajaFuerte()
        {
            var fundsViewModel = await _getFundsByNameService.ExecuteAsync(
                _configuration.Configuration["Constants:_SHOPSTAT_CAJA_FUERTE"]);
            UpdateLabelText(lbl_Oro, fundsViewModel.Funds, lbl_Funds);
        }

        private void UpdateLabelText(Label label, string funds, Label referenceLabel)
        {
            label.Text = funds;
            label.Left = referenceLabel.Left + (referenceLabel.Width - label.Width) / 2;
        }

        private void FormMainEditFunds_Shown(object sender, EventArgs e)
            => Reset_TextBox();

        private void Reset_TextBox()
        {
            txtBox.Text = "";
            txtBox.Focus();
        }
        #endregion

        #region RellenarTextboxNumerico

        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------- RELLENAR TEXTBOX NUMERICO ---------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var textBox = (sender as TextBox);
                if (textBox.Text.Length == 0) { btn_Back_Click(sender, e); return; }

                int parsedValue;
                if (int.TryParse(textBox.Text, out parsedValue))
                {
                    if (parsedValue == 0) { textBox.Text = ""; return; }
                }

                btn_Save_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }

            if (textBox.Text.Length > _MAX_LENGTH_TEXTBOX && !char.IsControl(e.KeyChar)) { e.Handled = true; }

        }
        #endregion

        #region GuardarDatos

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------- GUARDAR EN BASE DE DATOS ---------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (txtBox.Text.Contains('-'))
            {
                Reset_TextBox();
                return;
            }

            try
            {
                var txtBoxQuantity = int.Parse(txtBox.Text);
                var sound = _configuration.Configuration["Constants:_SOUND_RETRIEVE_BENEFITS"];

                await _sumToBeneficioService.ExecuteAsync(txtBoxQuantity, sound);
            }
            catch (NotEnoughFundsException ex) { MessageBox.Show(ex.Message); }
            catch (Exception) { MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); }

            Reset_TextBox();
            await Load_CajaFuerte();
        }
        #endregion

        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------------- CERRAR ------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_Back_Click(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_CLOSE_DRAWER"]);

            this.Close();
        }
    }
}
