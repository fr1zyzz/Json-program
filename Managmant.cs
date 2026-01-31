using System.Text.Json;
using UserDate;
using System.Text;
using System.Text.Encodings.Web;

namespace Managmant
{
    public class ApplicationManagment
    {
        int id;
        DateTime ApplicationDate = DateTime.Now;
        public List<Application>? allUsers;
        string path = Path.Combine(AppContext.BaseDirectory, "users.json");

        public void LoadFromJson()
        {
            if (!File.Exists(path) || new FileInfo(path).Length == 0)
            {
                allUsers = new List<Application>();
                return;
            }

            string json = File.ReadAllText(path, Encoding.UTF8);
            allUsers = JsonSerializer.Deserialize<List<Application>>(json) ?? new List<Application>();
        }

        public void SaveToJson()
        {
            string json = JsonSerializer.Serialize(allUsers, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(path, json, Encoding.UTF8);
        }
        public void DoUWantCreateNewUser()
        {
            ApplicationStatus Status = ApplicationStatus.Sent;
            Console.Write("Um mit dem Ausfüllen des Antrags zu beginnen, geben Sie den Namen des Unternehmens ein, in dem Sie arbeiten: ");
            string? CompanyName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(CompanyName))
            {
                Console.Write("Sie haben einen ungültigen Wert eingegeben.");
                return;
            }
            Console.Write("Schreiben Sie die Position, in der Sie arbeiten: ");
            string? Position = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Position))
            {
                Console.Write("Sie haben einen ungültigen Wert eingegeben.");
                return;
            }
            Console.Write("Schreiben Sie die Informationen, die Sie möchten, dass wir verarbeiten: ");
            string? Notes = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Notes))
            {
                Console.Write("Sie haben einen ungültigen Wert eingegeben.");
                return;
            }


            CreateNewUser(CompanyName, Position, Status, Notes);
        }
        public void CreateNewUser(string CompanyName, string Position, ApplicationStatus Status, string Notes)
        {
            int res = 0;
            string path = Path.Combine(AppContext.BaseDirectory, "users.json");
            LoadFromJson();
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
            SaveToJson();
            Console.WriteLine("Der Antrag wurde erfolgreich hinzugefügt.");
            return;
        }
    }
}
