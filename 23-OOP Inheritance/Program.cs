namespace _23_OOP_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Inheritance (Kalıtım Alma veya Miras Alma): Var olan kodun yeniden kullanıbilirliğini artırmak ve yazılımın bakımını kolaylaştırmak amacıyla kullanılan güçlü bir kavramdır. 

            //Parent, Super, Base Class bu klaslardan davranış ve özellik bakımından kalıtım aldığımız sınıflara ise Child veya subclass gibi...

            Phone phone1 = new Phone("AEG");
            Console.WriteLine(phone1);
            Console.WriteLine(phone1.Call());

            Console.WriteLine("\n" + new string('*', 20) + "\n");

            MobilPhone phone2 = new MobilPhone("Nokia");
            phone2.HasCamera = true;
            phone2.IsTouched = true;
            Console.WriteLine(phone2);
            Console.WriteLine(phone2.Call());
            Console.WriteLine(phone2.TakePhoto());

            Console.WriteLine("\n" + new string('*', 20) + "\n");

            SmartPhone phone3 = new SmartPhone("Apple");
            phone3.HasCamera = true;
            phone3.IsTouched = true;
            phone3.FrontCam = true;
            Console.WriteLine(phone3);
            Console.WriteLine(phone3.Call());
            Console.WriteLine(phone3.DoVideoCall());


        }
    }
}
