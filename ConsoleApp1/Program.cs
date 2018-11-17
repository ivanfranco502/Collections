using System;
using System.Collections.Generic;

namespace CollectionsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListExampleWithoutKnowInitialize();
            //Console.ReadLine();

            //ListExampleKnowInitialize();
            //Console.ReadLine();

            ////REMOVE

            ////REMOVE ODD NUMBERS

            //IterateThroughList();
            //Console.ReadLine();

            //IterateThruDictionary();
            //Console.ReadLine();

            //FindInDictionary("K");
            //Console.ReadLine();

            //FindInDictionary2("K");
            //Console.ReadLine();

            ListCars();
            Console.ReadLine();
        }

        private static void ListExampleKnowInitialize()
        {
            var salmons = new List<string> { "chinook", "coho", "pink", "sockeye" };


            salmons.RemoveAt(1);
            salmons.RemoveAt(1);

            // Iterate through the list.  
            foreach (var salmon in salmons)
            {
                Console.Write(salmon + " ");
            }
        }

        private static void ListExampleWithoutKnowInitialize()
        {
            var salmons = new List<string>();
            salmons.Add("chinook");
            salmons.Add("coho");
            salmons.Add("pink");
            salmons.Add("sockeye");

            // Iterate through the list.  
            foreach (var salmon in salmons)
            {
                Console.Write(salmon + " ");
            }
        }

        private static void IterateThroughList()
        {
            var theGalaxies = new List<Galaxy>
            {
                new Galaxy() { Name="Tadpole", MegaLightYears=400},
                new Galaxy() { Name="Pinwheel", MegaLightYears=25},
                new Galaxy() { Name="Milky Way", MegaLightYears=0},
                new Galaxy() { Name="Andromeda", MegaLightYears=3}
            };

            foreach (Galaxy theGalaxy in theGalaxies)
            {
                Console.WriteLine(theGalaxy.Name + "  " + theGalaxy.MegaLightYears);
            }
        }

        public class Galaxy
        {
            public string Name { get; set; }
            public int MegaLightYears { get; set; }
        }

        private static void IterateThruDictionary()
        {
            Dictionary<string, Element> elements = BuildDictionary();

            foreach (KeyValuePair<string, Element> kvp in elements)
            {
                Element theElement = kvp.Value;

                Console.WriteLine("key: " + kvp.Key);
                Console.WriteLine("values: " + theElement.Symbol + " " +
                                  theElement.Name + " " + theElement.AtomicNumber);
            }
        }

        private static Dictionary<string, Element> BuildDictionary()
        {
            var elements = new Dictionary<string, Element>();

            AddToDictionary(elements, "K", "Potassium", 19);
            AddToDictionary(elements, "Ca", "Calcium", 20);
            AddToDictionary(elements, "Sc", "Scandium", 21);
            AddToDictionary(elements, "Ti", "Titanium", 22);

            return elements;
        }

        private static void AddToDictionary(Dictionary<string, Element> elements,
            string symbol, string name, int atomicNumber)
        {
            Element theElement = new Element();

            theElement.Symbol = symbol;
            theElement.Name = name;
            theElement.AtomicNumber = atomicNumber;

            elements.Add(key: theElement.Symbol, value: theElement);
        }

        public class Element
        {
            public string Symbol { get; set; }
            public string Name { get; set; }
            public int AtomicNumber { get; set; }
        }

        private static void FindInDictionary(string symbol)
        {
            Dictionary<string, Element> elements = BuildDictionary();

            if (elements.ContainsKey(symbol) == false)
            {
                Console.WriteLine(symbol + " not found");
            }
            else
            {
                Element theElement = elements[symbol];
                Console.WriteLine("found: " + theElement.Name);
            }
        }

        private static void FindInDictionary2(string symbol)
        {
            Dictionary<string, Element> elements = BuildDictionary();

            Element theElement = null;
            if (elements.TryGetValue(symbol, out theElement) == false)
                Console.WriteLine(symbol + " not found");
            else
                Console.WriteLine("found: " + theElement.Name);
        }

        private static void ListCars()
        {
            var cars = new List<Car>
            {
                {new Car() {Name = "car1", Color = "blue", Speed = 20}},
                {new Car() {Name = "car2", Color = "red", Speed = 50}},
                {new Car() {Name = "car3", Color = "green", Speed = 10}},
                {new Car() {Name = "car4", Color = "blue", Speed = 50}},
                {new Car() {Name = "car5", Color = "blue", Speed = 30}},
                {new Car() {Name = "car6", Color = "red", Speed = 60}},
                {new Car() {Name = "car7", Color = "green", Speed = 50}}
            };

            // Sort the cars by color alphabetically, and then by speed  
            // in descending order.  
            cars.Sort();

            // View all of the cars.  
            foreach (Car thisCar in cars)
            {
                Console.Write(thisCar.Color.PadRight(5) + " ");
                Console.Write(thisCar.Speed.ToString() + " ");
                Console.Write(thisCar.Name);
                Console.WriteLine();
            }

            // Output:  
            //  blue  50 car4  
            //  blue  30 car5  
            //  blue  20 car1  
            //  green 50 car7  
            //  green 10 car3  
            //  red   60 car6  
            //  red   50 car2  
        }

        public class Car : IComparable<Car>
        {
            public string Name { get; set; }
            public int Speed { get; set; }
            public string Color { get; set; }

            public int CompareTo(Car other)
            {
                // A call to this method makes a single comparison that is  
                // used for sorting.  

                // Determine the relative order of the objects being compared.  
                // Sort by color alphabetically, and then by speed in  
                // descending order.  

                // Compare the colors.  
                int compare;
                compare = String.Compare(this.Color, other.Color, true);

                // If the colors are the same, compare the speeds.  
                if (compare == 0)
                {
                    compare = this.Speed.CompareTo(other.Speed);

                    // Use descending order for speed.  
                    compare = -compare;
                }

                return compare;
            }
        }
    }
}
