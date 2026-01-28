using System.Net;
using System.Text.Json;
using UserDate;

namespace Managmant
{
    class ApplicationManagment
    {
        int id;
        DateTime ApplicationDate = DateTime.Now;
        List<Application>? allUsers;
        public void DoUWantCreateNewUser()
        {
            ApplicationStatus Status = ApplicationStatus.Sent;
            Console.Write("Чтобы начать заполнение заявки введите имя компании в которой вы работаете: ");
            string? CompanyName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(CompanyName))
            {
                Console.Write("Вы ввели неправильное значение");
                return;
            }
            Console.Write("Напишите позицию на которой вы работаете: ");
            string? Position = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Position))
            {
                Console.Write("Вы ввели неправильное значение");
                return;
            }
            Console.Write("Напишите информацию, которую вы хотите, чтобы мы обработали: ");
            string? Notes = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Notes))
            {
                Console.Write("Вы ввели неправильное значение");
                return;
            }


            CreateNewUser(CompanyName, Position, Status, Notes);
        }
        public void CreateNewUser(string CompanyName, string Position, ApplicationStatus Status, string Notes)
        {
            int res = 0;
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
                for(int i = 0; i < allUsers.Count; i++)
                {
                    if(allUsers[i].Id > res)
                    {
                        res = allUsers[i].Id;
                    }
                }
            }

            id = res + 1;

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