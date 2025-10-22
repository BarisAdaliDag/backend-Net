using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_OOP_Inheritance_Lab
{
    internal class Student : Person
    {
        public static int Id = 100;
        private int _no;
        private List<int> _notlar = new List<int>();// new List<int>() referansi olustur

        public List<int> Notlar
        {
            get { return _notlar; }
            set { _notlar = value; }
        }


        public int No
        {
            get { return _no; }
            set { _no = value; }
        }

        public Student( string firstName, string lastName, string email,List<int> notlar,int no) : base( firstName, lastName, email)
        {
          Id = ++Id;
            _notlar = notlar;
            No = no;
        }

        public double AvgNotes(List<int> _notlar)
        {
            //double toplam = 0;
            //double sonuc = 0;
            // foreach (int n in _notlar)
            //{
            //    toplam += n;
            //}
            //sonuc = toplam / _notlar.Count;
            //return sonuc.ToString("0.00"); ;
            return Notlar.Count() == 0 ? 0 : Notlar.Average();


        }
        public void AddGrade(int score) {
            Notlar.Add(score);

        }

        public override string ToString()
        {
            return    $"Id = {Id} No ={No} " + base.ToString();
        }
    }
}
