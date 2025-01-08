namespace CortezosWorkshop.Estadisticas
{
    partial class FormEstadisticasMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEstadisticasMain));
            btn_menu_principal = new Button();
            lbl_oroTotal = new Label();
            lbl_cajafuerte = new Label();
            lbl_beneficio = new Label();
            lbl_oroGastado = new Label();
            lbl_mapasCompletados = new Label();
            lbl_recursosExtraidos = new Label();
            btn_log = new Button();
            lbl_lockpicksCrafteados = new Label();
            lbl_herramientasCrafteadas = new Label();
            lbl_armadurasCrafteadas = new Label();
            SuspendLayout();
            // 
            // btn_menu_principal
            // 
            btn_menu_principal.Location = new Point(12, 12);
            btn_menu_principal.Name = "btn_menu_principal";
            btn_menu_principal.Size = new Size(99, 23);
            btn_menu_principal.TabIndex = 2;
            btn_menu_principal.Text = "Menú principal";
            btn_menu_principal.UseVisualStyleBackColor = true;
            btn_menu_principal.Click += btn_menu_principal_Click;
            // 
            // lbl_oroTotal
            // 
            lbl_oroTotal.AutoSize = true;
            lbl_oroTotal.Location = new Point(246, 62);
            lbl_oroTotal.Name = "lbl_oroTotal";
            lbl_oroTotal.Size = new Size(190, 15);
            lbl_oroTotal.TabIndex = 4;
            lbl_oroTotal.Text = "- Oro total vendido en la tienda:     ";
            // 
            // lbl_cajafuerte
            // 
            lbl_cajafuerte.AutoSize = true;
            lbl_cajafuerte.Location = new Point(246, 97);
            lbl_cajafuerte.Name = "lbl_cajafuerte";
            lbl_cajafuerte.Size = new Size(216, 15);
            lbl_cajafuerte.TabIndex = 5;
            lbl_cajafuerte.Text = "- Fondos almacenados en la caja fuerte:";
            // 
            // lbl_beneficio
            // 
            lbl_beneficio.AutoSize = true;
            lbl_beneficio.Location = new Point(246, 168);
            lbl_beneficio.Name = "lbl_beneficio";
            lbl_beneficio.Size = new Size(223, 15);
            lbl_beneficio.TabIndex = 6;
            lbl_beneficio.Text = "- Beneficio retirado para nuestro disfrute:";
            // 
            // lbl_oroGastado
            // 
            lbl_oroGastado.AutoSize = true;
            lbl_oroGastado.Location = new Point(246, 133);
            lbl_oroGastado.Name = "lbl_oroGastado";
            lbl_oroGastado.Size = new Size(251, 15);
            lbl_oroGastado.TabIndex = 7;
            lbl_oroGastado.Text = "- Oro gastado en comprar mapas y materiales:";
            // 
            // lbl_mapasCompletados
            // 
            lbl_mapasCompletados.AutoSize = true;
            lbl_mapasCompletados.Location = new Point(246, 204);
            lbl_mapasCompletados.Name = "lbl_mapasCompletados";
            lbl_mapasCompletados.Size = new Size(125, 15);
            lbl_mapasCompletados.TabIndex = 8;
            lbl_mapasCompletados.Text = "- Mapas completados:";
            // 
            // lbl_recursosExtraidos
            // 
            lbl_recursosExtraidos.AutoSize = true;
            lbl_recursosExtraidos.Location = new Point(246, 239);
            lbl_recursosExtraidos.Name = "lbl_recursosExtraidos";
            lbl_recursosExtraidos.Size = new Size(160, 15);
            lbl_recursosExtraidos.TabIndex = 9;
            lbl_recursosExtraidos.Text = "- Total de recursos extraídos::";
            // 
            // btn_log
            // 
            btn_log.Location = new Point(12, 415);
            btn_log.Name = "btn_log";
            btn_log.Size = new Size(64, 23);
            btn_log.TabIndex = 10;
            btn_log.Text = "Log";
            btn_log.UseVisualStyleBackColor = true;
            btn_log.Click += btn_log_Click;
            // 
            // lbl_lockpicksCrafteados
            // 
            lbl_lockpicksCrafteados.AutoSize = true;
            lbl_lockpicksCrafteados.Location = new Point(246, 344);
            lbl_lockpicksCrafteados.Name = "lbl_lockpicksCrafteados";
            lbl_lockpicksCrafteados.Size = new Size(128, 15);
            lbl_lockpicksCrafteados.TabIndex = 13;
            lbl_lockpicksCrafteados.Text = "- Lockpicks crafteados:";
            // 
            // lbl_herramientasCrafteadas
            // 
            lbl_herramientasCrafteadas.AutoSize = true;
            lbl_herramientasCrafteadas.Location = new Point(246, 309);
            lbl_herramientasCrafteadas.Name = "lbl_herramientasCrafteadas";
            lbl_herramientasCrafteadas.Size = new Size(146, 15);
            lbl_herramientasCrafteadas.TabIndex = 12;
            lbl_herramientasCrafteadas.Text = "- Herramientas crafteadas:";
            // 
            // lbl_armadurasCrafteadas
            // 
            lbl_armadurasCrafteadas.AutoSize = true;
            lbl_armadurasCrafteadas.Location = new Point(246, 273);
            lbl_armadurasCrafteadas.Name = "lbl_armadurasCrafteadas";
            lbl_armadurasCrafteadas.Size = new Size(191, 15);
            lbl_armadurasCrafteadas.TabIndex = 11;
            lbl_armadurasCrafteadas.Text = "- Armaduras completas crafteadas:";
            // 
            // FormEstadisticasMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_lockpicksCrafteados);
            Controls.Add(lbl_herramientasCrafteadas);
            Controls.Add(lbl_armadurasCrafteadas);
            Controls.Add(btn_log);
            Controls.Add(lbl_recursosExtraidos);
            Controls.Add(lbl_mapasCompletados);
            Controls.Add(lbl_oroGastado);
            Controls.Add(lbl_beneficio);
            Controls.Add(lbl_cajafuerte);
            Controls.Add(lbl_oroTotal);
            Controls.Add(btn_menu_principal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimizeBox = false;
            MinimumSize = new Size(816, 489);
            Name = "FormEstadisticasMain";
            StartPosition = FormStartPosition.Manual;
            Text = "Estadísticas";
            FormClosing += Form_Closing;
            Load += FormEstadisticasMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_menu_principal;
        private Label lbl_oroTotal;
        private Label lbl_cajafuerte;
        private Label lbl_beneficio;
        private Label lbl_oroGastado;
        private Label lbl_mapasCompletados;
        private Label lbl_recursosExtraidos;
        private Button btn_log;
        private Label lbl_lockpicksCrafteados;
        private Label lbl_herramientasCrafteadas;
        private Label lbl_armadurasCrafteadas;
    }
}