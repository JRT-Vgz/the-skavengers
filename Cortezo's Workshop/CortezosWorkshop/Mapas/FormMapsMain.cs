using _1___Entities;
using _2___Servicios.Interfaces;

namespace CortezosWorkshop.Maps
{
    public partial class FormMapsMain : Form
    {
        private readonly IRepository<OreMap> _oreMapsRepository;

        private bool _txt_materialRecogidoClick = false;
        public FormMapsMain(IRepository<OreMap> oreMapsRepository)
        {
            InitializeComponent();
            _oreMapsRepository = oreMapsRepository;
        }

        // -------------------------------------------------------------------------------------------------------
        // -------------------------------------------- CARGAR DATOS ---------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormMapsMain_Load(object sender, EventArgs e)
        {
            await ChargeData();
        }

        private async Task ChargeData()
        {
            for (int i = 1; i <= 20; i++) { cbo_mapQuantity.Items.Add(i); }
            cbo_mapQuantity.SelectedIndex = 0;

            cbo_oreMaps.DataSource = await _oreMapsRepository.GetAllAsync();
            cbo_oreMaps.DisplayMember = "Name";
            cbo_oreMaps.SelectedIndex = 0;

            txt_materialRecogido.Text = "0";
            _txt_materialRecogidoClick = false;
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

            if (textBox.Text.Length == 5 && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private async void btn_addMap_Click(object sender, EventArgs e)
        {
            if (txt_materialRecogido.Text == "0" || txt_materialRecogido.Text == "")
            {
                MessageBox.Show("Escribe cuánto material has recogido en el mapa.");
                return;
            }

            var txtBoxQuantity = (int)cbo_mapQuantity.SelectedItem;
            var materialRecogido = int.Parse(txt_materialRecogido.Text);
            await Update_Ore_Map_Data(txtBoxQuantity, materialRecogido);
            await ChargeData();
        }

        private async Task Update_Ore_Map_Data(int txtBoxQuantity, int txtBoxMaterialRecogido)
        {
            var selectedOreMap = (OreMap)cbo_oreMaps.SelectedItem;
            var oreMap = await _oreMapsRepository.GetByNameAsync(selectedOreMap.Name);

            oreMap.Quantity = oreMap.Quantity + txtBoxQuantity;
            oreMap.TotalOre = oreMap.TotalOre + txtBoxMaterialRecogido;

            await _oreMapsRepository.UpdateAsync(oreMap);
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
