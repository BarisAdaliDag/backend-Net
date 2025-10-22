namespace _19_Extension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string selam = "hello World";
            Console.WriteLine(selam.ReverseString());


            //Metnin ilk Harfini Buyuten bir extension
            Console.WriteLine(selam.CapitilizeString());


            try
            {
                int x = int.Parse(selam);
            }catch(Exception e) { 
            //...}
        }
    }
}