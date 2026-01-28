using System.Text.Json;
using UserDate;
using Managmant;
namespace SecondFunction

{
    class ShowAllList
    {
        public void ShowAllLists()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "users.json");
            if (!File.Exists(path) || new FileInfo(path).Length == 0)
            {
                Console.WriteLine("Список является пустым.");
            }
                string json = File.ReadAllText(path);
                Console.WriteLine($"Вот полный список: \n{json}");
        }
    }
}