using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDqus
{
    internal static class ChCat
    {
        public static string ChoiceCategory()
        {
            Console.WriteLine("Категории вопросов:");
            Console.WriteLine("1. История");
            Console.WriteLine("2. Литература");
            Console.WriteLine("3. Биология");
            Console.WriteLine("4. География");
            Console.Write("Выберете категорию вопросов: ");
            int cat = Convert.ToInt32(Console.ReadLine());
            string path = "";
            switch (cat)
            {
                case 1:
                    path = @"QHistory";
                    break;
                case 2:
                    path = @"QLiterature";
                    break;
                case 3:
                    path = @"QBiology";
                    break;
                case 4:
                    path = @"QGeography";
                    break;
                default:
                    Console.WriteLine("Такой категории не существует");
                    return path;
            }
            return path;
        }
    }
}
