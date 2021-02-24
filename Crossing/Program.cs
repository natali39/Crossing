using System;
using System.Collections.Generic;
using System.Threading;

namespace Crossing
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            Console.WriteLine(game.ShowMission());
            Console.WriteLine("Нажмите любую клавишу, чтобы начать игру.");
            Console.ReadKey();

            while (true)
            {
                Console.Clear();
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
                            Console.WriteLine($"В лодке уже находится пассажир {boat.Passeger.Name}.");
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

                        Console.WriteLine("Введите номер пассажира, которого хотите перевезти, и нажмите клавишу ENTER");

                        var userInput = Console.ReadLine();

                        if (int.TryParse(userInput, out var inputPassengerId) == false)
                        {
                            Console.WriteLine("Нужно ввести число - номер пассажира.");
                            Thread.Sleep(2000);
                            break;
                        }

                        var selectedPassenger = currentCoast.GetPassager(inputPassengerId);

                        if (selectedPassenger == null)
                        {
                            Console.WriteLine("Пассажира с таким номером нет на этом берегу");
                            Thread.Sleep(2000);
                            break;
                        }

                        boat.AddPassager(selectedPassenger);

                        Console.WriteLine($"Пассажир {selectedPassenger.Name} в лодке.");
                        Thread.Sleep(2000);
                        break;

                    case ConsoleKey.Delete:

                        if (boat.IsEmpty())
                        {
                            Console.WriteLine("В лодке нет пассажиров");
                            Thread.Sleep(2000);
                            break;
                        }

                        boat.RemovePassager();
                        break;

                    case ConsoleKey.LeftArrow:
                        if (currentCoast == game.LeftCoast)
                        {
                            Console.WriteLine("Вы уже на левом берегу.");
                            Thread.Sleep(2000);
                            break;
                        }

                        if (currentCoast.CanStayPassengers() == false)
                            break;

                        boat.Coast = game.LeftCoast;
                        break;

                    case ConsoleKey.RightArrow:
                        if (currentCoast == game.RightCoast)
                        {
                            Console.WriteLine("Вы уже на правом берегу.");
                            Thread.Sleep(2000);
                            break;
                        }

                        if (currentCoast.CanStayPassengers() == false)
                            break;

                        boat.Coast = game.RightCoast;
                        break;

                    case ConsoleKey.Home:
                        Console.Clear();
                        Console.WriteLine(game.ShowMission());
                        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить игру.");
                        Console.ReadKey();
                        break;

                    default:
                        break;
                }

                if (game.IsEnd())
                {
                    Console.WriteLine("Игра окончена. Вы выиграли!");
                    break;
                }
            }
        }
    }
}
