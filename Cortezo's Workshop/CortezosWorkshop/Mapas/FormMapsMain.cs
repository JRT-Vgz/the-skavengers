using _1___Entities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services.OreMapServices;

namespace CortezosWorkshop.Maps
{
    public partial class FormMapsMain : Form
    {
        private readonly IRepository<OreMap> _oreMapsRepository;
        private readonly AddCompletedMapData _addCompletedMapData;
        private readonly UpdateRecommendedPrice _updateRecommendedPrice;

        private IEnumerable<OreMap> _oreMaps;
        private string _actualRecommendedPrice;
        private bool _txt_materialRecogidoClick = false;

        private const int _MAX_LENGTH_RECURSOS_AÑADIDOS_TEXTBOX = 5;
        private const int _MAX_LENGTH_PRECIO_RECOMENDADO_TEXTBOX = 11;

        public FormMapsMain(IRepository<OreMap> oreMapsRepository,
            AddCompletedMapData addCompletedMapData,
            UpdateRecommendedPrice updateRecommendedPrice)
        {
            InitializeComponent();
            _oreMapsRepository = oreMapsRepository;
            _addCompletedMapData = addCompletedMapData;
            _updateRecommendedPrice = updateRecommendedPrice;
        }

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormMapsMain_Load(object sender, EventArgs e)
        {
            await Load_OreMaps();
            await Load_AddMapDefaultData();
            await Load_RecommendedPricesDefaultData();
        }

        private async Task Load_OreMaps() { _oreMaps = await _oreMapsRepository.GetAllAsync(); }
            private async Task Load_AddMapDefaultData()
        {
            for (int i = 1; i <= 20; i++) { cbo_mapQuantity.Items.Add(i); }
            cbo_mapQuantity.SelectedIndex = 0;

            cbo_oreMaps.DataSource = _oreMaps;
            cbo_oreMaps.DisplayMember = "Name";
            cbo_oreMaps.ValueMember = "Name";
            cbo_oreMaps.SelectedIndex = 0;

            txt_materialRecogido.Text = "0";
            _txt_materialRecogidoClick = false;
        }

        private async Task Load_RecommendedPricesDefaultData()
        {
            cbo_oreMapsPrices.BindingContext = new BindingContext();
            cbo_oreMapsPrices.DataSource = _oreMaps;
            cbo_oreMapsPrices.DisplayMember = "Name";
            cbo_oreMapsPrices.ValueMember = "Name";
            cbo_oreMapsPrices.SelectedIndex = 0;

            Load_RecommendedPrice();
        }

        private void Load_RecommendedPrice()
        {
            txt_oreMapPrice.Text = _oreMaps.ElementAt(cbo_oreMapsPrices.SelectedIndex).RecommendedPrice;
            _actualRecommendedPrice = txt_oreMapPrice.Text;
        }

        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------------- AÑADIR MAPA ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void txt_materialRecogido_Enter(object sender, EventArgs e)
        {
            if (!_txt_materialRecogidoClick)
            {
                _txt_materialRecogidoClick = true;
                txt_materialRecogido.Text = "";
            }
        }

        private void txt_materialRecogido_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (e.KeyChar == (char)13) { btn_addMap_Click(sender, e); }

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }

            if (textBox.Text.Length == _MAX_LENGTH_RECURSOS_AÑADIDOS_TEXTBOX && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private async void btn_addMap_Click(object sender, EventArgs e)
        {
            if (txt_materialRecogido.Text == "0" || txt_materialRecogido.Text == "")
            {
                MessageBox.Show("Escribe cuánto material has recogido en el mapa.");
                return;
            }
            else if (txt_materialRecogido.Text.Contains('-'))
            {
                MessageBox.Show("Los recursos no pueden ser negativos.");
                await Load_AddMapDefaultData();
                return;
            }

            try
            {
                var oreMapName = cbo_oreMaps.SelectedValue.ToString();
                var mapQuantity = (int)cbo_mapQuantity.SelectedItem;
                var resourcesQuantity = int.Parse(txt_materialRecogido.Text);

                await _addCompletedMapData.ExecuteAsync(oreMapName, mapQuantity, resourcesQuantity);
                await Load_OreMaps();
            }
            catch (Exception) { MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); }           
            await Load_AddMapDefaultData();
        }

        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------ CAMBIAR PRECIOS RECOMENDADOS -------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void cbo_oreMapsPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_RecommendedPrice();
        }
        private void txt_oreMapPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (e.KeyChar == (char)13)
            {
                Save_New_Recommended_Price();
                btn_menu_principal.Focus();
            }

            if (textBox.Text.Length == _MAX_LENGTH_PRECIO_RECOMENDADO_TEXTBOX && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private void txt_oreMapPrice_Leave(object sender, EventArgs e) { Save_New_Recommended_Price(); }

        private async Task Save_New_Recommended_Price()
        {
            var newRecommendedPrice = txt_oreMapPrice.Text;
            if (newRecommendedPrice.Length > _MAX_LENGTH_PRECIO_RECOMENDADO_TEXTBOX)
            {
                Load_RecommendedPrice();
                return;
            }
            if (newRecommendedPrice != _actualRecommendedPrice)
            {
                try
                {
                    var oreMap = _oreMaps.ElementAt(cbo_oreMapsPrices.SelectedIndex);
                    await _updateRecommendedPrice.ExecuteAsync(oreMap, newRecommendedPrice);
                    await Load_OreMaps();
                }
                catch (Exception) { MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); }               
                Load_RecommendedPrice();
            }
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
