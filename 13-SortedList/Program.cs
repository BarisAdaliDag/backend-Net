internal class Program
{
    private static void Main(string[] args)
    {
      // Sorted List, key-valur ciftlerine gore sirali bir sekilde data saklar

        //Key anahtalari benzersiz olmasi gerekir hata verir
      SortedList<int,string> sinif= new SortedList<int,string>();
        sinif.Add(3, "Ali");
        sinif.Add(1, "Veli");
        sinif.Add(4, "Ayse");
        sinif.Add(5, "Zeynep");
        
        foreach (var item in sinif)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }

        //HashSet, ozellikle benzersiz elemanlar tutmak istediginiz zaman kullanilir.
        //ayni data olunca eklemiyor hata dondermez

        HashSet<string> emailSet = new HashSet<string>();
        emailSet.Add("email@gmail.com");
        emailSet.Add("email1@gmail.com");
        emailSet.Add("email2@gmail.com");
        emailSet.Add("email@gmail.com");

        foreach (var item in emailSet)
        {
            Console.WriteLine(item);
        }


    }
}