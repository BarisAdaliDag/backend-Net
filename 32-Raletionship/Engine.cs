using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_OOP_Relationship
{
    public class Engine
    {
        public Engine(string model, int horsePower)
        {
            Model = model;
            HorsePower = horsePower;
        }

        public string Model { get; set; }
        public int HorsePower { get; set; }

        public void Start()
        {
            Console.WriteLine($"Engine {Model} with {HorsePower} HP is starting...");
        }

        public void Stop() 
        { 
            Console.WriteLine($"Engine {Model} is stopping..."); 
        }
    }

    public class MusicSystem
    {
        public MusicSystem(string brand)
        {
            Brand = brand;
        }

        public string Brand { get; set; }

        public void PlayMusic()
        {
            Console.WriteLine($"Playing music on {Brand} music system.");
        }
    }

    public class Car
    {
        public Car(string brand, Engine engine)
        {
            Brand = brand;
            Engine = engine;
        }

        public string Brand { get; set; }
        public Engine Engine { get; set; } // Composition
        public MusicSystem MusicSystem { get; set; } //Aggregation (Opsiyonel)

        public void StartCar() 
        {
            Console.WriteLine($"Starting {Brand} car...");
            Engine.Start();
            MusicSystem?.PlayMusic();
        }
    }
}
