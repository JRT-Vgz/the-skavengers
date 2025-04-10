namespace Forms.Armory.Forms
{
    partial class FormAutoEquipTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutoEquipTemplate));
            btn_menu_principal = new Button();
            btn_crearPlantilla = new Button();
            btn_pegarDatos = new Button();
            txt_playerName = new TextBox();
            lbl_playerName = new Label();
            lbl_alterEgo = new Label();
            txt_alterEgo = new TextBox();
            btn_addAlterEgo = new Button();
            lbl_templateName = new Label();
            txt_templateName = new TextBox();
            lbl_echoSkillName = new Label();
            txt_echoSkillName = new TextBox();
            lbl_echoSkillLevel = new Label();
            txt_echoSkillLevel = new TextBox();
            chk_activateAspect = new CheckBox();
            chk_activateWeaponAspect = new CheckBox();
            chk_activateSpellbookAspect = new CheckBox();
            chk_activateArmorAspect = new CheckBox();
            cbo_weaponAspect = new ComboBox();
            cbo_spellbookAspect = new ComboBox();
            cbo_armorAspect = new ComboBox();
            chk_helm = new CheckBox();
            lbl_exceptional = new Label();
            chk_gorget = new CheckBox();
            chk_gloves = new CheckBox();
            chk_legs = new CheckBox();
            chk_chest = new CheckBox();
            chk_shoulders = new CheckBox();
            lbl_alterEgo1 = new Label();
            lbl_alterEgo2 = new Label();
            lbl_alterEgo3 = new Label();
            lbl_alterEgo4 = new Label();
            lbl_alterEgo5 = new Label();
            lbl_alterEgo10 = new Label();
            lbl_alterEgo9 = new Label();
            lbl_alterEgo8 = new Label();
            lbl_alterEgo7 = new Label();
            lbl_alterEgo6 = new Label();
            lbl_alterEgo15 = new Label();
            lbl_alterEgo14 = new Label();
            lbl_alterEgo13 = new Label();
            lbl_alterEgo12 = new Label();
            lbl_alterEgo11 = new Label();
            chk_itemsLoaded = new CheckBox();
            SuspendLayout();
            // 
            // btn_menu_principal
            // 
            btn_menu_principal.Location = new Point(12, 12);
            btn_menu_principal.Name = "btn_menu_principal";
            btn_menu_principal.Size = new Size(99, 23);
            btn_menu_principal.TabIndex = 100;
            btn_menu_principal.Text = "Menú principal";
            btn_menu_principal.UseVisualStyleBackColor = true;
            btn_menu_principal.Click += btn_menu_principal_Click;
            // 
            // btn_crearPlantilla
            // 
            btn_crearPlantilla.Location = new Point(528, 373);
            btn_crearPlantilla.Name = "btn_crearPlantilla";
            btn_crearPlantilla.Size = new Size(100, 33);
            btn_crearPlantilla.TabIndex = 18;
            btn_crearPlantilla.Text = "Crear plantilla";
            btn_crearPlantilla.UseVisualStyleBackColor = true;
            btn_crearPlantilla.Click += btn_crearPlantilla_Click;
            // 
            // btn_pegarDatos
            // 
            btn_pegarDatos.Location = new Point(482, 332);
            btn_pegarDatos.Name = "btn_pegarDatos";
            btn_pegarDatos.Size = new Size(183, 23);
            btn_pegarDatos.TabIndex = 17;
            btn_pegarDatos.Text = "Pegar equipo del portapapeles";
            btn_pegarDatos.UseVisualStyleBackColor = true;
            btn_pegarDatos.Click += btn_pegarDatos_Click;
            // 
            // txt_playerName
            // 
            txt_playerName.Location = new Point(200, 67);
            txt_playerName.Name = "txt_playerName";
            txt_playerName.Size = new Size(131, 23);
            txt_playerName.TabIndex = 1;
            txt_playerName.TextAlign = HorizontalAlignment.Center;
            txt_playerName.KeyPress += txt_playerName_KeyPress;
            // 
            // lbl_playerName
            // 
            lbl_playerName.AutoSize = true;
            lbl_playerName.Location = new Point(67, 70);
            lbl_playerName.Name = "lbl_playerName";
            lbl_playerName.Size = new Size(127, 15);
            lbl_playerName.TabIndex = 7;
            lbl_playerName.Text = "Nombre del personaje:";
            // 
            // lbl_alterEgo
            // 
            lbl_alterEgo.AutoSize = true;
            lbl_alterEgo.Location = new Point(55, 250);
            lbl_alterEgo.Name = "lbl_alterEgo";
            lbl_alterEgo.Size = new Size(58, 15);
            lbl_alterEgo.TabIndex = 9;
            lbl_alterEgo.Text = "Alter ego:";
            // 
            // txt_alterEgo
            // 
            txt_alterEgo.Location = new Point(119, 247);
            txt_alterEgo.Name = "txt_alterEgo";
            txt_alterEgo.Size = new Size(131, 23);
            txt_alterEgo.TabIndex = 5;
            txt_alterEgo.TextAlign = HorizontalAlignment.Center;
            txt_alterEgo.KeyPress += txt_alterEgo_KeyPress;
            // 
            // btn_addAlterEgo
            // 
            btn_addAlterEgo.Location = new Point(256, 246);
            btn_addAlterEgo.Name = "btn_addAlterEgo";
            btn_addAlterEgo.Size = new Size(75, 23);
            btn_addAlterEgo.TabIndex = 6;
            btn_addAlterEgo.Text = "Añadir";
            btn_addAlterEgo.UseVisualStyleBackColor = true;
            btn_addAlterEgo.Click += btn_addAlterEgo_Click;
            // 
            // lbl_templateName
            // 
            lbl_templateName.AutoSize = true;
            lbl_templateName.Location = new Point(67, 107);
            lbl_templateName.Name = "lbl_templateName";
            lbl_templateName.Size = new Size(127, 15);
            lbl_templateName.TabIndex = 12;
            lbl_templateName.Text = "Nombre de la plantilla:";
            // 
            // txt_templateName
            // 
            txt_templateName.Location = new Point(200, 104);
            txt_templateName.Name = "txt_templateName";
            txt_templateName.Size = new Size(131, 23);
            txt_templateName.TabIndex = 2;
            txt_templateName.TextAlign = HorizontalAlignment.Center;
            txt_templateName.KeyPress += txt_templateName_KeyPress;
            // 
            // lbl_echoSkillName
            // 
            lbl_echoSkillName.AutoSize = true;
            lbl_echoSkillName.Location = new Point(38, 141);
            lbl_echoSkillName.Name = "lbl_echoSkillName";
            lbl_echoSkillName.Size = new Size(156, 15);
            lbl_echoSkillName.TabIndex = 14;
            lbl_echoSkillName.Text = "Skill representativa del Echo:";
            // 
            // txt_echoSkillName
            // 
            txt_echoSkillName.Location = new Point(200, 138);
            txt_echoSkillName.Name = "txt_echoSkillName";
            txt_echoSkillName.Size = new Size(131, 23);
            txt_echoSkillName.TabIndex = 3;
            txt_echoSkillName.TextAlign = HorizontalAlignment.Center;
            txt_echoSkillName.KeyPress += txt_echoSkillName_KeyPress;
            // 
            // lbl_echoSkillLevel
            // 
            lbl_echoSkillLevel.AutoSize = true;
            lbl_echoSkillLevel.Location = new Point(59, 175);
            lbl_echoSkillLevel.Name = "lbl_echoSkillLevel";
            lbl_echoSkillLevel.Size = new Size(135, 15);
            lbl_echoSkillLevel.TabIndex = 16;
            lbl_echoSkillLevel.Text = "Valor de la skill del Echo:";
            // 
            // txt_echoSkillLevel
            // 
            txt_echoSkillLevel.Location = new Point(200, 172);
            txt_echoSkillLevel.Name = "txt_echoSkillLevel";
            txt_echoSkillLevel.Size = new Size(131, 23);
            txt_echoSkillLevel.TabIndex = 4;
            txt_echoSkillLevel.TextAlign = HorizontalAlignment.Center;
            txt_echoSkillLevel.Enter += txt_echoSkillLevel_Enter;
            txt_echoSkillLevel.KeyPress += txt_echoSkillLevel_KeyPress;
            // 
            // chk_activateAspect
            // 
            chk_activateAspect.AutoSize = true;
            chk_activateAspect.Location = new Point(521, 46);
            chk_activateAspect.Name = "chk_activateAspect";
            chk_activateAspect.Size = new Size(107, 19);
            chk_activateAspect.TabIndex = 7;
            chk_activateAspect.Text = "Activar aspecto";
            chk_activateAspect.UseVisualStyleBackColor = true;
            chk_activateAspect.CheckedChanged += chk_activateAspect_CheckedChanged;
            // 
            // chk_activateWeaponAspect
            // 
            chk_activateWeaponAspect.AutoSize = true;
            chk_activateWeaponAspect.Location = new Point(439, 86);
            chk_activateWeaponAspect.Name = "chk_activateWeaponAspect";
            chk_activateWeaponAspect.Size = new Size(156, 19);
            chk_activateWeaponAspect.TabIndex = 8;
            chk_activateWeaponAspect.Text = "Activar aspecto del arma";
            chk_activateWeaponAspect.UseVisualStyleBackColor = true;
            chk_activateWeaponAspect.CheckedChanged += chk_activateWeaponAspect_CheckedChanged;
            // 
            // chk_activateSpellbookAspect
            // 
            chk_activateSpellbookAspect.AutoSize = true;
            chk_activateSpellbookAspect.Location = new Point(439, 120);
            chk_activateSpellbookAspect.Name = "chk_activateSpellbookAspect";
            chk_activateSpellbookAspect.Size = new Size(153, 19);
            chk_activateSpellbookAspect.TabIndex = 9;
            chk_activateSpellbookAspect.Text = "Activar aspecto del libro";
            chk_activateSpellbookAspect.UseVisualStyleBackColor = true;
            chk_activateSpellbookAspect.CheckedChanged += chk_activateSpellbookAspect_CheckedChanged;
            // 
            // chk_activateArmorAspect
            // 
            chk_activateArmorAspect.AutoSize = true;
            chk_activateArmorAspect.Location = new Point(439, 156);
            chk_activateArmorAspect.Name = "chk_activateArmorAspect";
            chk_activateArmorAspect.Size = new Size(189, 19);
            chk_activateArmorAspect.TabIndex = 10;
            chk_activateArmorAspect.Text = "Activar aspecto de la armadura";
            chk_activateArmorAspect.UseVisualStyleBackColor = true;
            // 
            // cbo_weaponAspect
            // 
            cbo_weaponAspect.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_weaponAspect.FormattingEnabled = true;
            cbo_weaponAspect.Location = new Point(634, 84);
            cbo_weaponAspect.Name = "cbo_weaponAspect";
            cbo_weaponAspect.Size = new Size(121, 23);
            cbo_weaponAspect.TabIndex = 21;
            // 
            // cbo_spellbookAspect
            // 
            cbo_spellbookAspect.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_spellbookAspect.FormattingEnabled = true;
            cbo_spellbookAspect.Location = new Point(634, 118);
            cbo_spellbookAspect.Name = "cbo_spellbookAspect";
            cbo_spellbookAspect.Size = new Size(121, 23);
            cbo_spellbookAspect.TabIndex = 22;
            // 
            // cbo_armorAspect
            // 
            cbo_armorAspect.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_armorAspect.FormattingEnabled = true;
            cbo_armorAspect.Location = new Point(634, 154);
            cbo_armorAspect.Name = "cbo_armorAspect";
            cbo_armorAspect.Size = new Size(121, 23);
            cbo_armorAspect.TabIndex = 23;
            // 
            // chk_helm
            // 
            chk_helm.AutoSize = true;
            chk_helm.Location = new Point(498, 231);
            chk_helm.Name = "chk_helm";
            chk_helm.Size = new Size(58, 19);
            chk_helm.TabIndex = 11;
            chk_helm.Text = "Casco";
            chk_helm.UseVisualStyleBackColor = true;
            // 
            // lbl_exceptional
            // 
            lbl_exceptional.AutoSize = true;
            lbl_exceptional.Location = new Point(539, 208);
            lbl_exceptional.Name = "lbl_exceptional";
            lbl_exceptional.Size = new Size(70, 15);
            lbl_exceptional.TabIndex = 25;
            lbl_exceptional.Text = "Excepcional";
            // 
            // chk_gorget
            // 
            chk_gorget.AutoSize = true;
            chk_gorget.Location = new Point(498, 255);
            chk_gorget.Name = "chk_gorget";
            chk_gorget.Size = new Size(62, 19);
            chk_gorget.TabIndex = 12;
            chk_gorget.Text = "Gorget";
            chk_gorget.UseVisualStyleBackColor = true;
            // 
            // chk_gloves
            // 
            chk_gloves.AutoSize = true;
            chk_gloves.Location = new Point(498, 280);
            chk_gloves.Name = "chk_gloves";
            chk_gloves.Size = new Size(69, 19);
            chk_gloves.TabIndex = 13;
            chk_gloves.Text = "Guantes";
            chk_gloves.UseVisualStyleBackColor = true;
            // 
            // chk_legs
            // 
            chk_legs.AutoSize = true;
            chk_legs.Location = new Point(590, 280);
            chk_legs.Name = "chk_legs";
            chk_legs.Size = new Size(64, 19);
            chk_legs.TabIndex = 16;
            chk_legs.Text = "Piernas";
            chk_legs.UseVisualStyleBackColor = true;
            // 
            // chk_chest
            // 
            chk_chest.AutoSize = true;
            chk_chest.Location = new Point(590, 255);
            chk_chest.Name = "chk_chest";
            chk_chest.Size = new Size(59, 19);
            chk_chest.TabIndex = 15;
            chk_chest.Text = "Pecho";
            chk_chest.UseVisualStyleBackColor = true;
            // 
            // chk_shoulders
            // 
            chk_shoulders.AutoSize = true;
            chk_shoulders.Location = new Point(590, 231);
            chk_shoulders.Name = "chk_shoulders";
            chk_shoulders.Size = new Size(85, 19);
            chk_shoulders.TabIndex = 14;
            chk_shoulders.Text = "Hombreras";
            chk_shoulders.UseVisualStyleBackColor = true;
            // 
            // lbl_alterEgo1
            // 
            lbl_alterEgo1.AutoSize = true;
            lbl_alterEgo1.Location = new Point(59, 282);
            lbl_alterEgo1.Name = "lbl_alterEgo1";
            lbl_alterEgo1.Size = new Size(43, 15);
            lbl_alterEgo1.TabIndex = 35;
            lbl_alterEgo1.Text = "- Vacío";
            // 
            // lbl_alterEgo2
            // 
            lbl_alterEgo2.AutoSize = true;
            lbl_alterEgo2.Location = new Point(59, 307);
            lbl_alterEgo2.Name = "lbl_alterEgo2";
            lbl_alterEgo2.Size = new Size(43, 15);
            lbl_alterEgo2.TabIndex = 36;
            lbl_alterEgo2.Text = "- Vacío";
            // 
            // lbl_alterEgo3
            // 
            lbl_alterEgo3.AutoSize = true;
            lbl_alterEgo3.Location = new Point(59, 332);
            lbl_alterEgo3.Name = "lbl_alterEgo3";
            lbl_alterEgo3.Size = new Size(43, 15);
            lbl_alterEgo3.TabIndex = 37;
            lbl_alterEgo3.Text = "- Vacío";
            // 
            // lbl_alterEgo4
            // 
            lbl_alterEgo4.AutoSize = true;
            lbl_alterEgo4.Location = new Point(59, 357);
            lbl_alterEgo4.Name = "lbl_alterEgo4";
            lbl_alterEgo4.Size = new Size(43, 15);
            lbl_alterEgo4.TabIndex = 38;
            lbl_alterEgo4.Text = "- Vacío";
            // 
            // lbl_alterEgo5
            // 
            lbl_alterEgo5.AutoSize = true;
            lbl_alterEgo5.Location = new Point(59, 382);
            lbl_alterEgo5.Name = "lbl_alterEgo5";
            lbl_alterEgo5.Size = new Size(43, 15);
            lbl_alterEgo5.TabIndex = 39;
            lbl_alterEgo5.Text = "- Vacío";
            // 
            // lbl_alterEgo10
            // 
            lbl_alterEgo10.AutoSize = true;
            lbl_alterEgo10.Location = new Point(159, 382);
            lbl_alterEgo10.Name = "lbl_alterEgo10";
            lbl_alterEgo10.Size = new Size(43, 15);
            lbl_alterEgo10.TabIndex = 44;
            lbl_alterEgo10.Text = "- Vacío";
            // 
            // lbl_alterEgo9
            // 
            lbl_alterEgo9.AutoSize = true;
            lbl_alterEgo9.Location = new Point(159, 357);
            lbl_alterEgo9.Name = "lbl_alterEgo9";
            lbl_alterEgo9.Size = new Size(43, 15);
            lbl_alterEgo9.TabIndex = 43;
            lbl_alterEgo9.Text = "- Vacío";
            // 
            // lbl_alterEgo8
            // 
            lbl_alterEgo8.AutoSize = true;
            lbl_alterEgo8.Location = new Point(159, 332);
            lbl_alterEgo8.Name = "lbl_alterEgo8";
            lbl_alterEgo8.Size = new Size(43, 15);
            lbl_alterEgo8.TabIndex = 42;
            lbl_alterEgo8.Text = "- Vacío";
            // 
            // lbl_alterEgo7
            // 
            lbl_alterEgo7.AutoSize = true;
            lbl_alterEgo7.Location = new Point(159, 307);
            lbl_alterEgo7.Name = "lbl_alterEgo7";
            lbl_alterEgo7.Size = new Size(43, 15);
            lbl_alterEgo7.TabIndex = 41;
            lbl_alterEgo7.Text = "- Vacío";
            // 
            // lbl_alterEgo6
            // 
            lbl_alterEgo6.AutoSize = true;
            lbl_alterEgo6.Location = new Point(159, 282);
            lbl_alterEgo6.Name = "lbl_alterEgo6";
            lbl_alterEgo6.Size = new Size(43, 15);
            lbl_alterEgo6.TabIndex = 40;
            lbl_alterEgo6.Text = "- Vacío";
            // 
            // lbl_alterEgo15
            // 
            lbl_alterEgo15.AutoSize = true;
            lbl_alterEgo15.Location = new Point(259, 382);
            lbl_alterEgo15.Name = "lbl_alterEgo15";
            lbl_alterEgo15.Size = new Size(43, 15);
            lbl_alterEgo15.TabIndex = 49;
            lbl_alterEgo15.Text = "- Vacío";
            // 
            // lbl_alterEgo14
            // 
            lbl_alterEgo14.AutoSize = true;
            lbl_alterEgo14.Location = new Point(259, 357);
            lbl_alterEgo14.Name = "lbl_alterEgo14";
            lbl_alterEgo14.Size = new Size(43, 15);
            lbl_alterEgo14.TabIndex = 48;
            lbl_alterEgo14.Text = "- Vacío";
            // 
            // lbl_alterEgo13
            // 
            lbl_alterEgo13.AutoSize = true;
            lbl_alterEgo13.Location = new Point(259, 332);
            lbl_alterEgo13.Name = "lbl_alterEgo13";
            lbl_alterEgo13.Size = new Size(43, 15);
            lbl_alterEgo13.TabIndex = 47;
            lbl_alterEgo13.Text = "- Vacío";
            // 
            // lbl_alterEgo12
            // 
            lbl_alterEgo12.AutoSize = true;
            lbl_alterEgo12.Location = new Point(259, 307);
            lbl_alterEgo12.Name = "lbl_alterEgo12";
            lbl_alterEgo12.Size = new Size(43, 15);
            lbl_alterEgo12.TabIndex = 46;
            lbl_alterEgo12.Text = "- Vacío";
            // 
            // lbl_alterEgo11
            // 
            lbl_alterEgo11.AutoSize = true;
            lbl_alterEgo11.Location = new Point(259, 282);
            lbl_alterEgo11.Name = "lbl_alterEgo11";
            lbl_alterEgo11.Size = new Size(43, 15);
            lbl_alterEgo11.TabIndex = 45;
            lbl_alterEgo11.Text = "- Vacío";
            // 
            // chk_itemsLoaded
            // 
            chk_itemsLoaded.AutoSize = true;
            chk_itemsLoaded.Enabled = false;
            chk_itemsLoaded.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chk_itemsLoaded.Location = new Point(671, 337);
            chk_itemsLoaded.Name = "chk_itemsLoaded";
            chk_itemsLoaded.Size = new Size(15, 14);
            chk_itemsLoaded.TabIndex = 101;
            chk_itemsLoaded.UseVisualStyleBackColor = true;
            // 
            // FormArmeriaMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chk_itemsLoaded);
            Controls.Add(lbl_alterEgo15);
            Controls.Add(lbl_alterEgo14);
            Controls.Add(lbl_alterEgo13);
            Controls.Add(lbl_alterEgo12);
            Controls.Add(lbl_alterEgo11);
            Controls.Add(lbl_alterEgo10);
            Controls.Add(lbl_alterEgo9);
            Controls.Add(lbl_alterEgo8);
            Controls.Add(lbl_alterEgo7);
            Controls.Add(lbl_alterEgo6);
            Controls.Add(lbl_alterEgo5);
            Controls.Add(lbl_alterEgo4);
            Controls.Add(lbl_alterEgo3);
            Controls.Add(lbl_alterEgo2);
            Controls.Add(lbl_alterEgo1);
            Controls.Add(chk_legs);
            Controls.Add(chk_chest);
            Controls.Add(chk_shoulders);
            Controls.Add(chk_gloves);
            Controls.Add(chk_gorget);
            Controls.Add(lbl_exceptional);
            Controls.Add(chk_helm);
            Controls.Add(cbo_armorAspect);
            Controls.Add(cbo_spellbookAspect);
            Controls.Add(cbo_weaponAspect);
            Controls.Add(chk_activateArmorAspect);
            Controls.Add(chk_activateSpellbookAspect);
            Controls.Add(chk_activateWeaponAspect);
            Controls.Add(chk_activateAspect);
            Controls.Add(lbl_echoSkillLevel);
            Controls.Add(txt_echoSkillLevel);
            Controls.Add(lbl_echoSkillName);
            Controls.Add(txt_echoSkillName);
            Controls.Add(lbl_templateName);
            Controls.Add(txt_templateName);
            Controls.Add(btn_addAlterEgo);
            Controls.Add(lbl_alterEgo);
            Controls.Add(txt_alterEgo);
            Controls.Add(lbl_playerName);
            Controls.Add(txt_playerName);
            Controls.Add(btn_pegarDatos);
            Controls.Add(btn_crearPlantilla);
            Controls.Add(btn_menu_principal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormArmeriaMain";
            StartPosition = FormStartPosition.Manual;
            Text = "Armería";
            FormClosing += FormArmeriaMain_FormClosing;
            Load += FormArmeriaMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_menu_principal;
        private Button btn_crearPlantilla;
        private Button btn_pegarDatos;
        private TextBox txt_playerName;
        private Label lbl_playerName;
        private Label lbl_alterEgo;
        private TextBox txt_alterEgo;
        private Button btn_addAlterEgo;
        private Label lbl_templateName;
        private TextBox txt_templateName;
        private Label lbl_echoSkillName;
        private TextBox txt_echoSkillName;
        private Label lbl_echoSkillLevel;
        private TextBox txt_echoSkillLevel;
        private CheckBox chk_activateAspect;
        private CheckBox chk_activateWeaponAspect;
        private CheckBox chk_activateSpellbookAspect;
        private CheckBox chk_activateArmorAspect;
        private ComboBox cbo_weaponAspect;
        private ComboBox cbo_spellbookAspect;
        private ComboBox cbo_armorAspect;
        private CheckBox chk_helm;
        private Label lbl_exceptional;
        private CheckBox chk_gorget;
        private CheckBox chk_gloves;
        private CheckBox chk_legs;
        private CheckBox chk_chest;
        private CheckBox chk_shoulders;
        private Label lbl_alterEgo1;
        private Label lbl_alterEgo2;
        private Label lbl_alterEgo3;
        private Label lbl_alterEgo4;
        private Label lbl_alterEgo5;
        private Label lbl_alterEgo10;
        private Label lbl_alterEgo9;
        private Label lbl_alterEgo8;
        private Label lbl_alterEgo7;
        private Label lbl_alterEgo6;
        private Label lbl_alterEgo15;
        private Label lbl_alterEgo14;
        private Label lbl_alterEgo13;
        private Label lbl_alterEgo12;
        private Label lbl_alterEgo11;
        private CheckBox chk_itemsLoaded;
    }
}