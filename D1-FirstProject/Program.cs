//{
    internal class Program
{
    static void Main(string[] args)
    {
        string name = "Baris";
        string soyad = "dag";
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Adim  " + name);
        Console.WriteLine("Placeholder - Adim {0} soyad {1}", name, soyad);
        Console.WriteLine("Placeholder - Adim {0} yas {1}", name, 38);
        Console.WriteLine($" String Interpolation {name}");
        //string selam = Console.ReadLine();

        //Primative Veri Tipleri
        #region Integer Types
        //byte 0-255 
        Console.WriteLine(nameof(Byte)); //nameof ,byteof
        Console.WriteLine($"Alt Limit: {Byte.MinValue,5}");
        Console.WriteLine($"ust: {Byte.MaxValue,5}");
        Console.WriteLine($"Boyut: {sizeof(Byte),5}");

        Console.WriteLine(new string('*', 20));

        //Sbyte  -128  127
        Console.WriteLine(nameof(SByte)); //nameof ,byteof
        Console.WriteLine($"Alt Limit: {SByte.MinValue,5}");
        Console.WriteLine($"ust: {SByte.MaxValue,5}");
        Console.WriteLine($"Boyut: {sizeof(SByte),5}");

        Console.WriteLine(new string('*', 20));

        //Short
        Console.WriteLine(nameof(Int16));
        Console.WriteLine($"Alt Limit: {short.MinValue,5}");
        Console.WriteLine($"ust: {short.MaxValue,5}");
        Console.WriteLine($"Boyut: {sizeof(short),5}");

        Console.WriteLine(new string('*', 20));

        //UShort
        Console.WriteLine(nameof(UInt16));
        Console.WriteLine($"Alt Limit: {ushort.MinValue,5}");
        Console.WriteLine($"ust: {ushort.MaxValue,5}");
        Console.WriteLine($"Boyut: {sizeof(ushort),5}");

        Console.WriteLine(new string('*', 20));

        //UShort
        Console.WriteLine(nameof(UInt16));
        Console.WriteLine($"Alt Limit: {ushort.MinValue,5}");
        Console.WriteLine($"ust: {ushort.MaxValue,5}");
        Console.WriteLine($"Boyut: {sizeof(ushort),5}");

        Console.WriteLine(new string('*', 20));

        //Integer
        Console.WriteLine(nameof(Int32));
        Console.WriteLine($"Alt Limit: {int.MinValue,5}");
        Console.WriteLine($"ust: {int.MaxValue,5}");
        Console.WriteLine($"Boyut: {sizeof(int),5}");

        Console.WriteLine(new string('*', 20));

        //UInteger
        Console.WriteLine(nameof(UInt32));
        Console.WriteLine($"Alt Limit: {uint.MinValue,5}");
        Console.WriteLine($"ust: {uint.MaxValue,5}");
        Console.WriteLine($"Boyut: {sizeof(uint),5}");

        Console.WriteLine(new string('*', 20));

        //Long
        Console.WriteLine(nameof(Int64));
        Console.WriteLine($"Alt Limit: {long.MinValue,5}");
        Console.WriteLine($"ust: {long.MaxValue,5}");
        Console.WriteLine($"Boyut: {sizeof(long),5}");

        Console.WriteLine(new string('*', 20));

        //ULong
        Console.WriteLine(nameof(UInt64));
        Console.WriteLine($"Alt Limit: {ulong.MinValue,5}");
        Console.WriteLine($"ust: {ulong.MaxValue,5}");
        Console.WriteLine($"Boyut: {sizeof(ulong),5}");

        Console.WriteLine(new string('=', 20));



        #endregion


        #region Ondalikli Sayilar(Floating Point Types)
        //Float
        Console.WriteLine(nameof(Single));
        Console.WriteLine($"Alt Limit: {float.MinValue,5}");
        Console.WriteLine($"ust: {float.MaxValue,5}");
        Console.WriteLine($"Boyut: {sizeof(float),5}");

        //1,23456789=> 1,2345678 cevirecek daha buyuk tutamiyor
        Console.WriteLine(new string('*', 20));

        //double
        Console.WriteLine(nameof(Double));
        Console.WriteLine($"Alt Limit: {double.MinValue,5}");
        Console.WriteLine($"ust: {double.MaxValue,5}");
        Console.WriteLine($"Boyut: {sizeof(double),5}");


        Console.WriteLine(new string('*', 20));

        //Decimal
        Console.WriteLine(nameof(Decimal));
        Console.WriteLine($"Alt Limit: {decimal.MinValue,5}");
        Console.WriteLine($"ust: {decimal.MaxValue,5}");
        Console.WriteLine($"Boyut: {sizeof(decimal),5}");


        Console.WriteLine(new string('*', 20));


        #endregion


        #region Karakteler
        //Char
        Console.WriteLine(nameof(Char));
        Console.WriteLine($" Limit: 1");

        Console.WriteLine($"Boyut: {sizeof(char),5}");

        char karakter = 'c';// tek tirnak
        Console.WriteLine(new string('*', 20));
        //String
        Console.WriteLine(nameof(String));
        Console.WriteLine($" Limit: 1");

        //Boyut yok array


        Console.WriteLine(new string('*', 20));


        //Referans tipte boyut yoktur degeisiklik oldugunda bellekte referans adresi degisir
        #endregion

        #region Booleans

        //Bool
        Console.WriteLine(nameof(Boolean));
        Console.WriteLine($"Alt limit {false}");
        Console.WriteLine($"Alt limit {true}");
        Console.WriteLine($"Boyut {1}");



        Console.WriteLine(new string('*', 20));
        #endregion

        #region DegiskenTanimlama

        //veri_tipi degisken_adi = deger;
        int age, score;
        age = 0;
        score = 0;

        //sanke_case PascalCase camelCase

        void CalculateScore() { }// fonksiyonlar ilk harfi buyuk tercih edilir c# da.

        float ondalik1 = 2.5f;
        double ondalik2 = 2.5;
        decimal ondalik3 = 2.5m;


        //value type olayi datayi direk uzerinde tasir
        // int sayiX; default value 0 olarak ataniyor
        bool boolQ;//default false
        char charZ;


        /*

         STACK
        VALUE TYPE (Deger Tipli)
        Datayi dogrudan uzerinde taşımaları
        int , double, bool, char , enum , struct,
        Stack küçük boyutlu veri tipleri için uygundur.Hızlı çalışırlar


        HEAP
        REFERANCE TYPE (Adres Tipli)
        Datayı doğrudan üzerinde taşımaz.Bir adres vasıtasıyla dayaua erişim yapar
        string , class , interface , delegate , array,
        Heap geniş bir bellek alanı sağlar ancak stack'a göre daha yavaş çalışırlar

         */
        string strW;
        strW = "merhaba Dunya";

        Console.WriteLine(strW.GetHashCode());

        int int1 = 5;
        int int2 = int1;

        string str1 = "Merhaba";
        string str2 = str1;
        //int bellekte 2 tane yer tutuyor value type oldugu icin 
        //String bellekte 1 tane tutuyor referans tipli oldugu  icin

        string text1 = "Fatih";
        text1 += "akin";
        string text2 = "Fatih";
        Console.WriteLine(Object.ReferenceEquals(text1, text2)); // String immutable 
                                                                 //  StringBuilder string value type yapida calistirmasini sagliyor daha performansli


        #endregion

        #region GelismisVeriTipleri

        Object deger1 = 1;
        Object deger2 = "2";
        deger1 = "2";
        deger1 = true;
        //Entepede object var int vs object turunden turemistir. Bu yuzden tum değer tiplerini pbject atayabilirsin.
        //Tip guvenli sikintisi var

        //Boxing : Ilkel veri tipini object atama
        //- Unboxing : Objecten ilkel veri tipine donusturme

        // Console.WriteLine((int)deger1*2);// deger2 varsa patlar ama consol uyarisi vermez


        //Derleme Zamani- Çalışma Zamanı

        //var Derleme zamaninda tip atamasi yapilir
        var degisken = 5;
        var degisken2 = 5.4;
        var degisken3 = "Merhaba";
        var degisken4 = true;

        Console.WriteLine(degisken * 2);//int oldugunu biliyor



        //dynamic Calisma zamaninda tip atamasi yapilir
        dynamic degiske = 5;
        dynamic degiske2 = 5.4;
        dynamic degiske3 = "Merhaba";
        dynamic degiske4 = true;

        // Console.WriteLine(degiske * 3);
        //hata gozukmuyor derlendiginde patlar string dolayi



        #endregion


        #region Nullable Tipler

        int? nullableSayi = null; //Bu degisken int tipindedir.Ama null gecilebilir.
        Console.WriteLine(nullableSayi);
        Console.WriteLine(nullableSayi.HasValue);
        nullableSayi = 25;
        Console.WriteLine(nullableSayi);
        Console.WriteLine(nullableSayi.HasValue);
        int deneme = nullableSayi.Value;

        int? puan = null;
        int sonuc = puan ?? 50;
        Console.WriteLine(sonuc);



        #endregion



    }
}
}




