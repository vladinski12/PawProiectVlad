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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PawProiectVlad
{
	public partial class Form5 : Form
	{
		private List<Masina> masini = new List<Masina>();
		public Form5()
		{
			InitializeComponent();

			comboBox1.SelectedIndex = 0;
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

			FileStream fs = new FileStream("masini.dat", FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			if (new FileInfo("masini.dat").Length != 0)
				masini = (List<Masina>)bf.Deserialize(fs);
			fs.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "") { errorProvider1.Clear(); errorProvider1.SetError(textBox1, "Completeaza numele masinii!"); }
			else if (numericUpDown1.Value <= 0) { errorProvider1.Clear(); errorProvider1.SetError(numericUpDown1, "Completeaza capacitatea!"); }
			else if (textBox2.Text == "") { errorProvider1.Clear(); errorProvider1.SetError(textBox2, "Completeaza locatia curenta!"); }
			else
			{
				Masina m = new Masina(textBox1.Text, decimal.ToInt32(numericUpDown1.Value), Char.Parse(comboBox1.Text), textBox2.Text);
				masini.Add(m);
				FileStream fs = new FileStream("masini.dat", FileMode.Create, FileAccess.Write);
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(fs, masini);
				fs.Close();
				this.Close();
				new Form2().Show();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			new Form2().Show();
			this.Close();
		}
	}
}
