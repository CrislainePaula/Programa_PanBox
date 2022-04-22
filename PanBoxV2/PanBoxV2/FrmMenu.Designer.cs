namespace PanBoxV2
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnFuncionarios = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.frmFuncionario1 = new PanBoxV2.FrmFuncionario();
            this.principal1 = new PanBoxV2.Principal();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Controls.Add(this.BtnSair);
            this.panel1.Controls.Add(this.BtnFuncionarios);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 628);
            this.panel1.TabIndex = 0;
            // 
            // BtnSair
            // 
            this.BtnSair.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnSair.FlatAppearance.BorderSize = 0;
            this.BtnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSair.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.ForeColor = System.Drawing.Color.DarkMagenta;
            this.BtnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSair.Location = new System.Drawing.Point(0, 583);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(253, 45);
            this.BtnSair.TabIndex = 7;
            this.BtnSair.Text = "Sair";
            this.BtnSair.UseVisualStyleBackColor = false;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // BtnFuncionarios
            // 
            this.BtnFuncionarios.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BtnFuncionarios.FlatAppearance.BorderSize = 0;
            this.BtnFuncionarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFuncionarios.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFuncionarios.ForeColor = System.Drawing.Color.DarkMagenta;
            this.BtnFuncionarios.Image = global::PanBoxV2.Properties.Resources.funcionarios;
            this.BtnFuncionarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFuncionarios.Location = new System.Drawing.Point(0, 283);
            this.BtnFuncionarios.Name = "BtnFuncionarios";
            this.BtnFuncionarios.Size = new System.Drawing.Size(253, 45);
            this.BtnFuncionarios.TabIndex = 1;
            this.BtnFuncionarios.Text = "Funcionários";
            this.BtnFuncionarios.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::PanBoxV2.Properties.Resources.panbox_logo1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 51);
            this.panel2.TabIndex = 1;
            // 
            // frmFuncionario1
            // 
            this.frmFuncionario1.BackColor = System.Drawing.Color.LavenderBlush;
            this.frmFuncionario1.Location = new System.Drawing.Point(252, 0);
            this.frmFuncionario1.Name = "frmFuncionario1";
            this.frmFuncionario1.Size = new System.Drawing.Size(800, 637);
            this.frmFuncionario1.TabIndex = 2;
            // 
            // principal1
            // 
            this.principal1.Location = new System.Drawing.Point(252, 0);
            this.principal1.Name = "principal1";
            this.principal1.Size = new System.Drawing.Size(796, 746);
            this.principal1.TabIndex = 1;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 628);
            this.Controls.Add(this.frmFuncionario1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.principal1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMenu";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.Button BtnFuncionarios;
        private Principal principal1;
        private FrmFuncionario frmFuncionario1;
    }
}