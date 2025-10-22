using System.Collections;
internal class Program
{
    static void Main(string[] args)
    {
        ArrayList arrayList = new ArrayList() { "Selam", 112 };
        arrayList.Add(10);
        arrayList.Add(25.2);

        foreach (var item in arrayList)
        {
            // int sonuc = item * 2; Olmaz object yapida
            if (item.GetType() == typeof(int))
            {
                int sonuc = (int)item * 2;
            }

            //if (item as Person)
            //{
            //    var result = item is Person;
            //}

            Console.WriteLine(item);
        }
    }
}
}
