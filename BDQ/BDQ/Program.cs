using System.Text.Json;
using static BDqus.CreateQuestions;
using static BDqus.RedQ;

namespace BDqus // Note: actual namespace depends on the project name.
{
	internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите логин: ");
            string log = Console.ReadLine()!;
            Console.Write("Введите пароль: ");
            string pas = Console.ReadLine()!;           
            string jsonString = File.ReadAllText("Password.json");
//            Console.Write(jsonString);
            Autor autor = JsonSerializer.Deserialize<Autor>(jsonString)!;
            if (autor.Login != log || autor.Password != pas)
            {
                Console.Write("Неверно задан логин или пароль");
                return;
            }
            string action;
            do
            {                
                do
                {
                    Console.Write("Редактировать или добавлять вопросы ? 1 - редактировать, 2 - добавлять: ");
                    action = Console.ReadLine()!;
                } while (action != "1" && action != "2");
                if (action == "2") CreateQ();
                else EditorQ();
                Console.Write("Продолжим работу? д/н: ");
                action = Console.ReadLine()!;
            } while (action == "д");
            Console.Write("До встречи!");
        }
             public class Autor
        {
            public string? Login { get; }
            public string? Password { get; }
            public Autor(string? login, string? password)
            {
                Login = login;
                Password = password;
            }
        }
    }
}


 