using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawProiectVlad
{
	[Serializable]
	public class Ruta : ICloneable,IComparable
	{
		private string numeRuta;
		private string punctPlecare;
		private string punctSosire;
		private double distanta;


		public Ruta()
		{
			numeRuta = string.Empty;
			punctPlecare = string.Empty;
			punctSosire = string.Empty;
			distanta = 0;
		}

		public Ruta(string numeRuta, string punctPlecare, string punctSosire, double distanta)
		{
			this.numeRuta = numeRuta ?? throw new ArgumentNullException(nameof(numeRuta));
			this.punctPlecare = punctPlecare ?? throw new ArgumentNullException(nameof(punctPlecare));
			this.punctSosire = punctSosire ?? throw new ArgumentNullException(nameof(punctSosire));
			this.distanta = distanta;
		}

		~Ruta()
		{
			Console.WriteLine("Destructor was called");
		}

		public string NumeRuta { get => numeRuta; set => numeRuta = value; }
		public string PunctPlecare { get => punctPlecare; set => punctPlecare = value; }
		public string PunctSosire { get => punctSosire; set => punctSosire = value; }
		public double Distanta { get => distanta; set => distanta = value; }

		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public int CompareTo(object obj)
		{
			Ruta r = (Ruta)obj;
			if (this.distanta > r.distanta) {return -1;}
			else if(this.distanta>r.distanta) { return 1;}
			else { return 0; }
		}

		public override string ToString()
		{
			return numeRuta+","+punctPlecare + "," + punctSosire + ","+distanta;
		}

		public static double operator+(Ruta r1,Ruta r2)
		{
			double distanta;
			distanta = r1.distanta + r2.distanta;
			return distanta;
		}
	}
}
