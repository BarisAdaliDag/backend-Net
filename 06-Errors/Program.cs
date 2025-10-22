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
        //String input = "1234";
        //int number;
        //bool success = int.TryParse(input, out number);
        //if (success)
        //{
        //    Console.WriteLine("Basarili bir giris" + number);

        //}
        //else
        //{
        //    Console.WriteLine("basarisiz " + number);
        //}

        #endregion


        #region Question1
        //Banka hesap yonetimi sistemi

        /*Senaryo: Banka Hesap Yönetim Sistemi
          Bir banka için müşteri hesaplarını yönetecek bir sistem geliştiriyorsunuz. Bu sistem, kullanıcının bir banka hesabını yönetmesine olanak tanır. Kullanıcı, sisteme giriş yaptıktan sonra çeşitli işlemler gerçekleştirebilir: bakiye sorgulama, para yatırma, para çekme ve çıkış yapma.

          Adımlar:
          Kullanıcı Girişi: Kullanıcıdan, doğru kullanıcı adı ve şifreyi girmesi istenir. Yanlış giriş yaparsa sistemden çıkış yapılmaz, tekrar denemesi sağlanır. Bu işlem while döngüsü ve try-catch kullanılarak yapılacaktır.
          Doğru kullanıcı adı: admin, Şifre: 1234.

          İşlem Menüsü (Switch-Case ile): Kullanıcı giriş yaptıktan sonra bir menü karşısına çıkar:
          Bakiye Sorgulama
          Para Yatırma
          Para Çekme
          Çıkış Yap

          İşlemler: Kullanıcı, istediği işlemi menüden seçebilir:
          Bakiye Sorgulama: Kullanıcının hesabındaki mevcut bakiye görüntülenir.
          Para Yatırma: Kullanıcıdan yatırılacak miktar istenir. Bu miktar geçerli bir sayı olmalıdır (try-parse kullanılarak doğrulanır).
          Para Çekme: Kullanıcıdan çekilmek istenen miktar istenir. Eğer bakiye yetersizse, hata mesajı gösterilir (if kullanılarak kontrol edilir).
          Çıkış Yap: Kullanıcı sistemi kapatır ve teşekkür mesajı alır.
          Hata Yönetimi:

          Kullanıcı hatalı giriş yaparsa, try-catch bloğu ile yakalanır ve kullanıcıya tekrar deneme hakkı verilir.*/


        //string personName = "admin";
        //string personPassword = "1234";
        //double  customerMoney = 0;


        //bool isLoginsuccess = false;
        //Console.WriteLine("Bankamiza Hos geldin");
        //Start:
        //try
        //{
        //    while (!isLoginsuccess)
        //    {
        //        Console.WriteLine(" isminizi giriniz");
        //        string strName = Console.ReadLine();
        //        Console.WriteLine("Sifrenizi Giriniz");
        //        string strPassword = Console.ReadLine();
        //        if(strName == personName && strPassword == personPassword) {
        //        isLoginsuccess= true;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Hatali giris yaptiniz.Tekrar deneyiniz");
        //        }
        //    }


        //}catch(Exception ex)
        //{
        //    Console.WriteLine("Hata"+ex);
        //    goto Start;
        //}
        //Start1:
        //Console.WriteLine("Menu\n 1-4 arasi secim yapiniz" +
        //    "1-Bakiye sorgulamasi\n2-Para Yatirma\n3-Para cekme \n4- cikis");


        //    char islem = Console.ReadLine()[0];

        //    switch (islem)
        //    {
        //        case '1':
        //            Console.WriteLine("Bakiyeniz : " + customerMoney);

        //            break;
        //        case '2':
        //            Console.WriteLine("Bakiyeniz : " + customerMoney);
        //            Console.WriteLine("Yatirmak istediginiz parayi girin");
        //          String strIncomingMoney = Console.ReadLine();
        //        int number2;
        //        bool successIncoming = int.TryParse(strIncomingMoney, out number2);
        //        if (successIncoming)
        //        {
        //            customerMoney += number2;
        //            Console.WriteLine("Bakiyeniz : " + customerMoney);
        //            goto Start1;
        //        }
        //        else { Console.WriteLine("Hatali islem yapildi");
        //            goto Start1;
        //        }
        //        break;
        //    case '3':
        //        Console.WriteLine("Bakiyeniz : " + customerMoney);
        //        Console.WriteLine("Yatirmak istediginiz parayi girin");
        //        String strExitMoney = Console.ReadLine();
        //        int number3;
        //        bool successExitMoney = int.TryParse(strExitMoney, out number3);
        //        if (successExitMoney)
        //        {
        //            customerMoney -= number3;
        //            Console.WriteLine("Bakiyeniz : " + customerMoney);
        //            goto Start1;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Hatali islem yapildi");
        //            goto Start1;
        //        }
        //        break;
        //    case '4':
        //        Console.WriteLine("Cikis yapildi");
        //        return;





        //} 


        const string ADMIN_USERNAME = "admin";
        const string ADMIN_PASSWORD = "1234";
        double customerBalance = 0;

        Console.WriteLine("=== Bankamıza Hoş Geldiniz ===\n");

        // Kullanıcı Girişi
        bool isLoginSuccessful = false;
        while (!isLoginSuccessful)
        {
            Console.Write("Kullanıcı Adı: ");
            string username = Console.ReadLine();

            Console.Write("Şifre: ");
            string password = Console.ReadLine();

            if (username == ADMIN_USERNAME && password == ADMIN_PASSWORD)
            {
                isLoginSuccessful = true;
                Console.WriteLine("\n✓ Giriş başarılı!\n");
            }
            else
            {
                Console.WriteLine("\n✗ Hatalı kullanıcı adı veya şifre! Tekrar deneyiniz.\n");
            }
        }

        // Ana Menü Döngüsü
        bool exitRequested = false;
        while (!exitRequested)
        {
            Console.WriteLine("\n╔════════════════════════════╗");
            Console.WriteLine("║        ANA MENÜ            ║");
            Console.WriteLine("╠════════════════════════════╣");
            Console.WriteLine("║ 1 - Bakiye Sorgulama       ║");
            Console.WriteLine("║ 2 - Para Yatırma           ║");
            Console.WriteLine("║ 3 - Para Çekme             ║");
            Console.WriteLine("║ 4 - Çıkış                  ║");
            Console.WriteLine("╚════════════════════════════╝");
            Console.Write("\nSeçiminiz (1-4): ");

            string input = Console.ReadLine();

            // Boş girdi kontrolü
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("\n✗ Lütfen geçerli bir seçim yapınız!");
                continue;
            }

            char choice = input[0];

            switch (choice)
            {
                case '1':
                    // Bakiye Sorgulama
                    Console.WriteLine($"\n💰 Güncel Bakiyeniz: {customerBalance:C2}");
                    break;

                case '2':
                    // Para Yatırma
                    Console.WriteLine($"\n💰 Mevcut Bakiye: {customerBalance:C2}");
                    Console.Write("Yatırmak istediğiniz tutarı giriniz: ");

                    if (double.TryParse(Console.ReadLine(), out double depositAmount))
                    {
                        if (depositAmount > 0)
                        {
                            customerBalance += depositAmount;
                            Console.WriteLine($"\n✓ {depositAmount:C2} başarıyla yatırıldı.");
                            Console.WriteLine($"💰 Yeni Bakiye: {customerBalance:C2}");
                        }
                        else
                        {
                           
                            Console.WriteLine("\n✗ Lütfen pozitif bir tutar giriniz!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n✗ Geçersiz tutar! Lütfen sayısal bir değer giriniz.");
                    }
                    break;

                case '3':
                    // Para Çekme
                    Console.WriteLine($"\n💰 Mevcut Bakiye: {customerBalance:C2}");
                    Console.Write("Çekmek istediğiniz tutarı giriniz: ");

                    if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                    {
                        if (withdrawAmount > 0)
                        {
                            if (withdrawAmount <= customerBalance)
                            {
                                customerBalance -= withdrawAmount;
                                Console.WriteLine($"\n✓ {withdrawAmount:C2} başarıyla çekildi.");
                                Console.WriteLine($"💰 Kalan Bakiye: {customerBalance:C2}");
                            }
                            else
                            {
                                Console.WriteLine($"\n✗ Yetersiz bakiye! Mevcut bakiyeniz: {customerBalance:C2}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n✗ Lütfen pozitif bir tutar giriniz!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n✗ Geçersiz tutar! Lütfen sayısal bir değer giriniz.");
                    }
                    break;

                case '4':
                    // Çıkış
                    Console.WriteLine("\n✓ Sistemden çıkış yapılıyor...");
                    Console.WriteLine("Bizi tercih ettiğiniz için teşekkür ederiz. İyi günler!");
                    exitRequested = true;
                    break;

                default:
                    Console.WriteLine("\n✗ Geçersiz seçim! Lütfen 1-4 arasında bir seçim yapınız.");
                    break;
            }
        }





        #endregion
    }
}