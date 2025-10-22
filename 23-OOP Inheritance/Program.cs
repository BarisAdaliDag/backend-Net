namespace _23_OOP_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Inharitance (Kalıtım Alma veya Miras alma): Var olan kodun yenıden kullanabılırlığini arttırmak ve
            //yazılımın bakımını kolaylaştırmak amacıyla kullanılan güçlü bir kavramdır.


            //Parent, Super, Base class bu classlardan davranış ve
            //özellık bakımından kalıtım aldığınız sınıflara ıse child veya subclass gibi...

            Phone phone1 = new Phone("snoy");
            Console.WriteLine(phone1.GetInfo());
            Console.WriteLine(phone1.ToString());//override edildi
            Console.WriteLine(phone1);
            Console.WriteLine(phone1.Call());
            //MobilPhone phone2 = new MobilPhone();
            //phone2.Call();
            Console.WriteLine("***************************");
            MobilPhone phone2 = new MobilPhone("Nokia");
            phone2.HasCamera = true;
            phone2.IsTouched = true;
            Console.WriteLine(phone2);//tostring override yapildi
            Console.WriteLine(phone2.Call());

            Console.WriteLine("***************************");
            SmartPhone phone3 = new SmartPhone("Apple");
            phone3.HasCamera = true;
            phone3.IsTouched = true;
            phone3.FrontCam = true;
            Console.WriteLine(phone3.GetInfo());
            Console.WriteLine(phone3.Call());
            Console.WriteLine(phone3.TakePhoto());




        }
    }
}