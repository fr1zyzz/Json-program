using System.Text;

namespace SecondFunction

{
    public class ShowAllList
    {
        public void ShowAllLists()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "users.json");
            if (!File.Exists(path) || new FileInfo(path).Length == 0)
            {
                Console.WriteLine("Die Liste ist leer.");
                return;
            }

            string json = File.ReadAllText(path, Encoding.UTF8);
            Console.WriteLine($"Hier ist die vollständige Liste: \n{json}");
            
        }
    }
} 