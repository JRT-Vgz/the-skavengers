using _1___Entities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services;

namespace CortezosWorkshop.Precios
{
    public partial class FormPreciosMain : Form
    {
        #region Constructor
        private readonly IRepository<IngotResource> _ingotResourceRepository;

        private IEnumerable<IngotResource> _ingotResources;

        public FormPreciosMain(IRepository<IngotResource> ingotResourceRepository)
        {
            InitializeComponent();
            _ingotResourceRepository = ingotResourceRepository;
        }
        #endregion

        #region CargarDatos
        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormPreciosMain_Load(object sender, EventArgs e)
        {
            await Load_IngotResources();
            Load_Generic_Products();
            await Load_Prices(i => i.ToolPrice);
        }

        private async Task Load_IngotResources() { _ingotResources = await _ingotResourceRepository.GetAllAsync(); }

        private enum ProductType { FullPlate, Tools }

        private void Load_Generic_Products()
        {
            cbo_producto.Items.Add(new { Text = "Armadura completa", Value = ProductType.FullPlate });
            cbo_producto.Items.Add(new { Text = "Herramientas", Value = ProductType.Tools });
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
                materialLabelsArray[i].Text = ingotResourcesArray[i].IngotName;
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
        }
        #endregion

        #region CopiarPreciosAlPortapapeles

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
