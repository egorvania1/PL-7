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
            //Задание 1. Решить задачу, используя класс List
            //Даны упорядоченные списки L1 и L2. Вставить элементы списка L2 в список L1,
            //не нарушая его упорядоченности.
            Console.WriteLine("Задание 1");
            Console.WriteLine("Даны упорядоченные списки L1 и L2. Вставить элементы списка L2 в список L1, не нарушая его упорядоченности.");
            List<string> list1 = new List<string>() { "one", "two" };
            List<string> list2 = new List<string>() { "three", "four" };
            list2.AddRange(list1);
            foreach (var thing in list2)
            {
                Console.WriteLine(thing);
            }
        }
        public static void Task2() //Задание 2
        {
            //Задание 2. Решить задачу, используя класс LinkedList
            //Программа подсчитывает количество элементов списка L, у которых равные «соседи»;
            Console.WriteLine("Задание 2.");
            Console.WriteLine("Программа подсчитывает количество элементов списка L, у которых равные «соседи».");
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
        public static void Task3() //Задание 3
        {
            //Задание 3. Решить задачу, используя класс HashSet
            //Задан некоторый набор блюд в кафе. Определить для каждого из блюд, какие
            //из них заказывали все посетители, какие — некоторые из посетителей, и какие
            //не заказывал никто.
            Console.WriteLine("Задание 3.");
            Console.WriteLine("Задан некоторый набор блюд в кафе. Определить для каждого из блюд, какие " +
                "из них заказывали все посетители, какие — некоторые из посетителей, и какие " +
                "не заказывал никто.");
            HashSet<string> food = new HashSet<string>() { "potato", "cake" }; //Все блюда в кафе
            HashSet<string> vis1 = new HashSet<string>() { "potato", "cake" }; //Заказал первый посетитель
            HashSet<string> vis2 = new HashSet<string>() { "potato", "cake" }; //Заказал второй посетитель
            HashSet<string> vis3 = new HashSet<string>() { "potato", "cake" }; //Заказал третий посетитель 
            HashSet<string> vis4 = new HashSet<string>() { "potato", "cake" }; //Заказал четвёртый посетитель
        }
        public static void Task4() //Задание 4
        {
            //Задание 4. Решить задачу, используя класс HashSet.
            //Файл содержит текст на русском языке. Напечатать в алфавитном порядке все
            //согласные буквы, которые входят ровно в одно слово.
            Console.WriteLine("Задание 4.");
            Console.WriteLine("Файл содержит текст на русском языке. " +
                "Напечатать в алфавитном порядке все согласные буквы, которые входят ровно в одно слово.");
            HashSet<char> consonants = new HashSet<char>() { 'Б', 'В', 'Г', 'Д', 'Ж', 'З', 'Й', 'К', 'Л', 'М', 'Н', 'П', 'Р', 'С', 'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ' }; //Все согласные
            HashSet<char> inOneWord = new HashSet<char>();          //Согласные в одном слове
            HashSet<char> inMultipleWords = new HashSet<char>();    //Согласные в нескольких словах
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
                            if (!inOneWord.Contains(ch)) //Внесение в HashSet согласных, которые встречаются (на данный момент) только в одном слове
                            {
                                inOneWord.Add(ch);
                                isInOneWord = true;      //Буква есть в слове
                            }
                            else if (!isInOneWord)       //Если уже есть в предыдущем HashSet, то согласная встречается в другом слове
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
        public static void Task5() //Задание 5
        {
            //Задание 5. Решить задачу, используя класс Dictionary (или класс SortedList)
            /*
            На вход программы подаются сведения о результатах соревнований по
            школьному многоборью. Многоборье состоит из соревнований по четырем
            видам спорта, участие в каждом из которых оценивается баллами от 0 до 10 (0
            баллов получает ученик, не принимавший участия в соревнованиях по данному
            виду спорта). Победители определяются по наибольшей сумме набранных
            баллов. Известно, что общее количество участников соревнований не
            превосходит 100.
            В первой строке вводится количество учеников, принимавших участие в
            соревнованиях, N. Далее следуют N строк, имеющих следующий формат:
            <Фамилия> <Имя> <Баллы>
            Здесь <Фамилия> – строка, состоящая не более чем из 20 символов; <Имя> –
            строка, состоящая не более чем из 15 символов; <Баллы> - строка, содержащая
            четыре целых числа, разделенных пробелом, соответствующих баллам,
            полученным на соревнованиях по каждому из четырех видов спорта. При этом
            <Фамилия> и <Имя>, <Имя> и <Баллы> разделены одним пробелом. Примеры
            входных строк:
            Иванова Мария 5 8 6 3
            Петров Сергей 9 9 5 7
            Напишите программу, которая будет выводить на экран фамилии и имена трех
            лучших участников многоборья. Если среди остальных участников есть
            ученики, набравшие то же количество баллов, что и один из трех лучших, то их
            фамилии и имена также следует вывести. При этом имена и фамилии можно
            выводить в произвольном порядке.
             */

            Console.WriteLine("Задание 5.");
            Console.WriteLine("Вывести фамилии и имена трех лучших участников многоборья.");
            int N = 0;
            Dictionary<string, int[]> contestants = new Dictionary<string, int[]>();

            //Пока пользователь не введёт правильное число N
            bool isValid = false;
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
            
            //Пока пользователь не введёт правильно участников
            isValid = false;
            for (int i = 0; i < N; i++) //Ввод информации об участниках
            {
                while (!isValid)        //Пока информация об участнике неправильная - просить информацию
                {
                    string[] contestantInfo;        //Вся информация об участнике
                    int[] contScore = new int[4];   //Баллы участника
                    string creds;                   //ФИ участника
                    Console.Write("Введите <Фамилия> <Имя> <Балл1> <Балл2> <Балл3> <Балл4> участника " + (i+1) + ": ");
                    contestantInfo = Console.ReadLine().Split(' '); //Разделяем ввод по пробелам
                    if (contestantInfo.Length != 6)         //Если введено неправильное кол-во данных
                    {
                        Console.WriteLine("Строка введена неправильно");
                        continue;
                    }
                    else if (contestantInfo[0].Length > 20) //Если фамилия слишком длинная
                    {
                        Console.WriteLine("Слишком длинная фамилия!");
                        continue;
                    }
                    else if (contestantInfo[1].Length > 15) //Если имя слишком длинное
                    {
                        Console.WriteLine("Слишком длинное имя!");
                        continue;
                    }
                    creds = contestantInfo[0] + " " + contestantInfo[1];    //ФИ участника - ключ для словаря
                    for (int j = 0; j < 4; j++) //Ввод баллов участника
                    {
                        if (int.TryParse(contestantInfo[j + 2], out int score)) //Если баллы являются целым числом
                        {
                            contScore[j] = score;
                            if (score > 10 || score < 0) //Если введён неверный балл
                            {
                                Console.WriteLine("Баллы только от 0 до 10!");
                                continue;
                            }
                        }
                        else //Если баллы НЕ являются целым числом
                        {
                            Console.WriteLine("Баллы участника не являются целыми числами!");
                            continue;
                        }
                    }
                    if (contestants.TryAdd(creds, contScore)) //Пытаемся добавить участника в словарь
                    {
                        isValid = true; //Если программа дошла сюда, то все данные введены правильно
                        Console.WriteLine("Участник " + (i+1) + " успешно добавлен!");
                    }
                    else //Участник уже в словаре
                    {
                        Console.WriteLine("Участник с таким ФИ уже существует!");
                        continue;
                    }
                }
                isValid = false; //Начинам вводить заного
            }
            Dictionary<string, int> tempContestants = new Dictionary<string, int>(); //Временный словарь из участников, где их баллы суммируются.
            Console.WriteLine("Список(словарь) участников: ");
            foreach (var contestant in contestants)
            {
                Console.WriteLine("ФИ: " + contestant.Key + " Сумма баллов: " + contestant.Value.Sum());
                tempContestants.Add(contestant.Key, contestant.Value.Sum());
            }
            int count = 0; //Всего три места
            int maxValue;  //Максимальное ко-во баллов
            Dictionary<string, int[]> bestContestants = new Dictionary<string, int[]>();
            while (count < 3 && tempContestants.Count != 0) //Надо найти три максимальных балла
            {
                //Console.WriteLine("Loop " + count);
                maxValue = tempContestants.Values.Max();    //Максимальный балл, каждый раз новый т.к. из словаря удаляются все участники с максимальным баллом
                foreach (var contestant in tempContestants)
                {
                    if (contestant.Value == maxValue)   //Если у участника м
                    {
                        if (contestants.TryGetValue(contestant.Key, out int[] value))
                        {
                            bestContestants.Add(contestant.Key, value);
                            tempContestants.Remove(contestant.Key);
                        }
                    }
                }
                count++;
            }
            Console.WriteLine("Фамилии и имена трех лучших участников многоборья: ");
            foreach (var contestant in bestContestants)
            {
                Console.Write("ФИ: " + contestant.Key + " Баллы: ");
                foreach (int num in contestant.Value)
                {
                    Console.Write(num + " ");
                }
                Console.Write("\n");
            }
        }
    }
}
