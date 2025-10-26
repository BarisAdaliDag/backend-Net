namespace _25_OOP_Inheritance_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ogrenci Otomasyon Sistemi
            /*
             ogrenci => Ogrenci(No,Notlar(List<int>),Ortalama Hesaplama)
            ogretmen => Bransi,DeneyimYili,
            yonetici => Role, Yonettigi kisiler


            id (Otomatik Ogrencilar=100,Ogretmenler =300,Yoneticiler = 600) ,Ad Soyad,Email ToString
            
            Console Ui (listeleme ve ekleme)
             
             */

            Student student1 = new Student("Baris", "Adali", "aa@gmail.com", new List<int> { 100, 50, 40 } ,no:10);
            Console.WriteLine("");
            Console.WriteLine(student1);
            
            Student student2 = new Student("mehmet", "Dag", "aa@gmail.com", new List<int> { 100, 50, 40 },no:20);
            Console.WriteLine(student2);

            Console.WriteLine(student2.AvgNotes(new List<int> { 100, 50, 40 }));

            Teacher teacher = new Teacher("ahmet", "adiguzel", "@", 23, "tarih");
            Console.WriteLine(teacher);

           // Manager manager = Manager(){ };



        }
    }
}