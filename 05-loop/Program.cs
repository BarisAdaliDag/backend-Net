internal class Program
{
    private static void Main(string[] args)
    {

        #region ForDongusu

        for(int i = 0; i<5; i++)
        {
            Console.WriteLine(i);
        }

        //for(; ; )
        //{
        //    //sonuz dongu
        //}
        #endregion

        #region While

        int sayac = 0;
        while(sayac < 5)
        {
            Console.WriteLine(sayac);
            sayac++;
        }
        #endregion
        #region Do While

        string sifre;

        //do 
        //{
        //    Console.WriteLine("sifre giriniz");
        //    sifre = Console.ReadLine();

        //}while (sifre != "1234");
        #endregion

        #region Jump
        for (int i=0; i<5; i++) {
            if (i == 5)
                break; // dongunun disina cikarak akisi bir sonraki ifadeye yonlendirir.

            if (i == 2)
                continue; //  Bir sonraki iterasyona gecmek icin kullanilir.
            
            Console.WriteLine(" i :"+i);
        }

        int sayac1 = 0;
        start:// tercih edilmez
        if (sayac1 < 5)
        {
            Console.WriteLine("Sayac "+sayac1);
            sayac1++;
            goto start;
        }
        #endregion
    }
}