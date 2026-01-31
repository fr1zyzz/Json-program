using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;
using Managmant;
using System.Text.Json;

namespace Searching
{
    public class SearchForName
    {
        int ifNotTrue = 0;
        ApplicationManagment managment = new ApplicationManagment();
        public void Search()
        {   
            Console.Write("Um ein Unternehmen nach seinem Namen zu suchen, \ngeben Sie den Namen des Unternehmens ein: ");
            string? res = Console.ReadLine()!.ToLowerInvariant();
            Searching(res);
        }
        public void Searching(string res)
        {
            managment.LoadFromJson();
            for (int i = ifNotTrue; i < managment.allUsers?.Count; i++)
            {
                if (managment.allUsers[i].CompanyName.ToLowerInvariant().Contains(res))
                {
                    Console.WriteLine($"Hier ist der Antrag, der auf Ihre Anfrage hin gefunden wurde: \nId: {managment.allUsers?[i].Id}\nCompany Name: {managment.allUsers?[i].CompanyName}\nPosition: {managment.allUsers?[i].Position}\nApplicationDate: {managment.allUsers?[i].ApplicationDate}\nStatus: {managment.allUsers?[i].Status}\nNotes: {managment.allUsers?[i].Notes}");
                    ifNotTrue = i + 1;
                    Check(res);
                    return;
                }
            }
            Console.WriteLine("Nichts wurde gefunden");
            return;
        }
        public void Check(string res)
        {
            Console.WriteLine("Wenn Ihr Antrag falsch gefunden wurde, drücken Sie <1>, wenn er korrekt gefunden wurde, drücken Sie <0>");
            Int32.TryParse(Console.ReadLine(), out int a);
            switch (a)
            {
                case 1:
                    Console.WriteLine("Die Suche wird erneut durchgeführt.");
                    Searching(res);
                    break;
                case 0:
                    Console.WriteLine("Vielen Dank, dass Sie helfen, besser zu werden!");
                    ifNotTrue = 0;
                    break;
            }
        }
    }
}