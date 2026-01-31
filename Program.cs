using System.Text;
using System.Globalization;
using Managmant;
using SecondFunction; 
using Searching;
using Applicationstatus;
using Deleting;

namespace MainMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding  = Encoding.UTF8;

            var culture = new CultureInfo("de-DE");
            Thread.CurrentThread.CurrentCulture   = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            Show();
        }

        public static void Show()
        {
            List<UserDate.Application> AllUsers = new List<UserDate.Application>();
            Console.Write("1. Neuen Antrag hinzufügen \n2. Alle Anträge anzeigen \n3. Antrag nach Unternehmen finden \n4. Status des Antrags ändern \n5. Antrag löschen \n0. Programm beenden \nSie haben eingegeben: ");
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
                        Remove delete = new Remove();
                        delete.RemoveFromList();
                        break;
                        default:
                        Console.WriteLine("Sie haben das Program beendet.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Sie haben einen Wert eingegeben, der außerhalb des zulässigen Bereichs liegt.");
                    Show();
                }
            }
            else
            {
                Console.WriteLine("Sie haben einen ungültigen Wert eingegeben.");
                Show();
            }
        }
    }
}
