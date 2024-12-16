namespace CortezosWorkshop.Maps
{
    partial class FormMapsMain
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
            lbl_addMap = new Label();
            lbl_x = new Label();
            cbo_oreMaps = new ComboBox();
            lbl_materialRecogido = new Label();
            txt_materialRecogido = new TextBox();
            btn_addMap = new Button();
            cbo_mapQuantity = new ComboBox();
            lbl_preciosRecomendados = new Label();
            cbo_oreMapsPrices = new ComboBox();
            txt_oreMapPrice = new TextBox();
            label2 = new Label();
            txt_buyResourcesPrice = new TextBox();
            cbo_buyResources = new ComboBox();
            lbl_precioPorLingote = new Label();
            lbl_costePorArmadura = new Label();
            lbl_precioVentaArmadura = new Label();
            lbl_mediaLingotes = new Label();
            lbl_precioVentaHerramienta = new Label();
            lbl_costePorHerramienta = new Label();
            rb_map = new RadioButton();
            rb_commodity = new RadioButton();
            rb_ingots = new RadioButton();
            lbl_precioVentaLockpicks = new Label();
            lbl_costePorLockpicks = new Label();
            lbl_beneficioLockpicks = new Label();
            lbl_beneficioArmadura = new Label();
            lbl_beneficioHerramienta = new Label();
            SuspendLayout();
            // 
            // btn_menu_principal
            // 
            btn_menu_principal.Location = new Point(12, 12);
            btn_menu_principal.Name = "btn_menu_principal";
            btn_menu_principal.Size = new Size(99, 23);
            btn_menu_principal.TabIndex = 0;
            btn_menu_principal.Text = "Menú principal";
            btn_menu_principal.UseVisualStyleBackColor = true;
            btn_menu_principal.Click += btn_menu_principal_Click;
            // 
            // lbl_addMap
            // 
            lbl_addMap.AutoSize = true;
            lbl_addMap.Location = new Point(123, 57);
            lbl_addMap.Name = "lbl_addMap";
            lbl_addMap.Size = new Size(78, 15);
            lbl_addMap.TabIndex = 1;
            lbl_addMap.Text = "Añadir mapa:";
            // 
            // lbl_x
            // 
            lbl_x.AutoSize = true;
            lbl_x.Location = new Point(266, 62);
            lbl_x.Name = "lbl_x";
            lbl_x.Size = new Size(13, 15);
            lbl_x.TabIndex = 3;
            lbl_x.Text = "x";
            // 
            // cbo_oreMaps
            // 
            cbo_oreMaps.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_oreMaps.FormattingEnabled = true;
            cbo_oreMaps.Location = new Point(294, 54);
            cbo_oreMaps.Name = "cbo_oreMaps";
            cbo_oreMaps.Size = new Size(150, 23);
            cbo_oreMaps.TabIndex = 2;
            // 
            // lbl_materialRecogido
            // 
            lbl_materialRecogido.AutoSize = true;
            lbl_materialRecogido.Location = new Point(450, 57);
            lbl_materialRecogido.Name = "lbl_materialRecogido";
            lbl_materialRecogido.Size = new Size(103, 15);
            lbl_materialRecogido.TabIndex = 5;
            lbl_materialRecogido.Text = "Material recogido:";
            // 
            // txt_materialRecogido
            // 
            txt_materialRecogido.Location = new Point(559, 54);
            txt_materialRecogido.Name = "txt_materialRecogido";
            txt_materialRecogido.Size = new Size(100, 23);
            txt_materialRecogido.TabIndex = 3;
            txt_materialRecogido.TextAlign = HorizontalAlignment.Center;
            txt_materialRecogido.Enter += txt_materialRecogido_Enter;
            txt_materialRecogido.KeyDown += txt_materialRecogido_KeyDown;
            txt_materialRecogido.KeyPress += txt_materialRecogido_KeyPress;
            // 
            // btn_addMap
            // 
            btn_addMap.Location = new Point(703, 54);
            btn_addMap.Name = "btn_addMap";
            btn_addMap.Size = new Size(75, 23);
            btn_addMap.TabIndex = 4;
            btn_addMap.Text = "Añadir";
            btn_addMap.UseVisualStyleBackColor = true;
            btn_addMap.Click += btn_addMap_Click;
            // 
            // cbo_mapQuantity
            // 
            cbo_mapQuantity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_mapQuantity.FormattingEnabled = true;
            cbo_mapQuantity.Location = new Point(207, 54);
            cbo_mapQuantity.Name = "cbo_mapQuantity";
            cbo_mapQuantity.Size = new Size(53, 23);
            cbo_mapQuantity.TabIndex = 1;
            // 
            // lbl_preciosRecomendados
            // 
            lbl_preciosRecomendados.AutoSize = true;
            lbl_preciosRecomendados.Location = new Point(542, 160);
            lbl_preciosRecomendados.Name = "lbl_preciosRecomendados";
            lbl_preciosRecomendados.Size = new Size(130, 15);
            lbl_preciosRecomendados.TabIndex = 6;
            lbl_preciosRecomendados.Text = "Precios recomendados:";
            // 
            // cbo_oreMapsPrices
            // 
            cbo_oreMapsPrices.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_oreMapsPrices.FormattingEnabled = true;
            cbo_oreMapsPrices.Location = new Point(479, 188);
            cbo_oreMapsPrices.Name = "cbo_oreMapsPrices";
            cbo_oreMapsPrices.Size = new Size(150, 23);
            cbo_oreMapsPrices.TabIndex = 25;
            cbo_oreMapsPrices.SelectedIndexChanged += cbo_oreMapsPrices_SelectedIndexChanged;
            // 
            // txt_oreMapPrice
            // 
            txt_oreMapPrice.Location = new Point(650, 188);
            txt_oreMapPrice.Name = "txt_oreMapPrice";
            txt_oreMapPrice.Size = new Size(103, 23);
            txt_oreMapPrice.TabIndex = 26;
            txt_oreMapPrice.TextAlign = HorizontalAlignment.Center;
            txt_oreMapPrice.KeyDown += txt_oreMapPrice_KeyDown;
            txt_oreMapPrice.KeyPress += txt_oreMapPrice_KeyPress;
            txt_oreMapPrice.Leave += txt_oreMapPrice_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(292, 185);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 28;
            label2.Text = "Precio";
            // 
            // txt_buyResourcesPrice
            // 
            txt_buyResourcesPrice.Location = new Point(264, 203);
            txt_buyResourcesPrice.Name = "txt_buyResourcesPrice";
            txt_buyResourcesPrice.Size = new Size(100, 23);
            txt_buyResourcesPrice.TabIndex = 29;
            txt_buyResourcesPrice.TextAlign = HorizontalAlignment.Center;
            txt_buyResourcesPrice.Enter += txt_buyResourcesPrice_Enter;
            txt_buyResourcesPrice.KeyDown += txt_buyResourcesPrice_KeyDown;
            txt_buyResourcesPrice.KeyPress += txt_oreMapCompra_KeyPress;
            txt_buyResourcesPrice.Leave += txt_buyResourcesPrice_Leave;
            // 
            // cbo_buyResources
            // 
            cbo_buyResources.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_buyResources.FormattingEnabled = true;
            cbo_buyResources.Location = new Point(108, 203);
            cbo_buyResources.Name = "cbo_buyResources";
            cbo_buyResources.Size = new Size(150, 23);
            cbo_buyResources.TabIndex = 30;
            // 
            // lbl_precioPorLingote
            // 
            lbl_precioPorLingote.AutoSize = true;
            lbl_precioPorLingote.Location = new Point(145, 262);
            lbl_precioPorLingote.Name = "lbl_precioPorLingote";
            lbl_precioPorLingote.Size = new Size(153, 15);
            lbl_precioPorLingote.TabIndex = 31;
            lbl_precioPorLingote.Text = "- Precio por lingote :     0 gp";
            // 
            // lbl_costePorArmadura
            // 
            lbl_costePorArmadura.AutoSize = true;
            lbl_costePorArmadura.Location = new Point(40, 299);
            lbl_costePorArmadura.Name = "lbl_costePorArmadura";
            lbl_costePorArmadura.Size = new Size(161, 15);
            lbl_costePorArmadura.TabIndex = 32;
            lbl_costePorArmadura.Text = "- Coste por armadura:     0 gp";
            // 
            // lbl_precioVentaArmadura
            // 
            lbl_precioVentaArmadura.AutoSize = true;
            lbl_precioVentaArmadura.Location = new Point(40, 323);
            lbl_precioVentaArmadura.Name = "lbl_precioVentaArmadura";
            lbl_precioVentaArmadura.Size = new Size(178, 15);
            lbl_precioVentaArmadura.TabIndex = 33;
            lbl_precioVentaArmadura.Text = "- Precio venta armadura :     0 gp";
            // 
            // lbl_mediaLingotes
            // 
            lbl_mediaLingotes.AutoSize = true;
            lbl_mediaLingotes.Location = new Point(145, 238);
            lbl_mediaLingotes.Name = "lbl_mediaLingotes";
            lbl_mediaLingotes.Size = new Size(187, 15);
            lbl_mediaLingotes.TabIndex = 34;
            lbl_mediaLingotes.Text = "- Cantidad media de lingotes :     0";
            // 
            // lbl_precioVentaHerramienta
            // 
            lbl_precioVentaHerramienta.AutoSize = true;
            lbl_precioVentaHerramienta.Location = new Point(40, 383);
            lbl_precioVentaHerramienta.Name = "lbl_precioVentaHerramienta";
            lbl_precioVentaHerramienta.Size = new Size(191, 15);
            lbl_precioVentaHerramienta.TabIndex = 36;
            lbl_precioVentaHerramienta.Text = "- Precio venta herramienta :     0 gp";
            // 
            // lbl_costePorHerramienta
            // 
            lbl_costePorHerramienta.AutoSize = true;
            lbl_costePorHerramienta.Location = new Point(40, 359);
            lbl_costePorHerramienta.Name = "lbl_costePorHerramienta";
            lbl_costePorHerramienta.Size = new Size(174, 15);
            lbl_costePorHerramienta.TabIndex = 35;
            lbl_costePorHerramienta.Text = "- Coste por herramienta:     0 gp";
            // 
            // rb_map
            // 
            rb_map.AutoSize = true;
            rb_map.Location = new Point(108, 162);
            rb_map.Name = "rb_map";
            rb_map.Size = new Size(60, 19);
            rb_map.TabIndex = 37;
            rb_map.TabStop = true;
            rb_map.Text = "Mapas";
            rb_map.UseVisualStyleBackColor = true;
            // 
            // rb_commodity
            // 
            rb_commodity.AutoSize = true;
            rb_commodity.Location = new Point(185, 162);
            rb_commodity.Name = "rb_commodity";
            rb_commodity.Size = new Size(89, 19);
            rb_commodity.TabIndex = 38;
            rb_commodity.TabStop = true;
            rb_commodity.Text = "Commodity";
            rb_commodity.UseVisualStyleBackColor = true;
            // 
            // rb_ingots
            // 
            rb_ingots.AutoSize = true;
            rb_ingots.Location = new Point(292, 163);
            rb_ingots.Name = "rb_ingots";
            rb_ingots.Size = new Size(70, 19);
            rb_ingots.TabIndex = 39;
            rb_ingots.TabStop = true;
            rb_ingots.Text = "Lingotes";
            rb_ingots.UseVisualStyleBackColor = true;
            // 
            // lbl_precioVentaLockpicks
            // 
            lbl_precioVentaLockpicks.AutoSize = true;
            lbl_precioVentaLockpicks.Location = new Point(264, 323);
            lbl_precioVentaLockpicks.Name = "lbl_precioVentaLockpicks";
            lbl_precioVentaLockpicks.Size = new Size(176, 15);
            lbl_precioVentaLockpicks.TabIndex = 41;
            lbl_precioVentaLockpicks.Text = "- Precio venta lockpicks :     0 gp";
            // 
            // lbl_costePorLockpicks
            // 
            lbl_costePorLockpicks.AutoSize = true;
            lbl_costePorLockpicks.Location = new Point(264, 299);
            lbl_costePorLockpicks.Name = "lbl_costePorLockpicks";
            lbl_costePorLockpicks.Size = new Size(159, 15);
            lbl_costePorLockpicks.TabIndex = 40;
            lbl_costePorLockpicks.Text = "- Coste por lockpicks:     0 gp";
            // 
            // lbl_beneficioLockpicks
            // 
            lbl_beneficioLockpicks.AutoSize = true;
            lbl_beneficioLockpicks.Location = new Point(264, 391);
            lbl_beneficioLockpicks.Name = "lbl_beneficioLockpicks";
            lbl_beneficioLockpicks.Size = new Size(171, 15);
            lbl_beneficioLockpicks.TabIndex = 45;
            lbl_beneficioLockpicks.Text = "- Beneficio por lockpicks:     0%";
            // 
            // lbl_beneficioArmadura
            // 
            lbl_beneficioArmadura.AutoSize = true;
            lbl_beneficioArmadura.Location = new Point(264, 357);
            lbl_beneficioArmadura.Name = "lbl_beneficioArmadura";
            lbl_beneficioArmadura.Size = new Size(176, 15);
            lbl_beneficioArmadura.TabIndex = 43;
            lbl_beneficioArmadura.Text = "- Beneficio por armadura:     0 %";
            // 
            // lbl_beneficioHerramienta
            // 
            lbl_beneficioHerramienta.AutoSize = true;
            lbl_beneficioHerramienta.Location = new Point(264, 374);
            lbl_beneficioHerramienta.Name = "lbl_beneficioHerramienta";
            lbl_beneficioHerramienta.Size = new Size(189, 15);
            lbl_beneficioHerramienta.TabIndex = 44;
            lbl_beneficioHerramienta.Text = "- Beneficio por herramienta:     0 %";
            // 
            // FormMapsMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_beneficioHerramienta);
            Controls.Add(lbl_beneficioArmadura);
            Controls.Add(lbl_beneficioLockpicks);
            Controls.Add(lbl_precioVentaLockpicks);
            Controls.Add(lbl_costePorLockpicks);
            Controls.Add(rb_ingots);
            Controls.Add(rb_commodity);
            Controls.Add(rb_map);
            Controls.Add(lbl_precioVentaHerramienta);
            Controls.Add(lbl_costePorHerramienta);
            Controls.Add(lbl_mediaLingotes);
            Controls.Add(lbl_precioVentaArmadura);
            Controls.Add(lbl_costePorArmadura);
            Controls.Add(lbl_precioPorLingote);
            Controls.Add(cbo_buyResources);
            Controls.Add(txt_buyResourcesPrice);
            Controls.Add(label2);
            Controls.Add(txt_oreMapPrice);
            Controls.Add(cbo_oreMapsPrices);
            Controls.Add(lbl_preciosRecomendados);
            Controls.Add(cbo_mapQuantity);
            Controls.Add(btn_addMap);
            Controls.Add(txt_materialRecogido);
            Controls.Add(lbl_materialRecogido);
            Controls.Add(cbo_oreMaps);
            Controls.Add(lbl_x);
            Controls.Add(lbl_addMap);
            Controls.Add(btn_menu_principal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMapsMain";
            StartPosition = FormStartPosition.Manual;
            Text = "Mapas y materiales";
            FormClosing += Form_Closing;
            Load += FormMapsMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_menu_principal;
        private Label lbl_addMap;
        private Label lbl_x;
        private ComboBox cbo_oreMaps;
        private Label lbl_materialRecogido;
        private TextBox txt_materialRecogido;
        private Button btn_addMap;
        private ComboBox cbo_mapQuantity;
        private Label lbl_preciosRecomendados;
        private ComboBox cbo_oreMapsPrices;
        private TextBox txt_oreMapPrice;
        private Label label2;
        private TextBox txt_buyResourcesPrice;
        private ComboBox cbo_buyResources;
        private Label lbl_precioPorLingote;
        private Label lbl_costePorArmadura;
        private Label lbl_precioVentaArmadura;
        private Label lbl_mediaLingotes;
        private Label lbl_precioVentaHerramienta;
        private Label lbl_costePorHerramienta;
        private RadioButton rb_map;
        private RadioButton rb_commodity;
        private RadioButton rb_ingots;
        private Label lbl_precioVentaLockpicks;
        private Label lbl_costePorLockpicks;
        private Label lbl_beneficioLockpicks;
        private Label lbl_beneficioArmadura;
        private Label lbl_beneficioHerramienta;
    }
}