namespace _24_OOP_Inheritance2
{
    internal class Program
    {

        //visual studioda paket indirdik class designer bu
        static List<BaseMember> members = new List<BaseMember>()
        {
          new  VipMember("fatih", "akin", new DateTime(2025, 9, 22), "Kadir hoca"),
         new VipMember("mehmet", "yildiz", new DateTime(2025, 10, 1), "Kadir hoca"),
          new StandartMember("fatih", "akin", new DateTime(2025, 9, 1)){Kit = true},


        };

        static void Main(string[] args)




        {
            #region OOP Casting



            //  BaseMember deneme = new BaseMember() //Olmaz çünkü constractor protected kullanılmış

            StandartMember standart1 = new StandartMember("fatih", "akin", new DateTime(2025, 9, 1));
            standart1.Kit = true;
            Console.WriteLine(standart1);

            VipMember vipMember = new VipMember("fatih", "akin", new DateTime(2025, 9, 1), "dd");
            Console.WriteLine(vipMember);
            List<BaseMember> list = new List<BaseMember>();
            list.Add(standart1);
            list.Add(vipMember);

            foreach (var item in list)
            {
                if (item is VipMember)
                {
                    var result = item as VipMember;
                }
                else if (item.GetType() == typeof(StandartMember))
                {
                    var result = (StandartMember)item;
                }

                {

                }

            }
            #endregion


            #region Exp2
            Console.WriteLine("Spor salonu üyelik sistemi");
            while (true)
            {
                Console.WriteLine("1) Üye Ekle 2) Üye Listele 3) Çıkış");
                Console.Write("Seçim: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Write("Üye Adı: ");
                        string name = Console.ReadLine();
                        Console.Write("Üye Soyadı: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Başlangıç: ");
                        int day = int.Parse(Console.ReadLine());
                        Console.Write("Üye Tipi A-Vip B-Standart");
                        string input1 = Console.ReadLine();
                        if (input1 == "A")
                            members.Add(new VipMember(name, lastName, new DateTime(2025, 10, 21).AddDays(day), "Kadir Hoca"));
                        else
                            members.Add(new StandartMember(lastName, name, new DateTime(2025, 10, 21).AddDays(day)));
                        break;
                    case "2":
                        Console.Write("Üye Tipi A-Vip B-Standart C-Hepsi");
                        string input2 = Console.ReadLine();
                        if (input2 == "A")
                        {
                            foreach (var item in members)
                            {
                                if (item is VipMember)
                                    Console.WriteLine(item);
                            }
                        }
                        else if (input2 == "B")
                        {
                            foreach (var item in members)
                            {
                                if (item is StandartMember)
                                    Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            foreach (var item in members)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Hatalı veya yanlış giriş!");
                        break;
                }
            }

            #endregion
        }
    }
}