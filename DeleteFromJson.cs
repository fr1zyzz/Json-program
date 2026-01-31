using Managmant;
using Searching;
using SecondFunction;

namespace Deleting{
    public class Remove
    {
        ApplicationManagment managment = new ApplicationManagment();
        SearchForName search = new SearchForName();
        ShowAllList second = new ShowAllList();
        public void RemoveFromList()
        {
            managment.LoadFromJson();
            search.Search();
            Console.Write("Geben Sie die ID des Unternehmens ein, das Sie aus der Liste löschen möchten. \nSie haben eingegeben: ");
            Int32.TryParse(Console.ReadLine(), out int a);
            
            for(int i = 0; i < managment.allUsers?.Count(); i++)
            {
                if(managment.allUsers[i].Id == a)
                {
                    managment.allUsers?.RemoveAt(i);
                    Console.WriteLine("Der Antrag wurde erfolgreich gelöscht.");
                }
            }

            managment.SaveToJson();
            second.ShowAllLists();
        }
    }
}