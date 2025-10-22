internal class Program
{
    private static void Main(string[] args)
    {
        #region Arry
        //Diziler ayni veri tipindeki birden cok degeri bir arada tutmamiza olanak saglayan yapilardir.

        int[] numbers;
        numbers= new int[10];
        //new ornekleme
        numbers[0]=1;
        numbers[1]=2;
        Console.WriteLine(numbers[2]);

        numbers = new int[2];
        Console.WriteLine(numbers[1]);

        string[] meyveler = { "Elma", "Armut", "Portakal" };

        //diziler buyutme icin add methodu yok

        for(int i = 0; i < meyveler.Length; i++)
        {
            Console.WriteLine($"{meyveler[i]}");
        }

        foreach (string meyve in meyveler) {
            Console.WriteLine(meyve);

        }

        int[] numbers2 = { 1, 2, 3, 4 };

        for (int i = 0; i < numbers2.Length; i++)
        {
            numbers2[i] = numbers2[i] * 2;
        }
        foreach (var item in numbers2)
        {
          //  item = item * 2; YAPILAMAZ
        }
        //for indeks uzerinden islem yapar.
        //okuma  yazma yapilabilir

        //Foreach sirala uzerindedn islem yapar 
        //sadece okuma yapilir



        #endregion

        #region MultidimensionalArrys
        int[,] matris = new int[3,3] {
        { 1,2,3},
            {4,5,6},
       {7,8,9},
        };

        Console.WriteLine(matris[2,2]);

        for ( int i = 0; i<3; i++)
        {
            for (int j = 0; j<3; j++)
            {
                Console.WriteLine(matris[i,j]);
            }
        }
        #endregion

        #region Jagged
        //Duzensiz Diziler
        int[][] duzensizDizi = new int[3][];
        duzensizDizi[0] = new int[2];
        duzensizDizi[1] = new int[3];
        duzensizDizi[2] = new int[1];


        #endregion

        #region ArraySinifi
        string[] ornekDizi = { "Istanbul", "Ankara", "Izmir", "Bursa", "Eskisehir", "Konya", "Trabzon", "sivas", "Eskisehir" };

        //Sort
        //Array.Sort(ornekDizi);
        //Console.WriteLine("sirali dizi"+ornekDizi);

        Array.Sort(ornekDizi,4,5); //4 siradan 5 adim kadar sort islemi yapar
        Console.WriteLine("sirali dizi");
            foreach(var item in ornekDizi)
        {
            Console.WriteLine(item);
                
        }
        Console.WriteLine(  "********************************");
        
        Array.Reverse(ornekDizi,4,5);

        Console.WriteLine("ters dizi");
        foreach (var item in ornekDizi)
        {
            Console.WriteLine(item);

        }

       int index = Array.LastIndexOf(ornekDizi, "Izmir");
        Console.WriteLine(index);

        int index1 = Array.LastIndexOf(ornekDizi, "Istanbul",2,3);
        Console.WriteLine(index1);

        int index2 = Array.IndexOf(ornekDizi, "Bursa");
        int lastIndex1 = Array.LastIndexOf(ornekDizi, "Bursa");

        if(index2 != lastIndex1)
        {
            Console.WriteLine("Birden fazla var");

        }
        else
        {
            Console.WriteLine("Bir tane");
        }

        //Clear
        //Array.Clear(ornekDizi);
        //foreach(var item in ornekDizi)
        //{
        //    Console.WriteLine(item);
        //}

        //Copy
        //string[] yeniSehirler = new string[4];
        //Array.Copy(ornekDizi,3 ,yeniSehirler,2,3);


        Array.Resize(ref ornekDizi,12);
        //foreach(var item in ornekDizi)
        //{
        //    Console.WriteLine(item);
        //}

        int[] myNumbers = { 5, 1, 8, 9 };
        Console.WriteLine(myNumbers.Max());  // returns the largest value
        Console.WriteLine(myNumbers.Min());  // returns the smallest value
        Console.WriteLine(myNumbers.Sum());  // returns the sum of elements

        List<string> list = new List<string>();




        #endregion
    }
}