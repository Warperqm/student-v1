using System;
using System.Collections.Generic;

namespace ConsoleApp126
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseStudent baseStudent = new BaseStudent();
            baseStudent.Start();
        }
    }

    struct Student
    {
        public Student(string name, string surname, string patronymic, string age, string group)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Age = age;
            Group = group;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public string Age { get; private set; }
        public string Group { get; private set; }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic}, Возраст: {Age}, Группа: {Group}";
        }
    }

    class BaseStudent
    {
        private const string CommandAdd = "1";
        private const string CommandDelete = "2";
        private const string CommandSearchById = "3";
        private const string CommandUpdate = "4";
        private const string CommandListAll = "5";
        private const string CommandExit = "6";

        private List<Student> students;

        public BaseStudent()
        {
            students = new List<Student>();
        }

        public void Start()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine($"{CommandAdd}. Добавить студента");
                Console.WriteLine($"{CommandDelete}. Удалить студента");
                Console.WriteLine($"{CommandSearchById}. Искать студента по индексу");
                Console.WriteLine($"{CommandUpdate}. Изменить данные студента");
                Console.WriteLine($"{CommandListAll}. Показать список студентов");
                Console.WriteLine($"{CommandExit}. Выход");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case CommandAdd:
                        Add();
                        break;

                    case CommandDelete:
                        DeleteById();
                        break;

                    case CommandSearchById:
                        SearchStudentById();
                        break;

                    case CommandUpdate:
                        UpdateStudent();
                        break;

                    case CommandListAll:
                        ListAllStudents();
                        break;

                    case CommandExit:
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void Add()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.Write("Введите отчество: ");
            string patronymic = Console.ReadLine();
            Console.Write("Введите возраст: ");
            string age = Console.ReadLine();
            Console.Write("Введите группу: ");
            string group = Console.ReadLine();

            students.Add(new Student(name, surname, patronymic, age, group));
            Console.WriteLine("Студент добавлен.");
            Console.ReadKey();
        }

        private void DeleteById()
        {
            Console.Write("Введите индекс удаляемого студента: ");
            if (int.TryParse(Console.ReadLine(), out int id) && id > 0 && id <= students.Count)
            {
                students.RemoveAt(id - 1);
                Console.WriteLine("Студент удален.");
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }
            Console.ReadKey();
        }

        private void SearchStudentById()
        {
            Console.Write("Введите индекс студента для поиска: ");
            if (int.TryParse(Console.ReadLine(), out int id) && id > 0 && id <= students.Count)
            {
                var student = students[id - 1];
                Console.WriteLine("Найденный студент:");
                Console.WriteLine(student);
            }
            else
            {
                Console.WriteLine("Студент с таким индексом не найден.");
            }
            Console.ReadKey();
        }

        private void UpdateStudent()
        {
            Console.Write("Введите индекс студента для изменения: ");
            if (int.TryParse(Console.ReadLine(), out int id) && id > 0 && id <= students.Count)
            {
                var student = students[id - 1];

                Console.Write("Введите новое имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите новую фамилию: ");
                string surname = Console.ReadLine();
                Console.Write("Введите новое отчество: ");
                string patronymic = Console.ReadLine();
                Console.Write("Введите новый возраст: ");
                string age = Console.ReadLine();
                Console.Write("Введите новую группу: ");
                string group = Console.ReadLine();

                students[id - 1] = new Student(name, surname, patronymic, age, group);
                Console.WriteLine("Данные студента обновлены.");
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }
            Console.ReadKey();
        }

        private void ListAllStudents()
        {
            Console.WriteLine("Список студентов:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {students[i]}");
            }
            Console.ReadKey();
        }
    }
}
