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
	public partial class View : UserControl
	{
		public View(ArrayList _list)
		{
			InitializeComponent();
			foreach(var item in _list)
			{
				listView1.Items.Add(item.ToString());
			}
		}
	}
}
