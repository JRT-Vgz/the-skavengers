using _1___Entities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services.ProductServices;

namespace CortezosWorkshop.Configuracion
{
    public partial class FormConfigMain : Form
    {
        private readonly IRepository<GenericProduct> _genericProductsRepository;
        private readonly IRepository<IngotResource> _ingotResourceRepository;
        private readonly UpdateConfiguredResources _updateConfiguredResourcesService;
        private readonly UpdateFullPlatePriceService _updateFullPlatePriceService;
        private readonly UpdateToolPriceService _updateToolPriceService;

        private IEnumerable<GenericProduct> _genericProducts;
        private IEnumerable<IngotResource> _ingotResources;
        private string _actualConfiguredResources;
        private string _actualFullPlatePrice;
        private string _actualToolPrice;

        private const int _MAX_LENGTH_CONFIG_RESOURCES_TEXTBOX = 5;
        private const int _MAX_LENGTH_PRICE_PRODUCT = 7;
        public FormConfigMain(IRepository<GenericProduct> genericProductsRepository,
            IRepository<IngotResource> ingotResourceRepository,
            UpdateConfiguredResources updateConfiguredResourcesService,
            UpdateFullPlatePriceService updateFullPlatePriceService,
            UpdateToolPriceService updateToolPriceService)
        {
            InitializeComponent();
            _genericProductsRepository = genericProductsRepository;
            _ingotResourceRepository = ingotResourceRepository;
            _updateConfiguredResourcesService = updateConfiguredResourcesService;
            _updateFullPlatePriceService = updateFullPlatePriceService;
            _updateToolPriceService = updateToolPriceService;
        }

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormConfigMain_Load(object sender, EventArgs e)
        {
            await Load_Products();
            await Load_IngotResources();
            Load_ConfigResourcesDefaultData();
            Load_FullPlatePricesDefaultData();
            Load_ToolPricesDefaultData();
        }

        private async Task Load_Products() { _genericProducts = await _genericProductsRepository.GetAllAsync(); }
        private async Task Load_IngotResources() { _ingotResources = await _ingotResourceRepository.GetAllAsync(); }
        private void Load_ConfigResourcesDefaultData()
        {
            cbo_productos.DataSource = _genericProducts;
            cbo_productos.DisplayMember = "Name";
            cbo_productos.SelectedIndex = 0;

            Load_ConfiguredResources();
        }

        private void Load_ConfiguredResources()
        {
            txt_configResources.Text = _genericProducts.ElementAt(cbo_productos.SelectedIndex).Resources.ToString();
            lbl_material.Text = _genericProducts.ElementAt(cbo_productos.SelectedIndex).MaterialName;
            _actualConfiguredResources = txt_configResources.Text;
        }

        private void Load_FullPlatePricesDefaultData()
        {
            cbo_matArCompleta.DataSource = _ingotResources;
            cbo_matArCompleta.DisplayMember = "IngotName";
            cbo_matArCompleta.SelectedIndex = 0;

            Load_FullPlatePrice();
        }

        private void Load_FullPlatePrice()
        {
            txt_precioArCompleta.Text = _ingotResources.ElementAt(cbo_matArCompleta.SelectedIndex).FullPlatePrice.ToString();
            _actualFullPlatePrice = txt_precioArCompleta.Text;
        }

        private void Load_ToolPricesDefaultData()
        {
            cbo_matHerramienta.BindingContext = new BindingContext();
            cbo_matHerramienta.DataSource = _ingotResources;
            cbo_matHerramienta.DisplayMember = "IngotName";
            cbo_matHerramienta.SelectedIndex = 0;

            Load_ToolPrice();
        }

        private void Load_ToolPrice()
        {
            txt_precioHerramienta.Text = _ingotResources.ElementAt(cbo_matHerramienta.SelectedIndex).ToolPrice.ToString();
            _actualToolPrice = txt_precioHerramienta.Text;
        }

        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------ CONFIGURAR RECURSOS PRODUCTO -------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void cbo_productos_SelectedIndexChanged(object sender, EventArgs e) { Load_ConfiguredResources(); }

        private async void txt_precioProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (e.KeyChar == (char)13)
            {
                await Save_New_Configurated_Resources();
                btn_menu_principal.Focus();
            }

            if (textBox.Text.Length == _MAX_LENGTH_CONFIG_RESOURCES_TEXTBOX && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private async void txt_precioProductos_Leave(object sender, EventArgs e) { await Save_New_Configurated_Resources(); }

        private async Task Save_New_Configurated_Resources()
        {
            var newConfiguratedResourcesText = txt_configResources.Text;
            if (newConfiguratedResourcesText.Length > _MAX_LENGTH_CONFIG_RESOURCES_TEXTBOX)
            {
                Load_ConfiguredResources();
                return;
            }
            else if (newConfiguratedResourcesText.Contains('-'))
            {
                MessageBox.Show("Los recursos no pueden ser negativos.");
                Load_ConfiguredResources();
                return;
            }

            if (newConfiguratedResourcesText != _actualConfiguredResources)
            {
                try
                {
                    var product = _genericProducts.ElementAt(cbo_productos.SelectedIndex);
                    await _updateConfiguredResourcesService.ExecuteAsync(product, int.Parse(newConfiguratedResourcesText));
                }
                catch (Exception) { MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); }

                Load_ConfiguredResources();
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------- CAMBIAR PRECIO DE ARMADURA COMPLETA ----------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void cbo_matArCompleta_SelectedIndexChanged(object sender, EventArgs e) { Load_FullPlatePrice(); }

        private async void txt_precioArCompleta_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (e.KeyChar == (char)13)
            {
                await Save_New_FullPlate_Price();
                btn_menu_principal.Focus();
            }

            if (textBox.Text.Length == _MAX_LENGTH_PRICE_PRODUCT && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private async void txt_precioArCompleta_Leave(object sender, EventArgs e) { await Save_New_FullPlate_Price(); }

        private async Task Save_New_FullPlate_Price()
        {
            var newFullPlatePriceText = txt_precioArCompleta.Text;
            if (newFullPlatePriceText.Length > _MAX_LENGTH_PRICE_PRODUCT)
            {
                Load_FullPlatePrice();
                return;
            }
            else if (newFullPlatePriceText.Contains('-'))
            {
                MessageBox.Show("El precio no puede ser negativo.");
                Load_FullPlatePrice();
                return;
            }

            if (newFullPlatePriceText != _actualFullPlatePrice)
            {
                try
                {
                    var ingotResource = _ingotResources.ElementAt(cbo_matArCompleta.SelectedIndex);
                    await _updateFullPlatePriceService.ExecuteAsync(ingotResource, int.Parse(newFullPlatePriceText));
                    await Load_IngotResources();
                }
                catch (Exception) { MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); }

                Load_FullPlatePrice();
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------- CAMBIAR PRECIO DE HERRAMIENTAS ------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void cbo_matHerramienta_SelectedIndexChanged(object sender, EventArgs e) { Load_ToolPrice(); }       

        private async void txt_precioHerramienta_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (e.KeyChar == (char)13)
            {
                await Save_New_Tool_Price();
                btn_menu_principal.Focus();
            }

            if (textBox.Text.Length == _MAX_LENGTH_PRICE_PRODUCT && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private async void txt_precioHerramienta_Leave(object sender, EventArgs e) { await Save_New_Tool_Price(); }

        private async Task Save_New_Tool_Price()
        {
            var newToolPriceText = txt_precioHerramienta.Text;
            if (newToolPriceText.Length > _MAX_LENGTH_PRICE_PRODUCT)
            {
                Load_ToolPrice();
                return;
            }
            else if (newToolPriceText.Contains('-'))
            {
                MessageBox.Show("El precio no puede ser negativo.");
                Load_ToolPrice();
                return;
            }

            if (newToolPriceText != _actualToolPrice)
            {
                try
                {
                    var ingotResource = _ingotResources.ElementAt(cbo_matHerramienta.SelectedIndex);
                    await _updateToolPriceService.ExecuteAsync(ingotResource, int.Parse(newToolPriceText));
                    await Load_IngotResources();
                }
                catch (Exception) { MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); }

                Load_ToolPrice();
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
