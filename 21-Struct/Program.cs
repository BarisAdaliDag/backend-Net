namespace _21_Struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Struct value tipli veri turu tanimlama class

            Color color = new Color();
            color.Red = 255;
            color.Green = 0;
            color.Blue = 0;


            color.GetColor();

            List<Product> products = new List<Product>()
            { new Product("Kalem",new Currency(150),new Product("silgi",new Currency(100),new Product("Defter",new Currency(250),






            };

        }
    }
}