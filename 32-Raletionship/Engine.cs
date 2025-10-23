using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_Raletionship
{
    public class Engine
    {
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public void Start()
        {

        }
        public void Stop() { }




    }
    public class MusicSystem
    {
        public string Brand { get; set; }

        public MusicSystem(string brand)
        {
            Brand = brand;
        }
        public void PlayMusic()
        {
            Console.WriteLine();
        }
    }

    public class Car
    {
        public Car(string brand, Engine emgine)
        {
            Brand = brand;
            Emgine = emgine;
        }

        public string Brand { get; set; }
        public Engine Emgine { get; set; } //Completition
        public MusicSystem MusicSystem { get; set; }    //Aggretetion(Opsiyonel)

        public void StartCar() { }

    }
}
