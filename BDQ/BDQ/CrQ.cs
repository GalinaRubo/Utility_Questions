
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
namespace BDqus
{
	internal class CreateQuestions
	{
		public static void CreateQ()
		{
            do
            {
                string path = ChCat.ChoiceCategory();               
                do
                {
                    string Ques = SetQues();
                    string[] Unsers = SetUnsers();
                    int[] RightUnsers = SetRightUnsers();
					Console.Write("Записать вопрос в файл?(д/н): ");
                    if (Console.ReadLine() != "д") break;
					Question question = new Question(Ques, Unsers, RightUnsers);
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                        WriteIndented = true
                    };
                    string jsonString = JsonSerializer.Serialize(question, options);
                    //                    Console.WriteLine(jsonString);
                    using (StreamWriter fw = File.AppendText(path))
                    {
                        fw.WriteLine(jsonString);
                    }
                    Console.Write("Продолжить ввод?(д/н): ");
                } while (Console.ReadLine() == "д");
                Console.Write("Выбрать другую категорию?(д/н): ");
            } while (Console.ReadLine() == "д");
            return;
        }
        public static string SetQues()
        {
            string str;
            do
            {
                Console.WriteLine("Введите вопрос: ");
                 str = Console.ReadLine();
            } while (str == "");            
			return str;
		}
        public static string[] SetUnsers()
        {
            string[] unsers = new string[4];
            Console.WriteLine("Введите последовательно четыре ответа");
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    Console.Write("Введите ответ: ");
                    unsers[i] = Console.ReadLine();
                } while (unsers[i] == "");
            }
            return unsers;
        }
        public static int[] SetRightUnsers()
        {
            int[] rightUnsers = new int[4];
            Console.WriteLine("Введите последовательно маски ответов: 1 - верный, 0 - неверный ");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Введите ответ: ");
                rightUnsers[i] = Convert.ToInt32(Console.ReadLine());
                while (rightUnsers[i] != 0 && rightUnsers[i] != 1)
                {
                    Console.Write("Введите маски ответов корректно: 1 - верный, 0 - неверный ");
                    Console.Write("Введите ответ: ");
                    rightUnsers[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return rightUnsers;
        }

    }
}
