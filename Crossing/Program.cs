using System;
using System.Threading;

namespace Crossing
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            while (true)
            {
                Console.WriteLine(game.ShowMission());
                Console.WriteLine();
                Console.WriteLine(game.ShowControlKey());
                Console.WriteLine();
                Console.WriteLine(game.ShowState());
                Console.WriteLine();

                var boat = game.Boat;
                var currentCoast = boat.Coast;

                Console.WriteLine($"Выберите ваше действие:");

                var pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {
                    case ConsoleKey.Spacebar:

                        if (boat.IsEmpty() == false)
                        {
                            Console.WriteLine($"В лодке уже находится пассажир {boat.Passager.Name}.");
                            Console.WriteLine("Вы не можете посадить в лодку больше одного пассажира");
                            Thread.Sleep(3000);
                            break;
                        }

                        if (currentCoast.IsEmpty())
                        {
                            Console.WriteLine($"На станции {currentCoast.Name} берег нет пассажиров.");
                            Thread.Sleep(2000);
                            break;
                        }

                        var boardingIsComplieted = BoardingPasseger(boat);
                        if (boardingIsComplieted == false) break;

                        break;

                    case ConsoleKey.Delete:

                        if (boat.IsEmpty())
                        {
                            Console.WriteLine("В лодке нет пассажиров");
                            Thread.Sleep(2000);
                            break;
                        }

                        currentCoast.Passagers.Add(boat.Passager);
                        boat.RemovePassager();

                        break;

                    case ConsoleKey.LeftArrow:

                        if (CanStayPassegers(currentCoast) == false)
                            break;

                        boat.Coast = game.LeftCoast;

                        if (boat.Passager != null)
                        {
                            boat.Coast.Passagers.Add(boat.Passager);
                            boat.Passager = null;
                        }
                        break;

                    case ConsoleKey.RightArrow:

                        if (CanStayPassegers(currentCoast) == false)
                            break;

                        boat.Coast = game.RightCoast;

                        if (boat.Passager != null)
                        {
                            boat.Coast.Passagers.Add(boat.Passager);
                            boat.Passager = null;
                        }
                        break;

                    default:
                        break;
                }

                if (game.IsEnd())
                {
                    Console.WriteLine("Игра окончена. Вы выиграли!");
                    break;
                }

                Console.Clear();
            }
        }

        private static bool BoardingPasseger(Boat boat)
        {
            Console.WriteLine("Введите номер пассажира, которого хотите перевезти, и нажмите клавишу ENTER");

            var userInput = Console.ReadLine();

            var inputIsNumber = int.TryParse(userInput, out var inputPassegerId);

            if (inputIsNumber == false)
            {
                Console.WriteLine("Нужно ввести число - номер пассажира.");
                Thread.Sleep(2000);
                return false;
            }

            var currentCoast = boat.Coast;
            var selectedPasseger = currentCoast.GetPassager(inputPassegerId);

            if (selectedPasseger == null)
            {
                Console.WriteLine("Пассажира с таким номером нет на этом берегу");
                Thread.Sleep(2000);
                return false;
            }

            var boarding = boat.AddPassager(selectedPasseger);
            if (boarding)
            {
                currentCoast.Passagers.Remove(selectedPasseger);
            }

            Console.WriteLine($"Пассажир {selectedPasseger.Name} в лодке.");
            Thread.Sleep(2000);
            return true;
        }

        private static bool CanStayPassegers(Coast coast)
        {
            var compatibility = coast.CheckCompatibility(coast.Passagers);

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
