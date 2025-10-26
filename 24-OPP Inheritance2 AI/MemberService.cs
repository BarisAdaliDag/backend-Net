using _24_OOP_Inheritance2_AI;
using System.Collections.Generic;


using System.Collections.Generic;

namespace _24_OOP_Inheritance2.Services_AI
{
    /// <summary>
    /// Üyeleri yönetir. LINQ kullanmadan, List döner.
    /// DİKKAT: Dışarıdan değiştirilebilir!
    /// </summary>
    internal class MemberService
    {
        // İçte List tutuyoruz
        private readonly List<BaseMember> _members;

        public MemberService(List<BaseMember> members)
        {
            _members = members;
        }

        // Üye ekle
        public void AddMember(BaseMember member)
        {
            _members.Add(member);
        }

        // TÜM ÜYELERİ LİSTE OLARAK GETİR
        public List<BaseMember> GetAll()
        {
            return _members; // doğrudan listeyi veriyoruz
        }

        // SADECE VIP ÜYELERİ LİSTE OLARAK
        public List<BaseMember> GetVip()
        {
            var vipList = new List<BaseMember>();
            foreach (var member in _members)
            {
                if (member is VipMember)
                {
                    vipList.Add(member);
                }
            }
            return vipList;
        }

        // SADECE STANDART ÜYELERİ LİSTE OLARAK
        public List<BaseMember> GetStandart()
        {
            var standartList = new List<BaseMember>();
            foreach (var member in _members)
            {
                if (member is StandartMember)
                {
                    standartList.Add(member);
                }
            }
            return standartList;
        }
    }
}

//namespace _24_OOP_Inheritance2.Services_AI
//{
//    /// <summary>
//    /// Üyeleri yönetir. LINQ kullanmadan, sadece foreach ve is ile çalışır.
//    /// </summary>
//    internal class MemberService
//    {
//        // İçte List tutuyoruz (ekleme, silme için)
//        private readonly List<BaseMember> _members;

//        public MemberService(List<BaseMember> members)
//        {
//            _members = members;
//        }

//        // Üye ekle
//        public void AddMember(BaseMember member)
//        {
//            _members.Add(member);
//        }

//        // TÜM ÜYELERİ GETİR (IEnumerable → sadece dolaş)
//        public IEnumerable<BaseMember> GetAll()
//        {
//            foreach (var member in _members)
//            {
//                yield return member; // tek tek döner
//            }
//        }

//        // SADECE VIP ÜYELER
//        public IEnumerable<BaseMember> GetVip()
//        {
//            foreach (var member in _members)
//            {
//                if (member is VipMember) // tip kontrolü
//                {
//                    yield return member;
//                }
//            }
//        }

//        // SADECE STANDART ÜYELER
//        public IEnumerable<BaseMember> GetStandart()
//        {
//            foreach (var member in _members)
//            {
//                if (member is StandartMember)
//                {
//                    yield return member;
//                }
//            }
//        }
//    }
//}