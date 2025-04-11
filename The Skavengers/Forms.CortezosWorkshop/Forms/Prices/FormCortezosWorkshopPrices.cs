using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;
using _1_Domain.TheSkavengers.Interfaces;
using _2_Application.TheSkavengers.Services;

namespace Forms.CortezosWorkshop.Forms.Prices
{
    public partial class FormCortezosWorkshopPrices : Form
    {
        #region Constructor
        private readonly ConstantsConfigurationService _configuration;
        private readonly IRepository<IngotResource> _ingotResourceRepository;
        private readonly ISoundSystem _soundSystem;

        private IEnumerable<IngotResource> _ingotResources;
        private bool _isClosing = false;

        public bool IsClosing { get { return _isClosing; } }

        public FormCortezosWorkshopPrices(ConstantsConfigurationService configuration,
            IRepository<IngotResource> ingotResourceRepository,
            ISoundSystem soundSystem)
        {
            InitializeComponent();
            _configuration = configuration;
            _ingotResourceRepository = ingotResourceRepository;
            _soundSystem = soundSystem;
        }
        #endregion

        #region CargarDatos
        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormPreciosMain_Load(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_OPEN_DOOR"]);

            await Load_IngotResources();
            Load_Generic_Products();
            await Load_Prices(i => i.ToolPrice);
        }

        private async Task Load_IngotResources() { _ingotResources = await _ingotResourceRepository.GetAllAsync(); }

        private enum ProductType { FullPlate, Tools, Lockpicks }

        private void Load_Generic_Products()
        {
            cbo_producto.Items.Add(new { Text = "Armadura completa", Value = ProductType.FullPlate });
            cbo_producto.Items.Add(new { Text = "Herramientas", Value = ProductType.Tools });
            cbo_producto.Items.Add(new { Text = "Lockpicks", Value = ProductType.Lockpicks });
            cbo_producto.DisplayMember = "Text";
            cbo_producto.SelectedIndex = 1;
        }

        private async Task Load_Prices(Func<IngotResource, int> propertySelector)
        {
            var ingotResourcesArray = _ingotResources.ToArray();

            var materialLabelsArray = new Label[]
            {
                lbl_material1, lbl_material2, lbl_material3, lbl_material4, lbl_material5,
                lbl_material6, lbl_material7, lbl_material8, lbl_material9
            };

            var priceLabelsArray = new Label[]
            {
                lbl_precio1, lbl_precio2, lbl_precio3, lbl_precio4, lbl_precio5,
                lbl_precio6, lbl_precio7, lbl_precio8, lbl_precio9,
            };

            for (int i = 0; i < ingotResourcesArray.Length; i++)
            {
                materialLabelsArray[i].Text = ingotResourcesArray[i].ResourceName;
                priceLabelsArray[i].Text = propertySelector(ingotResourcesArray[i]).ToString();
            }
        }
        #endregion

        #region CambioDeProducto

        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- CAMBIO DE PRODUCTO ------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void cbo_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProductType = (ProductType)((dynamic)cbo_producto.SelectedItem).Value;

            if (selectedProductType == ProductType.FullPlate) { await Load_Prices(i => i.FullPlatePrice); }
            else if (selectedProductType == ProductType.Tools) { await Load_Prices(i => i.ToolPrice); }
            else if (selectedProductType == ProductType.Lockpicks) { await Load_Prices(i => i.LockpicksPrice); }
        }
        #endregion

        #region CopiarPreciosAlPortapapeles

        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------- COPIAR PRECIOS AL PORTAPAPELES ------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_copiar_Click(object sender, EventArgs e)
        {
            btn_copiar1.Tag = "lbl_precio1";
            btn_copiar2.Tag = "lbl_precio2";
            btn_copiar3.Tag = "lbl_precio3";
            btn_copiar4.Tag = "lbl_precio4";
            btn_copiar5.Tag = "lbl_precio5";
            btn_copiar6.Tag = "lbl_precio6";
            btn_copiar7.Tag = "lbl_precio7";
            btn_copiar8.Tag = "lbl_precio8";
            btn_copiar9.Tag = "lbl_precio9";

            var button = (Button)sender;
            string labelName = button.Tag.ToString();

            var label = this.Controls.Find(labelName, true).FirstOrDefault() as Label;

            if (label != null)
            {
                _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_COPY_PRICE"]);

                Clipboard.SetText(label.Text);
            }
        }

        #endregion

        #region CopiarTodoAlPortapapeles
        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------- COPIAR TODO AL PORTAPAPELES -------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_copyAll_Click(object sender, EventArgs e)
        {
            var toolsTextArray = new string[]
            {
                "Herramientas-Dull", "Herramientas-Shadow", "Herramientas-Copper", "Herramientas-Bronze", "Herramientas-Gold",
                "Herramientas-Agapite", "Herramientas-Verite", "Herramientas-Valorite", "Herramientas-Avarite"
            };
            var lockpicksTextArray = new string[]
            {
                "Lockpicks-Dull", "Lockpicks-Shadow", "Lockpicks-Copper", "Lockpicks-Bronze", "Lockpicks-Gold",
                "Lockpicks-Agapite", "Lockpicks-Verite", "Lockpicks-Valorite", "Lockpicks-Avarite"
            };

            var ingotResourceArray = _ingotResources.ToArray();

            var text = "# HERRAMIENTAS:\n";

            for (int i = 0; i < toolsTextArray.Length; i++)
            {
                text += $"    setvar! {toolsTextArray[i]} '{ingotResourceArray[i].ToolPrice}'\n";
            }

            text += "\n# LOCKPICKS:\n";

            for (int i = 0; i < lockpicksTextArray.Length; i++)
            {
                text += $"    setvar! {lockpicksTextArray[i]} '{ingotResourceArray[i].LockpicksPrice}'\n";
            }

            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_COPY_ALL_PRICES"]);

            Clipboard.SetText(text);
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
                _isClosing = true;
                Application.Exit();
            }
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            _soundSystem.PlaySound(_configuration.Configuration["Constants:_SOUND_CLOSE_DOOR"]);

            this.Hide();
        }
        #endregion
    }
}
