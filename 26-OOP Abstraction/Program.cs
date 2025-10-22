namespace _26_OOP_Abstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Bateri bateri1 = new Bateri("Marshall",  "Tam Profesyonel");
            Console.WriteLine(bateri1.BilgiVer());
            Console.WriteLine("Sesi " + bateri1.Cal() );

            Gitar gitar1 = new Gitar("Yamaha", "Profesyonel");
            Console.WriteLine(gitar1.BilgiVer());
            Console.WriteLine("Sesi " + gitar1.Cal());

            Muzisyen muzisyen1 = new Muzisyen("Fatih", "Alkan");
            muzisyen1.CaldigiEnsturman = gitar1;
            Muzisyen muzisyen2 = new Muzisyen("mert", "kahraman");
            muzisyen2.CaldigiEnsturman = gitar1;
            Muzisyen muzisyen3 = new Muzisyen("Redmi", "amator");
            muzisyen3.CaldigiEnsturman = bateri1;
            Muzisyen muzisyen4 = new Muzisyen("Baris", "amator");
            muzisyen4.CaldigiEnsturman = bateri1;

            MuzikGurubu muzikGurubu = new MuzikGurubu("Bilge calgicilar");
            
            muzikGurubu.Calgicilar.Add(muzisyen2);
            muzikGurubu.Calgicilar.Add(muzisyen3);
            muzikGurubu.Calgicilar.Add(muzisyen4);

            foreach (var item in muzikGurubu.Calgicilar)
            {
                Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(item.CaldigiEnsturman.BilgiVer());
                Console.WriteLine(item.CaldigiEnsturman.Cal());

            }

        }
    }
}