
using _1_Domain.CortezosWorkshop.Entities;
using _1_Domain.CortezosWorkshop.Interfaces;
using _2_Application.CortezosWorkshop.Services.ShopStatServices;
using _2_Application.TheSkavengers.Services;
using _3_Data.CortezosWorkshop;
using _3_Presenters.CortezosWorkshop.ViewModels;
using Forms.Armory.Forms;
using Forms.CortezosWorkshop;
using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContext _context;

        public FormTheSkavengersMain(IServiceProvider serviceProvider,
            AppDbContext context)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _context = context;
        }

        private void FormTheSkavengersMain_Load(object sender, EventArgs e)
        {
             PrecargarDatos();
        }

        private void PrecargarDatos()
        {
            _context.ShopStats.Take(0).ToList();
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
