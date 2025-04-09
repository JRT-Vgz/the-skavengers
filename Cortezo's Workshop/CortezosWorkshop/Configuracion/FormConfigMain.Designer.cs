namespace TheSkavengers.Configuracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfigMain));
            btn_volver = new Button();
            lbl_plateArMain = new Label();
            lbl_plateArMats = new Label();
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
            btn_addCraft = new Button();
            txt_materialGastado = new TextBox();
            lbl_materialGastado = new Label();
            cbo_genericProduct = new ComboBox();
            lbl_x = new Label();
            lbl_addCrafts = new Label();
            lbl_plateArCfg = new Label();
            lbl_toolCfg = new Label();
            lbl_toolMats = new Label();
            lbl_toolMain = new Label();
            lbl_lockpickCfg = new Label();
            lbl_lockpickMats = new Label();
            lbl_lockpickMain = new Label();
            txt_quantityCrafted = new TextBox();
            SuspendLayout();
            // 
            // btn_volver
            // 
            btn_volver.Location = new Point(12, 12);
            btn_volver.Name = "btn_volver";
            btn_volver.Size = new Size(99, 23);
            btn_volver.TabIndex = 1;
            btn_volver.Text = "Volver";
            btn_volver.UseVisualStyleBackColor = true;
            btn_volver.Click += btn_volverl_Click;
            // 
            // lbl_plateArMain
            // 
            lbl_plateArMain.AutoSize = true;
            lbl_plateArMain.Location = new Point(283, 140);
            lbl_plateArMain.Name = "lbl_plateArMain";
            lbl_plateArMain.Size = new Size(119, 15);
            lbl_plateArMain.TabIndex = 2;
            lbl_plateArMain.Text = "Armadura completa: ";
            // 
            // lbl_plateArMats
            // 
            lbl_plateArMats.AutoSize = true;
            lbl_plateArMats.Location = new Point(451, 140);
            lbl_plateArMats.Name = "lbl_plateArMats";
            lbl_plateArMats.Size = new Size(50, 15);
            lbl_plateArMats.TabIndex = 5;
            lbl_plateArMats.Text = "Material";
            // 
            // lbl_configPrecios
            // 
            lbl_configPrecios.AutoSize = true;
            lbl_configPrecios.Location = new Point(80, 248);
            lbl_configPrecios.Name = "lbl_configPrecios";
            lbl_configPrecios.Size = new Size(156, 15);
            lbl_configPrecios.TabIndex = 6;
            lbl_configPrecios.Text = "Configurar precios de venta:";
            // 
            // lbl_armaduraCompleta
            // 
            lbl_armaduraCompleta.AutoSize = true;
            lbl_armaduraCompleta.Location = new Point(147, 283);
            lbl_armaduraCompleta.Name = "lbl_armaduraCompleta";
            lbl_armaduraCompleta.Size = new Size(135, 15);
            lbl_armaduraCompleta.TabIndex = 7;
            lbl_armaduraCompleta.Text = "Armadura completa de :";
            // 
            // cbo_matArCompleta
            // 
            cbo_matArCompleta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_matArCompleta.FormattingEnabled = true;
            cbo_matArCompleta.Location = new Point(285, 280);
            cbo_matArCompleta.Name = "cbo_matArCompleta";
            cbo_matArCompleta.Size = new Size(117, 23);
            cbo_matArCompleta.TabIndex = 8;
            // 
            // txt_precioArCompleta
            // 
            txt_precioArCompleta.Location = new Point(441, 280);
            txt_precioArCompleta.Name = "txt_precioArCompleta";
            txt_precioArCompleta.Size = new Size(100, 23);
            txt_precioArCompleta.TabIndex = 9;
            txt_precioArCompleta.TextAlign = HorizontalAlignment.Center;
            // 
            // lbl_flecha1
            // 
            lbl_flecha1.AutoSize = true;
            lbl_flecha1.Location = new Point(410, 283);
            lbl_flecha1.Name = "lbl_flecha1";
            lbl_flecha1.Size = new Size(25, 15);
            lbl_flecha1.TabIndex = 10;
            lbl_flecha1.Text = "-->";
            // 
            // lbl_gp1
            // 
            lbl_gp1.AutoSize = true;
            lbl_gp1.Location = new Point(547, 283);
            lbl_gp1.Name = "lbl_gp1";
            lbl_gp1.Size = new Size(21, 15);
            lbl_gp1.TabIndex = 11;
            lbl_gp1.Text = "gp";
            // 
            // lbl_gp2
            // 
            lbl_gp2.AutoSize = true;
            lbl_gp2.Location = new Point(547, 321);
            lbl_gp2.Name = "lbl_gp2";
            lbl_gp2.Size = new Size(21, 15);
            lbl_gp2.TabIndex = 16;
            lbl_gp2.Text = "gp";
            // 
            // lbl_flecha2
            // 
            lbl_flecha2.AutoSize = true;
            lbl_flecha2.Location = new Point(410, 321);
            lbl_flecha2.Name = "lbl_flecha2";
            lbl_flecha2.Size = new Size(25, 15);
            lbl_flecha2.TabIndex = 15;
            lbl_flecha2.Text = "-->";
            // 
            // txt_precioHerramienta
            // 
            txt_precioHerramienta.Location = new Point(441, 318);
            txt_precioHerramienta.Name = "txt_precioHerramienta";
            txt_precioHerramienta.Size = new Size(100, 23);
            txt_precioHerramienta.TabIndex = 14;
            txt_precioHerramienta.TextAlign = HorizontalAlignment.Center;
            // 
            // cbo_matHerramienta
            // 
            cbo_matHerramienta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_matHerramienta.FormattingEnabled = true;
            cbo_matHerramienta.Location = new Point(285, 318);
            cbo_matHerramienta.Name = "cbo_matHerramienta";
            cbo_matHerramienta.Size = new Size(117, 23);
            cbo_matHerramienta.TabIndex = 13;
            // 
            // lbl_herramienta
            // 
            lbl_herramienta.AutoSize = true;
            lbl_herramienta.Location = new Point(187, 321);
            lbl_herramienta.Name = "lbl_herramienta";
            lbl_herramienta.Size = new Size(95, 15);
            lbl_herramienta.TabIndex = 12;
            lbl_herramienta.Text = "Herramienta de :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(547, 359);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 21;
            label1.Text = "gp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(410, 359);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 20;
            label2.Text = "-->";
            // 
            // txt_precioLockpicks
            // 
            txt_precioLockpicks.Location = new Point(441, 356);
            txt_precioLockpicks.Name = "txt_precioLockpicks";
            txt_precioLockpicks.Size = new Size(100, 23);
            txt_precioLockpicks.TabIndex = 19;
            txt_precioLockpicks.TextAlign = HorizontalAlignment.Center;
            // 
            // cbo_matLockpicks
            // 
            cbo_matLockpicks.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_matLockpicks.FormattingEnabled = true;
            cbo_matLockpicks.Location = new Point(285, 356);
            cbo_matLockpicks.Name = "cbo_matLockpicks";
            cbo_matLockpicks.Size = new Size(117, 23);
            cbo_matLockpicks.TabIndex = 18;
            // 
            // lbl_lockpicks
            // 
            lbl_lockpicks.AutoSize = true;
            lbl_lockpicks.Location = new Point(198, 359);
            lbl_lockpicks.Name = "lbl_lockpicks";
            lbl_lockpicks.Size = new Size(81, 15);
            lbl_lockpicks.TabIndex = 17;
            lbl_lockpicks.Text = "Lockpicks de :";
            // 
            // btn_addCraft
            // 
            btn_addCraft.Location = new Point(679, 82);
            btn_addCraft.Name = "btn_addCraft";
            btn_addCraft.Size = new Size(75, 23);
            btn_addCraft.TabIndex = 27;
            btn_addCraft.Text = "Añadir";
            btn_addCraft.UseVisualStyleBackColor = true;
            btn_addCraft.Click += btn_addCraft_Click;
            // 
            // txt_materialGastado
            // 
            txt_materialGastado.Location = new Point(535, 82);
            txt_materialGastado.Name = "txt_materialGastado";
            txt_materialGastado.Size = new Size(100, 23);
            txt_materialGastado.TabIndex = 25;
            txt_materialGastado.TextAlign = HorizontalAlignment.Center;
            txt_materialGastado.Enter += txt_materialGastado_Enter;
            txt_materialGastado.KeyDown += txt_materialGastado_KeyDown;
            txt_materialGastado.KeyPress += txt_materialGastado_KeyPress;
            // 
            // lbl_materialGastado
            // 
            lbl_materialGastado.AutoSize = true;
            lbl_materialGastado.Location = new Point(426, 85);
            lbl_materialGastado.Name = "lbl_materialGastado";
            lbl_materialGastado.Size = new Size(98, 15);
            lbl_materialGastado.TabIndex = 28;
            lbl_materialGastado.Text = "Material gastado:";
            // 
            // cbo_genericProduct
            // 
            cbo_genericProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_genericProduct.FormattingEnabled = true;
            cbo_genericProduct.Location = new Point(270, 82);
            cbo_genericProduct.Name = "cbo_genericProduct";
            cbo_genericProduct.Size = new Size(150, 23);
            cbo_genericProduct.TabIndex = 24;
            // 
            // lbl_x
            // 
            lbl_x.AutoSize = true;
            lbl_x.Location = new Point(242, 90);
            lbl_x.Name = "lbl_x";
            lbl_x.Size = new Size(13, 15);
            lbl_x.TabIndex = 26;
            lbl_x.Text = "x";
            // 
            // lbl_addCrafts
            // 
            lbl_addCrafts.AutoSize = true;
            lbl_addCrafts.Location = new Point(80, 85);
            lbl_addCrafts.Name = "lbl_addCrafts";
            lbl_addCrafts.Size = new Size(90, 15);
            lbl_addCrafts.TabIndex = 23;
            lbl_addCrafts.Text = "Añadir crafteos:";
            // 
            // lbl_plateArCfg
            // 
            lbl_plateArCfg.Location = new Point(408, 140);
            lbl_plateArCfg.Name = "lbl_plateArCfg";
            lbl_plateArCfg.Size = new Size(25, 15);
            lbl_plateArCfg.TabIndex = 29;
            lbl_plateArCfg.Text = "0";
            lbl_plateArCfg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_toolCfg
            // 
            lbl_toolCfg.Location = new Point(408, 164);
            lbl_toolCfg.Name = "lbl_toolCfg";
            lbl_toolCfg.Size = new Size(25, 15);
            lbl_toolCfg.TabIndex = 32;
            lbl_toolCfg.Text = "0";
            lbl_toolCfg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_toolMats
            // 
            lbl_toolMats.AutoSize = true;
            lbl_toolMats.Location = new Point(451, 164);
            lbl_toolMats.Name = "lbl_toolMats";
            lbl_toolMats.Size = new Size(50, 15);
            lbl_toolMats.TabIndex = 31;
            lbl_toolMats.Text = "Material";
            // 
            // lbl_toolMain
            // 
            lbl_toolMain.AutoSize = true;
            lbl_toolMain.Location = new Point(318, 164);
            lbl_toolMain.Name = "lbl_toolMain";
            lbl_toolMain.Size = new Size(84, 15);
            lbl_toolMain.TabIndex = 30;
            lbl_toolMain.Text = "Herramientas: ";
            // 
            // lbl_lockpickCfg
            // 
            lbl_lockpickCfg.Location = new Point(408, 188);
            lbl_lockpickCfg.Name = "lbl_lockpickCfg";
            lbl_lockpickCfg.Size = new Size(25, 15);
            lbl_lockpickCfg.TabIndex = 35;
            lbl_lockpickCfg.Text = "0";
            lbl_lockpickCfg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_lockpickMats
            // 
            lbl_lockpickMats.AutoSize = true;
            lbl_lockpickMats.Location = new Point(451, 188);
            lbl_lockpickMats.Name = "lbl_lockpickMats";
            lbl_lockpickMats.Size = new Size(50, 15);
            lbl_lockpickMats.TabIndex = 34;
            lbl_lockpickMats.Text = "Material";
            // 
            // lbl_lockpickMain
            // 
            lbl_lockpickMain.AutoSize = true;
            lbl_lockpickMain.Location = new Point(337, 188);
            lbl_lockpickMain.Name = "lbl_lockpickMain";
            lbl_lockpickMain.Size = new Size(65, 15);
            lbl_lockpickMain.TabIndex = 33;
            lbl_lockpickMain.Text = "Lockpicks: ";
            // 
            // txt_quantityCrafted
            // 
            txt_quantityCrafted.Location = new Point(183, 83);
            txt_quantityCrafted.Name = "txt_quantityCrafted";
            txt_quantityCrafted.Size = new Size(53, 23);
            txt_quantityCrafted.TabIndex = 36;
            txt_quantityCrafted.Text = "0";
            txt_quantityCrafted.TextAlign = HorizontalAlignment.Center;
            txt_quantityCrafted.Enter += txt_quantityCrafted_Enter;
            txt_quantityCrafted.KeyDown += txt_quantityCrafted_KeyDown;
            txt_quantityCrafted.KeyPress += txt_quantityCrafted_KeyPress;
            // 
            // FormConfigMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txt_quantityCrafted);
            Controls.Add(lbl_lockpickCfg);
            Controls.Add(lbl_lockpickMats);
            Controls.Add(lbl_lockpickMain);
            Controls.Add(lbl_toolCfg);
            Controls.Add(lbl_toolMats);
            Controls.Add(lbl_toolMain);
            Controls.Add(lbl_plateArCfg);
            Controls.Add(btn_addCraft);
            Controls.Add(txt_materialGastado);
            Controls.Add(lbl_materialGastado);
            Controls.Add(cbo_genericProduct);
            Controls.Add(lbl_x);
            Controls.Add(lbl_addCrafts);
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
            Controls.Add(lbl_plateArMats);
            Controls.Add(lbl_plateArMain);
            Controls.Add(btn_volver);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimizeBox = false;
            MinimumSize = new Size(816, 489);
            Name = "FormConfigMain";
            StartPosition = FormStartPosition.Manual;
            Text = "Configuración";
            FormClosing += Form_Closing;
            Load += FormConfigMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_volver;
        private Label lbl_plateArMain;
        private Label lbl_plateArMats;
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
        private Button btn_addCraft;
        private TextBox txt_materialGastado;
        private Label lbl_materialGastado;
        private ComboBox cbo_genericProduct;
        private Label lbl_x;
        private Label lbl_addCrafts;
        private Label lbl_plateArCfg;
        private Label lbl_toolCfg;
        private Label lbl_toolMats;
        private Label lbl_toolMain;
        private Label lbl_lockpickCfg;
        private Label lbl_lockpickMats;
        private Label lbl_lockpickMain;
        private TextBox txt_quantityCrafted;
    }
}