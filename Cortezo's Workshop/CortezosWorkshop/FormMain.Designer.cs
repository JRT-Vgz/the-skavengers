namespace CortezosWorkshop
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_precios = new Button();
            btn_mapas = new Button();
            btn_config = new Button();
            lbl_Titulo = new Label();
            lbl_Tesoreria = new Label();
            lbl_Oro = new Label();
            btn_addFunds = new Button();
            btn_beneficio = new Button();
            SuspendLayout();
            // 
            // btn_precios
            // 
            btn_precios.Location = new Point(280, 156);
            btn_precios.Name = "btn_precios";
            btn_precios.Size = new Size(238, 33);
            btn_precios.TabIndex = 0;
            btn_precios.Text = "PRECIOS";
            btn_precios.UseVisualStyleBackColor = true;
            btn_precios.Click += btn_precios_Click;
            // 
            // btn_mapas
            // 
            btn_mapas.Location = new Point(280, 222);
            btn_mapas.Name = "btn_mapas";
            btn_mapas.Size = new Size(238, 33);
            btn_mapas.TabIndex = 1;
            btn_mapas.Text = "MAPAS";
            btn_mapas.UseVisualStyleBackColor = true;
            btn_mapas.Click += btn_mapas_Click;
            // 
            // btn_config
            // 
            btn_config.Location = new Point(280, 287);
            btn_config.Name = "btn_config";
            btn_config.Size = new Size(238, 33);
            btn_config.TabIndex = 2;
            btn_config.Text = "CONFIGURACIÓN";
            btn_config.UseVisualStyleBackColor = true;
            btn_config.Click += btn_config_Click;
            // 
            // lbl_Titulo
            // 
            lbl_Titulo.AutoSize = true;
            lbl_Titulo.Location = new Point(332, 39);
            lbl_Titulo.Name = "lbl_Titulo";
            lbl_Titulo.Size = new Size(135, 15);
            lbl_Titulo.TabIndex = 3;
            lbl_Titulo.Text = "CORTEZO'S WORKSHOP";
            // 
            // lbl_Tesoreria
            // 
            lbl_Tesoreria.AutoSize = true;
            lbl_Tesoreria.Location = new Point(368, 359);
            lbl_Tesoreria.Name = "lbl_Tesoreria";
            lbl_Tesoreria.Size = new Size(56, 15);
            lbl_Tesoreria.TabIndex = 4;
            lbl_Tesoreria.Text = "Tesorería:";
            // 
            // lbl_Oro
            // 
            lbl_Oro.AutoSize = true;
            lbl_Oro.Location = new Point(380, 387);
            lbl_Oro.Name = "lbl_Oro";
            lbl_Oro.Size = new Size(0, 15);
            lbl_Oro.TabIndex = 5;
            // 
            // btn_addFunds
            // 
            btn_addFunds.Location = new Point(494, 383);
            btn_addFunds.Name = "btn_addFunds";
            btn_addFunds.Size = new Size(92, 22);
            btn_addFunds.TabIndex = 6;
            btn_addFunds.Text = "Caja fuerte";
            btn_addFunds.UseVisualStyleBackColor = true;
            btn_addFunds.Click += btn_addFunds_Click;
            // 
            // btn_beneficio
            // 
            btn_beneficio.Location = new Point(215, 383);
            btn_beneficio.Name = "btn_beneficio";
            btn_beneficio.Size = new Size(92, 22);
            btn_beneficio.TabIndex = 7;
            btn_beneficio.Text = "Beneficio";
            btn_beneficio.UseVisualStyleBackColor = true;
            btn_beneficio.Click += btn_beneficio_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_beneficio);
            Controls.Add(btn_addFunds);
            Controls.Add(lbl_Oro);
            Controls.Add(lbl_Tesoreria);
            Controls.Add(lbl_Titulo);
            Controls.Add(btn_config);
            Controls.Add(btn_mapas);
            Controls.Add(btn_precios);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cortezo's Workshop";
            Load += FormMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_precios;
        private Button btn_mapas;
        private Button btn_config;
        private Label lbl_Titulo;
        private Label lbl_Tesoreria;
        private Label lbl_Oro;
        private Button btn_addFunds;
        private Button btn_beneficio;
    }
}
