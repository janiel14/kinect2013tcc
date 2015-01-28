namespace TCCKinect1._0.visao
{
    partial class FormMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">verdade se for necessário descartar os recursos gerenciados; caso contrário, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte do Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clinicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fisioterapeutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichaDeAvaliaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SessaoStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessoesRelatorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.janelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.SessaoStripMenuItem1,
            this.relatóriosToolStripMenuItem,
            this.janelaToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.janelaToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 46);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clinicaToolStripMenuItem,
            this.fisioterapeutaToolStripMenuItem,
            this.fichaDeAvaliaçãoToolStripMenuItem,
            this.pacienteToolStripMenuItem});
            this.cadastroToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cadastroToolStripMenuItem.Image")));
            this.cadastroToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cadastroToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.cadastroToolStripMenuItem.Margin = new System.Windows.Forms.Padding(1);
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(103, 40);
            this.cadastroToolStripMenuItem.Text = "Cadastros";
            // 
            // clinicaToolStripMenuItem
            // 
            this.clinicaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clinicaToolStripMenuItem.Image")));
            this.clinicaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clinicaToolStripMenuItem.Name = "clinicaToolStripMenuItem";
            this.clinicaToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.clinicaToolStripMenuItem.Text = "Clinica";
            this.clinicaToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.clinicaToolStripMenuItem.Click += new System.EventHandler(this.clinicaToolStripMenuItem_Click);
            // 
            // fisioterapeutaToolStripMenuItem
            // 
            this.fisioterapeutaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fisioterapeutaToolStripMenuItem.Image")));
            this.fisioterapeutaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fisioterapeutaToolStripMenuItem.Name = "fisioterapeutaToolStripMenuItem";
            this.fisioterapeutaToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.fisioterapeutaToolStripMenuItem.Text = "Fisioterapeuta";
            this.fisioterapeutaToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fisioterapeutaToolStripMenuItem.Click += new System.EventHandler(this.fisioterapeutaToolStripMenuItem_Click);
            // 
            // fichaDeAvaliaçãoToolStripMenuItem
            // 
            this.fichaDeAvaliaçãoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fichaDeAvaliaçãoToolStripMenuItem.Image")));
            this.fichaDeAvaliaçãoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fichaDeAvaliaçãoToolStripMenuItem.Name = "fichaDeAvaliaçãoToolStripMenuItem";
            this.fichaDeAvaliaçãoToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.fichaDeAvaliaçãoToolStripMenuItem.Text = "Ficha de Avaliação";
            this.fichaDeAvaliaçãoToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fichaDeAvaliaçãoToolStripMenuItem.Click += new System.EventHandler(this.fichaDeAvaliaçãoToolStripMenuItem_Click);
            // 
            // pacienteToolStripMenuItem
            // 
            this.pacienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pacienteToolStripMenuItem.Image")));
            this.pacienteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pacienteToolStripMenuItem.Name = "pacienteToolStripMenuItem";
            this.pacienteToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.pacienteToolStripMenuItem.Text = "Paciente";
            this.pacienteToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pacienteToolStripMenuItem.Click += new System.EventHandler(this.pacienteToolStripMenuItem_Click);
            // 
            // SessaoStripMenuItem1
            // 
            this.SessaoStripMenuItem1.Image = global::TCCKinect1._0.Properties.Resources.Sessao1;
            this.SessaoStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SessaoStripMenuItem1.Margin = new System.Windows.Forms.Padding(2);
            this.SessaoStripMenuItem1.Name = "SessaoStripMenuItem1";
            this.SessaoStripMenuItem1.Size = new System.Drawing.Size(93, 38);
            this.SessaoStripMenuItem1.Text = "Sessões";
            this.SessaoStripMenuItem1.Click += new System.EventHandler(this.SessaoStripMenuItem1_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sessoesRelatorioToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Image = global::TCCKinect1._0.Properties.Resources.relatorios;
            this.relatóriosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(103, 42);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // sessoesRelatorioToolStripMenuItem
            // 
            this.sessoesRelatorioToolStripMenuItem.Image = global::TCCKinect1._0.Properties.Resources.relatorio_sessoes;
            this.sessoesRelatorioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sessoesRelatorioToolStripMenuItem.Name = "sessoesRelatorioToolStripMenuItem";
            this.sessoesRelatorioToolStripMenuItem.Size = new System.Drawing.Size(130, 38);
            this.sessoesRelatorioToolStripMenuItem.Text = "Sessões";
            this.sessoesRelatorioToolStripMenuItem.Click += new System.EventHandler(this.sessoesRelatorioToolStripMenuItem_Click);
            // 
            // janelaToolStripMenuItem
            // 
            this.janelaToolStripMenuItem.Image = global::TCCKinect1._0.Properties.Resources.janelas01;
            this.janelaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.janelaToolStripMenuItem.Name = "janelaToolStripMenuItem";
            this.janelaToolStripMenuItem.Size = new System.Drawing.Size(88, 42);
            this.janelaToolStripMenuItem.Text = "Janelas";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sairToolStripMenuItem.Image")));
            this.sairToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sairToolStripMenuItem.Margin = new System.Windows.Forms.Padding(2);
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(70, 38);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(901, 687);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(900, 0);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Fisioterapia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fisioterapeutaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clinicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichaDeAvaliaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pacienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SessaoStripMenuItem1;
        protected System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem janelaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessoesRelatorioToolStripMenuItem;
    }
}

