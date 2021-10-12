using System;
using System.IO;
using System.Linq;
using System.Text;

namespace DZ_SkillBox_2._7
{
    class Program
    {
        private static char letter; // кнопка нажатия

        static void Main(string[] args)
        {

            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Добро пожаловать в записную книжку");
                    Console.WriteLine("- a)Посмотреть книжку \n- b)Добавить в книжку \n- c)Удалить из книжки");
                    Console.Write("Выбирите действие: ");

                    letter = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    if (letter == 'a' || letter == 'b' || letter == 'c')
                    {
                        break;
                    }
                
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы не правильно написали букву. Выберите a, b или c.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Clear();
                ChouseBtn(letter);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nХотите закончить программу? \n - Y - да, хочу. Либо нажмите на любую клавишу, чтобы продолжить...");
                letter = Console.ReadKey().KeyChar;
                Console.ForegroundColor = ConsoleColor.White;

                if (letter == 'y')
                {
                    break;
                }

                Console.Clear();
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        /// <summary>
        /// Выводит средний балл по всем предметам
        /// </summary>
        /// <param name="a">Первый предмет</param>
        /// <param name="b">Второй предмет</param>
        /// <param name="c">Третий предмет</param>
        /// <returns></returns>
        static public float ArithmeticMean(float a, float b, float c)
        {
            return (a + b + c) / 3;
        }

        /// <summary>
        /// Метод выбора действий в книжке
        /// </summary>
        /// <param name="letter">Значение для выбора каталога</param>
        static public void ChouseBtn(char letter)
        {
            switch (letter)
            {
                case 'a': // Показать книжку
                    Console.WriteLine("- Записная книжка -");
                    ShowTxt("test.txt");
                    break;
                case 'b': // Добавить в книжку
                    Console.WriteLine("- Добавляем в книжку -");
                    WriterInTxt(AddInfo());
                    break;
                case 'c': // Удалить строки в книжке
                    Console.WriteLine("- Удаляем информацию о человеке -");
                    Console.Write("Напишите ФИО: ");
                    string txt = Console.ReadLine();
                    DeleteLineInTxt(txt, "test.txt");
                    Console.WriteLine(txt + " был удален");
                    break;
                default:
                    Console.WriteLine("Вы выбрали неправильно");
                    break;
            }
        }

        /// <summary>
        /// Добавляем информацию о человеке
        /// </summary>
        /// <returns></returns>
        static public string AddInfo()
        {
            Console.Write("Напишите своё ФИО: ");
            string fullName = Console.ReadLine();

            Console.Write("Ваш возраст: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Ваш email: ");
            string email = Console.ReadLine();

            Console.Write("Баллы по программированию: ");
            float programmingScores = float.Parse(Console.ReadLine());

            Console.Write("Баллы по математике: ");
            float mathScores = float.Parse(Console.ReadLine());

            Console.Write("Баллы по физике: ");
            float physicsScores = float.Parse(Console.ReadLine());

            return "ФИО: " + fullName + "; Возраст: " + age + "; email: " + email + 
                   "; Баллы по программированию: " + programmingScores + "; Баллы по математике: " +  mathScores + "; Баллы по физике: " + physicsScores + "; Средняя сумма балов: " + ArithmeticMean(programmingScores, mathScores, physicsScores);
        }

        /// <summary>
        /// Сохраняем текст в созданном файле
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public bool WriterInTxt(string str)
        {
            try
            {
                string writePath = "test.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
                {
                    sw.WriteLine(str);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Показывает текст из файла
        /// </summary>
        /// <param name="path"></param>
        static public void ShowTxt(string path)
        {
            string[] lines = File.ReadAllLines(path); //Читаем все строки из файла names.txt в массив строк lines
            foreach (var line in lines) //Перебираем все элементы массива lines. Для каждого значения будет вызываться код, находящийся ниже
            {
                Console.WriteLine(line); //Собственно выводим в консоль строку
            }
        }

        /// <summary>
        /// Удаляет строку из файла
        /// </summary>
        /// <param name="txt">Какой текст нужно удалить</param>
        /// <param name="path">Имя файла</param>
        static public void DeleteLineInTxt(string txt, string path)
        {
            var re = File.ReadAllLines(path, Encoding.Default).Where(s => !s.Contains(txt));
            File.WriteAllLines("test.txt", re, Encoding.Default);
        }

    }
}
