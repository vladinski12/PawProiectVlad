using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawProiectVlad
{
	public partial class Form7 : Form
	{
		public Form7(ArrayList _lista)
		{
			InitializeComponent();
			View view = new View(_lista);
			view.Dock = DockStyle.Fill;
			this.Controls.Add(view);
		}

		private void inapoiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
			form2.Show();
			this.Hide();
		}
	}
}
