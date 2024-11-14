using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetCsharpDefaultInterfaces
{
    internal class Book : IComparable, ICloneable
    {
        public string name { get; set; }
        public string author { get; set; }
        public int year { get; set; }
        public string describing { get; set; }
        public int pageNumber { get; set; }

        public Book()
        {
            name = "";
            author = "";
            year = 0;
            describing = "";
            pageNumber = 0;
        }
        public Book(string n, string a, string desc, int y, int pn)
        {
            name = n;
            author = a;
            describing = desc;
            year = y;
            pageNumber = pn;
        }
        public void Show()
        {
            Console.WriteLine("\n{0}   {1}   {2}   {3}   {4}", name, author, year, pageNumber, describing);
        }
        public override string ToString()
        {
            return string.Format("\n{0}, {1}, {2}", name, author, describing, year, pageNumber);
        }
        public void Input()
        {
            Console.WriteLine("\nВведите название книги: ");
            name = Console.ReadLine();
            Console.WriteLine("\nВведите имя и фамилию автора: ");
            author = Console.ReadLine();
            Console.WriteLine("\nВведите описание книги: ");
            describing = Console.ReadLine();
            Console.WriteLine("\nВведите год издания: ");
            year = int.Parse(Console.ReadLine());
            Console.WriteLine("\nВведите кол-во страниц: ");
            pageNumber = int.Parse(Console.ReadLine());
        }
        public int CompareTo(object obj)
        {
            if (obj is Book)
                return name.CompareTo((obj as Book).name);

            throw new NotImplementedException();
        }
        public class SortByName : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Book && obj2 is Book)
                    return (obj1 as Book).name.CompareTo((obj2 as Book).name);

                throw new NotImplementedException();
            }
        }
        public class SortByAuthor : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Book && obj2 is Book)
                    return (obj1 as Book).author.CompareTo((obj2 as Book).author);

                throw new NotImplementedException();
            }
        }
        public class SortByYear : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Book && obj2 is Book)
                    return (obj1 as Book).year.CompareTo((obj2 as Book).year);

                throw new NotImplementedException();
            }
        }
        public class SortByPages : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Book && obj2 is Book)
                    return (obj1 as Book).pageNumber.CompareTo((obj2 as Book).pageNumber);

                throw new NotImplementedException();
            }
        }
        public object Clone()
        {
            return new Book(name, author, describing, year, pageNumber);
        }

    }
    class Library : IEnumerable, IEnumerator
    {
        Book[] ar;
        int curpos = -1;
        public Library(int len)
        {
            ar = new Book[len];
            for (int i = 0; i < len; i++)
            {
                ar[i] = new Book();
            }
        }

        public Library() : this(1) { }

        public Library(Book[] books)
        {
            ar = new Book[books.Length];
            for (int i = 0; i < books.Length; i++)
            {
                ar[i] = new Book(books[i].name, books[i].author, books[i].describing, books[i].year, books[i].pageNumber);
            }
        }

        public void InputClub()
        {
            for (int i = 0; i < ar.Length; i++)
                ar[i].Input();
        }

        public void ShowClubs()
        {
            for (int i = 0; i < ar.Length; i++)
                ar[i].Show();
        }


        public IEnumerator GetEnumerator()
        {
            Console.WriteLine("\nВыполняется метод GetEnumerator");
            // возвращается ссылка на объект класса, реализующего перечислитель
            return this;
        }

        // реализация перечислителя
        #region enumerator

        //Устанавливает перечислитель в его начальное положение, т. е. перед первым элементом коллекции
        public void Reset()
        {
            Console.WriteLine("\nВыполняется метод Reset");
            curpos = -1;
        }
        public object Current // Получает текущий элемент в коллекции
        {
            get
            {
                Console.WriteLine("\nВыполняется свойство Current");
                return ar[curpos];
            }
        }

        // Перемещает перечислитель к следующему элементу коллекции
        public bool MoveNext()
        {
            Console.WriteLine("\nВыполняется метод MoveNext");
            if (curpos < ar.Length - 1)
            {
                curpos++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }

        }
        #endregion enumerator
    }
}
