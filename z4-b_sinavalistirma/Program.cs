using SinavAlistirma.DataAccess;
using SinavAlistirma.Models;

namespace SinavAlistirma
{
    // IBaseEntity,BaseEntity,Member,Author,Post,Category,Comment
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerDal customerDal = new CustomerDal();
            for (int i = 0; i < 3; i++)
            {
                Customer customer = new();
                Console.Write("Ad : ");
                customer.FirstName = Console.ReadLine() ?? "";
                Console.Write("Soyad : ");
                customer.LastName = Console.ReadLine() ?? "";
                Console.Write("Dogum Tarihi : ");
                customer.BirthDate = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Adres : ");
                customer.Address = Console.ReadLine();
                Console.Write("Email : ");
                customer.Email = Console.ReadLine() ?? "";
                Console.WriteLine("Username : ");
                customer.Username = Console.ReadLine() ?? "";
                Console.Write("Password : ");
                customer.Password = Console.ReadLine() ?? "";
                Console.Write("PhoneNumber : ");
                customer.PhoneNumber = Console.ReadLine() ?? "";

                customerDal.Create(customer);

                Console.Clear();
            }

            Console.WriteLine("Musteriler...");
            List<Customer> customers = customerDal.GetAll();

            foreach (Customer customer in customers)
                Console.WriteLine(customer);

            Console.WriteLine("_______________________________________");
            Console.WriteLine("Uzerinde islem yapmak istenen id");
            Guid guid = Guid.Parse(Console.ReadLine() ?? "");
            Console.WriteLine("Bu veri uzerinde hangi islemi yapmak istiyorsunu...");
            Console.WriteLine("1- Guncelleme\n2-Silme");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Customer? customerToUpdate = customerDal.Get(guid);
                    Console.Write("Ad : ");
                    customerToUpdate.FirstName = Console.ReadLine() ?? customerToUpdate.FirstName;
                    Console.Write("Soyad : ");
                    customerToUpdate.LastName = Console.ReadLine() ?? customerToUpdate.LastName;
                    Console.Write("Dogum Tarihi : ");
                    string birthDateInput = Console.ReadLine() ?? "";
                    if (!string.IsNullOrEmpty(birthDateInput))
                        customerToUpdate.BirthDate = Convert.ToDateTime(birthDateInput);
                    Console.Write("Adres : ");
                    customerToUpdate.Address = Console.ReadLine() ?? customerToUpdate.Address;
                    Console.Write("Email : ");
                    customerToUpdate.Email = Console.ReadLine() ?? customerToUpdate.Email;
                    Console.WriteLine("Username : ");
                    customerToUpdate.Username = Console.ReadLine() ?? customerToUpdate.Username;
                    Console.Write("Password : ");
                    customerToUpdate.Password = Console.ReadLine() ?? customerToUpdate.Password;
                    Console.Write("PhoneNumber : ");
                    customerToUpdate.PhoneNumber = Console.ReadLine() ?? customerToUpdate.PhoneNumber;

                    customerDal.Update(customerToUpdate);
                    break;
                    case 2:
                    customerDal.HardDelete(guid);
                    break;
                default:
                    Console.WriteLine("Boyle secimmi var :D");
                    break;
            }

            Console.Clear();
            Console.WriteLine("Guncel Musteriler...");
            customerDal.GetAll().ForEach(item =>
            {
                Console.WriteLine(item);
            });
        }
    }
}
