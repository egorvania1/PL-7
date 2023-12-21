//Вариант 3
using System;
using System.Transactions;
using static System.Formats.Asn1.AsnWriter;

namespace lab7
{
    class Tasks
    {
        public static void Task1()
        {
            Console.WriteLine("Задание 1");
            Console.WriteLine("Инфо о задании");
            List<string> list1 = new List<string>() { "one", "two" };
            List<string> list2 = new List<string>() { "three", "four" };
            list2.AddRange(list1);
            foreach (var thing in list2)
            {
                Console.WriteLine(thing);
            }
        }
        public static void Task2()
        {
            Console.WriteLine("Задание 2");
            Console.WriteLine("Инфо о задании");
            LinkedList<string> words = new LinkedList<string>(new[] { "one", "two", "one", "three" });
            var currentNode = words.First;
            int count = 0;
            while (currentNode != null)
            {
                var prev = currentNode.Previous;
                var next = currentNode.Next;
                Console.WriteLine(currentNode.Value);
                if (prev != null && next != null && (prev.Value == next.Value))
                {
                    count++;
                }
                currentNode = currentNode.Next;
            }
            Console.WriteLine(count);
        }
        public static void Task3()
        {
            Console.WriteLine("Задание 3");
            Console.WriteLine("Инфо о задании");
            HashSet<string> food = new HashSet<string>() { "potato", "cake" };
            HashSet<string> orderAll = new HashSet<string>();
            HashSet<string> orderSome = new HashSet<string>();
            HashSet<string> orderNone = new HashSet<string>();
        }
        public static void Task4() 
        {
            Console.WriteLine("Задание 4");
            Console.WriteLine("Инфо о задании");
            HashSet<char> consonants = new HashSet<char>() { 'Б', 'В', 'Г', 'Д', 'Ж', 'З', 'Й', 'К', 'Л', 'М', 'Н', 'П', 'Р', 'С', 'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ' };
            HashSet<char> inOneWord = new HashSet<char>();
            HashSet<char> inMultipleWords = new HashSet<char>();
            bool isInOneWord = false;
            string s;
            string[] words;
            StreamReader inputFile;
            string inputPath = ".\\text.txt";           //Файл ввода
            //Открываем файл ввода
            try
            {
                inputFile = new StreamReader(File.Open(inputPath, FileMode.Open));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            while ((s = inputFile.ReadLine()) != null) //Читаем строки
            {
                words = s.Split(' '); //Разделяем строку на массив слов через пробелы
                foreach (string word in words)  //Каждое слово в массиве слов
                {
                    foreach (char ch in word)   //Каждый символ в слове
                    {
                        if (consonants.Contains(ch)) //Если в слове есть согласная
                        {
                            if (!inOneWord.Contains(ch)) //Внесение в HashSet согласных, которые встречаются только в одном слове
                            {
                                inOneWord.Add(ch);
                                isInOneWord = true;      //Буква есть в слове
                            }
                            else if (!isInOneWord)       //Если уже есть в предыдущем HashSet и слово другое, значит согласная встречалась в других словах
                            {
                                inMultipleWords.Add(ch);  
                            }
                        }
                    }
                    isInOneWord = false;    //Слово меняется на другое
                }
                Console.WriteLine(s);
            }
            inOneWord.ExceptWith(inMultipleWords); //Убираем согласные, которые встречались в нескольких словах
            foreach (char ch in inOneWord)
            {
                Console.Write(ch + " ");
            }    
            inputFile.Close();
        }
        public static void Task5()
        {
            Console.WriteLine("Задание 5");
            Console.WriteLine("Инфо о задании");
            int N = 0;
            bool isValid = false;
            Dictionary<string, int[]> contestants = new Dictionary<string, int[]>();
            while (!isValid)
            {
                try
                {
                    Console.Write("Введите кол-во участников (целое число N): ");
                    N = Convert.ToInt32(Console.ReadLine());
                    if (N <= 0)
                    {
                        Console.WriteLine("Кол-во участников не может быть меньше или равно нулю!");
                    }
                    else if (N > 100)
                    {
                        Console.WriteLine("Кол-во участников не должно превышать 100!");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            isValid = false;
            for (int i = 0; i < N; i++) //Ввод информации об участниках
            {
                while (!isValid)
                {
                    string[] contestantInfo;        //Вся информация об участнике
                    int[] contScore = new int[4];   //Баллы участника
                    string creds;                   //ФИ участника
                    Console.Write("Введите <Фамилия> <Имя> <Баллы> участника " + (i+1) + ": ");
                    contestantInfo = Console.ReadLine().Split(' ');
                    if (contestantInfo.Length != 6)
                    {
                        Console.WriteLine("Строка введена неправильно");
                        continue;
                    }
                    else if (contestantInfo[0].Length > 20)
                    {
                        Console.WriteLine("Слишком длинная фамилия!");
                        continue;
                    }
                    else if (contestantInfo[1].Length > 15)
                    {
                        Console.WriteLine("Слишком длинное имя!");
                        continue;
                    }
                    creds = contestantInfo[0] + " " + contestantInfo[1];
                    for (int j = 0; j < 4; j++) //Ввод баллов участника
                    {
                        if (int.TryParse(contestantInfo[j + 2], out int score)) //Если строка является целым числом
                        {
                            contScore[j] = score;
                            if (score > 10 || score < 0)
                            {
                                Console.WriteLine("Баллы только от 0 до 10!");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Баллы участника не являются целыми числами!");
                            continue;
                        }
                    }
                    if (contestants.TryAdd(creds, contScore))
                    {
                        isValid = true;
                        Console.WriteLine("Участник " + (i+1) + " успешно добавлен!");
                    }
                    else
                    {
                        Console.WriteLine("Участник с таким ФИ уже существует!");
                        continue;
                    }
                }
                isValid = false;
            }
            foreach (var contestant in contestants)
            {
            }
        }
    }
}
