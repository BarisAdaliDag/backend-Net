namespace Z2_OOP_ıntro
{

    // User(Id,Username,Password,Email,EmailConfirm,FirstName,LastName,CreatedDate)
    // Id : Sadece okunabilir olacak. Tip Guid olsun.
    // Username bos gecilemez, 3 ile 20 karakter arasinda olabilir. Eger fazla olursa kirpilsin, eksik kalirsa sol tarafi * sembolu ile doldurulsun.
    // Password en az 8 karakter uzunlugunda olmalidir. Assagi bir durumda herhangi bir karakter ile doldurunuz.
    // Email : Bos gecilemez olsun.
    // EmailConfirm : Sadece okunabilir olsun. Email ile ayni degeri dondursun.
    // FirstName ve LastName : Bos gecilemez.

    // Message(Id,Content,SenderId,RecevierId,CreatedDate)
    // Id : Sadece okunabilir olacak. Tip Guid olsun.
    // Content : En az 1 karakter uzunlugunda olmalidir. Assagi bir durumda herhangi bir karakter ile doldurunuz.
    // SenderId ve RecevierId : Bos gecilemez.
    // CreatedDate : Sadece okunabilir olsun. Mesajin olusturuldugu tarihi dondursun.

    // Generic Repository(CRUD) yapisi olusturunuz. Static bir listeyi depo haline getiriniz.
    // Kullanici uyelik olusturur.
    // Kullanici giris yapar.
    // Belirtilen kullanici id veya kullanici adi ile mesaj gonderir.
    // Kullanici cikis yapar.
    // Diger kullanici giris yapip gelen mesajlari gorur.
    // Cevap verir.



    internal class Program
    {
        static void Main(string[] args)
        {
            #region Ornek Olusturma
            //Kumanda kumanda = new(); // Yeni bir ornek olusturmak demek
            //kumanda.Marka = "Samsungasfdsfsdafsdafsdafsdafsdaf";
            //kumanda.Model = "X6";
            //kumanda.PilAdedi = -10;

            //if (kumanda.Marka.Length > 7)
            //    kumanda.Marka = kumanda.Marka.Remove(7);

            //Console.WriteLine(kumanda.Marka);
            //Console.WriteLine(kumanda.Model);

            //if(kumanda.PilAdedi < 1)
            //    kumanda.PilAdedi = 1;

            //Console.WriteLine(kumanda.PilAdedi);

            //Console.WriteLine("KUMANDA 2");

            //Kumanda kumanda2 = new()
            //{
            //    Model = "LG M1",
            //    Marka = "LG",
            //    PilAdedi = 2
            //};

            //if (kumanda2.Marka.Length > 7)
            //    kumanda2.Marka = kumanda2.Marka.Remove(7);

            //Console.WriteLine(kumanda2.Marka);
            //Console.WriteLine(kumanda2.Model);

            //if (kumanda2.PilAdedi < 1)
            //    kumanda2.PilAdedi = 1;

            //Console.WriteLine(kumanda2.PilAdedi);
            #endregion


            //var k1 = new Kumanda();
            //Console.WriteLine($"k1 : {k1.Marka}");

            // Not : Bir sinif sadece bir tane constructor(yapici metodu) uzerinden ayaga kalkabilir. Fakat istenirse ayaga kaldirilan contructor uzerinden diger constructor lar tetiklenebilir.
            //var k2 = new Kumanda("Samsung","17 Pro Max",2);


            //Kumanda k3 = new Kumanda("Samsungggg","J7",-5);
            //Console.WriteLine(k3.Marka);
            //Console.WriteLine(k3.Model);
            //Console.WriteLine(k3.PilAdedi);

            //k3.Marka = "Arcelikkkkkkkk";
            //Console.WriteLine(k3.Marka);

            //Console.WriteLine(k3.MarkaGet());
            //Console.WriteLine(k3.ModelGet());
            //Console.WriteLine(k3.PilAdediGet());

            //Console.Clear();

            //var k4 = new Kumanda();
            //k4.MarkaSet("Ballalalala");
            //k4.ModelSet("B7");
            //k4.PilAdediSet(0);

            //Console.WriteLine(k4.MarkaGet());
            //Console.WriteLine(k4.ModelGet());
            //Console.WriteLine(k4.PilAdediGet());


            Kumanda k5 = new Kumanda();
            //k5.Marka = "Vestel";
            //k5.PilAdedi = -3;

            //Console.WriteLine(k5.PilAdedi);

            Console.WriteLine(k5.Identity);
            //k5.Identity = 1;
        }
    }
}

