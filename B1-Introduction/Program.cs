internal class Program
{
    private static void Main(string[] args)
    {
        #region MyRegion

        #endregion



        //#region Ex1
        //Console.WriteLine("Console  Tek Cift Kontrolu . Tek ise treu donecek");
        //Console.WriteLine("Bir Rakam Giriniz.");
        //int sayi = Convert.ToInt32(Console.ReadLine());
        //bool isOdd = sayi % 2 == 1;
        //Console.WriteLine("Sayi tek = " + isOdd);
        //#endregion

        //#region Ex2
        //float number = 10f;
        //Console.WriteLine($" {number} buyuk sayi giriniz");
        //float sayi2 = float.Parse(Console.ReadLine());
        //bool buyukMu = sayi2>number;
        //Console.WriteLine(buyukMu);
        //#endregion

        //#region Ex3
        ////0-100 arasi sayi
        //Console.WriteLine("Bir sayi giriniz");
        //int sayi3 = Convert.ToInt32(Console.ReadLine());
        //bool isBetweenHunderedAndZero = sayi3 > 0 && sayi3 < 100;
        //Console.WriteLine(isBetweenHunderedAndZero);

        //#endregion

        //#region Ex4
        ////iki soru cozu
        //int number4 = 10,number5= 20;
        //Console.WriteLine(number4);
        //Console.WriteLine(" ilk 10 ikinci 20 .ilk sayi buyuk mu? Dogru ise true yanlis ise false yazin");

        //bool cevap = Convert.ToBoolean(Console.ReadLine());
        //bool sonuc = cevap == (number4 > number5);
        //Console.WriteLine(sonuc);

        //#endregion

        #region Ex5
        //5 karakteli harf iste 5 harfli olduguna bak
        Console.WriteLine("Yazi girin");
        string str1= Console.ReadLine();
        bool result1 = str1.Length == 5;
        Console.WriteLine(result1);

        #endregion


    }
}