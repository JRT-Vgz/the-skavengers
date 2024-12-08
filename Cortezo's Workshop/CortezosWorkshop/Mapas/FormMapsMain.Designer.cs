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
            lbl_addMap.Location = new Point(93, 89);
            lbl_addMap.Name = "lbl_addMap";
            lbl_addMap.Size = new Size(78, 15);
            lbl_addMap.TabIndex = 1;
            lbl_addMap.Text = "Añadir mapa:";
            // 
            // lbl_x
            // 
            lbl_x.AutoSize = true;
            lbl_x.Location = new Point(236, 94);
            lbl_x.Name = "lbl_x";
            lbl_x.Size = new Size(13, 15);
            lbl_x.TabIndex = 3;
            lbl_x.Text = "x";
            // 
            // cbo_oreMaps
            // 
            cbo_oreMaps.FormattingEnabled = true;
            cbo_oreMaps.Location = new Point(264, 86);
            cbo_oreMaps.Name = "cbo_oreMaps";
            cbo_oreMaps.Size = new Size(150, 23);
            cbo_oreMaps.TabIndex = 2;
            // 
            // lbl_materialRecogido
            // 
            lbl_materialRecogido.AutoSize = true;
            lbl_materialRecogido.Location = new Point(420, 89);
            lbl_materialRecogido.Name = "lbl_materialRecogido";
            lbl_materialRecogido.Size = new Size(103, 15);
            lbl_materialRecogido.TabIndex = 5;
            lbl_materialRecogido.Text = "Material recogido:";
            // 
            // txt_materialRecogido
            // 
            txt_materialRecogido.Location = new Point(529, 86);
            txt_materialRecogido.Name = "txt_materialRecogido";
            txt_materialRecogido.Size = new Size(100, 23);
            txt_materialRecogido.TabIndex = 3;
            txt_materialRecogido.TextAlign = HorizontalAlignment.Center;
            txt_materialRecogido.Enter += txt_materialRecogido_Enter;
            txt_materialRecogido.KeyPress += txt_materialRecogido_KeyPress;
            // 
            // btn_addMap
            // 
            btn_addMap.Location = new Point(673, 86);
            btn_addMap.Name = "btn_addMap";
            btn_addMap.Size = new Size(75, 23);
            btn_addMap.TabIndex = 4;
            btn_addMap.Text = "Añadir";
            btn_addMap.UseVisualStyleBackColor = true;
            btn_addMap.Click += btn_addMap_Click;
            // 
            // cbo_mapQuantity
            // 
            cbo_mapQuantity.FormattingEnabled = true;
            cbo_mapQuantity.Location = new Point(177, 86);
            cbo_mapQuantity.Name = "cbo_mapQuantity";
            cbo_mapQuantity.Size = new Size(53, 23);
            cbo_mapQuantity.TabIndex = 1;
            // 
            // FormMapsMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}