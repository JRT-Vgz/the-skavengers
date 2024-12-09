using _1___Entities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services.OreMapServices;
using _2___Servicios.Services.ProductServices;
using _3___Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CortezosWorkshop.Configuracion
{
    public partial class FormConfigMain : Form
    {
        private readonly IRepository<Product> _productsRepository;
        private readonly UpdateConfiguredResources _updateConfiguredResources;

        private IEnumerable<Product> _products;
        private string _actualConfiguredResources;
        private bool _txt_precioProductosClick = false;

        private const int _MAX_LENGTH_CONFIG_RESOURCES_TEXTBOX = 5;
        public FormConfigMain(IRepository<Product> productsRepository,
            UpdateConfiguredResources updateConfiguredResources)
        {
            InitializeComponent();
            _productsRepository = productsRepository;
            _updateConfiguredResources = updateConfiguredResources;
        }

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormConfigMain_Load(object sender, EventArgs e)
        {
            await Load_Products();
            await Load_ConfigResourcesDefaultData();
        }

        private async Task Load_Products() { _products = await _productsRepository.GetAllAsync(); }
        private async Task Load_ConfigResourcesDefaultData()
        {
            cbo_productos.DataSource = _products;
            cbo_productos.DisplayMember = "Name";
            cbo_productos.SelectedIndex = 0;

            _txt_precioProductosClick = false;

            Load_ConfiguredResources();
        }

        private void Load_ConfiguredResources()
        {
            txt_configResources.Text = _products.ElementAt(cbo_productos.SelectedIndex).Resources.ToString();
            lbl_material.Text = _products.ElementAt(cbo_productos.SelectedIndex).MaterialName;
            _actualConfiguredResources = txt_configResources.Text;
        }

        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------ CONFIGURAR RECURSOS PRODUCTO -------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void cbo_productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ConfiguredResources();
        }

        private void txt_precioProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (e.KeyChar == (char)13)
            {
                Save_New_Configurated_Resources();
                btn_menu_principal.Focus();
            }

            if (textBox.Text.Length == _MAX_LENGTH_CONFIG_RESOURCES_TEXTBOX && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private void txt_precioProductos_Leave(object sender, EventArgs e) { Save_New_Configurated_Resources(); }

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
                    var product = _products.ElementAt(cbo_productos.SelectedIndex);
                    await _updateConfiguredResources.ExecuteAsync(product, int.Parse(newConfiguratedResourcesText));
                }
                catch (Exception) { }

                Load_ConfiguredResources();
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
