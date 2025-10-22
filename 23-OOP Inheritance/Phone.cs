using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_OOP_Inheritance
{
    public class Phone
    {
		private string _brand;
		protected string _connectionType = "Kablolu Baglanti";

        public Phone(string brand)
        {
            _brand = brand;
        }
		public Phone() {
			Console.WriteLine("Base class Parametresiz");
		}

        public string ConnectionType
		{
			get { return _connectionType; }
			set { _connectionType = value; }
		}


		public string Brand
		{
			get { return _brand; }
		 private	set { _brand = value; }
		}

		//Polymorphisim (Çok biçimlilik);Metodun davraşını değiştirme
          virtual public string Call()
		{
			return "Arama gerceklestiriyor .... Did did did";

		}
		public string GetInfo()
		{
			return $"Marka : {Brand} ,Bağlantı{ConnectionType}";
		}
        public override string ToString()
        {
            return $"Marka : {Brand} ,Bağlantı{ConnectionType}";
        }

    }
}
