namespace Forms.TheSkavengers
{
    partial class FormTheSkavengersMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTheSkavengersMain));
            lbl_Titulo = new Label();
            btn_armory = new Button();
            btn_workshop = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lbl_Titulo
            // 
            lbl_Titulo.AutoSize = true;
            lbl_Titulo.Font = new Font("Jokerman", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Titulo.Location = new Point(250, 64);
            lbl_Titulo.Name = "lbl_Titulo";
            lbl_Titulo.Size = new Size(307, 47);
            lbl_Titulo.TabIndex = 13;
            lbl_Titulo.Text = "THE SKAVENGERS";
            lbl_Titulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_armory
            // 
            btn_armory.Location = new Point(282, 229);
            btn_armory.Name = "btn_armory";
            btn_armory.Size = new Size(238, 33);
            btn_armory.TabIndex = 11;
            btn_armory.Text = "ARMERÍA";
            btn_armory.UseVisualStyleBackColor = true;
            btn_armory.Click += btn_armory_Click;
            // 
            // btn_workshop
            // 
            btn_workshop.Location = new Point(282, 163);
            btn_workshop.Name = "btn_workshop";
            btn_workshop.Size = new Size(238, 33);
            btn_workshop.TabIndex = 10;
            btn_workshop.Text = "CORTEZO'S WORKSHOP";
            btn_workshop.UseVisualStyleBackColor = true;
            btn_workshop.Click += btn_workshop_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(749, 420);
            label1.Name = "label1";
            label1.Size = new Size(39, 21);
            label1.TabIndex = 14;
            label1.Text = "v1.2";
            // 
            // FormTheSkavengersMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(lbl_Titulo);
            Controls.Add(btn_armory);
            Controls.Add(btn_workshop);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "FormTheSkavengersMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "The Skavengers";
            Shown += FormTheSkavengersMain_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Titulo;
        private Button btn_armory;
        private Button btn_workshop;
        private Label label1;
    }
}