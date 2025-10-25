namespace _21_Struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Struct, value tipli veri türü tanımlama.

            Color color = new Color();
            color.Red = 255;
            color.Green = 245;
            color.Blue = 70;

            color.GetColor();

            List<Product> products = new List<Product>()
            {
                new Product("Kalem", new Currency(150)),
                new Product("Defter", new Currency(250)),
                new Product("Kitap", new Currency(250, "$")),
            };

            foreach (var item in products)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine(item.Id + " - " + item.Name + " - " + item.Price.GetCurrency());
            }
        }
    }
}
