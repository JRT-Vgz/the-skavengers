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

namespace CortezosWorkshop.Maps
{
    public partial class FormMapsMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public FormMapsMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void FormMapsMain_Load(object sender, EventArgs e)
        {
            
        }
    }
}
