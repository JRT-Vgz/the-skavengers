using _1___Entities;
using _2___Servicios.Interfaces;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CortezosWorkshop
{
    public partial class FormMain : Form
    {
        private readonly IRepository<OreMap> _oreMapRepository;
        public FormMain(IRepository<OreMap> oreMapRepository)
        {
            InitializeComponent();
            _oreMapRepository = oreMapRepository;
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            await Refresh();
        }

        private async Task Refresh()
        {
            var oreMaps = await _oreMapRepository.GetAllAsync();
            dgv.DataSource = oreMaps;
        }

    }
}
