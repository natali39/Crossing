using System;
using System.Collections.Generic;

namespace Crossing
{
    public class Game
    {
        public Coast LeftCoast { get; set; }
        public Coast RightCoast { get; set; }
        public Boat Boat { get; set; }
        public List<Passager> Passagers { get; set; }

        public Game()
        {
            Passagers = GetPassagers();
            LeftCoast = new Coast("Левый");
            RightCoast = new Coast("Правый");
            LeftCoast.Passagers = Passagers;
            Boat = new Boat(LeftCoast);
        }

        public bool IsEnd()
        {
            return RightCoast.Passagers.Count == 3;
        }

        private List<Passager> GetPassagers()
        {
            return new List<Passager>
            {
                new Passager(1, "Волк", "Коза"),
                new Passager(2, "Коза", "Капуста"),
                new Passager(3, "Капуста", "")
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
            return $"{LeftCoast.GetPassagersInfo()}{Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"{RightCoast.GetPassagersInfo()}{Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"{Boat.ShowState()}{Environment.NewLine}";
        }

        public string ShowControlKey()
        {
            return $"Возможые действия:{Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"Загрузить пассажира в лодку: клавиша SPACE{Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"Убрать пассажира из лодки: клавиша DELETE{Environment.NewLine}" +
                   $"{Environment.NewLine}" +
                   $"Переправить лодку на другой берег: стрелка <- ВЛЕВО или ВПРАВО ->{Environment.NewLine}";
        }
    }
}
