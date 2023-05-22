using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PawProiectVlad
{
	[Serializable]
	public class Transporturi : ICloneable, IComparable,IEnumerable
	{
		private Ruta ruta;
		private List<Sofer> soferi;
		private List<Masina> masini;
		private DateTime dataPlecare;
		private DateTime dataSosire;

		public Transporturi()
		{
			ruta = new Ruta();
			soferi = new List<Sofer>();
			masini = new List<Masina>();
			dataPlecare = DateTime.Now;
			dataSosire = DateTime.Now;
		}

		public Transporturi(Ruta r, List<Sofer> s,List<Masina> m, DateTime dataPlecare, DateTime dataSosire):this()
		{
			this.ruta = r;
			for(int i=0;i<s.Count;i++)
			{
				this.soferi.Add((Sofer)s[i].Clone());
			}
			for(int i=0;i<m.Count;i++)
			{
				this.masini.Add((Masina)m[i].Clone());
			}
			this.dataPlecare = dataPlecare;
			this.dataSosire = dataSosire;
		}

		~Transporturi()
		{
			Console.WriteLine("Destructor was called");
		}

		public DateTime DataPlecare { get => dataPlecare; set => dataPlecare = value; }
		public DateTime DataSosire { get => dataSosire; set => dataSosire = value; }
		internal Ruta Ruta { get => ruta; set => ruta = value; }
		internal List<Masina> Masini { get => masini; set => masini = value; }
		internal List<Sofer> Soferi { get => soferi; set => soferi = value; }

		public object Clone()
		{
			Transporturi clone = (Transporturi)this.MemberwiseClone();
			List<Masina> masiniNoi = new List<Masina>();
			for(int i=0;i<masini.Count;i++)
			{
				masiniNoi[i] = (Masina)masini[i].Clone();
			}
			clone.masini = masiniNoi;

			List<Sofer> soferiNoi= new List<Sofer>();
			for(int i=0;i<soferi.Count;i++)
			{
				soferiNoi[i] = (Sofer)soferi[i].Clone();
			}
			clone.soferi = soferiNoi;

			return clone;
		}

		public int CompareTo(object obj)
		{
			Transporturi t = (Transporturi)obj;
			if (this.dataPlecare > t.dataPlecare) return -1;
			else if (this.dataPlecare < t.dataPlecare) return 1;
			else return 0;
		}

		public IEnumerator GetEnumerator()
		{
			Tuple<Sofer, Masina>[] t = new Tuple<Sofer, Masina>[masini.Count];
			for(int i=0;i<masini.Count;i++)
			{
				t[i] = Tuple.Create(soferi[i], masini[i]);
			}
			return t.GetEnumerator();
		}

		public Tuple<Sofer,Masina> this[int index] 
		{
			get
			{
				if (index >= 0 && index < masini.Count)
				{
					return Tuple.Create(soferi[index],masini[index]);
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (index >= 0 && index < masini.Count)
				{
					soferi[index]= value.Item1;
					masini[index] = value.Item2;
				}
			}
		}

		public override string ToString()
		{
			string s = "Ruta: "+ruta.ToString() +Environment.NewLine+ ", Soferi: ";
			for(int i=0;i<soferi.Count;i++)
			{
				s += soferi[i].ToString() + ",";
			}
			s +=Environment.NewLine + " Masini: ";
			for(int i=0;i<masini.Count;i++)
			{
				s += masini[i].ToString() + ",";
			}
			return s + Environment.NewLine+"Data plecare: "+ dataPlecare.ToString() 
				+ Environment.NewLine +"Data sosire: "+ dataSosire.ToString() + ",";
		}

		public int getElapsedTime()
		{
			int durata = (int)(this.DataSosire - this.DataPlecare).TotalMinutes;
			return durata;
		}

	}
}
