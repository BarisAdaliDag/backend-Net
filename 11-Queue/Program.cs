internal class Program
{
    private static void Main(string[] args)
    {
     // Queue (kuyruklu) yapisi ilk giren ilk cikar (FIFO - First in First Out) prensibiyle calisir.

        Queue<string> kuyruk = new Queue<string>();
        kuyruk.Enqueue("A"); // kuyruga eleman ekler
        kuyruk.Enqueue("B");
        kuyruk.Enqueue("C");
        kuyruk.Enqueue("D");
        kuyruk.Dequeue(); // kuyruktaki ilk elemani cikar ve dondurur

        string bas = kuyruk.Peek(); //Kuyruktaki ilk elemani cikarmadan dondurur.

        #region Ex1

        Queue<string> cagriKuyrugu= new Queue<string>();
        string girls = "";
        while(true)
        {
            Console.WriteLine("Cagri Merkezi sistemi");
            Console.WriteLine("1-Cagri ekle");
            Console.WriteLine("2-Cagri listele");
            Console.WriteLine("3-Cagri isle");
            Console.WriteLine("4-cikis");
            Console.WriteLine("Seciminizi Yapin");
            girls = Console.ReadLine();
            switch (girls) {
                case "1":
                    Console.Write("Cagri bilgisi ");
                    string cagriBilgisi = Console.ReadLine();
                    cagriKuyrugu.Enqueue(cagriBilgisi);
                    Console.WriteLine("cagri kuyrugu eklendi");
                    break;
                case "2":
                    Console.WriteLine("Mevcut Cagrilar");
                    foreach (var item in cagriKuyrugu)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "3":
                    if (cagriKuyrugu.Count > 0)
                    {
                        string istenecekCagri = cagriKuyrugu.Dequeue();
                        string siradakiCagri = cagriKuyrugu.Peek();
                        Console.WriteLine($"Islenecek cegri : {siradakiCagri}");
                    }

                    break;
                
                case "4":
                    Console.WriteLine("Cikis yapiliyor");
                    return;
                default:
                    Console.WriteLine("Gecersiz Giris yaptiniz");
                    break;



            }



        }
        
        
        
        #endregion
    }
}