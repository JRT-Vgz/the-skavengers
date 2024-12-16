using _1___Entities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services;
using _2___Servicios.Services.OreMapServices;
using _2___Servicios.Services.ResourcesBuyServices;
using _3_Presenters.ViewModels;

namespace CortezosWorkshop.Maps
{
    public partial class FormMapsMain : Form
    {
        #region Constructor

        private readonly ConfigurationService _configuration;
        private readonly IRepository<IngotResource> _ingotResourcesRepository;
        private readonly AddCompletedMapData _addCompletedMapData;
        private readonly UpdateRecommendedPrice _updateRecommendedPrice;
        private readonly MapBuyService<BuyResourceViewModel> _mapBuyService;
        private readonly CommodityBuyService<BuyResourceViewModel> _commodityBuyService;
        private readonly IngotBuyService<BuyResourceViewModel> _ingotBuyService;

        private IEnumerable<IngotResource> _ingotResources;
        private string _actualRecommendedPrice;
        private bool _txt_materialRecogidoClick = false;
        private bool _txt_buyResourcesPriceClick = false;

        private const int _MAX_LENGTH_RECURSOS_AÑADIDOS_TEXTBOX = 5;
        private const int _MAX_LENGTH_PRECIO_RECOMENDADO_TEXTBOX = 11;
        private const int _MAX_LENGTH_COMPRAR_RECURSO_TEXTBOX = 8;

        public FormMapsMain(ConfigurationService configuration,
            IRepository<IngotResource> ingotResourcesRepository,
            AddCompletedMapData addCompletedMapData,
            UpdateRecommendedPrice updateRecommendedPrice,
            MapBuyService<BuyResourceViewModel> mapBuyService,
            CommodityBuyService<BuyResourceViewModel> commodityBuyService,
            IngotBuyService<BuyResourceViewModel> ingotBuyService)
        {
            InitializeComponent();
            _configuration = configuration;
            _ingotResourcesRepository = ingotResourcesRepository;
            _addCompletedMapData = addCompletedMapData;
            _updateRecommendedPrice = updateRecommendedPrice;
            _mapBuyService = mapBuyService;
            _commodityBuyService = commodityBuyService;
            _ingotBuyService = ingotBuyService;

            rb_map.CheckedChanged += RB_CheckedChanged;
            rb_commodity.CheckedChanged += RB_CheckedChanged;
            rb_ingots.CheckedChanged += RB_CheckedChanged;
        }
        #endregion

        #region CargarDatos

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormMapsMain_Load(object sender, EventArgs e)
        {
            await Load_IngotResources();
            Load_AddMapDefaultData();
            Load_RecommendedPricesDefaultData();
            Load_BuyResourcesDefaultCheckButton();
        }

        private async Task Load_IngotResources() { _ingotResources = await _ingotResourcesRepository.GetAllAsync(); }
        private void Load_AddMapDefaultData()
        {
            for (int i = 1; i <= 20; i++) { cbo_mapQuantity.Items.Add(i); }
            cbo_mapQuantity.SelectedIndex = 0;

            cbo_oreMaps.DataSource = _ingotResources;
            cbo_oreMaps.DisplayMember = "MapName";
            cbo_oreMaps.SelectedIndex = 0;

            txt_materialRecogido.Text = "0";
            _txt_materialRecogidoClick = false;
        }

        private void Load_RecommendedPricesDefaultData()
        {
            cbo_oreMapsPrices.BindingContext = new BindingContext();
            cbo_oreMapsPrices.DataSource = _ingotResources;
            cbo_oreMapsPrices.DisplayMember = "MapName";
            cbo_oreMapsPrices.SelectedIndex = 0;

            Load_RecommendedPrice();
        }

        private void Load_RecommendedPrice()
        {
            txt_oreMapPrice.Text = _ingotResources.ElementAt(cbo_oreMapsPrices.SelectedIndex).MapRecommendedPrice;
            _actualRecommendedPrice = txt_oreMapPrice.Text;
        }

        private void Load_BuyResourcesDefaultCheckButton()
            => rb_map.Checked = true;
        private void Load_BuyResourcesDefaultData(string displayName)
        {
            cbo_buyResources.BindingContext = new BindingContext();
            cbo_buyResources.DataSource = _ingotResources;
            cbo_buyResources.DisplayMember = displayName;
            cbo_buyResources.SelectedIndex = 0;

            lbl_mediaLingotes.Text = "- Cantidad media de lingotes:     0";
            lbl_precioPorLingote.Text = "- Precio por lingote:     0 gp";
            lbl_costePorArmadura.Text = "- Coste por armadura:     0 gp";
            lbl_precioVentaArmadura.Text = "- Precio venta armadura:     0 gp";
            lbl_costePorHerramienta.Text = "- Coste por herramienta:     0 gp";
            lbl_precioVentaHerramienta.Text = "- Precio venta herramienta:     0 gp";
            lbl_costePorLockpicks.Text = "- Coste por lockpicks:     0 gp";
            lbl_precioVentaLockpicks.Text = "- Precio venta lockpicks:     0 gp";

            txt_buyResourcesPrice.Text = "0";
            _txt_buyResourcesPriceClick = false;
        }
        #endregion

        #region AñadirMapa

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

        private void txt_materialRecogido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_addMap_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void txt_materialRecogido_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
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
                Load_AddMapDefaultData();
                return;
            }

            try
            {
                await Load_IngotResources();
                var ingotResource = _ingotResources.ElementAt(cbo_oreMaps.SelectedIndex);
                var mapQuantity = (int)cbo_mapQuantity.SelectedItem;
                var resourcesQuantity = int.Parse(txt_materialRecogido.Text);

                await _addCompletedMapData.ExecuteAsync(ingotResource, mapQuantity, resourcesQuantity);
            }
            catch (Exception) { MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); }
            Load_AddMapDefaultData();
        }
        #endregion

        #region CambiarPreciosRecomendados

        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------ CAMBIAR PRECIOS RECOMENDADOS -------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void cbo_oreMapsPrices_SelectedIndexChanged(object sender, EventArgs e) { Load_RecommendedPrice(); }

        private async void txt_oreMapPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await Save_New_Recommended_Price();
                btn_menu_principal.Focus();
            }
        }

        private async void txt_oreMapPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (textBox.Text.Length == _MAX_LENGTH_PRECIO_RECOMENDADO_TEXTBOX && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private async void txt_oreMapPrice_Leave(object sender, EventArgs e) { await Save_New_Recommended_Price(); }

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
                    await Load_IngotResources();
                    var ingotResource = _ingotResources.ElementAt(cbo_oreMapsPrices.SelectedIndex);
                    await _updateRecommendedPrice.ExecuteAsync(ingotResource, newRecommendedPrice);
                }
                catch (Exception) { MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); }
                Load_RecommendedPrice();
            }
        }
        #endregion

        #region ComprarRecursos

        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------------ COMPRAR RECURSOS -------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void RB_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked) { return; }

            if (sender == rb_map)
            {
                Load_BuyResourcesDefaultData
                    (_configuration.Configuration["Constants:_RESOURCE_MAP_NAME_COLUMN"]);
            }
            else if (sender == rb_commodity)
            {
                Load_BuyResourcesDefaultData
                    (_configuration.Configuration["Constants:_RESOURCE_COMMODITY_NAME_COLUMN"]);
            }
            else if (sender == rb_ingots)
            {
                Load_BuyResourcesDefaultData
                    (_configuration.Configuration["Constants:_RESOURCE_NAME_COLUMN"]);
            }
        }

        private void txt_buyResourcesPrice_Enter(object sender, EventArgs e)
        {
            if (!_txt_buyResourcesPriceClick)
            {
                _txt_buyResourcesPriceClick = true;
                txt_buyResourcesPrice.Text = "";
            }
        }

        private async void txt_buyResourcesPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await Show_Info_For_Buy_Resources();
                btn_menu_principal.Focus();
            }
        }

        private async void txt_oreMapCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }

            if (textBox.Text.Length == _MAX_LENGTH_COMPRAR_RECURSO_TEXTBOX && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private async void txt_buyResourcesPrice_Leave(object sender, EventArgs e)
        {
            if (txt_buyResourcesPrice.Text != "") { await Show_Info_For_Buy_Resources(); }
        }
        private async Task Show_Info_For_Buy_Resources()
        {
            try
            {
                await Load_IngotResources();
                var ingotResource = _ingotResources.ElementAt(cbo_buyResources.SelectedIndex);
                var buyPrice = int.Parse(txt_buyResourcesPrice.Text);

                var buyResourceViewModel = new BuyResourceViewModel();
                if (rb_map.Checked == true)
                { buyResourceViewModel = await _mapBuyService.ExecuteAsync(ingotResource, buyPrice); }
                else if (rb_commodity.Checked == true)
                { buyResourceViewModel = await _commodityBuyService.ExecuteAsync(ingotResource, buyPrice); }
                else if (rb_ingots.Checked == true)
                { buyResourceViewModel = await _ingotBuyService.ExecuteAsync(ingotResource, buyPrice); }

                lbl_mediaLingotes.Text = buyResourceViewModel.ResourceQuantity;
                lbl_precioPorLingote.Text = buyResourceViewModel.PricePerResource;
                lbl_costePorArmadura.Text = buyResourceViewModel.FullPlateGoldCost;
                lbl_precioVentaArmadura.Text = buyResourceViewModel.FullPlateSellPrice;
                lbl_costePorHerramienta.Text = buyResourceViewModel.ToolGoldCost;
                lbl_precioVentaHerramienta.Text = buyResourceViewModel.ToolSellPrice;
                lbl_costePorLockpicks.Text = buyResourceViewModel.LockpicksGoldCost;
                lbl_precioVentaLockpicks.Text = buyResourceViewModel.LockpicksSellPrice;
                lbl_beneficioArmadura.Text = buyResourceViewModel.FullPlateBenefit;
                lbl_beneficioHerramienta.Text = buyResourceViewModel.ToolBenefit;
                lbl_beneficioLockpicks.Text = buyResourceViewModel.LockpicksBenefit;
            }
            catch (Exception) 
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); 
            }

            _txt_buyResourcesPriceClick = false;
        }
        #endregion

        #region VolverAlMenuPrincipal

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
        #endregion
    }
}
