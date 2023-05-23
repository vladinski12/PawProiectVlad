using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawProiectVlad
{
	public partial class Form6 : Form
	{
		private List<Transporturi> t;
		public Form6(List<Transporturi> _t)
		{
			InitializeComponent();
			t = _t;
		}


		private string dataFormat(int x)
		{
			TimeSpan duration = TimeSpan.FromMinutes(x);
			int days = duration.Days;
			int hours = duration.Hours;
			int minutes = duration.Minutes;
			string durationString = "";
			if (days > 0)
			{
				durationString += days + " d";
				durationString += " ";
			}

			if (hours > 0)
			{
				durationString += hours + " h";
				durationString += " ";
			}

			durationString += minutes + " m";
			return durationString.ToString();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			int[] data = t.Select(obj => obj.getElapsedTime()).Where(x => x != 0).ToArray();
			float total = data.Sum();
			float startAngle = 0;
			float sweepAngle;
			Graphics g = e.Graphics;
			Rectangle rect = panel1.ClientRectangle;
			float cx = rect.Width / 2f;
			float cy = rect.Height / 2f;
			float radius = Math.Min(cx, cy) * 0.8f;
			Brush[] brushes = { Brushes.Red, Brushes.Blue, Brushes.Green, Brushes.Orange, Brushes.Purple, Brushes.Magenta, Brushes.Yellow };
			Font font = new Font("Arial", 12f, FontStyle.Bold);

			for (int i = 0; i < data.Length; i++)
			{
				sweepAngle = data[i] / total * 360f;
				g.FillPie(brushes[i % brushes.Length], cx - radius, cy - radius, radius * 2, radius * 2, startAngle, sweepAngle);
				startAngle += sweepAngle;
			}

			for (int i = 0; i < data.Length; i++)
			{
				sweepAngle = data[i] / total * 360f;
				float midAngle = startAngle + sweepAngle / 2f;
				float labelX = cx + (radius / 2f) * (float)Math.Cos(midAngle * Math.PI / 180f);
				float labelY = cy + (radius / 2f) * (float)Math.Sin(midAngle * Math.PI / 180f);
				string labelText = dataFormat(data[i]);
				SizeF labelSize = g.MeasureString(labelText, font);
				g.DrawString(labelText, font, Brushes.Black, labelX - labelSize.Width / 2f, labelY - labelSize.Height / 2f);
				startAngle += sweepAngle;
			}
		}

		private void pd_print(object sender, PrintPageEventArgs e)
		{
			int[] data = t.Select(obj => obj.getElapsedTime()).Where(x => x != 0).ToArray();
			float total = data.Sum();
			float startAngle = 0;
			float sweepAngle;
			Graphics g = e.Graphics;
			Rectangle rect = panel1.ClientRectangle;
			float cx = rect.Width / 2f;
			float cy = rect.Height / 2f;
			float radius = Math.Min(cx, cy) * 0.8f;
			Brush[] brushes = { Brushes.Red, Brushes.Blue, Brushes.Green, Brushes.Orange, Brushes.Purple, Brushes.Magenta, Brushes.Yellow };
			Font font = new Font("Arial", 12f, FontStyle.Bold);

			for (int i = 0; i < data.Length; i++)
			{
				sweepAngle = data[i] / total * 360f;
				g.FillPie(brushes[i % brushes.Length], cx - radius, cy - radius, radius * 2, radius * 2, startAngle, sweepAngle);
				startAngle += sweepAngle;
			}

			for (int i = 0; i < data.Length; i++)
			{
				sweepAngle = data[i] / total * 360f;
				float midAngle = startAngle + sweepAngle / 2f;
				float labelX = cx + (radius / 2f) * (float)Math.Cos(midAngle * Math.PI / 180f);
				float labelY = cy + (radius / 2f) * (float)Math.Sin(midAngle * Math.PI / 180f);
				string labelText = dataFormat(data[i]);
				SizeF labelSize = g.MeasureString(labelText, font);
				g.DrawString(labelText, font, Brushes.Black, labelX - labelSize.Width / 2f, labelY - labelSize.Height / 2f);
				startAngle += sweepAngle;
			}
		}

		private void printToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PrintDocument pd = new PrintDocument();
			pd.PrintPage += new PrintPageEventHandler(pd_print);
			PrintPreviewDialog dlg = new PrintPreviewDialog();
			dlg.Document = pd;
			dlg.ShowDialog();
		}

		private void panel1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop) && ((string[])e.Data.GetData(DataFormats.FileDrop)).Length == 1)
			{
				string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
				string extension = Path.GetExtension(file).ToLower();
				if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
				{
					e.Effect = DragDropEffects.Copy;
				}
			}
		}

		private Image ResizeImage(Image image, Size size)
		{
			float ratio = Math.Min((float)size.Width / image.Width, (float)size.Height / image.Height);
			int width = (int)(image.Width * ratio);
			int height = (int)(image.Height * ratio);
			Bitmap bitmap = new Bitmap(width, height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.DrawImage(image, 0, 0, width, height);
			}
			return bitmap;
		}

		private void panel1_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files != null && files.Length == 1)
			{
				string file = files[0];
				string extension = Path.GetExtension(file).ToLower();
				if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
				{
					PictureBox pictureBox = new PictureBox();
					pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
					pictureBox.Dock = DockStyle.Fill;
					Image image = Image.FromFile(file);
					pictureBox.Image = ResizeImage(image, panel1.ClientSize);
					panel1.Controls.Clear();
					panel1.Controls.Add(pictureBox);
				}
			}
		}

		private void panel1_DragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void inapoiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new Form1().Show();
			this.Hide();
		}
	}
}
