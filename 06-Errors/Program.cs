internal class Program
{
    private static void Main(string[] args)
    {
        #region trycatch


        /*
        Derleme Hatalri (Compile time Error) 
       Program kodu derlenmeden once ortaya cikar.oncelikle sozdizimi

       int sayi = "10";


       MANTIKSAL HATALAR(lOGICAL ERRORS) 
       Program duzgun bir sekilde delenir calisir ama istenmeyen sonuclar edilebilir.Yazilimci kaynakli hata


       ÇALIŞMA ZAMANI HATALARI (RUN TIME ERROR) 
       Program derlendikten sonra calistirma sirasinda meydana gelen hatalardir.



        */

        //Start:
        //Console.WriteLine("Bir sayi gir");
        //string strSayi = Console.ReadLine();
        //try {
        //    //Hata gelmesi muhtemel yer

        //    int donusensayi = int.Parse(strSayi);
        //}
        //catch (OverflowException ex)
        //{
        //    Console.WriteLine("daha kucuk sayi girin  "+ex.Message);
        //    goto Start;
        //        }
        //catch(FormatException ex) {
        //    Console.WriteLine("numeric sayi girin"+ex.Message);
        //    goto Start;

        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Hata " + ex.Message);
        //}
        //finally
        //{
        //    // Her turlu durumda calisan mekanizma
        //    Console.WriteLine("Her turlu çalışırım");
        //}


        ///
        //try
        //{
        //    int number = int.Parse("Bir");

        //} catch (FormatException ex) when (ex.Message.Contains("Input strings2"))
        //{
        //    Console.WriteLine("Giris formati hatasi " + ex.Message);
        //} catch (FormatException ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
        /*
                try
                {
                    Console.Write("Yas Girin");
                    int age = int.Parse(Console.ReadLine());
                    if(age < 18)
                    {
                        throw new ArgumentException("Yas 18 den kucuk olamaz!");

                    }
                } 
                //catch (FormatException ex) 
                //{
                //    Console.WriteLine("Giris formati hatasi " + ex.Message);
                //}
                //catch (ArgumentException ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                catch(Exception ex)
                {
                    throw new ArgumentException("Yas 18 den kucuk olamaz!");

                }
        */
        String input = "1234";
        int number;
        bool success = int.TryParse(input, out number);
        if (success)
        {
            Console.WriteLine("Basarili bir giris" + number);

        }
        else
        {
            Console.WriteLine("basarisiz " + number);
        }

        #endregion


        #region Question1
        //Banka hesap yonetimi sistemi
        string personName = "admin";
        string personPassword = "1234";
        double  customerMoney = 0;

       
        bool isLoginsuccess = false;
        Console.WriteLine("Bankamiza Hos geldin");
        Start:
        try
        {
            while (!isLoginsuccess)
            {
                Console.WriteLine(" isminizi giriniz");
                string strName = Console.ReadLine();
                Console.WriteLine("Sifrenizi Giriniz");
                string strPassword = Console.ReadLine();
                if(strName == personName && strPassword == personPassword) {
                isLoginsuccess= true;
                }
                else
                {
                    Console.WriteLine("Hatali giris yaptiniz.Tekrar deneyiniz");
                }
            }
            

        }catch(Exception ex)
        {
            Console.WriteLine("Hata"+ex);
            goto Start;
        }
        Start1:
        Console.WriteLine("Menu\n 1-4 arasi secim yapiniz" +
            "1-Bakiye sorgulamasi\n2-Para Yatirma\n3-Para cekme \n4- cikis");

        
            char islem = Console.ReadLine()[0];

            switch (islem)
            {
                case '1':
                    Console.WriteLine("Bakiyeniz : " + customerMoney);
                   
                    break;
                case '2':
                    Console.WriteLine("Bakiyeniz : " + customerMoney);
                    Console.WriteLine("Yatirmak istediginiz parayi girin");
                  String strIncomingMoney = Console.ReadLine();
                int number2;
                bool successIncoming = int.TryParse(strIncomingMoney, out number2);
                if (successIncoming)
                {
                    customerMoney += number2;
                    Console.WriteLine("Bakiyeniz : " + customerMoney);
                    goto Start1;
                }
                else { Console.WriteLine("Hatali islem yapildi");
                    goto Start1;
                }
                break;
            case '3':
                Console.WriteLine("Bakiyeniz : " + customerMoney);
                Console.WriteLine("Yatirmak istediginiz parayi girin");
                String strExitMoney = Console.ReadLine();
                int number3;
                bool successExitMoney = int.TryParse(strExitMoney, out number3);
                if (successExitMoney)
                {
                    customerMoney -= number3;
                    Console.WriteLine("Bakiyeniz : " + customerMoney);
                    goto Start1;
                }
                else
                {
                    Console.WriteLine("Hatali islem yapildi");
                    goto Start1;
                }
                break;
            case '4':
                Console.WriteLine("Cikis yapildi");
                return;
                break;




        } 


       



        #endregion
    }
}