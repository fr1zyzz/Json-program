using Managmant;
using SecondFunction; 
using Searching;
using Applicationstatus;
using System.Runtime.InteropServices.Marshalling;

namespace MainMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Show();
        }

        public static void Show()
        {
            List<UserDate.Application> AllUsers = new List<UserDate.Application>();
            Console.Write("1. Добавить новую заявку \n2. Показать все заявки \n3. Найти заявку по компании \n4. Изменить статус заявки \n5. Удалить заявку \n0. Завершить программу \nВы ввели: ");
            if(Int32.TryParse(Console.ReadLine(), out int abeme))
            {
                if(abeme <= 6 && abeme > 0 || abeme == 0)
                {
                    switch (abeme)
                    {
                        case 1: 
                        ApplicationManagment manager = new ApplicationManagment();
                        manager.DoUWantCreateNewUser();
                        break;
                        case 2: 
                        ShowAllList Show = new ShowAllList();
                        Show.ShowAllLists();
                        break;
                        case 3: 
                        SearchForName ser = new SearchForName();
                        ser.Search();
                        break;
                        case 4: 
                        Changing status = new Changing();
                        status.ChangeIt();
                        break;
                        case 5: 
                        Console.WriteLine("Вы выбрали пункт 5.");
                        break;
                        default:
                        Console.WriteLine("Вы завершили программу.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели значение выше/ниже доступного.");
                    Show();
                }
            }
            else
            {
                Console.WriteLine("Вы ввели неверное значение.");
                Show();
            }
        }
    }
}
