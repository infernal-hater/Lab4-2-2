using System.Text;

namespace lab_4_2_2
{
    class Program
    {
        
        public static void Main()
        {
            string path; // Путь до файла. Вводится пользователем.
            int count, maxcount = -1; // Здесь хранится число вхождений слова в строку.
            int maxlength = 0; // Здесь будет храниться длина самого длинного слова.
            int i, tmp = 0;

            do
            {
                Console.Write("Enter the file path: ");
                path = Console.ReadLine(); // Читаем путь к файлу с текстом.
            } while (!File.Exists(path));
            Stack<string> stack = new Stack<string>(); // Стек, здесь будут лежать самые длинные слова.
            string line = File.ReadAllText(path, Encoding.Default); // Читаем весь текст с файла.
            string[] words = line.Split(new string[] { " ", "\r\n", "\t" }, StringSplitOptions.RemoveEmptyEntries); // Разбиваем строку
                                                                                                                     // на массив слов.
            for (i = 0; i < words.Length; i++) // Цикл, пробегает по массиву слов.
                if (maxlength < words[i].Length)
                    maxlength = words[i].Length; // Если длина текущего слова больше той, что в памяти,
                                                 //- запоминаем новую длину.
            for (i = 0; i < words.Length; i++) // Цикл выбирает из массива слов слова максимальной длины.
            {
                if (words[i].Length == maxlength && !stack.Contains(words[i])) // Если длина слова соответствует максимальной,
                    stack.Push(words[i]); // и этого слова нет в стеке - убираем слово в стек.
            }

            string[] maxwords = stack.ToArray(); // Переводим стек в массив слов максимальной длины.
            
            for (i = 0; i < maxwords.Length; i++) // Пробегаемся по массиву слов максимальной длины.
            {
                count = 0; // Обнуляем счетчик для каждого нового слова.
                foreach (string x in words) // Перебираем исходный массив слов.
                {
                    if (x == maxwords[i])
                        ++count; // Если выбранное слово, совпадает с максимальным - наращиваем счетчик.
                    if (count > maxcount)
                    {
                        maxcount = count; // Попытка вытащить необходимые данные из циклов.
                        tmp = i;
                    }
                        
                }
            }
            Console.WriteLine("Самое длинное слово: {0}\n   Число вхождений: {1}", maxwords[tmp], maxcount); // Выводим результаты.
        }
    }
}





