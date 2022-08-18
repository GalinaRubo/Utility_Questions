
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace BDqus
{
	public class RedQ
	{
		public static void EditorQ()
		{
			string path = ChCat.ChoiceCategory();
			List<Question> listQ = new List<Question>();	
			string json = File.ReadAllText(path);
			int strBegin = 0;
		    int strEnd = 0;
			do
			{
				strBegin = json.IndexOf('{');
				if (strBegin == -1) break;
				strEnd = json.IndexOf('}');
				listQ.Add(JsonSerializer.Deserialize<Question>(json.Substring(strBegin, strEnd + 1)));
				json = json.Remove(strBegin, strEnd + 1);
			} while (strBegin != -1);
			string action;
			string finededQ;
			do
			{			
				Console.Write("Искать вопрос листая список или по подстроке в вопросе? 1 - список, 2 - подстрока: ");
				action = Console.ReadLine()!;
		    } while (action != "1" && action != "2");			
            if (action == "2") finededQ = ChooceQ(ref listQ);
            else finededQ = LeafQ(ref listQ);
			if (finededQ != null)
			{
				foreach (Question item in listQ)
				{
					if (item.Ques != finededQ) continue;
					{
						do
						{
							Console.Write("Удалить или редактировать вопрос? 1 - удалить, 2 - редактировать: ");
							action = Console.ReadLine()!;
						} while (action != "1" && action != "2");
						if (action == "2")
						{
							string Ques;
							string[] Unsers;
							int[] RightUnsers;
							Console.Write("Корректировать вопрос? д/н: ");
							if (Console.ReadLine() == "д") { Ques = CreateQuestions.SetQues(); }
							else { Ques = item.Ques; };
							Console.Write("Корректировать ответы? д/н: ");
							if (Console.ReadLine() == "д") { Unsers = CreateQuestions.SetUnsers(); }
							else { Unsers = item.Unsers; };
							Console.Write("Корректировать маски ответов? д/н: ");
							if (Console.ReadLine() == "д") { RightUnsers = CreateQuestions.SetRightUnsers(); }
							else { RightUnsers = item.RightUnsers; };
							Question question = new Question(Ques, Unsers, RightUnsers);
							listQ.Remove(item);
							listQ.Add(question);
							break;
						}
						else
						{
							listQ.Remove(item);
							break;
						}
					}
				}
			}
			else Console.Write("Такого вопроса не существует!");

			JsonSerializerOptions options = new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
				WriteIndented = true
			};
			FileStream file = new FileStream(path, FileMode.Truncate);
			file.Close();
			foreach (Question _item in listQ)
			{
				string jsonString = JsonSerializer.Serialize(_item, options);
				using (StreamWriter fw = File.AppendText(path))
				{
					fw.WriteLine(jsonString);
				}
			}			
		}
		static string ChooceQ(ref List <Question>_listQ)
		{
			Console.Write("Введите вопрос или часть вопроса: ");
			string word = Console.ReadLine()!;
			foreach (Question item in _listQ)
			{
				if (item.Ques.Contains(word) == true)
				{
					Console.WriteLine(item.Ques);
					Console.Write("Этот вопрос? д/н: ");
					if (Console.ReadLine() == "д")
						return item.Ques;
				}
            }
			return "";
         }
		static string LeafQ(ref List<Question> _listQ)
		{
			foreach (Question item in _listQ)
			{
				Console.WriteLine(item.Ques);
				Console.Write("Этот вопрос? д/н: ");
				if (Console.ReadLine() == "д")
						return item.Ques;
			}
			return "";
		}
		
	}
}
