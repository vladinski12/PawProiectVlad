using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace PawProiectVlad
{
	public partial class Form2 : Form
	{
		private List<Transporturi> transporturi = new List<Transporturi>();
		List<Ruta> rute = new List<Ruta>();
		List<Sofer> soferi = new List<Sofer>();
		List<Masina> masini = new List<Masina>();
		public Form2()
		{
			InitializeComponent();
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

			FileStream fs = new FileStream("transporturi.dat", FileMode.Open, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			if (new FileInfo("transporturi.dat").Length != 0)
				transporturi = (List<Transporturi>)bf.Deserialize(fs);
			fs.Close();

			fs = new FileStream("rute.dat", FileMode.OpenOrCreate, FileAccess.Read);
			bf = new BinaryFormatter();
			if (new FileInfo("rute.dat").Length != 0)
			{
				rute = (List<Ruta>)bf.Deserialize(fs);
				foreach (Ruta ruta in rute)
				{
					comboBox1.Items.Add(ruta.ToString());
				}
			}
			fs.Close();

			fs = new FileStream("soferi.dat", FileMode.OpenOrCreate, FileAccess.Read);
			bf = new BinaryFormatter();
			if (new FileInfo("soferi.dat").Length != 0)
			{
				soferi = (List<Sofer>)bf.Deserialize(fs);
				foreach (Sofer sofer in soferi)
				{
					checkedListBox1.Items.Add(sofer.ToString());
				}
			}
			fs.Close();

			fs = new FileStream("masini.dat", FileMode.OpenOrCreate, FileAccess.Read);
			bf = new BinaryFormatter();
			if (new FileInfo("masini.dat").Length != 0)
			{
				masini = (List<Masina>)bf.Deserialize(fs);
				foreach (Masina masina in masini)
				{
					checkedListBox2.Items.Add(masina.ToString());
				}
			}
			fs.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form3 form3 = new Form3();
			form3.Show();
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form4 form4 = new Form4();
			form4.Show();
			this.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Form5 form5 = new Form5();
			form5.Show();
			this.Close();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (comboBox1.Text == "")
			{
				errorProvider1.Clear();
				errorProvider1.SetError(comboBox1, "Selectati o ruta!");
			}
			else if (checkedListBox1.CheckedItems.Count == 0)
			{
				errorProvider1.Clear();
				errorProvider1.SetError(checkedListBox1, "Introdu cel putin un sofer!");
			}
			else if (checkedListBox2.CheckedItems.Count == 0)
			{
				errorProvider1.Clear();
				errorProvider1.SetError(checkedListBox2, "Introdu cel putin o masina!");
			}
			else if (dateTimePicker2.Value.Date.AddDays(1) < DateTime.Now)
			{
				errorProvider1.Clear();
				errorProvider1.SetError(dateTimePicker2, "Data de sfarsit nu poate fi in trecut!");
			}
			else if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
			{
				MessageBox.Show("Data de inceput nu poate fi inaintea datei de sfarsit!");
			}
			else if (checkedListBox1.CheckedItems.Count != checkedListBox2.CheckedItems.Count)
			{
				MessageBox.Show("Numarul de soferi trebuie sa fie egal cu numarul masinilor!");
			}
			else
			{

				string rString = (string)(comboBox1.Text);
				string[] rutaStrings = rString.Split(',');
				Ruta r = new Ruta(rutaStrings[0].Trim(), rutaStrings[1].Trim(), rutaStrings[2].Trim(), Double.Parse(rutaStrings[3].Trim()));

				List<Sofer> soferi = new List<Sofer>();
				foreach (String item in checkedListBox1.CheckedItems)
				{
					string[] soferStrings = item.Split(',');
					for (int i = 0; i < soferStrings.Length; i = i + 4)
					{
						Sofer s = new Sofer(soferStrings[i].Trim(), Int32.Parse(soferStrings[i + 1].Trim()), bool.Parse(soferStrings[i + 2].Trim()), soferStrings[i + 3].Trim());
						soferi.Add(s);
					}
				}

				List<Masina> masini = new List<Masina>();
				foreach (String item in checkedListBox2.CheckedItems)
				{
					string[] masinaStrings = item.Split(',');
					for (int i = 0; i < masinaStrings.Length; i = i + 4)
					{
						Masina m = new Masina(masinaStrings[i].Trim(), Int32.Parse(masinaStrings[i + 1].Trim()), char.Parse(masinaStrings[i + 2].Trim()), masinaStrings[i + 3].Trim());
						masini.Add(m);
					}
				}

				Transporturi t = new Transporturi(r, soferi, masini, dateTimePicker1.Value, dateTimePicker2.Value);
				transporturi.Add(t);
				FileStream fs = new FileStream("transporturi.dat", FileMode.Create, FileAccess.Write);
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(fs, transporturi);
				fs.Close();


				this.Close();
				Form1 form1 = new Form1();
				form1.Show();
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Close();
			new Form1().Show();
		}

		private void vizualizareRuteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
			new Form7(new ArrayList(rute)).Show();
		}

		private void vizualizareSoferiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
			new Form7(new ArrayList(soferi)).Show();
		}

		private void vizualizareMasiniToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
			new Form7(new ArrayList(masini)).Show();
		}
	}
}
