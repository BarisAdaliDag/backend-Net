
using _24_OOP_Inheritance2.Exceptions_AI;
using _24_OOP_Inheritance2.Services_AI;
using _24_OOP_Inheritance2_AI;
using System;

namespace _24_OOP_Inheritance2_AI
{
    internal class Program
    {
        private static readonly List<BaseMember> members = new()
        {
            new VipMember("Fatih", "Akın", new DateTime(2025, 9, 22), "Kadir Hoca"),
            new VipMember("Mehmet", "Yıldız", new DateTime(2025, 10, 1), "Kadir Hoca"),
            new StandartMember("Ali", "Veli", new DateTime(2025, 9, 1)) { Kit = true }
        };

        private static readonly MemberService service = new(members);

        static void Main()
        {
            Console.WriteLine("Spor Salonu Üyelik Sistemi");
            while (true)
            {
                Console.WriteLine("\n1) Üye Ekle\n2) Üye Listele\n3) Çıkış");
                Console.Write("Seçim: ");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": AddMemberMenu(); break;
                        case "2": ListMembersMenu(); break;
                        case "3": return;
                        default: Console.WriteLine("Geçersiz seçim!"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"HATA: {ex.Message}");
                }
            }
        }

        static void AddMemberMenu()
        {
            Console.Write("Ad: "); var firstName = Console.ReadLine();
            Console.Write("Soyad: "); var lastName = Console.ReadLine();
            Console.Write("Gün (bugünden itibaren): "); var days = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Tip (A=VIP, B=Standart): "); var type = Console.ReadLine()?.ToUpper();

            var joinDate = DateTime.Today.AddDays(days);
            BaseMember member = type switch
            {
                "A" => new VipMember(firstName, lastName, joinDate, "Kadir Hoca"),
                "B" => new StandartMember(firstName, lastName, joinDate) { Kit = AskYesNo("Kit dahil mi? (e/h): ") },
                _ => throw new ValidationException("Geçersiz üye tipi", "type")
            };

            service.AddMember(member);
            Console.WriteLine("Üye eklendi!");
        }

        static void ListMembersMenu()
        {
            Console.Write("Listele: A=VIP, B=Standart, C=Hepsi: ");
            var filter = Console.ReadLine()?.ToUpper();
            var list = filter switch
            {
                "A" => service.GetVip(),
                "B" => service.GetStandart(),
                _ => service.GetAll()
            };

            foreach (var m in list)
                Console.WriteLine(m);
        }

        static bool AskYesNo(string question)
        {
            while (true)
            {
                Console.Write(question);
                var ans = Console.ReadLine()?.ToLower();
                if (ans == "e") return true;
                if (ans == "h") return false;
                Console.WriteLine("E/H giriniz.");
            }
        }
    }
}