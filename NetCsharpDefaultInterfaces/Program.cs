// See https://aka.ms/new-console-template for more information
using NetCsharpDefaultInterfaces;
using System;


Book[] book = new Book[4];
Console.WriteLine("Неупорядоченный массив:");
book[0] = new Book("Paper towns", "John Green", "dfvfdvdfvdf", 2008, 120);
book[1] = new Book("Borrow life", "Erich Remarque", "dfgvdfvdfv", 1966, 146);
book[2] = new Book("I Robot", "Isaac Azimov", "dfgdfgdfdfg", 1967, 245);
book[3] = new Book("1984", "George Orwell", "sfsrfsdsd", 1989, 251);

foreach (Book temp in book)
    temp.Show();
Console.WriteLine();
Array.Sort(book);
Console.WriteLine("\nУпорядоченный массив:");
foreach (Book temp in book)
    temp.Show();
Console.WriteLine();
Array.Sort(book, new Book.SortByName());
Console.WriteLine("\nМассив, упорядоченный по имени:");
foreach (Book temp in book)
    temp.Show();
Console.WriteLine();
Array.Sort(book, new Book.SortByAuthor());
Console.WriteLine("\nМассив, упорядоченный по автору:");
foreach (Book temp in book)
    temp.Show();
Console.WriteLine();
Array.Sort(book, new Book.SortByYear());
Console.WriteLine("\nМассив, упорядоченный по году:");
foreach (Book temp in book)
    temp.Show();
Console.WriteLine();
Array.Sort(book, new Book.SortByPages());
Console.WriteLine("\nМассив, упорядоченный по кол-ву страниц:");
foreach (Book temp in book)
    temp.Show();
Console.WriteLine();



Book b1 = new Book();
Console.WriteLine(b1);
Book b2 = b1; 
b2.name = "Athlantida";
b2.author = "Marius Blake";
b2.describing = "fertrecet";
b2.year = 2013;
b2.pageNumber = 384;
Console.WriteLine(b1.ToString());
Func(b1);
Console.WriteLine(b1.ToString());

static void Func(ICloneable cloneable)
{
    object o = cloneable.Clone(); 
    Console.WriteLine(o.ToString());
    Book b1 = o as Book;
    b1.name = "Azazel";
    b1.author = "Boris Acunin";
    b1.describing = "fertrecet";
    b1.year = 2015;
    b1.pageNumber = 220;
    Console.WriteLine(o.ToString());
}

Library lb = new(book);
foreach (Book temp in lb)
    temp.Show();
foreach (Book temp in lb)
    temp.Show();
