namespace CortezosWorkshop
{
    partial class FormMainEditFunds
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
            btn_Save = new Button();
            btn_Back = new Button();
            lbl_Funds = new Label();
            lbl_Oro = new Label();
            txtBox = new TextBox();
            SuspendLayout();
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(32, 138);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(75, 23);
            btn_Save.TabIndex = 0;
            btn_Save.Text = "Guardar";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_Back
            // 
            btn_Back.Location = new Point(156, 138);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(75, 23);
            btn_Back.TabIndex = 1;
            btn_Back.Text = "Cerrar";
            btn_Back.UseVisualStyleBackColor = true;
            btn_Back.Click += btn_Back_Click;
            // 
            // lbl_Funds
            // 
            lbl_Funds.AutoSize = true;
            lbl_Funds.Location = new Point(103, 26);
            lbl_Funds.Name = "lbl_Funds";
            lbl_Funds.Size = new Size(49, 15);
            lbl_Funds.TabIndex = 2;
            lbl_Funds.Text = "Fondos:";
            // 
            // lbl_Oro
            // 
            lbl_Oro.AutoSize = true;
            lbl_Oro.Location = new Point(120, 51);
            lbl_Oro.Name = "lbl_Oro";
            lbl_Oro.Size = new Size(0, 15);
            lbl_Oro.TabIndex = 6;
            // 
            // txtBox
            // 
            txtBox.Location = new Point(63, 84);
            txtBox.Name = "txtBox";
            txtBox.Size = new Size(130, 23);
            txtBox.TabIndex = 7;
            txtBox.TextAlign = HorizontalAlignment.Center;
            txtBox.KeyPress += txtBox_KeyPress;
            // 
            // FormMainEditFunds
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(253, 173);
            ControlBox = false;
            Controls.Add(txtBox);
            Controls.Add(lbl_Oro);
            Controls.Add(lbl_Funds);
            Controls.Add(btn_Back);
            Controls.Add(btn_Save);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMainEditFunds";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Caja fuerte";
            Load += FormMainEditFunds_Load;
            Shown += FormMainEditFunds_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Save;
        private Button btn_Back;
        private Label lbl_Funds;
        private Label lbl_Oro;
        private TextBox txtBox;
    }
}