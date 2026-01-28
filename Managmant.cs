using System.Net;
using System.Text.Json;
using UserDate;

namespace Managmant
{
    class ApplicationManagment
    {
        int id;
        DateTime ApplicationDate = DateTime.Now;
        List<Application> allUsers;
        public void DoUWantCreateNewUser()
        {
            string CompanyName;
            string Position;
            ApplicationStatus Status = ApplicationStatus.Sent;
            string Notes;
            Console.Write("Действительно ли вы хотите создать новую заявку? ");
            Console.Write("Введите имя вашей компании: ");
            CompanyName = Console.ReadLine();
            if (CompanyName == null)
            {
                Console.Write("Вы ввели неправильное значение");
                return;
            }
            Console.Write("Напишите позицию на которой вы работаете: ");
            Position = Console.ReadLine();
            if (Position == null)
            {
                Console.Write("Вы ввели неправильное значение");
                return;
            }
            Console.Write("Напишите информацию, которую вы хотите, чтобы мы обработали: ");
            Notes = Console.ReadLine();
            if (Notes == null)
            {
                Console.Write("Вы ввели неправильное значение");
                return;
            }


            CreateNewUser(id, CompanyName, Position, Status, Notes);
        }
        public void CreateNewUser(int id, string CompanyName, string Position, ApplicationStatus Status, string Notes)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "users.json");
            if (!File.Exists(path) || new FileInfo(path).Length == 0)
            {
                allUsers = new List<Application>();
            }
            else
            {
                string json = File.ReadAllText(path);
                allUsers = JsonSerializer.Deserialize<List<Application>>(json)
                           ?? new List<Application>();
            }
            if (allUsers == null || allUsers.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = allUsers.Count + 1;
            }

            Application newuser = new Application(id, CompanyName, Position, ApplicationDate, Status, Notes);
            allUsers?.Add(newuser);

            string newJson = JsonSerializer.Serialize(allUsers, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(path, newJson);
            Console.WriteLine("Заявка успешно добавлена.");
            return;
        }
    }
}