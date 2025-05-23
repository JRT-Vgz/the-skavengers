﻿namespace Forms.CortezosWorkshop
{
    partial class FormCortezosWorkshopBenefit
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
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(26, 135);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(75, 23);
            btn_Save.TabIndex = 0;
            btn_Save.Text = "Retirar";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // btn_Back
            // 
            btn_Back.Location = new Point(150, 135);
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
            lbl_Funds.Location = new Point(69, 9);
            lbl_Funds.Name = "lbl_Funds";
            lbl_Funds.Size = new Size(112, 15);
            lbl_Funds.TabIndex = 2;
            lbl_Funds.Text = "Fondos disponibles:";
            // 
            // lbl_Oro
            // 
            lbl_Oro.AutoSize = true;
            lbl_Oro.Location = new Point(107, 33);
            lbl_Oro.Name = "lbl_Oro";
            lbl_Oro.Size = new Size(0, 15);
            lbl_Oro.TabIndex = 6;
            // 
            // txtBox
            // 
            txtBox.Location = new Point(61, 90);
            txtBox.Name = "txtBox";
            txtBox.Size = new Size(130, 23);
            txtBox.TabIndex = 7;
            txtBox.TextAlign = HorizontalAlignment.Center;
            txtBox.KeyDown += txtBox_KeyDown;
            txtBox.KeyPress += txtBox_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 66);
            label1.Name = "label1";
            label1.Size = new Size(152, 15);
            label1.TabIndex = 8;
            label1.Text = "¿Cuánto oro quieres retirar?";
            // 
            // FormMainBeneficio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(253, 179);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(txtBox);
            Controls.Add(lbl_Oro);
            Controls.Add(lbl_Funds);
            Controls.Add(btn_Back);
            Controls.Add(btn_Save);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(269, 218);
            MinimizeBox = false;
            MinimumSize = new Size(269, 218);
            Name = "FormMainBeneficio";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Retirar fondos";
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
        private Label label1;
    }
}