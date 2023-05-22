using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawProiectVlad
{
	[Serializable]
	public class Masina : ICloneable, IComparable
	{
		private string numeMasina;
		private int capacitate;
		private char tipMasina;
		private string locatieCurenta;

		public Masina()
		{
			numeMasina = string.Empty;
			capacitate = 0;
			tipMasina = ' ';
			locatieCurenta = string.Empty;
		}

		public Masina(string numeMasina, int capacitate, char tipMasina, string locatieCurenta)
		{
			this.numeMasina = numeMasina ?? throw new ArgumentNullException(nameof(numeMasina));
			this.capacitate = capacitate;
			this.tipMasina = tipMasina;
			this.locatieCurenta = locatieCurenta ?? throw new ArgumentNullException(nameof(locatieCurenta));
		}
		~Masina()
		{
			Console.WriteLine("Destructor was called");
		}

		public string NumeMasina { get => numeMasina; set => numeMasina = value; }
		public int Capacitate { get => capacitate; set => capacitate = value; }
		public char TipMasina { get => tipMasina; set => tipMasina = value; }
		public string LocatieCurenta { get => locatieCurenta; set => locatieCurenta = value; }

		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public int CompareTo(object obj)
		{
			Masina m=(Masina)obj;
			if(this.capacitate>m.capacitate){return -1;}
			else if(this.capacitate<m.capacitate){return 1;}
			else{return 0;}
		}


		public static bool operator ==(Masina m1, Masina m2)
		{
			if(m1.numeMasina==m2.numeMasina && m1.capacitate==m2.capacitate && m1.tipMasina==m2.tipMasina && m1.locatieCurenta==m2.locatieCurenta)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool operator !=(Masina m1, Masina m2)
		{
			if(m1.numeMasina==m2.numeMasina && m1.capacitate==m2.capacitate && m1.tipMasina==m2.tipMasina && m1.locatieCurenta==m2.locatieCurenta)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public override string ToString()
		{
			return numeMasina + "," + capacitate + "," + tipMasina + "," + locatieCurenta;
		}
	}
}
