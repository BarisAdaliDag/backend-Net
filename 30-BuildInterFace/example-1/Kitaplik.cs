using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_OOP_BuiltInInterface.Example_1
{
    public class Kitaplık : IEnumerable<Kitap>, ICollection<Kitap>, IList<Kitap>
    {
        private Kitap[] InnerList;
        public Kitaplık()
        {
            InnerList = new Kitap[2];
            Count = 0;
        }

        public int Count { get; private set; }
        public int Capacity => InnerList.Length;

        public bool IsReadOnly => false;

        public Kitap this[int index] { get => InnerList[index]; set => InnerList[index] = value; }

        public IEnumerator<Kitap> GetEnumerator()
        {
            //Koleksiyonun yineleyicisini döndürürek foreach içinde gezinme sağlar.
            //return kitaplar.GetEnumerator();
            foreach (var item in InnerList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //Type-Safe 
            return GetEnumerator();
        }

        public void Add(Kitap item)
        {
            if (InnerList.Length == Count)
                DoubleArray();
            InnerList[Count] = item;
            Count++;
        }

        public void Clear()
        {
            InnerList = new Kitap[2];
            Count = 0;
        }

        public bool Contains(Kitap item)
        {
            return InnerList.Contains(item);
        }

        public void CopyTo(Kitap[] array, int arrayIndex)
        {
            InnerList.CopyTo(array, arrayIndex);
        }

        public bool Remove(Kitap item)
        {
            if (Count == 0)
                throw new Exception("There is no more item to be removed from to array.");

            if (InnerList.Length / 2 == Count)
                HalfArray();

            if (Count > 0)
                Count--;
            return true;
        }

        public int IndexOf(Kitap item)
        {
            return Array.IndexOf(InnerList, item);
        }

        public void Insert(int index, Kitap item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        private void DoubleArray()
        {
            var temp = new Kitap[InnerList.Length * 2];
            Array.Copy(InnerList, temp, InnerList.Length);
            InnerList = temp;
        }
        private void HalfArray()
        {
            if (InnerList.Length > 2)
            {
                var temp = new Kitap[InnerList.Length / 2];
                Array.Copy(InnerList, temp, InnerList.Length / 2);
                InnerList = temp;
            }
        }
    }
}
