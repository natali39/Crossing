using System;
using System.Collections.Generic;

namespace Crossing
{
    public class Game
    {
        public Coast LeftCoast { get; set; }
        public Coast RightCoast { get; set; }
        public Boat Boat { get; set; }
        public List<Passenger> Passengers { get; set; }

        public Game()
        {
            Passengers = GetPassengers();
            LeftCoast = new Coast("Левый");
            RightCoast = new Coast("Правый");
            LeftCoast.Passengers = Passengers;
            Boat = new Boat(LeftCoast);
        }

        public bool IsEnd()
        {
            return RightCoast.Passengers.Count == 3;
        }

        private List<Passenger> GetPassengers()
        {
            return new List<Passenger>
            {
                new Passenger(1, "Волк", "Коза"),
                new Passenger(2, "Коза", "Капуста"),
                new Passenger(3, "Капуста", "")
            };
        }

        public string ShowMission()
        {
            return
                $"Крестьянину нужно перевезти через реку волка, козу и капусту.{Environment.NewLine}" +
                $"Но лодка такова, что в ней может поместиться только крестьянин, а с ним{Environment.NewLine}" +
                $"или одна коза, или один волк, или одна капуста. Но если оставить волка с козой,{Environment.NewLine}" +
                $"то волк съест козу, а если оставить козу с капустой, то коза съест капусту.{Environment.NewLine}" +
                $"Попробуйте переправить волка, козу и капусту на правый берег таким образом,{Environment.NewLine}" +
                $"чтобы никто из них не пострадал.{Environment.NewLine}" +
                "*******************************************************************************";
        }

        public string ShowState()
        {
            return $"{LeftCoast.GetPassengersInfo()}{Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"{RightCoast.GetPassengersInfo()}{Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"{Boat.ShowState()}{Environment.NewLine}";
        }

        public string ShowControlKey()
        {
            return $"Возможые действия:{Environment.NewLine}" +
                   $"Посмотреть описание игры: клавиша HOME{Environment.NewLine}" +
                   $"Посадить пассажира в лодку: клавиша SPACE{Environment.NewLine}" +
                   $"Высадить пассажира из лодки: клавиша DELETE{Environment.NewLine}" +
                   $"Переправить лодку на другой берег: стрелка <- ВЛЕВО или ВПРАВО ->{Environment.NewLine}";
        }
    }
}
