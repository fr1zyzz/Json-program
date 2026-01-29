using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using Managmant;
using Searching;
using UserDate;
namespace Applicationstatus
{
    public class Changing
    {
        public void ChangeIt()
        {
            int res = 0;
            ApplicationManagment managment = new ApplicationManagment();
            managment.LoadFromJson();
            SearchForName search = new SearchForName();
            search.Search();
            Console.Write("Введите Id заявки, у которой вы хотите поменять статус. \n Вы ввели: ");
            Int32.TryParse(Console.ReadLine(), out int a);
            for(int i = 0; i < managment.allUsers?.Count; i++)
            {
                if(managment.allUsers[i].Id == a)
                {
                    res = i;
                    Status(a, res);
                }
            }
        void Status(int a, int res)
            {
                a--;
                Array status = Enum.GetValues(typeof(ApplicationStatus));
                Console.WriteLine("Вы нашли заявку по айди, какой статус вы хотите ей поставить?");
                Console.WriteLine("Доступны такие статусы:");
                for(int i = 0; i < status.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {(ApplicationStatus)status.GetValue(i)!}");
                }
                Console.WriteLine("0. Завершить программу без изменений.");
                Console.Write("Вы выбираете(цифру): ");
                Int32.TryParse(Console.ReadLine(), out int b);
                switch (b)
                {
                    case 1:
                    managment.allUsers[a].Status = (ApplicationStatus)status.GetValue(0)!;
                    Console.WriteLine("Статус успешно изменен!");
                    break;
                    case 2:
                    managment.allUsers[a].Status = (ApplicationStatus)status.GetValue(1)!;
                    Console.WriteLine("Статус успешно изменен!");
                    break;
                    case 3:
                    managment.allUsers[a].Status = (ApplicationStatus)status.GetValue(2)!;
                    Console.WriteLine("Статус успешно изменен!");
                    break;
                    case 4:
                    managment.allUsers[a].Status = (ApplicationStatus)status.GetValue(3)!;
                    Console.WriteLine("Статус успешно изменен!");
                    break;
                    case 0:
                    Console.WriteLine("Вы завершили программу без изменений.");
                    break;
                    default:
                    Console.WriteLine("Вы ввели неверное значение");
                    break;
                }
                managment.SaveToJson();
            }
        }
    }
}