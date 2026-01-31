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
            Console.Write("Geben Sie die ID des Antrags ein, dessen Status Sie ändern möchten. \nSie haben eingegeben: ");
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
                Console.WriteLine("Sie haben den Antrag nach der ID gefunden, welchen Status möchten Sie ihm zuweisen?");
                Console.WriteLine("Folgende Stati sind verfügbar:");
                for(int i = 0; i < status.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {(ApplicationStatus)status.GetValue(i)!}");
                }
                Console.WriteLine("Programm ohne Änderungen beenden.");
                Console.Write("Sie wählen (Zahl): ");
                Int32.TryParse(Console.ReadLine(), out int b);
                switch (b)
                {
                    case 1:
                    managment.allUsers[a].Status = (ApplicationStatus)status.GetValue(0)!;
                    Console.WriteLine("Der Status wurde erfolgreich geändert!");
                    break;
                    case 2:
                    managment.allUsers[a].Status = (ApplicationStatus)status.GetValue(1)!;
                    Console.WriteLine("Der Status wurde erfolgreich geändert!");
                    break;
                    case 3:
                    managment.allUsers[a].Status = (ApplicationStatus)status.GetValue(2)!;
                    Console.WriteLine("Der Status wurde erfolgreich geändert!");
                    break;
                    case 4:
                    managment.allUsers[a].Status = (ApplicationStatus)status.GetValue(3)!;
                    Console.WriteLine("Der Status wurde erfolgreich geändert!");
                    break;
                    case 0:
                    Console.WriteLine("Sie haben das Programm ohne Änderungen beendet.");
                    break;
                    default:
                    Console.WriteLine("Sie haben einen ungültigen Wert eingegeben");
                    break;
                }
                managment.SaveToJson();
            }
        }
    }
}