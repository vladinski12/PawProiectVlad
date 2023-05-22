using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PawProiectVlad
{
	public partial class Form1 : Form
	{
		private List<Transporturi> t = new List<Transporturi>();

		private DataTable dt= new DataTable();

		string connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = FirmaTransporturi.accdb";
		public Form1()
		{
			InitializeComponent();
			dt.Columns.Add("Ruta");
			dt.Columns.Add("Soferi");
			dt.Columns.Add("Masini");
			dt.Columns.Add("DataPlecare");
			dt.Columns.Add("DataSosire");
			FileStream fs = new FileStream("transporturi.dat", FileMode.OpenOrCreate, FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter();
			if (fs.Length > 0)
			{
				t = (List<Transporturi>)bf.Deserialize(fs);
				foreach (Transporturi transport in t)
				{
					DataRow newRow = dt.Rows.Add();

					// Set the value of the first cell in the new row
					newRow[0] = transport.Ruta.ToString();
					foreach (Sofer sofer in transport.Soferi)
					{
						newRow[1] += sofer.ToString() + Environment.NewLine;
					}
					foreach (Masina masina in transport.Masini)
					{
						newRow[2] += masina.ToString() + Environment.NewLine;
					}
					newRow[3] = transport.DataPlecare.ToString();
					newRow[4] = transport.DataSosire.ToString();

				}
				dataGridView1.DataSource = dt;
			}
			fs.Close();
		}

		private void adaugaTransportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
			form2.Show();
			this.Hide();
		}

		private void graficToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (t.Count >= 2)
			{
				Form6 form6 = new Form6(t);
				form6.Show();
				this.Hide();
			}
			else MessageBox.Show("Ai nevoie de cel putin 2 tranporturi ca sa poti vizualiza graficul");
		}

		private void incarcaDateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OleDbConnection conexiune = new OleDbConnection(connString);
			try
			{
				conexiune.Open();
				OleDbCommand comanda = new OleDbCommand();
				comanda.CommandText = "Select * from Transporturi";
				comanda.Connection = conexiune;
				OleDbDataReader reader = comanda.ExecuteReader();
				while (reader.Read())
				{
					DataRow row = dt.Rows.Add();
					row[0] = reader["Rute"].ToString();
					row[1] = reader["Soferi"].ToString();
					row[2] = reader["Masini"].ToString();
					row[3] = reader["Data Plecare"].ToString();
					row[4] = reader["Data Sosire"].ToString();
				}
				dataGridView1.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally { conexiune.Close(); }

		}

		private void exportaDateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OleDbConnection conexiune = new OleDbConnection(connString);
			try
			{
				conexiune.Open();
				OleDbCommand comanda = new OleDbCommand();
				comanda.Connection = conexiune;
				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					comanda.CommandText = String.Format("INSERT INTO Transporturi (Rute, Soferi, Masini, [Data Plecare], [Data Sosire]) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
						row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value);
					comanda.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				conexiune.Close();
				MessageBox.Show("Date Exportate!");
			}
		}
	}
}
