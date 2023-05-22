using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawProiectVlad
{
	[Serializable]
	public class Sofer : ICloneable, IComparable
	{
		private string numeSofer;
		private int varsta;
		private bool experimentat;
		private string locatieCurenta;

		public Sofer()
		{
			this.NumeSofer = string.Empty;
			this.varsta = 0;
			this.experimentat = false;
			this.locatieCurenta = string.Empty;
		}

		public Sofer(string numeSofer, int varsta, bool experimentat, string locatieCurenta)
		{
			this.numeSofer = numeSofer ?? throw new ArgumentNullException(nameof(numeSofer));
			this.varsta = varsta;
			this.experimentat = experimentat;
			this.locatieCurenta = locatieCurenta ?? throw new ArgumentNullException(nameof(locatieCurenta));
		}

		~Sofer()
		{
			Console.WriteLine("Destructor was called");
		}

		public string NumeSofer { get => numeSofer; set => numeSofer = value; }
		public int Varsta { get => varsta; set => varsta = value; }
		public bool Experimentat { get => experimentat; set => experimentat = value; }
		public string LocatieCurenta { get => locatieCurenta; set => locatieCurenta = value; }

		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public int CompareTo(object obj)
		{
			Sofer s = (Sofer)obj;
			if (this.experimentat && !s.experimentat) return 1;
			else if (!this.experimentat && s.experimentat) return -1;
			else return 0;
		}

		public static int operator -(Sofer s1, Sofer s2)
		{
			return s1.varsta - s2.varsta;
		}

		public static explicit operator int(Sofer s)
		{
			return s.varsta;
		}

		public override string ToString()
		{
			return this.numeSofer + "," + this.varsta + "," + this.experimentat + "," + this.locatieCurenta;
		}
	}
}
