using _1___Entities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services;

namespace CortezosWorkshop.Precios
{
    public partial class FormPreciosMain : Form
    {
        private readonly ConfigurationService _configuration;
        private readonly IRepository<GenericProduct> _genericProductsRepository;
        private readonly IRepository<IngotResource> _ingotResourceRepository;

        private IEnumerable<IngotResource> _ingotResources;
        private IEnumerable<GenericProduct> _genericProducts;

        public FormPreciosMain(ConfigurationService configuration,
            IRepository<GenericProduct> genericProductsRepository,
            IRepository<IngotResource> ingotResourceRepository)
        {
            InitializeComponent();
            _configuration = configuration;
            _genericProductsRepository = genericProductsRepository;
            _ingotResourceRepository = ingotResourceRepository;
        }

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormPreciosMain_Load(object sender, EventArgs e)
        {
            await Load_IngotResources();
            await Load_Generic_Products();
            await Load_ToolsPrices();
        }

        private async Task Load_IngotResources() { _ingotResources = await _ingotResourceRepository.GetAllAsync(); }

        private async Task Load_Generic_Products()
        {
            _genericProducts = await _genericProductsRepository.GetAllAsync();

            cbo_producto.DataSource = _genericProducts;
            cbo_producto.DisplayMember = "Name";
            cbo_producto.SelectedIndex = 1;
        }

        private async Task Load_FullPlatesPrices()
        {
            var ingotResourcesList = _ingotResources.ToList();

            var materialLabelsList = new List<Label>()
            {
                lbl_material1, lbl_material2, lbl_material3, lbl_material4, lbl_material5,
                lbl_material6, lbl_material7, lbl_material8, lbl_material9
            };

            var priceLabelsList = new List<Label>()
            {
                lbl_precio1, lbl_precio2, lbl_precio3, lbl_precio4, lbl_precio5,
                lbl_precio6, lbl_precio7, lbl_precio8, lbl_precio9
            };

            for (int i = 0; i < ingotResourcesList.Count; i++)
            {
                materialLabelsList[i].Text = ingotResourcesList[i].IngotName;
                priceLabelsList[i].Text = ingotResourcesList[i].FullPlatePrice.ToString();
            }
        }

        private async Task Load_ToolsPrices()
        {
            var ingotResourcesList = _ingotResources.ToList();

            var materialLabelsList = new List<Label>()
            {
                lbl_material1, lbl_material2, lbl_material3, lbl_material4, lbl_material5,
                lbl_material6, lbl_material7, lbl_material8, lbl_material9
            };

            var priceLabelsList = new List<Label>()
            {
                lbl_precio1, lbl_precio2, lbl_precio3, lbl_precio4, lbl_precio5,
                lbl_precio6, lbl_precio7, lbl_precio8, lbl_precio9
            };

            for (int i = 0; i < ingotResourcesList.Count; i++)
            {
                materialLabelsList[i].Text = ingotResourcesList[i].IngotName;
                priceLabelsList[i].Text = ingotResourcesList[i].ToolPrice.ToString();
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------- CAMBIO DE PRODUCTO ------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void cbo_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var genericProductText = _genericProducts.ElementAt(cbo_producto.SelectedIndex).Name;

            if (genericProductText == _configuration.Configuration["Constants:_GENERICPROD_FULL_PLATE"]) 
                { await Load_FullPlatesPrices(); }
            else if (genericProductText == _configuration.Configuration["Constants:_GENERICPROD_TOOLS"]) 
                { await Load_ToolsPrices(); }
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------- COPIAR PRECIOS AL PORTAPAPELES ------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_copiar1_Click(object sender, EventArgs e) { Clipboard.SetText(lbl_precio1.Text); }
        private void btn_copiar2_Click(object sender, EventArgs e) { Clipboard.SetText(lbl_precio2.Text); }
        private void btn_copiar3_Click(object sender, EventArgs e) { Clipboard.SetText(lbl_precio3.Text); }
        private void btn_copiar4_Click(object sender, EventArgs e) { Clipboard.SetText(lbl_precio4.Text); }
        private void btn_copiar5_Click(object sender, EventArgs e) { Clipboard.SetText(lbl_precio5.Text); }
        private void btn_copiar6_Click(object sender, EventArgs e) { Clipboard.SetText(lbl_precio6.Text); }
        private void btn_copiar7_Click(object sender, EventArgs e) { Clipboard.SetText(lbl_precio7.Text); }
        private void btn_copiar8_Click(object sender, EventArgs e) { Clipboard.SetText(lbl_precio8.Text); }
        private void btn_copiar9_Click(object sender, EventArgs e) { Clipboard.SetText(lbl_precio9.Text); }

        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------------- NAVEGACIÓN ----------------------------------------------
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
