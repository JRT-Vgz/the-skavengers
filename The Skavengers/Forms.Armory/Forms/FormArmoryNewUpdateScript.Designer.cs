namespace Forms.Armory.Forms
{
    partial class FormArmoryNewUpdateScript
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
            lbl_scriptName = new Label();
            txt_scriptName = new TextBox();
            btn_save = new Button();
            lbl_scriptVersion = new Label();
            txt_scriptVersion = new TextBox();
            btn_back = new Button();
            txt_scriptDescription = new TextBox();
            lbl_description = new Label();
            lbl_scriptContent = new Label();
            btn_loadFile = new Button();
            ofd_loadFile = new OpenFileDialog();
            lbl_loadFileName = new Label();
            txt_armoryPassword = new TextBox();
            lbl_armoryPassword = new Label();
            txt_scriptWarning = new TextBox();
            lbl_scriptWarning = new Label();
            SuspendLayout();
            // 
            // lbl_scriptName
            // 
            lbl_scriptName.AutoSize = true;
            lbl_scriptName.Location = new Point(38, 38);
            lbl_scriptName.Name = "lbl_scriptName";
            lbl_scriptName.Size = new Size(105, 15);
            lbl_scriptName.TabIndex = 0;
            lbl_scriptName.Text = "Nombre del script:";
            // 
            // txt_scriptName
            // 
            txt_scriptName.Location = new Point(146, 35);
            txt_scriptName.Name = "txt_scriptName";
            txt_scriptName.Size = new Size(187, 23);
            txt_scriptName.TabIndex = 1;
            txt_scriptName.KeyPress += txt_scriptName_KeyPress;
            // 
            // btn_save
            // 
            btn_save.Location = new Point(121, 261);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(75, 23);
            btn_save.TabIndex = 7;
            btn_save.Text = "Guardar";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // lbl_scriptVersion
            // 
            lbl_scriptVersion.AutoSize = true;
            lbl_scriptVersion.Location = new Point(92, 71);
            lbl_scriptVersion.Name = "lbl_scriptVersion";
            lbl_scriptVersion.Size = new Size(51, 15);
            lbl_scriptVersion.TabIndex = 3;
            lbl_scriptVersion.Text = "Versión: ";
            // 
            // txt_scriptVersion
            // 
            txt_scriptVersion.Location = new Point(146, 68);
            txt_scriptVersion.Name = "txt_scriptVersion";
            txt_scriptVersion.Size = new Size(42, 23);
            txt_scriptVersion.TabIndex = 2;
            txt_scriptVersion.KeyPress += txt_scriptVersion_KeyPress;
            // 
            // btn_back
            // 
            btn_back.Location = new Point(251, 261);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(75, 23);
            btn_back.TabIndex = 8;
            btn_back.Text = "Cerrar";
            btn_back.UseVisualStyleBackColor = true;
            btn_back.Click += btn_back_Click;
            // 
            // txt_scriptDescription
            // 
            txt_scriptDescription.Location = new Point(146, 101);
            txt_scriptDescription.Name = "txt_scriptDescription";
            txt_scriptDescription.Size = new Size(187, 23);
            txt_scriptDescription.TabIndex = 3;
            txt_scriptDescription.KeyPress += txt_scriptDescription_KeyPress;
            // 
            // lbl_description
            // 
            lbl_description.AutoSize = true;
            lbl_description.Location = new Point(68, 104);
            lbl_description.Name = "lbl_description";
            lbl_description.Size = new Size(72, 15);
            lbl_description.TabIndex = 6;
            lbl_description.Text = "Descripción:";
            // 
            // lbl_scriptContent
            // 
            lbl_scriptContent.AutoSize = true;
            lbl_scriptContent.Location = new Point(77, 177);
            lbl_scriptContent.Name = "lbl_scriptContent";
            lbl_scriptContent.Size = new Size(66, 15);
            lbl_scriptContent.TabIndex = 8;
            lbl_scriptContent.Text = "Contenido:";
            // 
            // btn_loadFile
            // 
            btn_loadFile.Location = new Point(146, 172);
            btn_loadFile.Name = "btn_loadFile";
            btn_loadFile.Size = new Size(94, 25);
            btn_loadFile.TabIndex = 5;
            btn_loadFile.Text = "Cargar Archivo";
            btn_loadFile.UseVisualStyleBackColor = true;
            btn_loadFile.Click += btn_loadFile_Click;
            // 
            // lbl_loadFileName
            // 
            lbl_loadFileName.AutoSize = true;
            lbl_loadFileName.Location = new Point(251, 179);
            lbl_loadFileName.Name = "lbl_loadFileName";
            lbl_loadFileName.Size = new Size(0, 15);
            lbl_loadFileName.TabIndex = 10;
            // 
            // txt_armoryPassword
            // 
            txt_armoryPassword.Location = new Point(213, 227);
            txt_armoryPassword.Name = "txt_armoryPassword";
            txt_armoryPassword.PasswordChar = '*';
            txt_armoryPassword.Size = new Size(102, 23);
            txt_armoryPassword.TabIndex = 6;
            txt_armoryPassword.KeyDown += txt_armoryPassword_KeyDown;
            txt_armoryPassword.KeyPress += txt_password_KeyPress;
            // 
            // lbl_armoryPassword
            // 
            lbl_armoryPassword.AutoSize = true;
            lbl_armoryPassword.Location = new Point(135, 230);
            lbl_armoryPassword.Name = "lbl_armoryPassword";
            lbl_armoryPassword.Size = new Size(70, 15);
            lbl_armoryPassword.TabIndex = 11;
            lbl_armoryPassword.Text = "Contraseña:";
            // 
            // txt_scriptWarning
            // 
            txt_scriptWarning.Location = new Point(146, 135);
            txt_scriptWarning.Name = "txt_scriptWarning";
            txt_scriptWarning.Size = new Size(187, 23);
            txt_scriptWarning.TabIndex = 4;
            txt_scriptWarning.KeyPress += txt_scriptWarning_KeyPress;
            // 
            // lbl_scriptWarning
            // 
            lbl_scriptWarning.AutoSize = true;
            lbl_scriptWarning.Location = new Point(68, 138);
            lbl_scriptWarning.Name = "lbl_scriptWarning";
            lbl_scriptWarning.Size = new Size(73, 15);
            lbl_scriptWarning.TabIndex = 13;
            lbl_scriptWarning.Text = "Advertencia:";
            // 
            // FormArmoryNewUpdateScript
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 315);
            ControlBox = false;
            Controls.Add(txt_scriptWarning);
            Controls.Add(lbl_scriptWarning);
            Controls.Add(txt_armoryPassword);
            Controls.Add(lbl_armoryPassword);
            Controls.Add(lbl_loadFileName);
            Controls.Add(btn_loadFile);
            Controls.Add(lbl_scriptContent);
            Controls.Add(txt_scriptDescription);
            Controls.Add(lbl_description);
            Controls.Add(btn_back);
            Controls.Add(txt_scriptVersion);
            Controls.Add(lbl_scriptVersion);
            Controls.Add(btn_save);
            Controls.Add(txt_scriptName);
            Controls.Add(lbl_scriptName);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(472, 354);
            MinimizeBox = false;
            MinimumSize = new Size(472, 354);
            Name = "FormArmoryNewUpdateScript";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Tag = "";
            Text = " Nuevo script";
            Load += FormArmoryNewUpdateScript_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_scriptName;
        private TextBox txt_scriptName;
        private Button btn_save;
        private Label lbl_scriptVersion;
        private TextBox txt_scriptVersion;
        private Button btn_back;
        private TextBox txt_scriptDescription;
        private Label lbl_description;
        private Label lbl_scriptContent;
        private Button btn_loadFile;
        private OpenFileDialog ofd_loadFile;
        private Label lbl_loadFileName;
        private TextBox txt_armoryPassword;
        private Label lbl_armoryPassword;
        private TextBox txt_scriptWarning;
        private Label lbl_scriptWarning;
    }
}