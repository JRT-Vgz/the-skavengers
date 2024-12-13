using _1___Entities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services.ProductServices;
using System.ComponentModel.Design;

namespace CortezosWorkshop.Configuracion
{
    public partial class FormConfigMain : Form
    {
        #region Constructor

        private readonly IRepository<GenericProduct> _genericProductsRepository;
        private readonly IRepository<IngotResource> _ingotResourceRepository;
        private readonly UpdateConfiguredResourcesService _updateConfiguredResourcesService;
        private readonly UpdateFullPlatePriceService _updateFullPlatePriceService;
        private readonly UpdateToolPriceService _updateToolPriceService;
        private readonly UpdateLockpicksPriceService _updateLockpicksPriceService;

        private IEnumerable<GenericProduct> _genericProducts;
        private IEnumerable<IngotResource> _ingotResources;

        private string _actualConfiguredResources;
        private string _actualFullPlatePrice;
        private string _actualToolPrice;
        private string _actualLockpicksPrice;

        private const int _MAX_LENGTH_CONFIG_RESOURCES_TEXTBOX = 5;
        private const int _MAX_LENGTH_PRICE_PRODUCT = 7;

        public FormConfigMain(IRepository<GenericProduct> genericProductsRepository,
            IRepository<IngotResource> ingotResourceRepository,
            UpdateConfiguredResourcesService updateConfiguredResourcesService,
            UpdateFullPlatePriceService updateFullPlatePriceService,
            UpdateToolPriceService updateToolPriceService,
            UpdateLockpicksPriceService updateLockpicksPriceService)
        {
            InitializeComponent();
            _genericProductsRepository = genericProductsRepository;
            _ingotResourceRepository = ingotResourceRepository;
            _updateConfiguredResourcesService = updateConfiguredResourcesService;
            _updateFullPlatePriceService = updateFullPlatePriceService;
            _updateToolPriceService = updateToolPriceService;
            _updateLockpicksPriceService = updateLockpicksPriceService;
        }
        #endregion

        #region CargarDatos

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormConfigMain_Load(object sender, EventArgs e)
        {           
            await Load_Products();
            await Load_IngotResources();
            InitializePriceChangeHandlers();

            Load_ConfigResourcesDefaultData();
            Load_ConfigProductDefaultData(cbo_matArCompleta, Load_FullPlatePrice);
            Load_ConfigProductDefaultData(cbo_matHerramienta, Load_ToolPrice);
            Load_ConfigProductDefaultData(cbo_matLockpicks, Load_LockpicksPrice);
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

        private void Load_ConfigProductDefaultData(ComboBox cbo_matProduct, Action loadProductData)
        {
            cbo_matProduct.BindingContext = new BindingContext();
            cbo_matProduct.DataSource = _ingotResources;
            cbo_matProduct.DisplayMember = "ResourceName";
            cbo_matProduct.SelectedIndex = 0;

            loadProductData();
        }

        private async Task Reload_All_Data()
        {
            await Load_IngotResources();
            Load_FullPlatePrice();
            Load_ToolPrice();
            Load_LockpicksPrice();
        }

        private void Load_ConfiguredResources()
        {
            txt_configResources.Text = _genericProducts.ElementAt(cbo_productos.SelectedIndex).Resources.ToString();
            lbl_material.Text = _genericProducts.ElementAt(cbo_productos.SelectedIndex).MaterialName;
            _actualConfiguredResources = txt_configResources.Text;
        }

        private void Load_FullPlatePrice()
        {
            txt_precioArCompleta.Text = _ingotResources.ElementAt(cbo_matArCompleta.SelectedIndex).FullPlatePrice.ToString();
            _actualFullPlatePrice = txt_precioArCompleta.Text;
        }

        private void Load_ToolPrice()
        {
            txt_precioHerramienta.Text = _ingotResources.ElementAt(cbo_matHerramienta.SelectedIndex).ToolPrice.ToString();
            _actualToolPrice = txt_precioHerramienta.Text;
        }

        private void Load_LockpicksPrice()
        {
            txt_precioLockpicks.Text = _ingotResources.ElementAt(cbo_matLockpicks.SelectedIndex).LockpicksPrice.ToString();
            _actualLockpicksPrice = txt_precioLockpicks.Text;
        }
        #endregion

        #region ConfigurarRecursosProducto

        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------ CONFIGURAR RECURSOS PRODUCTO -------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void cbo_productos_SelectedIndexChanged(object sender, EventArgs e) { Load_ConfiguredResources(); }

        private async void txt_configResources_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (e.KeyChar == (char)13)
            {
                await Save_New_Configurated_Resources();
                btn_menu_principal.Focus();
            }

            if (textBox.Text.Length == _MAX_LENGTH_CONFIG_RESOURCES_TEXTBOX && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private async void txt_configResources_Leave(object sender, EventArgs e)
        {
            if (txt_configResources.Text != "") { await Save_New_Configurated_Resources(); }
        }

        private async Task Save_New_Configurated_Resources()
        {
            var newConfiguratedResourcesText = txt_configResources.Text;
            var validationResult = ValidateTextBoxData(newConfiguratedResourcesText, _MAX_LENGTH_CONFIG_RESOURCES_TEXTBOX);
            if (!validationResult) { return; }

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
        #endregion

        #region CambiarPrecioDeProductos-Generico
        // -------------------------------------------------------------------------------------------------------
        // ------------------------------- CAMBIAR PRECIO DE PRODUCTOS - GENÉRICO --------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void InitializePriceChangeHandlers()
        {
            // Armadura completa
            ChangeProductPrice(cbo_matArCompleta, txt_precioArCompleta, _actualFullPlatePrice,
                Load_FullPlatePrice, _updateFullPlatePriceService.ExecuteAsync);

            // Herramientas
            ChangeProductPrice(cbo_matHerramienta, txt_precioHerramienta, _actualToolPrice,
                Load_ToolPrice, _updateToolPriceService.ExecuteAsync);

            // Lockpicks
            ChangeProductPrice(cbo_matLockpicks, txt_precioLockpicks, _actualLockpicksPrice,
                Load_LockpicksPrice, _updateLockpicksPriceService.ExecuteAsync);
        }

        private async Task ChangeProductPrice(ComboBox cbo_product, TextBox txt_productPrice, string currentPrice,
            Action load_productPrice, Func<IngotResource, int, Task> updatePriceServiceMethod)
        {
            // Configuración de SelectedIndexChanged del ComboBox: Cargar el precio inicial del producto.
            cbo_product.SelectedIndexChanged += (sender, e) => load_productPrice();

            // Configuración de KeyPress del TextBox: Control de digitos y ejecutar guardado con Enter.
            txt_productPrice.KeyPress += async (sender, e) =>
            {
                if (e.KeyChar == (char)13)
                {
                    await SaveNewPrice();
                    btn_menu_principal.Focus();
                }
                if (txt_productPrice.Text.Length == _MAX_LENGTH_PRICE_PRODUCT && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            // Configuración de Leave del TextBox: Dispara el guardado si el texto no está vacío.
            txt_productPrice.Leave += async (sender, e) => 
            { 
                if (txt_productPrice.Text != "") { await SaveNewPrice();} 
            };

            async Task SaveNewPrice()
            {
                var newPriceText = txt_productPrice.Text;
                var validationResult = ValidateTextBoxData(newPriceText, _MAX_LENGTH_PRICE_PRODUCT);
                if (!validationResult) { await Reload_All_Data();  return; }

                if (newPriceText != currentPrice)
                {
                    try
                    {
                        await Load_IngotResources();
                        var selectedResource = _ingotResources.ElementAt(cbo_product.SelectedIndex);
                        await updatePriceServiceMethod(selectedResource, int.Parse(newPriceText));
                    }
                    catch (Exception) { MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); }
                }

                await Reload_All_Data();
            }
        }       
        #endregion

        #region Validaciones
        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- VALIDACIONES ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private bool ValidateTextBoxData(string textBoxData, int textMaxLength)
        {
            var validationResult = false;

            if (textBoxData.Length > textMaxLength)
            {
                return validationResult;
            }
            else if (textBoxData == "0" || textBoxData == "")
            {
                MessageBox.Show("La cantidad no puede ser 0.");
                return validationResult;
            }
            else if (textBoxData.Contains('-'))
            {
                MessageBox.Show("La cantidad no puede ser negativa.");
                return validationResult;
            }

            validationResult = true;
            return validationResult;
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
