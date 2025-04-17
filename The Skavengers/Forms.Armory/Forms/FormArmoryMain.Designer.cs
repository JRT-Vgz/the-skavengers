namespace Forms.Armory.Forms
{
    partial class FormArmoryMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArmoryMain));
            panel_scriptMenu = new Panel();
            btn_newScript = new Button();
            lbl_createAutoEquipTemplate = new Label();
            btn_createAutoEquipTemplate = new Button();
            btn_menu_principal = new Button();
            dgv_scripts = new DataGridView();
            panel_scriptMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_scripts).BeginInit();
            SuspendLayout();
            // 
            // panel_scriptMenu
            // 
            panel_scriptMenu.Controls.Add(btn_newScript);
            panel_scriptMenu.Controls.Add(lbl_createAutoEquipTemplate);
            panel_scriptMenu.Controls.Add(btn_createAutoEquipTemplate);
            panel_scriptMenu.Controls.Add(btn_menu_principal);
            panel_scriptMenu.Dock = DockStyle.Top;
            panel_scriptMenu.Location = new Point(0, 0);
            panel_scriptMenu.Name = "panel_scriptMenu";
            panel_scriptMenu.Size = new Size(800, 58);
            panel_scriptMenu.TabIndex = 0;
            // 
            // btn_newScript
            // 
            btn_newScript.Location = new Point(306, 23);
            btn_newScript.Name = "btn_newScript";
            btn_newScript.Size = new Size(82, 23);
            btn_newScript.TabIndex = 107;
            btn_newScript.Text = "Nuevo script";
            btn_newScript.UseVisualStyleBackColor = true;
            btn_newScript.Click += btn_newScript_Click;
            // 
            // lbl_createAutoEquipTemplate
            // 
            lbl_createAutoEquipTemplate.AutoSize = true;
            lbl_createAutoEquipTemplate.Location = new Point(527, 23);
            lbl_createAutoEquipTemplate.Name = "lbl_createAutoEquipTemplate";
            lbl_createAutoEquipTemplate.Size = new Size(142, 15);
            lbl_createAutoEquipTemplate.TabIndex = 106;
            lbl_createAutoEquipTemplate.Text = "Plantilla de Auto-Equipar:";
            // 
            // btn_createAutoEquipTemplate
            // 
            btn_createAutoEquipTemplate.Location = new Point(675, 19);
            btn_createAutoEquipTemplate.Name = "btn_createAutoEquipTemplate";
            btn_createAutoEquipTemplate.Size = new Size(64, 23);
            btn_createAutoEquipTemplate.TabIndex = 104;
            btn_createAutoEquipTemplate.Text = "Crear";
            btn_createAutoEquipTemplate.UseVisualStyleBackColor = true;
            btn_createAutoEquipTemplate.Click += btn_createAutoEquipTemplate_Click;
            // 
            // btn_menu_principal
            // 
            btn_menu_principal.Location = new Point(12, 12);
            btn_menu_principal.Name = "btn_menu_principal";
            btn_menu_principal.Size = new Size(99, 23);
            btn_menu_principal.TabIndex = 101;
            btn_menu_principal.Text = "Menú principal";
            btn_menu_principal.UseVisualStyleBackColor = true;
            btn_menu_principal.Click += btn_menu_principal_Click;
            // 
            // dgv_scripts
            // 
            dgv_scripts.AllowUserToAddRows = false;
            dgv_scripts.AllowUserToDeleteRows = false;
            dgv_scripts.AllowUserToResizeColumns = false;
            dgv_scripts.AllowUserToResizeRows = false;
            dgv_scripts.BorderStyle = BorderStyle.Fixed3D;
            dgv_scripts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_scripts.Dock = DockStyle.Fill;
            dgv_scripts.Location = new Point(0, 58);
            dgv_scripts.MultiSelect = false;
            dgv_scripts.Name = "dgv_scripts";
            dgv_scripts.ReadOnly = true;
            dgv_scripts.RowHeadersVisible = false;
            dgv_scripts.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv_scripts.Size = new Size(800, 392);
            dgv_scripts.TabIndex = 1;
            dgv_scripts.CellContentClick += dgv_scripts_CellContentClick;
            // 
            // FormArmoryMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgv_scripts);
            Controls.Add(panel_scriptMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(833, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormArmoryMain";
            StartPosition = FormStartPosition.Manual;
            Text = "Armería";
            FormClosing += FormArmoryMain_FormClosing;
            Load += FormArmoryMain_Load;
            panel_scriptMenu.ResumeLayout(false);
            panel_scriptMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_scripts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_scriptMenu;
        private DataGridView dgv_scripts;
        private Button btn_menu_principal;
        private Label lbl_createAutoEquipTemplate;
        private Button btn_createAutoEquipTemplate;
        private Button btn_newScript;
    }
}