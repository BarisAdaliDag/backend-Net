namespace yy_deneme1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new AracRepository();

            var oto = new Otomobil("34ABC123", "Toyota", "Corolla", 2023, 800, 5);
            repo.Ekle(oto);
            oto.Kirala("Ali");

            Console.WriteLine(oto.KiraBilgisi());
            //Console.WriteLine($"Toplam Gelir: {repo.ToplamGunlukGelir()} TL");
        }
    }
}
