namespace ArgentinaGeneraCMS
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            filePath = new TextBox();
            label1 = new Label();
            btnFileSearch = new Button();
            label2 = new Label();
            password = new TextBox();
            btnGenerar = new Button();
            label3 = new Label();
            CMS = new RichTextBox();
            label4 = new Label();
            servicio = new ComboBox();
            SuspendLayout();
            // 
            // filePath
            // 
            filePath.Location = new Point(132, 12);
            filePath.Name = "filePath";
            filePath.ReadOnly = true;
            filePath.Size = new Size(498, 27);
            filePath.TabIndex = 0;
            filePath.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 15);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 1;
            label1.Text = "Certificado";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnFileSearch
            // 
            btnFileSearch.Location = new Point(629, 11);
            btnFileSearch.Name = "btnFileSearch";
            btnFileSearch.Size = new Size(36, 29);
            btnFileSearch.TabIndex = 2;
            btnFileSearch.Text = "...";
            btnFileSearch.UseVisualStyleBackColor = true;
            btnFileSearch.Click += btnFileSearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 48);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 3;
            label2.Text = "Contraseña";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // password
            // 
            password.Location = new Point(132, 45);
            password.Name = "password";
            password.PasswordChar = '*';
            password.Size = new Size(498, 27);
            password.TabIndex = 4;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(132, 127);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(129, 51);
            btnGenerar.TabIndex = 5;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 185);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 6;
            label3.Text = "CMS";
            // 
            // CMS
            // 
            CMS.BackColor = SystemColors.Window;
            CMS.Location = new Point(12, 208);
            CMS.Name = "CMS";
            CMS.ReadOnly = true;
            CMS.Size = new Size(1221, 337);
            CMS.TabIndex = 7;
            CMS.TabStop = false;
            CMS.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 85);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 8;
            label4.Text = "Servicio";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // servicio
            // 
            servicio.DropDownStyle = ComboBoxStyle.DropDownList;
            servicio.FormattingEnabled = true;
            servicio.Items.AddRange(new object[] { "Facturas A y B", "Facturas T", "Facturas de Exportación" });
            servicio.Location = new Point(132, 82);
            servicio.Name = "servicio";
            servicio.Size = new Size(206, 28);
            servicio.TabIndex = 9;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 557);
            Controls.Add(servicio);
            Controls.Add(label4);
            Controls.Add(CMS);
            Controls.Add(label3);
            Controls.Add(btnGenerar);
            Controls.Add(password);
            Controls.Add(label2);
            Controls.Add(btnFileSearch);
            Controls.Add(label1);
            Controls.Add(filePath);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Genera CMS - Argentina";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox filePath;
        private Label label1;
        private Button btnFileSearch;
        private Label label2;
        private TextBox password;
        private Button btnGenerar;
        private Label label3;
        private RichTextBox CMS;
        private Label label4;
        private ComboBox servicio;
    }
}
