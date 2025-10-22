namespace _15_method2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region params
            //birden fazla ayni degerden veri 

            int[] numerics = { 1, 2, 3, 4, 5 };
            var result = Topla(numerics);
            Console.WriteLine(result);
            var result1 = Topla(2,3,4,5,6,7,8);

            #endregion

            #region Out

            double sonuc, bolumdeKalan;
            sonuc = Bolme(15, 2,out bolumdeKalan);
            Console.WriteLine($"15/2 = {sonuc} kalan = {bolumdeKalan}");

            #endregion


            #region Ref
            int a = 15,b = 12;
            Console.WriteLine("islem oncesi " + a);
            Console.WriteLine("islem oncesi " + b);
            Console.WriteLine();
            Toplamdeger(a);
            Console.WriteLine("islem sonrasi a degiskeni"+ a);//10
            FarkDeger(ref b);
            Console.WriteLine("islem sonrasi a degiskeni" + b);//12 - 5 = 7

            int Toplamdeger(int a)
            {
                return a += 10;

            }
            void FarkDeger(ref int b)

            {
                b -= 5;

            }

            int sayi = 5;
            Console.WriteLine("once " + sayi);
            DegerDegistir(ref sayi);
            Console.WriteLine("Sonra " + sayi);


            #endregion



            #region Local Metotlar Fonksiyon
            int Hesapla (int a,int b) {
                return a + b;
            }
            #endregion



            #region BestPractis
            /*
            1-Anlamli isimler : CalculateTotalPrice
            2-Fiil kullanimi :  GetCustomer , SaveFile, SemdEmail
            3-camelCase ve PascalCase: C# dilinde metot isimleri PascalCase kullanilir



            solid


            liskov subtition  
            interface segratation  . Class interfacelerde gereksiz implementasyonlar yapma
            depency inversition:Sirtinizi soyutsinflara dayayin. Email servisin var bozuldu diger bolumlerde bozulmamasi icin interface dayaman lazim

             */
            #endregion
        }
        //! uc pranrezi fonksiyonun ustene yazinca altaki yapiyi olusturuyor
        /// <summary>
        ///  N sayida degiskeni toplayan method
        /// </summary>
        /// <param name="sayilar">Birden fazla sayi girisi</param>
        /// <returns>Sayilarin toplayan method</returns>
        public static int Topla(params int[] sayilar)
        {
            int toplam = 0;
            foreach (int i in sayilar)
            {
                toplam += i; 
            }
            return toplam;
        }
        /// <summary>
        /// Bolme islemini gerceklestirir
        /// </summary>
        /// <param name="bolunen">Bolunecek sayi</param>
        /// <param name="bolen"> Bolen sayi</param>
        /// <param name="kalan"> Kalan sayi </param>
        /// <returns></returns>
        public static double Bolme(double bolunen,double bolen, out double kalan)
        {
            kalan = bolunen % bolen;
            return bolunen / bolen;
        }

        public static void DegerDegistir(ref int x)
        {
            x = x + 10;
            

        }
    
    }
}