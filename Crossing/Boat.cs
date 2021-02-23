using System;

namespace Crossing
{
    public class Boat
    {
        public Passager Passager { get; set; }
        public Coast Coast { get; set; }

        public Boat(Coast coast)
        {
            Coast = coast;
        }

        public string ShowState()
        {
            var boatState = $"Лодка у станции: {Coast.Name} берег{Environment.NewLine}";

            if (Passager != null)
            {
                boatState += $"Пассажир в лодке: {Passager.Name}";
            }
            else
            {
                boatState += "Лодка пуста";
            }

            return boatState;
        }

        public bool AddPassager(Passager passager)
        {
            if (Passager == null)
            {
                Passager = passager;
                Coast.Passagers.Remove(passager);
                return true;
            }
            else return false;
        }

        public void RemovePassager()
        {
            Passager = null;
        }

        public bool IsEmpty()
        {
            return Passager == null;
        }
    }
}
