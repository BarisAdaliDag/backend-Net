namespace _18_OOP_Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Static, bir sınıfın, metodun, alanın veya üyenin yalnızca bir örneği olduğunu belirtmek için kullanılan özel bir anahtar kelimedir. Kısaca static nesnenin değil direk sınıfın yani şablonun bir parçasıdır.

            double alan = MathHelper.CalculateCircleArea(15);
            Console.WriteLine(alan);

            string original = "Hello";
            string encrypted = EncryptionHelper.Encrypt(original);

            Console.WriteLine("Original: " + original);
            Console.WriteLine("Encrypted: " + encrypted);
            Console.WriteLine("Decrypted: " + EncryptionHelper.Decrypt(encrypted));

            User user1 = new User() { Id = 1, Name = "Fatih" };
            Console.WriteLine(user1.Id);
            Console.WriteLine("Total User: " + User.TotalUsers);

            User user2 = new User();
            Console.WriteLine(user2.Id);
            Console.WriteLine("Total User: " + User.TotalUsers);


            Console.WriteLine(Ornek.dege1);
            Console.WriteLine(Ornek.dege2);

        }

        public static class Ornek
        {
            public static int dege1;
            public static int dege2 = 10;
            static Ornek()
            {
                dege1 = 10;
                Console.WriteLine("Static const çalıştı");
            }
        }
    }
}

