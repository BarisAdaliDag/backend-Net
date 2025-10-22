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
            #region Example



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
            Console.WriteLine( "******************************");
            Console.WriteLine("Spor salonu uyelik sistemi");
            while (false)
            {
                Console.WriteLine("1)Uye olmak ekle 2) Uye listele 3) Cikis");

                Console.Write("Secim :");

            }


            #endregion
        }
    }
}