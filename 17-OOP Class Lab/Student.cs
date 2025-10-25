using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_OOP_Class_Lab
{
	internal class Student
	//Filled = dışarıdan doğrudan erişilmez
	{ //propfull tab tab
		private int _id;
		private string _lastName;
		private string _firstName;
		private String _department;
		private ICollection<int> _examScores;

		//Constractor
		//ctor tab tab 
		public Student(int id, string firstName, string lastName)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			_examScores = new List<int>();
		}


		//Rad-Write
		public String Department
		{
			get;
			set;
		}


		public string FirstName
		{
			get { return _firstName; }
			private set { _firstName = value; }
		}



		public string LastName
		{
			get { return _lastName; }
			private set { _lastName = value; }
		}

		//Read only
		public int Id
		{
			get { return _id; }
			private set { _id = value; }

		}
		public string FullName => _firstName + " " + _lastName;

		//prop tab tab

		//public List<int> ExtraScores { get; set; } = new List<int>();//
		//    public ICollection<int> ExtraScores { get; set; } = new List<int>()//HashSet

		public double AverageScore => _examScores.Count == 0 ? 0 : _examScores.Average();

		public void AddExamScore(int score)
		{
			if (score < 0 || score > 100)
				throw new ArgumentException("Not 0 ile 100 arasindadir");


			_examScores.Add(score);
		}
		public IReadOnlyList<int> GetexamScores()
		{
			return _examScores.ToList().AsReadOnly();
		}
		public string DisplayInfo()
		{
			return $" Id: {Id} | Ad:  {FullName} Bolum: {Department} Not ortalamasi:  {AverageScore} Notlar {string.Join(" ,",_examScores)}";
		}


    }
}
