using _1___Entities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services.ProductServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

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
            Load_ConfigResourcesDefaultData();
            Load_FullPlatePricesDefaultData();
            Load_ToolPricesDefaultData();
            Load_LockpicksPricesDefaultData();
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
            cbo_matArCompleta.DisplayMember = "ResourceName";
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
            cbo_matHerramienta.DisplayMember = "ResourceName";
            cbo_matHerramienta.SelectedIndex = 0;

            Load_ToolPrice();
        }

        private void Load_ToolPrice()
        {
            txt_precioHerramienta.Text = _ingotResources.ElementAt(cbo_matHerramienta.SelectedIndex).ToolPrice.ToString();
            _actualToolPrice = txt_precioHerramienta.Text;
        }

        private void Load_LockpicksPricesDefaultData()
        {
            cbo_matLockpicks.BindingContext = new BindingContext();
            cbo_matLockpicks.DataSource = _ingotResources;
            cbo_matLockpicks.DisplayMember = "ResourceName";
            cbo_matLockpicks.SelectedIndex = 0;

            Load_LockpicksPrice();
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
        private void cbo_productos_SelectedIndexChanged(object sender, EventArgs e) { Load_ConfiguredResources(); }

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
            var validationResult = ValidateTextBoxData(newConfiguratedResourcesText, _MAX_LENGTH_CONFIG_RESOURCES_TEXTBOX, 
                Load_ConfiguredResources);
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

        #region CambiarPrecioDeArmaduraCompleta

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

        private async void txt_precioArCompleta_Leave(object sender, EventArgs e) 
        {
            if (txt_precioArCompleta.Text != "") { await Save_New_FullPlate_Price(); }
        }

        private async Task Save_New_FullPlate_Price()
        {
            var newFullPlatePriceText = txt_precioArCompleta.Text;
            var validationResult = ValidateTextBoxData(newFullPlatePriceText, _MAX_LENGTH_PRICE_PRODUCT, Load_FullPlatePrice);
            if (!validationResult) { return; }

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
        #endregion

        #region CambiarPrecioDeHerramientas
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

        private async void txt_precioHerramienta_Leave(object sender, EventArgs e)
        {
            if (txt_precioHerramienta.Text != "") { await Save_New_Tool_Price(); }
        }

        private async Task Save_New_Tool_Price()
        {
            var newToolPriceText = txt_precioHerramienta.Text;
            var validationResult = ValidateTextBoxData(newToolPriceText, _MAX_LENGTH_PRICE_PRODUCT, Load_ToolPrice);
            if (!validationResult) { return; }

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
        #endregion

        #region CambiarPrecioDeLockpicks
        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------ CAMBIAR PRECIO DE LOCKPICKS --------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void cbo_matLockpicks_SelectedIndexChanged(object sender, EventArgs e) { Load_LockpicksPrice(); }

        private async void txt_precioLockpicks_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (e.KeyChar == (char)13)
            {
                await Save_New_Lockpicks_Price();
                btn_menu_principal.Focus();
            }

            if (textBox.Text.Length == _MAX_LENGTH_PRICE_PRODUCT && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private async void txt_precioLockpicks_Leave(object sender, EventArgs e)
        {
            if (txt_precioLockpicks.Text != "") { await Save_New_Lockpicks_Price(); }
        }

        private async Task Save_New_Lockpicks_Price()
        {
            var newLockpicksPriceText = txt_precioLockpicks.Text;
            var validationResult = ValidateTextBoxData(newLockpicksPriceText, _MAX_LENGTH_PRICE_PRODUCT, Load_LockpicksPrice);
            if (!validationResult) { return; }

            if (newLockpicksPriceText != _actualLockpicksPrice)
            {
                try
                {
                    var ingotResource = _ingotResources.ElementAt(cbo_matLockpicks.SelectedIndex);
                    await _updateLockpicksPriceService.ExecuteAsync(ingotResource, int.Parse(newLockpicksPriceText));
                    await Load_IngotResources();
                }
                catch (Exception) { MessageBox.Show("Ha ocurrido un error inesperado. Prueba otra vez."); }

                Load_LockpicksPrice();
            }
        }
        #endregion

        #region Validaciones
        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- VALIDACIONES ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private bool ValidateTextBoxData(string textBoxData, int textMaxLength, Action loadFunction)
        {
            var validationResult = false;

            if (textBoxData.Length > textMaxLength)
            {
                loadFunction();
                return validationResult;
            }
            else if (textBoxData == "0" || textBoxData == "")
            {
                MessageBox.Show("La cantidad no puede ser 0.");
                loadFunction();
                return validationResult;
            }
            else if (textBoxData.Contains('-'))
            {
                MessageBox.Show("La cantidad no puede ser negativa.");
                loadFunction();
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
