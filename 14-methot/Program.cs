internal class Program
{
    //az eksik var
    private static void Main(string[] args)
    {


        SelamVer("Fatih");
        SelamVer("Fatih");
        SelamVer("Fatih");
       // int karesi = Topla(5, 2) * 2;
        LogMessage("default log");
        LogMessage("default log","error");
        LogMessage(message: "asdas", status: "asdass");
        DisplayUserInfo("Veli");


    }
    //[Erisim Belirleyici] [Niteleyici] [Geri Donus Tipi] [ metot adi] (parametleri)
    //
    //{Method govdesi}
    //
    
    //defult value private method

    
 

    private static void SelamVer(String ad)
    {
        Console.WriteLine("Selam Ver"+ad);
    }

    //static int Topla(int sayi1,int sayi2)
    //{
    //    try {
    //        return sayi1 + sayi2;
    //    }catch(Exception e)
    //    {
    //        Console.WriteLine(e);
    //        return 0;
    //    }
       
    //}
    public static void LogMessage(string message, string logLevel = " Info",string status = "1")
    {
        Console.WriteLine(message + logLevel);
    }

    public static void DisplayUserInfo(string name , int? age = null)
    {
        if(age != null)
        {
            Console.WriteLine($"{name} is {age} years old");
        }
        else
        {
            Console.WriteLine($"{name} did not have age");
        }
    }


    #region MethodOverloading
    //method imzasi parametlerdir

    public int Topla(int sayi1,int sayi2)
    {
        return sayi1 + sayi2;

    }
  
    public int Topla(int sayi1, int sayi2, int sayi3)
    {
        return sayi1 + sayi2 + sayi3;

    }
    public int Topla(int sayi1, int sayi2, int sayi3, int sayi4)
    {
        return sayi1 + sayi2 + sayi3 + sayi4;

    }

    #endregion

}