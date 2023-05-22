namespace PawProiectVlad
{
	partial class Form1
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.adaugaTransportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.graficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.incarcaDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportaDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 30);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(800, 420);
			this.dataGridView1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugaTransportToolStripMenuItem,
            this.graficToolStripMenuItem,
            this.incarcaDateToolStripMenuItem,
            this.exportaDateToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 30);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// adaugaTransportToolStripMenuItem
			// 
			this.adaugaTransportToolStripMenuItem.Name = "adaugaTransportToolStripMenuItem";
			this.adaugaTransportToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
			this.adaugaTransportToolStripMenuItem.Text = "Adauga &Transport";
			this.adaugaTransportToolStripMenuItem.Click += new System.EventHandler(this.adaugaTransportToolStripMenuItem_Click);
			// 
			// graficToolStripMenuItem
			// 
			this.graficToolStripMenuItem.Name = "graficToolStripMenuItem";
			this.graficToolStripMenuItem.Size = new System.Drawing.Size(62, 26);
			this.graficToolStripMenuItem.Text = "&Grafic";
			this.graficToolStripMenuItem.Click += new System.EventHandler(this.graficToolStripMenuItem_Click);
			// 
			// incarcaDateToolStripMenuItem
			// 
			this.incarcaDateToolStripMenuItem.Name = "incarcaDateToolStripMenuItem";
			this.incarcaDateToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
			this.incarcaDateToolStripMenuItem.Text = "&Importa Date";
			this.incarcaDateToolStripMenuItem.Click += new System.EventHandler(this.incarcaDateToolStripMenuItem_Click);
			// 
			// exportaDateToolStripMenuItem
			// 
			this.exportaDateToolStripMenuItem.Name = "exportaDateToolStripMenuItem";
			this.exportaDateToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
			this.exportaDateToolStripMenuItem.Text = "&Exporta Date";
			this.exportaDateToolStripMenuItem.Click += new System.EventHandler(this.exportaDateToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem adaugaTransportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem graficToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem incarcaDateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportaDateToolStripMenuItem;
	}
}

