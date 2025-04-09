using TheSkavengers.Armeria;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSkavengers
{
    public partial class FormTheSkavengersMain : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FormTheSkavengersMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private async void btn_workshop_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormMain>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            this.Show();
        }

        private void btn_armory_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormArmeriaMain>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            this.Show();
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------------- BOTONES -----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
    }
}
