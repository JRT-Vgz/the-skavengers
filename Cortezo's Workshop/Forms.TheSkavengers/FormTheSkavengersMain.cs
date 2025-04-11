
using Forms.Armory.Forms;
using Forms.CortezosWorkshop;
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

namespace Forms.TheSkavengers
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

            var frm = _serviceProvider.GetRequiredService<FormCortezosWorkshopMain>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }

        private void btn_armory_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormAutoEquipTemplate>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            this.Location = new Point(frm.Location.X, frm.Location.Y);
            this.Show();
        }


        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------------- BOTONES -----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
    }
}
