using Z4_OOP_Sinav_Alistirma.DataAcccess;
using Z4_OOP_Sinav_Alistirma.Models;

namespace Z4_OOP_Sinav_Alistirma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerDal customerDal = new CustomerDal();
            for (int i = 0; i<2; i++) {
               
                Customer customer = new Customer();
                Console.Write("Ad  : ");
                customer.FirstName = Console.ReadLine() ?? "";
                Console.Write("SoyAd  : ");
                customer.LastName = Console.ReadLine() ?? "";
                Console.Write("Dogum Tarihi  : ");
                customer.BirthDate = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Adres   : ");
                customer.Adress = Console.ReadLine() ?? "";
                Console.Write("Email  : ");
                customer.Email = Console.ReadLine() ?? "";
                Console.Write("UserName  : ");
                customer.Username = Console.ReadLine() ?? "";
                Console.Write("PhoneNumber  : ");
                customer.PhoneNumber = Console.ReadLine() ?? "";

         ;

                customerDal.Create(customer);
                Console.Clear();
            }
            Console.WriteLine("Musteriler");

            List<Customer> customers = customerDal.GetAll();
            foreach( Customer customer in customers)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine(  "---------------------------------------------------------------");
            Console.WriteLine("Uzerinde islem yapmak istenen id");
            Guid guid = Guid.Parse(Console.ReadLine());
            Console.WriteLine("Islem Yap");
            Console.WriteLine(" 1- guncellle 2- Silme");

            int secim = Convert.ToInt32(Console.ReadLine());

            switch (secim) {

                case 1:


                    Customer customerToUpdate = customerDal.Get(guid);
                    Console.Write("Ad  : ");
                    customerToUpdate.FirstName = Console.ReadLine() ?? "";
                    Console.Write("SoyAd  : ");
                    customerToUpdate.LastName = Console.ReadLine() ?? "";
                    Console.Write("Dogum Tarihi  : ");
                    customerToUpdate.BirthDate = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Adres   : ");
                    customerToUpdate.Adress = Console.ReadLine() ?? "";
                    Console.Write("Email  : ");
                    customerToUpdate.Email = Console.ReadLine() ?? "";
                    Console.Write("UserName  : ");
                    customerToUpdate.Username = Console.ReadLine() ?? "";
                    Console.Write("PhoneNumber  : ");
                    customerToUpdate.PhoneNumber = Console.ReadLine() ?? "";
                    customerDal.Update(customerToUpdate);
                    break;

                case 2:
                    customerDal.HardDelete(guid);
                    break;
                default:
                    Console.WriteLine("boyle bir islem mi var");
                    break;

                   

            }
            Console.WriteLine("\nGincel Musteriler\n");
            customerDal.GetAll().ForEach(x => Console.WriteLine(x));





        }
    }
}