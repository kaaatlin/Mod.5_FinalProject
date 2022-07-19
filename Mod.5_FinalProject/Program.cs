using System;

namespace Mod._5_FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EnterUser();
        }

        // Заполнение информации о пользователе
        static (string, string, int, bool, string[], int, string[]) EnterUser()
        {

            (string Name, string Surname, int Age, bool HasPet, string[] PetName, int NumCol, string[] favcolors) User;

            string checkname;
            do
            {
                Console.WriteLine("Введите Ваше имя: ");
                checkname = Console.ReadLine();

            } while (CheckName(checkname));

            User.Name = checkname;

            do
            {
                Console.WriteLine("Введите Вашу фамилию: ");
                checkname = Console.ReadLine();

            } while (CheckName(checkname));

            User.Surname = checkname;

            string inage;
            int age;
            do
            {
                Console.WriteLine("Введите Ваш возраст: ");
                inage = Console.ReadLine();

            } while (CheckUser(inage, out age));

            User.Age = age;

            string answer;
            bool flag;
            do
            {
                Console.WriteLine("Есть ли у вас животные? Да/Нет: ");
                answer = Console.ReadLine();
                CheckUserPet(answer, out flag);

            } while (flag == true);


            string numpets;
            int pets = 0;
            User.PetName = new string[pets];
            if (answer == "Нет")
            {
                User.HasPet = false;
            }
            else
            {
                User.HasPet = true;

                do
                {
                    Console.WriteLine("Сколько у Вас животных?");
                    numpets = Console.ReadLine();

                } while (CheckUser(numpets, out pets));

                Console.WriteLine("Введите имена Ваших животных: ");
                User.PetName = CreatePetName(pets);

            }

            string anscolor;
            int color;
            do
            {
                Console.WriteLine("Сколько у Вас любимых цветов?");
                anscolor = Console.ReadLine();

            } while (CheckUser(anscolor, out color));

            User.NumCol = color;

            Console.WriteLine("Введите имена Ваших любимых цветов: ");
            User.favcolors = CreatePetName(color);

            OutUser(User.Name, User.Surname, User.Age, User.HasPet, User.PetName, User.NumCol, User.favcolors);

            return User;

        }

        // Заполняем массив кличек и любимых цветов
        static string[] CreatePetName(int num)
        {
            var names = new string[num];

            for (int i = 0; i < names.Length; i++)
            {
                do
                {
                    names[i] = Console.ReadLine();

                } while (CheckName(names[i]));  //проверяем, что пользователь вводит только буквы

            }
            return names;
        }

        // проверка на пользовательский ввод имени, фамилии, кличек животных и названия цветов на наличие только букв
        static bool CheckName(string checkname)
        {
            bool goodname = true;
            foreach (char symbol in checkname)
            {
                if (Char.IsLetter(symbol))      //если пользователь ввел только буквы, то мы должны выйти из цикла do..while
                    goodname = false;
                else
                    goodname = true;            //иначе просим ввести еще раз
            }

            return goodname;
        }

        //проверка, что пользователь ввел только цифры больше 0
        static bool CheckUser(string inage, out int age)
        {
            if (int.TryParse(inage, out int result))
            {
                if (result > 0)
                {
                    age = result;
                    return false;
                }
                else
                {
                    age = result;
                    return true;
                }
            }
            else
            {
                age = 0;
                return true;
            }
        }

        // проверка, что пользователь ответил четко да или нет
        static bool CheckUserPet(string answer, out bool flag)
        {
            if (string.Equals(answer, "Да"))
            {
                flag = false;

            }
            else if (string.Equals(answer, "Нет"))
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        //вывод заполеннной анкеты
        static void OutUser(string Name, string Surname, int Age, bool HasPet, string[] PetName, int NumCol, string[] favcolors)
        {
            Console.WriteLine("\nВаше имя: " + Name);
            Console.WriteLine("Ваша фамилия: " + Surname);
            Console.WriteLine("Ваш возраст: " + Age);
            Console.WriteLine("Наличие животных: " + HasPet);

            if (HasPet == true)
            {
                Console.WriteLine("Клички Ваших животных: ");
                for (int i = 0; i < PetName.Length; i++)
                {
                    Console.WriteLine(PetName[i] + " ");
                }
            }

            Console.WriteLine("Количество любимых цветов: " + NumCol);
            Console.WriteLine("Любимые цвета: ");

            for (int i = 0; i < favcolors.Length; i++)
            {
                Console.WriteLine(favcolors[i] + " ");
            }

        }
    }
}
