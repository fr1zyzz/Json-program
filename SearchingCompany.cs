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
            Console.Write("Для поиска компании по ее названии, \nвведите название компании:");
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
                    Console.WriteLine($"Вот заявка которая была найдена по вашему запросу: \nId: {managment.allUsers?[i].Id}\nCompany Name: {managment.allUsers?[i].CompanyName}\nPosition: {managment.allUsers?[i].Position}\nApplicationDate: {managment.allUsers?[i].ApplicationDate}\nStatus: {managment.allUsers?[i].Status}\nNotes: {managment.allUsers?[i].Notes}");
                    ifNotTrue = i + 1;
                    Check(res);
                    return;
                }
            }
            Console.WriteLine("Ничего не было найдено");
            return;
        }
        public void Check(string res)
        {
            Console.WriteLine("Если ваша заявка была найдена не правильно нажмите <1>, если была найдена правильно нажмите <0>");
            Int32.TryParse(Console.ReadLine(), out int a);
            switch (a)
            {
                case 1:
                    Console.WriteLine("Поиск будет проведен заново.");
                    Searching(res);
                    break;
                case 0:
                    Console.WriteLine("Спасибо что помогаете становится лучше!");
                    ifNotTrue = 0;
                    break;
            }
        }
    }
}