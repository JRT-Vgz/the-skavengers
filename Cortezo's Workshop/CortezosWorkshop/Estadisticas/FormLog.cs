using _3___Repository.QueryObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CortezosWorkshop.Estadisticas
{
    public partial class FormLog : Form
    {
        private readonly LogQuery _logQuery;
        public FormLog(LogQuery logQuery)
        {
            InitializeComponent();
            _logQuery = logQuery;
        }

        private async void FormLogs_Load(object sender, EventArgs e)
        {
            await LoadLogs();
        }

        private async Task LoadLogs()
        {
            var logs = await _logQuery.GetLogsAsync();
            var logsList = logs.ToList();

            var logLabelsArray = new Label[]
            {
                lbl_log1, lbl_log2, lbl_log3, lbl_log4, lbl_log5, lbl_log6, lbl_log7, lbl_log8, lbl_log9, lbl_log10,
                lbl_log11, lbl_log12, lbl_log13, lbl_log14, lbl_log15, lbl_log16, lbl_log17, lbl_log18, lbl_log19, lbl_log20
            };

            for (int i = 0; i < logsList.Count; i++)
            {
                logLabelsArray[i].Text = $"{i + 1} - {logsList[i].Entry}";
            }
        }

        // -------------------------------------------------------------------------------------------------------
        // ---------------------------------------- VOLVER A ESTADISTICAS ----------------------------------------
        // -------------------------------------------------------------------------------------------------------
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            var frmMain = Application.OpenForms.OfType<FormEstadisticasMain>().FirstOrDefault();
            frmMain.Location = new Point(this.Location.X, this.Location.Y); ;

            this.Hide();
        }
    }
}
