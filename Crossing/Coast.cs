using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossing
{
    public class Coast
    {
        public string Name { get; set; }
        public List<Passager> Passagers { get; set; }
        public bool boat { get; set; }
        public Coast(string name)
        {
            Name = name;
            Passagers = new List<Passager>();
        }

        public string GetPassagersInfo()
        {
            var passagersInfo = $"Пассажиры на станции {Name} берег (количество {Passagers.Count}):{Environment.NewLine}";

            foreach (var passager in Passagers)
            {
                passagersInfo += $"{passager.Name} ({passager.Id}){Environment.NewLine}";
            }

            return passagersInfo;
        }

        public bool IsEmpty()
        {
            return Passagers.Count == 0;
        }

        public Passager GetPassager(int passagerId)
        {
            return Passagers.Where(p => p.Id == passagerId).FirstOrDefault();
        }

        public bool CheckCompatibility(List<Passager> passegers)
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
    }
}
