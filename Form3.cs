using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawProiectVlad
{
	public partial class Form3 : Form
	{
		private List<Ruta> rute = new List<Ruta>();
		public Form3()
		{
			InitializeComponent();
			FileStream fs = new FileStream("rute.dat", FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			if (new FileInfo("rute.dat").Length != 0)
				rute = (List<Ruta>)bf.Deserialize(fs);
			fs.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			new Form2().Show();
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "") { errorProvider1.Clear(); errorProvider1.SetError(textBox1, "Completeaza numele rutei!"); }
			else if (textBox2.Text == "") { errorProvider1.Clear(); errorProvider1.SetError(textBox2, "Completeaza punctul de plecare!"); }
			else if (textBox3.Text == "") { errorProvider1.Clear(); errorProvider1.SetError(textBox3, "Completeaza punctul de sosire!"); }
			else if (numericUpDown1.Value <= 0) { errorProvider1.Clear(); errorProvider1.SetError(numericUpDown1, "Completeaza distanta"); }
			else
			{
				Ruta r = new Ruta(textBox1.Text, textBox2.Text, textBox3.Text, decimal.ToDouble(numericUpDown1.Value));
				rute.Add(r);
				FileStream fs = new FileStream("rute.dat", FileMode.Create, FileAccess.Write);
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(fs, rute);
				fs.Close();
				this.Close();
				new Form2().Show();
			}
		}
	}
}
