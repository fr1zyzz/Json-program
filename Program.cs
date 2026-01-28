using System.Diagnostics.Contracts;
using Managmant;

namespace MainMenu
{
    class Menu
    {
        static void Main()
        {
            List<UserDate.Application> AllUsers = new List<UserDate.Application>();
            Console.Write("1. Добавить новую заявку \n2. Показать все заявки \n3. Найти заявку по компании \n4. Изменить статус заявки \n5. Удалить заявку \n6. Сохранить и выйти \n0. Завершить программу \nВы ввели: ");
            if(Int32.TryParse(Console.ReadLine(), out int abeme))
            {
                if(abeme <= 6 && abeme > 0 || abeme == 0)
                {
                    switch (abeme)
                    {
                        case 1: 
                        Console.WriteLine("Вы выбрали пункт 1.");
                        ApplicationManagment manager = new ApplicationManagment();
                        manager.DoUWantCreateNewUser();
                        break;
                        case 2: 
                        Console.WriteLine("Вы выбрали пункт 2.");
                        break;
                        case 3: 
                        Console.WriteLine("Вы выбрали пункт 3.");
                        break;
                        case 4: 
                        Console.WriteLine("Вы выбрали пункт 4.");
                        break;
                        case 5: 
                        Console.WriteLine("Вы выбрали пункт 5.");
                        break;
                        case 6: 
                        Console.WriteLine("Вы выбрали пункт 6.");
                        break;
                        default:
                        Console.WriteLine("Вы завершили программу.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели значение выше/ниже доступного.");
                    Main();
                }
            }
            else
            {
                Console.WriteLine("Вы ввели неверное значение.");
                Main();
            }
                
        }
    }
}
