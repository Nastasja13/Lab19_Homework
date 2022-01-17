using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19_Homework
{
    class Program
    {
        /*
         * Модель  компьютера  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,  частотой  работы  процессора,  
         * объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах 
         * и количеством экземпляров, имеющихся в наличии. 
         * Создать список, содержащий 6-10 записей с различным набором значений характеристик.
         * Определить:
         * - все компьютеры с указанным процессором. Название процессора запросить у пользователя;
         * - все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
         * - вывести весь список, отсортированный по увеличению стоимости;
         * - вывести весь список, сгруппированный по типу процессора;
         * - найти самый дорогой и самый бюджетный компьютер;
         * - есть ли хотя бы один компьютер в количестве не менее 30 штук?
         */
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                List<Computer> computers = new List<Computer>()
            {
                new Computer (){Id = "1", Name = "Марка", Cpu = "Тип процессора", FqCpu = 100, Ram = 4, Hd = 1000, Vc = 4, Price = 30, Number = 11},
                new Computer (){Id = "2", Name = "Hitachi", Cpu = "Intel 80486", FqCpu = 150, Ram = 4, Hd = 1000, Vc = 4, Price = 41, Number = 29},
                new Computer (){Id = "3", Name = "Apple", Cpu = "Pentium Pro", FqCpu = 180, Ram = 8, Hd = 1000, Vc = 11, Price = 97, Number = 14},
                new Computer (){Id = "4", Name = "Invasion Uran 235", Cpu = "Pentium", FqCpu = 800, Ram = 16, Hd = 2000, Vc = 48, Price = 2858, Number = 27},
                new Computer (){Id = "5", Name = "Intel", Cpu = "Pentium", FqCpu = 300, Ram = 16, Hd = 2000, Vc = 11, Price = 134, Number = 52},
                new Computer (){Id = "6", Name = "Intel", Cpu = "Pentium", FqCpu = 450, Ram = 16, Hd = 2000, Vc = 16, Price = 432, Number = 61},
                new Computer (){Id = "7", Name = "Alta", Cpu = "Pentium", FqCpu = 120, Ram = 8, Hd = 1000, Vc = 8, Price = 85, Number = 39},
            };

                Console.WriteLine($"Добро пожаловать в компьютерный магазин!\n" +
                    $"Выбирите интересующие вас действия:\n" +
                    $"- Для выбора компьютера по типу процессора, нажимте \"A\"\n" +
                    $"- Для выбора компьютера по объему оперативной памяти, нажмите \"BB\"\n" +
                    $"- Чтобы посмотреть все имеющиеся модели на складе по возрастанию стоимости, нажмите \"CCC\"\n" +
                    $"- Чтобы посмотреть модели по группировке типа процессора, нажмите \"DDDD\"\n" +
                    $"- Для просмотра самого дорогого компьютера, нажмите \"EEEEE\"\n" +
                    $"- Для просмотра самого дешевого компьютера, нажмите \"FFFFFF\"\n" +
                    $"- Для оптовых закупок: проверить наличие партии больше 30 шт., нажмите \"GGGGGGG\"\n");

                if (Console.ReadKey().Key == ConsoleKey.A)
                {
                    Console.Clear();
                    Console.WriteLine("Введите тип процессора");
                    string cpu = Console.ReadLine();
                    //выбрать только те компьютеры, у которых тип совпадает с введенным типом
                    List<Computer> computers1 = computers.Where(x => x.Cpu == cpu).ToList();
                    Print(computers1);
                    Console.WriteLine("\nНажмите \"Enter\", чтобы вернуться в меню.\n" +
                            "Для выхода, нажмите любую другую клавишу.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                else if (Console.ReadKey().Key == ConsoleKey.B)
                {
                    Console.Clear();
                    Console.WriteLine("Введите необходимый объем оперативной памяти");
                    int ram = Convert.ToInt32(Console.ReadLine());
                    List<Computer> computers2 = computers.Where(x => x.Ram >= ram).ToList();
                    Print(computers2);
                    Console.WriteLine("\nНажмите \"Enter\", чтобы вернуться в меню.\n" +
                            "Для выхода, нажмите любую другую клавишу.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                else if (Console.ReadKey().Key == ConsoleKey.C)
                {
                    Console.Clear();
                    Console.WriteLine("Имеющиеся в наличии модели по возрастанию стоимости");
                    //по увеличению стоимости
                    List<Computer> computers3 = computers.OrderBy(x => x.Price).ToList();
                    Print(computers3);
                    Console.WriteLine("\nНажмите \"Enter\", чтобы вернуться в меню.\n" +
                            "Для выхода, нажмите любую другую клавишу.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (Console.ReadKey().Key == ConsoleKey.D)
                {
                    Console.Clear();
                    Console.WriteLine("Группировка имеющихся на складе моделей по типу процессора");
                    //группировка по типу процессора
                    IEnumerable<IGrouping<string, Computer>> computers4 = computers.GroupBy(x => x.Cpu);
                    //перебрать коллекцию
                    foreach (IGrouping<string, Computer> gr in computers4)
                    {
                        Console.WriteLine(gr.Key); //общий параметр
                                                   //вывести все компы внутри группы с нужным типом процессора
                        foreach (Computer c in gr)
                        {
                            Console.WriteLine($"Код: {c.Id}. \nМарка: {c.Name }. \nТип процессора: {c.Cpu}. \nЧастота работы: {c.FqCpu}МГц. \nОбъем оперативной памяти: {c.Ram}Гб. \nОбъем жесткого диска: {c.Hd}Гб. \nОбъем памяти видеокарты: {c.Vc}Гб. \nСтоимость: {c.Price}тыс.руб. \nКолличество экземпляров, имеющихся в наличии: {c.Number} шт.\n");
                        }
                    }
                    Console.WriteLine("\nНажмите \"Enter\", чтобы вернуться в меню.\n" +
                            "Для выхода, нажмите любую другую клавишу.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                else if (Console.ReadKey().Key == ConsoleKey.E)
                {
                    Console.Clear();
                    Console.WriteLine("Самый дорогой компьютер");
                    Computer computerMax = computers.OrderByDescending(x => x.Price).FirstOrDefault();
                    Console.WriteLine($"Код: {computerMax.Id}. \nМарка: {computerMax.Name }. \nТип процессора: {computerMax.Cpu}. \nЧастота работы: {computerMax.FqCpu}МГц. \nОбъем оперативной памяти: {computerMax.Ram}Гб. \nОбъем жесткого диска: {computerMax.Hd}Гб. \nОбъем памяти видеокарты: {computerMax.Vc}Гб. \nСтоимость: {computerMax.Price}тыс.руб. \nКолличество экземпляров, имеющихся в наличии: {computerMax.Number} шт.\n");
                    Console.WriteLine("\nНажмите \"Enter\", чтобы вернуться в меню.\n" +
                            "Для выхода, нажмите любую другую клавишу.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                else if (Console.ReadKey().Key == ConsoleKey.F)
                {
                    Console.Clear();
                    Console.WriteLine("Самый дешевый компьютер");
                    Computer computerMin = computers.OrderBy(x => x.Price).FirstOrDefault();
                    Console.WriteLine($"Код: {computerMin.Id}. \nМарка: {computerMin.Name }. \nТип процессора: {computerMin.Cpu}. \nЧастота работы: {computerMin.FqCpu}МГц. \nОбъем оперативной памяти: {computerMin.Ram}Гб. \nОбъем жесткого диска: {computerMin.Hd}Гб. \nОбъем памяти видеокарты: {computerMin.Vc}Гб. \nСтоимость: {computerMin.Price}тыс.руб. \nКолличество экземпляров, имеющихся в наличии: {computerMin.Number} шт.\n");
                    Console.WriteLine("\nНажмите \"Enter\", чтобы вернуться в меню.\n" +
                            "Для выхода, нажмите любую другую клавишу.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                else if (Console.ReadKey().Key == ConsoleKey.G)
                {
                    Console.Clear();
                    //компьютер в кол-ве не меньше 30 шт. с ответом да или нет. Есть ли хотябы один?
                    Console.WriteLine("Есть ли на складе партия компьютеров в количестве больше 30 штук?");
                    if (computers.Any(x => x.Number > 30))
                    {
                        Console.WriteLine("На складе есть партия в количестве больше 30 штук.");
                        Console.WriteLine("\nНажмите \"Enter\", чтобы вернуться в меню.\n" +
                            "Для выхода, нажмите любую другую клавишу.");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Партии на складе в недостаточном колличестве.");
                        Console.WriteLine("\nНажмите \"Enter\", чтобы вернуться в меню.\n" +
                            "Для выхода, нажмите любую другую клавишу.");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            
                else
                {
                    Console.Clear();
                    Console.WriteLine("Нажмите клавишу \"Enter\", чтобы сделать выбор.\n" +
                        "Для выхода, нажмите любую другую клавишу.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

            }
        }
        //Метод получает список компьютеров и выводит на экран
        static void Print(List<Computer> computers)
        {
            //перебор всех в коллекции и вывод по каждому информации
            foreach (Computer c in computers)
            {
                Console.WriteLine($"Код: {c.Id}. \nМарка: {c.Name }. \nТип процессора: {c.Cpu}. \nЧастота работы: {c.FqCpu}МГц. \nОбъем оперативной памяти: {c.Ram}Гб. \nОбъем жесткого диска: {c.Hd}Гб. \nОбъем памяти видеокарты: {c.Vc}Гб. \nСтоимость: {c.Price}тыс.руб. \nКолличество экземпляров, имеющихся в наличии: {c.Number} шт.\n");
            }
            Console.WriteLine();
        }
    }
}
