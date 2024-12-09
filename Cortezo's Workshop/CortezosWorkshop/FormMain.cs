using _1___Entities;
using _2___Servicios.Interfaces;
using _3_Presenters.ViewModels;
using CortezosWorkshop.Configuracion;
using CortezosWorkshop.Estadisticas;
using CortezosWorkshop.Maps;
using CortezosWorkshop.Precios;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CortezosWorkshop
{
    public partial class FormMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly IPresenter<ShopStat, FundsViewModel> _presenter;
        public FormMain(IServiceProvider serviceProvider,
            IRepository<ShopStat> shopStatsRepository,
            IPresenter<ShopStat, FundsViewModel> presenter)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _shopStatsRepository = shopStatsRepository;
            _presenter = presenter;
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------------- TESORERIA ----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private async void FormMain_Load(object sender, EventArgs e)
        {
            await Load_Funds();
        }

        private async Task Load_Funds()
        {
            int idCajaFuerte = 1;
            var shopStatCajaFuerte = await _shopStatsRepository.GetByIdAsync(idCajaFuerte);
            var fundsViewModel = _presenter.Present(shopStatCajaFuerte);
            lbl_Oro.Text = fundsViewModel.Funds;
        }

        // -------------------------------------------------------------------------------------------------------
        // ----------------------------------------------- BOTONES -----------------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void btn_mapas_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormMapsMain>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            this.Show();
        }

        private void btn_precios_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormPreciosMain>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            this.Show();
        }

        private void btn_config_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormConfigMain>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            this.Show();
        }

        private void btn_estadisticas_Click(object sender, EventArgs e)
        {
            this.Hide();

            var frm = _serviceProvider.GetRequiredService<FormEstadisticasMain>();
            frm.Location = new Point(this.Location.X, this.Location.Y);
            frm.ShowDialog();

            this.Show();
        }

        private void btn_addFunds_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormMainEditFunds>();
            lbl_Oro.Text = "???";
            frm.ShowDialog();

            Load_Funds();
        }

        private void btn_beneficio_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormMainBeneficio>();
            lbl_Oro.Text = "???";
            frm.ShowDialog();

            Load_Funds();
        }             

        private void btn_portapapeles_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("Cortezo's cheap Tools & Armor");
        }
    }
}
