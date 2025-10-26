using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_OOP_BuiltInInterface.Example_3
{
    public class DosyaYazici : IDisposable
    {
        public StreamWriter _writer;

        public DosyaYazici(string dosyaYolu)
        {
            _writer = new StreamWriter(dosyaYolu);       
        }

        public void Yaz(string mesaj)
        {
            if (_writer == null)
                throw new Exception("asdas");

            _writer.WriteLine(mesaj);
        }

        public void Dispose()
        {
            _writer?.Dispose();
            _writer = null;
        }
    }
}
