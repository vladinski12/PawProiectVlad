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
	public partial class Form4 : Form
	{
		private List<Sofer> soferi = new List<Sofer>();
		public Form4()
		{
			InitializeComponent();
			FileStream fs = new FileStream("soferi.dat", FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			if (new FileInfo("soferi.dat").Length != 0)
				soferi = (List<Sofer>)bf.Deserialize(fs);
			fs.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "") { errorProvider1.Clear(); errorProvider1.SetError(textBox1, "Completeaza numele soferului!"); }
			else if (numericUpDown1.Value < 18) { errorProvider1.Clear(); errorProvider1.SetError(numericUpDown1, "Completeaza o varsta corecta!"); }
			else if (textBox2.Text == "") { errorProvider1.Clear(); errorProvider1.SetError(textBox1, "Completeaza locatia curenta!"); }
			else
			{
				Sofer s = new Sofer((string)textBox1.Text, decimal.ToInt32(numericUpDown1.Value), checkBox1.Checked, (string)textBox2.Text);
				soferi.Add(s);
				FileStream fs = new FileStream("soferi.dat", FileMode.Create, FileAccess.Write);
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(fs, soferi);
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
