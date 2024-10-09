using System;
using System.ComponentModel.Design;

//Определяем перечисление курятников с курами
public enum Coop { coop1, coop2, coop3 }
class Program
{        
    static void Main()
    {
        bool live = true;
        int Egg = 0;
        Console.WriteLine("В какой курятник пойдем?");
        foreach (Coop coop in Enum.GetValues(typeof(Coop)))
        {
            Console.WriteLine($"Курятник: {Enum.GetName(typeof(Coop), coop)}");
        }

        string input = Console.ReadLine();
        if (Enum.TryParse(input, out Coop selectedCoop))
        {
            Console.WriteLine($"Вы выбрали: {selectedCoop}");
        }
        else
        {
            DisplayRedMessage("Неверный ввод.");
            live = false;
        }
        while (live)
        {

            Console.WriteLine($"Что будем делать?:\nПокормить курицу - 1 \nЗабрать яйцо - 2\nНичего не делать - 3");
            string? input1 = Console.ReadLine();
            int MenusPoint;
            if (int.TryParse(input1, out MenusPoint))
            {
                switch (MenusPoint)
                {
                    case 1:
                        Feed();
                        break;
                    case 2:
                        TakeEgg();
                        break;
                    case 3:
                        DoNothing();
                        break;                  

                }
            }
            else
            {
                Console.WriteLine("Неверный ввод.");
                live = false;
            }
            //int Menus = int.Parse(input1);
            
            if (!live)
            {
                DisplayRedMessage("WASTED");
                Console.WriteLine("Курица умерла...");
                Console.WriteLine($"Яиц: {Egg}");
            }
        }
        void TakeEgg()
        {
            Console.WriteLine("Забираем яйцо...");
            Egg--;
            live = false;
        }

        void DoNothing()
        {
            Console.WriteLine("Ничего не делаем");
            live = false;
        }
        void Feed()
        {
            Console.WriteLine("Введите количество зерен:");
            int cereal = Convert.ToInt32(Console.ReadLine());
            if (cereal < 3)
            {
                live = false;
            }
            else
            {
                Egg++;
            }
        }
        void DisplayRedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
