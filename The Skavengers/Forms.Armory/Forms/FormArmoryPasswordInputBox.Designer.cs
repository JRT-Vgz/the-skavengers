namespace Forms.Armory.Forms
{
    partial class FormArmoryPasswordInputBox
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
            lbl_password = new Label();
            txt_armoryPassword = new TextBox();
            btn_ok = new Button();
            btn_cancel = new Button();
            SuspendLayout();
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Location = new Point(76, 20);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(134, 15);
            lbl_password.TabIndex = 0;
            lbl_password.Text = "Introduce la contraseña:";
            // 
            // txt_armoryPassword
            // 
            txt_armoryPassword.Location = new Point(76, 47);
            txt_armoryPassword.Name = "txt_armoryPassword";
            txt_armoryPassword.PasswordChar = '*';
            txt_armoryPassword.Size = new Size(134, 23);
            txt_armoryPassword.TabIndex = 1;
            txt_armoryPassword.KeyDown += txt_armoryPassword_KeyDown;
            txt_armoryPassword.KeyPress += textBox1_KeyPress;
            // 
            // btn_ok
            // 
            btn_ok.Location = new Point(48, 87);
            btn_ok.Name = "btn_ok";
            btn_ok.Size = new Size(78, 22);
            btn_ok.TabIndex = 2;
            btn_ok.Text = "OK";
            btn_ok.UseVisualStyleBackColor = true;
            btn_ok.Click += btn_ok_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(163, 87);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(78, 22);
            btn_cancel.TabIndex = 3;
            btn_cancel.Text = "Cancelar";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // FormArmoryPasswordInputBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 132);
            ControlBox = false;
            Controls.Add(btn_cancel);
            Controls.Add(btn_ok);
            Controls.Add(txt_armoryPassword);
            Controls.Add(lbl_password);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(303, 171);
            MinimizeBox = false;
            MinimumSize = new Size(303, 171);
            Name = "FormArmoryPasswordInputBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Contraseña";
            Load += FormArmoryPasswordInputBox_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_password;
        private TextBox txt_armoryPassword;
        private Button btn_ok;
        private Button btn_cancel;
    }
}