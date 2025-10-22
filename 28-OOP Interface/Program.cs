namespace _28_interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<IFutbolcu> Takim = new List<IFutbolcu>();
            Takim.Add(new Defans { Name = "Ahmet" });
            Takim.Add(new Defans { Name = "Veli" });
            Takim.Add(new Forvet { Name = "mehemt" });
             Takim.Add(new Kaleci { Name = "kemal" });

        }
    }
}