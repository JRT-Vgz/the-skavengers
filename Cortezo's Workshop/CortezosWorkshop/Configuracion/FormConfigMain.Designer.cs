namespace CortezosWorkshop.Configuracion
{
    partial class FormConfigMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_menu_principal = new Button();
            lbl_configRecursos = new Label();
            cbo_productos = new ComboBox();
            txt_configResources = new TextBox();
            lbl_material = new Label();
            lbl_configPrecios = new Label();
            lbl_armaduraCompleta = new Label();
            cbo_matArCompleta = new ComboBox();
            txt_precioArCompleta = new TextBox();
            lbl_flecha1 = new Label();
            lbl_gp1 = new Label();
            lbl_gp2 = new Label();
            lbl_flecha2 = new Label();
            txt_precioHerramienta = new TextBox();
            cbo_matHerramienta = new ComboBox();
            lbl_herramienta = new Label();
            label1 = new Label();
            label2 = new Label();
            txt_precioLockpicks = new TextBox();
            cbo_matLockpicks = new ComboBox();
            lbl_lockpicks = new Label();
            SuspendLayout();
            // 
            // btn_menu_principal
            // 
            btn_menu_principal.Location = new Point(12, 12);
            btn_menu_principal.Name = "btn_menu_principal";
            btn_menu_principal.Size = new Size(99, 23);
            btn_menu_principal.TabIndex = 1;
            btn_menu_principal.Text = "Menú principal";
            btn_menu_principal.UseVisualStyleBackColor = true;
            btn_menu_principal.Click += btn_menu_principal_Click;
            // 
            // lbl_configRecursos
            // 
            lbl_configRecursos.AutoSize = true;
            lbl_configRecursos.Location = new Point(80, 96);
            lbl_configRecursos.Name = "lbl_configRecursos";
            lbl_configRecursos.Size = new Size(114, 15);
            lbl_configRecursos.TabIndex = 2;
            lbl_configRecursos.Text = "Configurar recursos:";
            // 
            // cbo_productos
            // 
            cbo_productos.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_productos.FormattingEnabled = true;
            cbo_productos.Location = new Point(210, 93);
            cbo_productos.Name = "cbo_productos";
            cbo_productos.Size = new Size(155, 23);
            cbo_productos.TabIndex = 3;
            cbo_productos.SelectedIndexChanged += cbo_productos_SelectedIndexChanged;
            // 
            // txt_configResources
            // 
            txt_configResources.Location = new Point(386, 93);
            txt_configResources.Name = "txt_configResources";
            txt_configResources.Size = new Size(100, 23);
            txt_configResources.TabIndex = 4;
            txt_configResources.TextAlign = HorizontalAlignment.Center;
            txt_configResources.KeyDown += txt_configResources_KeyDown;
            txt_configResources.KeyPress += txt_configResources_KeyPress;
            txt_configResources.Leave += txt_configResources_Leave;
            // 
            // lbl_material
            // 
            lbl_material.AutoSize = true;
            lbl_material.Location = new Point(503, 96);
            lbl_material.Name = "lbl_material";
            lbl_material.Size = new Size(50, 15);
            lbl_material.TabIndex = 5;
            lbl_material.Text = "Material";
            // 
            // lbl_configPrecios
            // 
            lbl_configPrecios.AutoSize = true;
            lbl_configPrecios.Location = new Point(80, 187);
            lbl_configPrecios.Name = "lbl_configPrecios";
            lbl_configPrecios.Size = new Size(156, 15);
            lbl_configPrecios.TabIndex = 6;
            lbl_configPrecios.Text = "Configurar precios de venta:";
            // 
            // lbl_armaduraCompleta
            // 
            lbl_armaduraCompleta.AutoSize = true;
            lbl_armaduraCompleta.Location = new Point(147, 222);
            lbl_armaduraCompleta.Name = "lbl_armaduraCompleta";
            lbl_armaduraCompleta.Size = new Size(135, 15);
            lbl_armaduraCompleta.TabIndex = 7;
            lbl_armaduraCompleta.Text = "Armadura completa de :";
            // 
            // cbo_matArCompleta
            // 
            cbo_matArCompleta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_matArCompleta.FormattingEnabled = true;
            cbo_matArCompleta.Location = new Point(285, 219);
            cbo_matArCompleta.Name = "cbo_matArCompleta";
            cbo_matArCompleta.Size = new Size(117, 23);
            cbo_matArCompleta.TabIndex = 8;
            // 
            // txt_precioArCompleta
            // 
            txt_precioArCompleta.Location = new Point(441, 219);
            txt_precioArCompleta.Name = "txt_precioArCompleta";
            txt_precioArCompleta.Size = new Size(100, 23);
            txt_precioArCompleta.TabIndex = 9;
            txt_precioArCompleta.TextAlign = HorizontalAlignment.Center;
            // 
            // lbl_flecha1
            // 
            lbl_flecha1.AutoSize = true;
            lbl_flecha1.Location = new Point(410, 222);
            lbl_flecha1.Name = "lbl_flecha1";
            lbl_flecha1.Size = new Size(25, 15);
            lbl_flecha1.TabIndex = 10;
            lbl_flecha1.Text = "-->";
            // 
            // lbl_gp1
            // 
            lbl_gp1.AutoSize = true;
            lbl_gp1.Location = new Point(547, 222);
            lbl_gp1.Name = "lbl_gp1";
            lbl_gp1.Size = new Size(21, 15);
            lbl_gp1.TabIndex = 11;
            lbl_gp1.Text = "gp";
            // 
            // lbl_gp2
            // 
            lbl_gp2.AutoSize = true;
            lbl_gp2.Location = new Point(547, 260);
            lbl_gp2.Name = "lbl_gp2";
            lbl_gp2.Size = new Size(21, 15);
            lbl_gp2.TabIndex = 16;
            lbl_gp2.Text = "gp";
            // 
            // lbl_flecha2
            // 
            lbl_flecha2.AutoSize = true;
            lbl_flecha2.Location = new Point(410, 260);
            lbl_flecha2.Name = "lbl_flecha2";
            lbl_flecha2.Size = new Size(25, 15);
            lbl_flecha2.TabIndex = 15;
            lbl_flecha2.Text = "-->";
            // 
            // txt_precioHerramienta
            // 
            txt_precioHerramienta.Location = new Point(441, 257);
            txt_precioHerramienta.Name = "txt_precioHerramienta";
            txt_precioHerramienta.Size = new Size(100, 23);
            txt_precioHerramienta.TabIndex = 14;
            txt_precioHerramienta.TextAlign = HorizontalAlignment.Center;
            // 
            // cbo_matHerramienta
            // 
            cbo_matHerramienta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_matHerramienta.FormattingEnabled = true;
            cbo_matHerramienta.Location = new Point(285, 257);
            cbo_matHerramienta.Name = "cbo_matHerramienta";
            cbo_matHerramienta.Size = new Size(117, 23);
            cbo_matHerramienta.TabIndex = 13;
            // 
            // lbl_herramienta
            // 
            lbl_herramienta.AutoSize = true;
            lbl_herramienta.Location = new Point(187, 260);
            lbl_herramienta.Name = "lbl_herramienta";
            lbl_herramienta.Size = new Size(95, 15);
            lbl_herramienta.TabIndex = 12;
            lbl_herramienta.Text = "Herramienta de :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(547, 298);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 21;
            label1.Text = "gp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(410, 298);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 20;
            label2.Text = "-->";
            // 
            // txt_precioLockpicks
            // 
            txt_precioLockpicks.Location = new Point(441, 295);
            txt_precioLockpicks.Name = "txt_precioLockpicks";
            txt_precioLockpicks.Size = new Size(100, 23);
            txt_precioLockpicks.TabIndex = 19;
            txt_precioLockpicks.TextAlign = HorizontalAlignment.Center;
            // 
            // cbo_matLockpicks
            // 
            cbo_matLockpicks.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_matLockpicks.FormattingEnabled = true;
            cbo_matLockpicks.Location = new Point(285, 295);
            cbo_matLockpicks.Name = "cbo_matLockpicks";
            cbo_matLockpicks.Size = new Size(117, 23);
            cbo_matLockpicks.TabIndex = 18;
            // 
            // lbl_lockpicks
            // 
            lbl_lockpicks.AutoSize = true;
            lbl_lockpicks.Location = new Point(198, 298);
            lbl_lockpicks.Name = "lbl_lockpicks";
            lbl_lockpicks.Size = new Size(81, 15);
            lbl_lockpicks.TabIndex = 17;
            lbl_lockpicks.Text = "Lockpicks de :";
            // 
            // FormConfigMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txt_precioLockpicks);
            Controls.Add(cbo_matLockpicks);
            Controls.Add(lbl_lockpicks);
            Controls.Add(lbl_gp2);
            Controls.Add(lbl_flecha2);
            Controls.Add(txt_precioHerramienta);
            Controls.Add(cbo_matHerramienta);
            Controls.Add(lbl_herramienta);
            Controls.Add(lbl_gp1);
            Controls.Add(lbl_flecha1);
            Controls.Add(txt_precioArCompleta);
            Controls.Add(cbo_matArCompleta);
            Controls.Add(lbl_armaduraCompleta);
            Controls.Add(lbl_configPrecios);
            Controls.Add(lbl_material);
            Controls.Add(txt_configResources);
            Controls.Add(cbo_productos);
            Controls.Add(lbl_configRecursos);
            Controls.Add(btn_menu_principal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConfigMain";
            StartPosition = FormStartPosition.Manual;
            Text = "Configuración";
            FormClosing += Form_Closing;
            Load += FormConfigMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_menu_principal;
        private Label lbl_configRecursos;
        private ComboBox cbo_productos;
        private TextBox txt_configResources;
        private Label lbl_material;
        private Label lbl_configPrecios;
        private Label lbl_armaduraCompleta;
        private ComboBox cbo_matArCompleta;
        private TextBox txt_precioArCompleta;
        private Label lbl_flecha1;
        private Label lbl_gp1;
        private Label lbl_gp2;
        private Label lbl_flecha2;
        private TextBox txt_precioHerramienta;
        private ComboBox cbo_matHerramienta;
        private Label lbl_herramienta;
        private Label label1;
        private Label label2;
        private TextBox txt_precioLockpicks;
        private ComboBox cbo_matLockpicks;
        private Label lbl_lockpicks;
    }
}