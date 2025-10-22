using System.Collections;
internal class Program
{
    private static void Main(string[] args)
    {
        ArrayList arrayList = new ArrayList() { "selam",112};
        arrayList.Add(10);
        arrayList.Add(20.5);

        foreach (var item in arrayList)
        {
           // int sonuc = item * 2; Olmaz object yapida

            if(item.GetType() == typeof(int))
            {
                int sonuc = (int)item;
            }
          //if(item as Int32)
          //  {

          //  }
          

        }
    }
}