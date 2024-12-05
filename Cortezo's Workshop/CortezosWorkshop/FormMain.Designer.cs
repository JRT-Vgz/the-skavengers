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
            label1 = new Label();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(332, 39);
            label1.Name = "label1";
            label1.Size = new Size(135, 15);
            label1.TabIndex = 3;
            label1.Text = "CORTEZO'S WORKSHOP";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btn_config);
            Controls.Add(btn_mapas);
            Controls.Add(btn_precios);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cortezo's Workshop";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_precios;
        private Button btn_mapas;
        private Button btn_config;
        private Label label1;
    }
}
