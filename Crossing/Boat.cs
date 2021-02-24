using System;

namespace Crossing
{
    public class Boat
    {
        public Passenger Passeger { get; set; }
        public Coast Coast { get; set; }

        public Boat(Coast coast)
        {
            Coast = coast;
        }

        public string ShowState()
        {
            var boatState = $"Лодка у станции: {Coast.Name} берег{Environment.NewLine}";

            if (Passeger != null)
            {
                boatState += $"Пассажир в лодке: {Passeger.Name}";
            }
            else
            {
                boatState += "Лодка пуста";
            }

            return boatState;
        }

        public bool AddPassager(Passenger passager)
        {
            if (Passeger == null)
            {
                Passeger = passager;
                Coast.Passengers.Remove(passager);
                return true;
            }
            else return false;
        }

        public void RemovePassager()
        {
            if (Passeger != null)
            {
                Coast.Passengers.Add(Passeger);
                Passeger = null;
            }
        }

        public bool IsEmpty()
        {
            return Passeger == null;
        }
    }
}
