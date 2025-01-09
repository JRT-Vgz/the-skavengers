using _1___Entities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services;
using _2___Servicios.Services.ProductServices;
using _3_SoundSystem;

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
        private readonly ConfigurationService _configuration;
        private readonly ISoundSystem _soundSystem;

        private IEnumerable<GenericProduct> _genericProducts;
        private IEnumerable<IngotResource> _ingotResources;

        private string _actualFullPlatePrice;
        private string _actualToolPrice;
        private string _actualLockpicksPrice;

        private bool _txt_quantityCraftedClick = false;
        private bool _txt_materialGastadoClick = false;

        private bool _isTaskRunning = false;
        private bool _isSavingByKeyPress = false;

        private const int _MAX_LENGTH_QUANTITY_CRAFTED_TEXTBOX = 2;
        private const int _MAX_LENGTH_MATERIAL_GASTADO_TEXTBOX = 5;
        private const int _MAX_LENGTH_PRICE_PRODUCT = 7;

        public FormConfigMain(IRepository<GenericProduct> genericProductsRepository,
            IRepository<IngotResource> ingotResourceRepository,
            UpdateConfiguredResourcesService updateConfiguredResourcesService,
            UpdateFullPlatePriceService updateFullPlatePriceService,
            UpdateToolPriceService updateToolPriceService,
            UpdateLockpicksPriceService updateLockpicksPriceService,
            ConfigurationService configuration,
            ISoundSystem soundSystem)
        {
            InitializeComponent();
            _genericProductsRepository = genericProductsRepository;
            _ingotResourceRepository = ingotResourceRepository;
            _updateConfiguredResourcesService = updateConfiguredResourcesService;
            _updateFullPlatePriceService = updateFullPlatePriceService;
            _updateToolPriceService = updateToolPriceService;
            _updateLockpicksPriceService = updateLockpicksPriceService;
            _configuration = configuration;
            _soundSystem = soundSystem;
        }
        #endregion

        #region CargarDatos

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormConfigMain_Load(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_OPEN_DOOR"]);

            await Load_Products();
            await Load_IngotResources();

            Load_ConfigResourcesDefaultData();
            Load_ConfigProductDefaultData(cbo_matArCompleta, Load_FullPlatePrice);
            Load_ConfigProductDefaultData(cbo_matHerramienta, Load_ToolPrice);
            Load_ConfigProductDefaultData(cbo_matLockpicks, Load_LockpicksPrice);

            InitializePriceChangeHandlers();
        }

        private async Task Load_Products() { _genericProducts = await _genericProductsRepository.GetAllAsync(); }
        private async Task Load_IngotResources() { _ingotResources = await _ingotResourceRepository.GetAllAsync(); }

        private void Load_ConfigResourcesDefaultData()
        {
            cbo_genericProduct.DataSource = _genericProducts;
            cbo_genericProduct.DisplayMember = "Name";
            cbo_genericProduct.SelectedIndex = 0;

            txt_quantityCrafted.Text = "0";
            txt_materialGastado.Text = "0";

            _txt_quantityCraftedClick = false;
            _txt_materialGastadoClick = false;

            Load_ConfiguredResources();
        }

        private void Load_ConfiguredResources()
        {
            var genericProductsArray = _genericProducts.ToArray();

            var lblCfgArray = new Label[] { lbl_plateArCfg, lbl_toolCfg, lbl_lockpickCfg };
            var lblMatsArray = new Label[] { lbl_plateArMats, lbl_toolMats, lbl_lockpickMats };

            for (int i = 0; i < genericProductsArray.Length; i++)
            {
                lblCfgArray[i].Text = genericProductsArray[i].Resources.ToString();
                lblMatsArray[i].Text = genericProductsArray[i].MaterialName;
            }

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

        #region AñadirCrafteos

        // TXT_QUANTITY_CRAFTED TEXTBOX
        private void txt_quantityCrafted_Enter(object sender, EventArgs e)
        {
            if (!_txt_quantityCraftedClick)
            {
                _txt_quantityCraftedClick = true;
                txt_quantityCrafted.Text = "";
            }
        }

        private void txt_quantityCrafted_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_materialGastado.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txt_quantityCrafted_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }

            if (textBox.Text.Length > _MAX_LENGTH_QUANTITY_CRAFTED_TEXTBOX && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }


        // TXT_MATERIAL_GASTADO TEXTBOX
        private void txt_materialGastado_Enter(object sender, EventArgs e)
        {
            if (!_txt_materialGastadoClick)
            {
                _txt_materialGastadoClick = true;
                txt_materialGastado.Text = "";
            }
        }

        private void txt_materialGastado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_addCraft_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void txt_materialGastado_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }

            if (textBox.Text.Length > _MAX_LENGTH_MATERIAL_GASTADO_TEXTBOX && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }


        private async void btn_addCraft_Click(object sender, EventArgs e)
        {
            if (txt_quantityCrafted.Text == "0" || txt_quantityCrafted.Text == "")
            {
                MessageBox.Show("Escribe cuántos productos has crafteado.");
                return;
            }
            else if (txt_quantityCrafted.Text.Contains('-'))
            {
                MessageBox.Show("Los productos no pueden ser negativos.");
                return;
            }
            else if (txt_materialGastado.Text == "0" || txt_materialGastado.Text == "")
            {
                MessageBox.Show("Escribe cuánto material has gastado en el crafteo.");
                return;
            }
            else if (txt_materialGastado.Text.Contains('-'))
            {
                MessageBox.Show("Los recursos no pueden ser negativos.");
                return;
            }

            await AddCraftedResults();
        }

        private async Task AddCraftedResults()
        {
            _isTaskRunning = true;

            try
            {
                var product = _genericProducts.ElementAt(cbo_genericProduct.SelectedIndex);
                var quantityCrafted = int.Parse(txt_quantityCrafted.Text);
                var materialGastado = int.Parse(txt_materialGastado.Text);

                string craftSoundFile = _configuration.Configuration["Constants:_SOUND_CRAFT"];

                await _updateConfiguredResourcesService.ExecuteAsync(product, quantityCrafted, materialGastado, craftSoundFile);
            }
            catch (Exception) { MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); }

            await Load_Products();
            Load_ConfigResourcesDefaultData();

            _isTaskRunning = false;
        }

        #endregion

        #region CambiarPrecioDeProductos-Generico
        // -------------------------------------------------------------------------------------------------------
        // ------------------------------- CAMBIAR PRECIO DE PRODUCTOS - GENÉRICO --------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void InitializePriceChangeHandlers()
        {
            // Armadura completa
            ChangeProductPrice(cbo_matArCompleta, txt_precioArCompleta, Load_FullPlatePrice, _updateFullPlatePriceService.ExecuteAsync);

            // Herramientas
            ChangeProductPrice(cbo_matHerramienta, txt_precioHerramienta, Load_ToolPrice, _updateToolPriceService.ExecuteAsync);

            // Lockpicks
            ChangeProductPrice(cbo_matLockpicks, txt_precioLockpicks, Load_LockpicksPrice, _updateLockpicksPriceService.ExecuteAsync);
        }

        private string ReloadCurrentProductPrice(ComboBox cbo_product)
        {
            string currentPrice = "";

            if (cbo_product == cbo_matArCompleta) { currentPrice = _actualFullPlatePrice; }
            else if (cbo_product == cbo_matHerramienta) { currentPrice = _actualToolPrice; }
            else if (cbo_product == cbo_matLockpicks) { currentPrice = _actualLockpicksPrice; }

            return currentPrice;
        }

        private async Task ChangeProductPrice(ComboBox cbo_product, TextBox txt_productPrice,
            Action load_productPrice, Func<IngotResource, int, Task> updatePriceServiceMethod)
        {
            // Configuración de SelectedIndexChanged del ComboBox: Cargar el precio inicial del producto.
            cbo_product.SelectedIndexChanged += (sender, e) => load_productPrice();

            // Configuración de KeyDown del TextBox: Ejecutar guardado con Enter.
            txt_productPrice.KeyDown += async (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    _isSavingByKeyPress = true;
                    e.SuppressKeyPress = true;
                    await SaveNewPrice();
                    btn_menu_principal.Focus();
                }
            };

            // Configuración de KeyPress del TextBox: Control de digitos.
            txt_productPrice.KeyPress += async (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }
                if (txt_productPrice.Text.Length == _MAX_LENGTH_PRICE_PRODUCT && !char.IsControl(e.KeyChar)) { e.Handled = true; }
            };

            // Configuración de Leave del TextBox: Dispara el guardado si el texto no está vacío.
            txt_productPrice.Leave += async (sender, e) =>
            {
                if (!_isSavingByKeyPress) { await SaveNewPrice(); }
                else { _isSavingByKeyPress = false; }
            };

            async Task SaveNewPrice()
            {
                _isTaskRunning = true;

                var newPriceText = txt_productPrice.Text;
                if (newPriceText == "") { newPriceText = "0"; }

                var validationResult = ValidatePricesTextBoxData(newPriceText, _MAX_LENGTH_PRICE_PRODUCT);
                if (!validationResult) { await Reload_All_Data(); _isTaskRunning = false; return; }

                var currentPrice = ReloadCurrentProductPrice(cbo_product);
                if (newPriceText != currentPrice)
                {
                    try
                    {
                        await Load_IngotResources();
                        var selectedResource = _ingotResources.ElementAt(cbo_product.SelectedIndex);

                        _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_CHANGE_PRICE"]);

                        await updatePriceServiceMethod(selectedResource, int.Parse(newPriceText));
                    }
                    catch (Exception) { MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); }
                }
                await Reload_All_Data();
                _isTaskRunning = false;
            }
        }
        #endregion

        #region Validaciones
        private bool ValidatePricesTextBoxData(string textBoxData, int textMaxLength)
        {
            var validationResult = false;

            if (textBoxData.Length > textMaxLength)
            {
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

        private async void btn_menu_principal_Click(object sender, EventArgs e)
        {
            if (_isTaskRunning) { while (_isTaskRunning) { await Task.Delay(100); } }

            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_CLOSE_DOOR"]);

            var frmMain = Application.OpenForms.OfType<FormMain>().FirstOrDefault();
            frmMain.Location = new Point(this.Location.X, this.Location.Y); ;

            this.Hide();
        }
        #endregion

    }
}
