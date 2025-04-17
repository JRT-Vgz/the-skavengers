

using _2_Application.TheSkavengers.Services;

namespace Forms.Armory.Forms
{
    public partial class FormArmoryPasswordInputBox : Form
    {
        private readonly ConstantsConfigurationService _configuration;

        public string PasswordSet { get; private set; }

        public FormArmoryPasswordInputBox(ConstantsConfigurationService configuration)
        {
            InitializeComponent();
            _configuration = configuration;
        }


        private void FormArmoryPasswordInputBox_Load(object sender, EventArgs e)
        {
            txt_armoryPassword.Focus();
        }

        // -------------------------------------------------------------------------------------------------------
        // --------------------------------------- CONTROL DE TEXTBOX --------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void txt_armoryPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_ok_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (textBox.Text.Length == _configuration.GetInt("Armory_Constants:_MAX_LENGTH_ARMORY_PASSWORD_TEXTBOX")
                && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // -------------------------------------------------------------------------------------------------------
        // ------------------------------------------- NAVEGACIÓN ------------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_ok_Click(object sender, EventArgs e)
        {
            PasswordSet = txt_armoryPassword.Text;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
