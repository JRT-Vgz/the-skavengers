using _1___Entities;
using _2___Servicios.Interfaces;
using _2___Servicios.Services.ShopStatServices;
using _3___Repository;
using _3_Mappers.Dtos.ShopStatDtos;
using _3_Presenters.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CortezosWorkshop
{
    public partial class FormMainEditFunds : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRepository<ShopStat> _shopStatsRepository;
        private readonly IPresenter<ShopStat, FundsViewModel> _presenter;
        private readonly UpdateShopStat<ShopStatUpdateDto> _updateShowStat;

        public FormMainEditFunds(IServiceProvider serviceProvider,
            IRepository<ShopStat> shopStatsRepository,
            IPresenter<ShopStat, FundsViewModel> presenter,
            UpdateShopStat<ShopStatUpdateDto> updateShowStat)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _shopStatsRepository = shopStatsRepository;
            _presenter = presenter;
            _updateShowStat = updateShowStat;
        }

        private async void FormMainEditFunds_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X + 300, this.Location.Y + 165);
            await Load_Funds();
        }
        private async Task Load_Funds()
        {
            int idOro = 1;
            var shopStatOro = await _shopStatsRepository.GetByIdAsync(idOro);
            var shopStatOroViewModel = _presenter.Present(shopStatOro);
            lbl_Oro.Text = shopStatOroViewModel.Funds;
        }

        private void FormMainEditFunds_Shown(object sender, EventArgs e)
        {
            txtBox.Focus();
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (sender as TextBox);
            if (e.KeyChar == (char)13) 
            { 
                if (textBox.Text.Length == 0) { btn_Back_Click(sender, e); }
                btn_Save_Click(sender, e); 
            }
           
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == '-' && textBox.SelectionStart == 0) { return; }

                e.Handled = true;
            }

            if (textBox.Text.Length == 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (txtBox.Text.Length == 0 || (txtBox.Text.Length == 1 && txtBox.Text == "-"))
            {
                Reset_TextBox();
                return;
            }

            var txtBoxQuantity = int.Parse(txtBox.Text);
            var actualFunds = int.Parse(lbl_Oro.Text.Replace(".", "").Replace(" gp", ""));
            var newFunds = actualFunds + txtBoxQuantity;
            Save_Funds_And_Reset_Form(newFunds);
        }

        private void Reset_TextBox()
        {
            txtBox.Text = "";
            txtBox.Focus();
        }
        private async void Save_Funds_And_Reset_Form(int newFunds)
        {
            var shopStatUpdateDto = new ShopStatUpdateDto
            {
                Name = "Oro",
                Quantity = newFunds
            };

            await _updateShowStat.ExecuteAsync(shopStatUpdateDto, 1);
            Reset_TextBox();
            await Load_Funds();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
