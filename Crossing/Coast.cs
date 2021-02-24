using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossing
{
    public class Coast
    {
        public string Name { get; set; }
        public List<Passenger> Passengers { get; set; }
        public bool boat { get; set; }
        public Coast(string name)
        {
            Name = name;
            Passengers = new List<Passenger>();
        }

        public string GetPassengersInfo()
        {
            var passagersInfo = $"Пассажиры на станции {Name} берег (количество {Passengers.Count}):{Environment.NewLine}";

            foreach (var passager in Passengers)
            {
                passagersInfo += $"{passager.Name} ({passager.Id}){Environment.NewLine}";
            }

            return passagersInfo;
        }

        public bool IsEmpty()
        {
            return Passengers.Count == 0;
        }

        public Passenger GetPassager(int passagerId)
        {
            return Passengers.Where(p => p.Id == passagerId).FirstOrDefault();
        }

        public bool CheckCompatibility(List<Passenger> passegers)
        {
            foreach (var passeger in passegers)
            {
                var food = passeger.Food;
                foreach (var p in passegers)
                {
                    if (p.Name == food)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CanStayPassengers()
        {
            var compatibility = CheckCompatibility(Passengers);

            if (compatibility == false)
            {
                Console.WriteLine("Вы не cможете покинуть этот берег, т.к. оставшиеся на берегу пассажиры несовместимы.");
                Console.WriteLine("Для продолжения нажмите ENTER");
                Console.ReadLine();

                return false;
            }
            return true;
        }
    }
}
