using _1___Entities;
using _2___Servicios.Interfaces;
using CortezosWorkshop.Configuracion;
using CortezosWorkshop.Maps;
using CortezosWorkshop.Precios;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CortezosWorkshop
{
    public partial class FormMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public FormMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btn_mapas_Click(object sender, EventArgs e)
        {
            var parentLocation = this.Location;
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormMapsMain>();
            frm.Location = new Point(parentLocation.X, parentLocation.Y);
            frm.ShowDialog();

            this.Show();
        }

        private void btn_precios_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormPreciosMain>();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btn_config_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormConfigMain>();
            //this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
