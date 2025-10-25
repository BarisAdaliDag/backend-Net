using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2_OOP_ıntro
{
    public class Kumanda
    {
        public string Abc { get; set; } = null!;


        //// Constructor - Yapici metod
        //public Kumanda()
        //{

        //}

        //// Destructor - Yikici metod
        //~Kumanda()
        //{
        //    // Sinifin isi bittiginde garbage collector un tam kaldiracagi esnada calisir.
        //}
        // prop + tab tab
        //public int Id { get; set; }
        //public string Marka { get; set; }
        //public string Model { get; set; }
        //public int PilAdedi { get; set; }


        // ctor + tab tab
        //public Kumanda()
        //{
        //    Console.WriteLine("Kumanda constructor tetiklendi...");
        //}
        //public Kumanda(string marka,string model) : this()
        //{
        //    Marka = marka;
        //    Model = model;

        //    Console.WriteLine($"{Marka} {Model}");
        //}
        //public Kumanda(string marka,string model,int pilAdedi) : this(marka,model)
        //{
        //    //this.Marka = marka;
        //    //Model = model;
        //    PilAdedi = pilAdedi;
        //    Console.WriteLine(PilAdedi);
        //}

        //public Kumanda()
        //{

        //}
        //public Kumanda(string marka, string model, int pilAdedi)
        //{
        //    if(marka.Length > 7)
        //        this.marka = marka.Remove(7);
        //    else
        //        this.marka = marka;

        //    if(pilAdedi < 1)
        //        this.pilAdedi = 1;
        //    else
        //        this.pilAdedi = pilAdedi;

        //    this.model = model;
        //}

        //string marka;
        //string model;
        //int pilAdedi;

        //public string MarkaGet() => marka;
        //public void MarkaSet(string marka)
        //{
        //    if (marka.Length > 7)
        //        this.marka = marka.Remove(7);
        //    else
        //        this.marka = marka;
        //}

        //public string ModelGet() => model;
        //public void ModelSet(string model)
        //{
        //    this.model = model;
        //}

        //public int PilAdediGet()
        //{
        //    return pilAdedi;
        //}
        //public void PilAdediSet(int pilAdedi)
        //{
        //    if (pilAdedi < 1)
        //        this.pilAdedi = 1;
        //    else
        //        this.pilAdedi = pilAdedi;
        //}



        // Property
        // kumanda.Marka = "value"  => set
        // Console.Write(kumanda.Marka) => get
        //string _marka;
        //public string Marka 
        //{
        //    get
        //    {
        //        // Geriye olusturulan property(ozellik) tipinde deger dondurur.
        //        return _marka;
        //    }
        //    set
        //    {
        //        // Disaridan gelen degeri alir ve gerekli islemleri yapar.
        //        if(value.Length > 7)
        //            value = value.Remove(7);

        //        _marka = value;
        //    }
        //}
        //public string Model { get; set; }

        //int _pilAdedi;
        //public int PilAdedi 
        //{
        //    get => _pilAdedi;

        //    set/*(value)*/
        //    {
        //        if(value < 1)
        //            value = 1;

        //        _pilAdedi = value;
        //    } 
        //}

        // Bu alandayken diledigim gibi deger atamasini ve okumasini yapabilirim. Fakat disaridan cagirildiginda sadece okunabilir olur.
        public int Identity { get; private set; } = 2;
    }
}
