using program;
using System.Globalization;
using System.Text.RegularExpressions;


class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите действие: ");
        Console.WriteLine("1 - добавить книгу");
        Console.WriteLine("2 - вывести все данные из бд");
        Console.WriteLine("3 - изменить данные");
        Console.WriteLine("4 - удалить данные");
        Console.WriteLine("0 - выход из программы");
        while (true)
        {
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '1': Add(); break;
                case '2': Read(); break;
                case '3': Update(); break;
                case '4': Remove(); break;
                case '0': System.Environment.Exit(0); break;
                default: break;
            }
        }
    }

    static void Add()
    {
        Console.WriteLine("\n*************************************************************************************************");
        Console.WriteLine("Введите название книги: ");
        string name = Console.ReadLine();
        Console.WriteLine("Введите автора: ");
        string author = Console.ReadLine();
        if (name != null && author != null)
        {
            using (ApplicationContext app = new ApplicationContext())
            {
                app.Books.Add(new Book() { Name = name, Author = author });
                app.SaveChanges();
                Console.WriteLine("Данные успешно добавлены!");
            }
        }
        else
        {
            Console.WriteLine("Введите все данные!!!");
            Add();
        }
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в главное меню\n");
        if (char.ToLower(Console.ReadKey(true).KeyChar) != null) Main();

    }

    static void Read()
    {
        Console.WriteLine("\n*************************************************************************************************");
        using (ApplicationContext app = new ApplicationContext())
        {
            var books = app.Books.ToList();
            if (books.Count > 0)
            {
                Console.WriteLine("  Id" + "".PadRight(4) +
                    "Name".PadRight(9) + "Author");
                foreach (var u in books)
                {
                    Console.WriteLine("".PadRight(2) + u.Id + "".PadRight(5) + u.Name.PadRight(10) + u.Author);
                }
            }
            else
            {
                Console.WriteLine("База данных пуста");
            }
        }
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в главное меню\n");
        if (char.ToLower(Console.ReadKey(true).KeyChar) != null) Main();
    }

    static void Update()
    {
        Console.WriteLine("\n*************************************************************************************************");
        Console.WriteLine("Введите Id объекта, данные которого вы хотите обновить: ");
        int id;
        bool check = Int32.TryParse(Console.ReadLine(), out id);
        if (check)
        {
            Book book = null;
            using (ApplicationContext app = new ApplicationContext())
            {
                book = app.Books.Find(id);
                if (book != null)
                {
                    Console.WriteLine("Введите новое название книги");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите автора книги");
                    string author = Console.ReadLine();
                    if (name != null && author != null)
                    {
                        book.Name = name;
                        book.Author = author;
                        app.Books.Update(book);
                        Console.WriteLine("Данные успешно изменены!");
                    }
                    app.SaveChanges();

                }
            }
        }
        else
        {
            Console.WriteLine("Неккоректно введенное Id");
            Update();
        }
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в главное меню\n");
        if (char.ToLower(Console.ReadKey(true).KeyChar) != null) Main();

    }

    static void Remove()
    {
        Console.WriteLine("\n*************************************************************************************************");
        Console.WriteLine("Введите Id объекта, которого вы хотите удалить: ");
        int id;
        bool check = Int32.TryParse(Console.ReadLine(), out id);
        if (check)
        {
            Book book = null;
            using (ApplicationContext app = new ApplicationContext())
            {
                try
                {
                    book = app.Books.Find(id);
                    app.Books.Remove(book);
                    app.SaveChanges();
                    Console.WriteLine("Данные успешно удалены!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Id отсутствует в базе данных");
                }
            }
        }
        else
        {
            Console.WriteLine("Введено некорректное значение");
            Remove();
        }
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в главное меню\n");
        if (char.ToLower(Console.ReadKey(true).KeyChar) != null) Main();

    }


}

