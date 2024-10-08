using System;
using System.Collections.Generic;

namespace Book
{
    class BookSpace
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }

        public BookSpace(string title, string author, string date, string type)
        {
            Title = title;
            Author = author;
            Date = date;
            Type = type;
        }
    }

    class BookTools
    {
        public static List<BookSpace> Books = new List<BookSpace>();

        public static void ShowBooks()
        {
            foreach (BookSpace book in Books)
            {
                Console.WriteLine($"Titre : {book.Title}, Auteur : {book.Author}, Date : {book.Date}, Type : {book.Type}");
            }
        }

        public static void SearchBooks()
        {
            Console.WriteLine("Entrez le titre du livre à rechercher : ");
            string titleForSearch = Console.ReadLine();
            bool found = false;
            foreach (BookSpace book in Books)
            {
                if (book.Title == titleForSearch)
                {
                    Console.WriteLine($"Titre : {book.Title}, Auteur : {book.Author}, Date : {book.Date}, Type : {book.Type}");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Livre introuvable");
            }
        }

        public static void AddBooks()
        {
            Console.WriteLine("Informations du Livre à Ajouter");
            Console.WriteLine("Titre : ");
            string newBookName = Console.ReadLine();
            Console.WriteLine("Auteur : ");
            string newBookAuthor = Console.ReadLine();
            Console.WriteLine("Date : ");
            string newBookDate = Console.ReadLine();
            Console.WriteLine("Type : ");
            string newBookType = Console.ReadLine();
            
            BookSpace newBook = new BookSpace(newBookName, newBookAuthor, newBookDate, newBookType);
            Books.Add(newBook);
        }

        public static void DeleteBooks()
        {
            Console.WriteLine("Titre du Livre à Supprimer : ");
            string bookToDelete = Console.ReadLine();
            BookSpace bookToRemove = null;
            foreach (BookSpace book in Books)
            {
                if (book.Title == bookToDelete)
                {
                    bookToRemove = book;
                    break;
                }
            }
            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
                Console.WriteLine("Livre Supprimé");
            }
            else
            {
                Console.WriteLine("Livre introuvable");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool question = true;
            Console.WriteLine("1. Afficher les Livres");
            Console.WriteLine("2. Ajouter des Livres");
            Console.WriteLine("3. Rechercher des Livres");
            Console.WriteLine("4. Supprimer des Livres");
            Console.WriteLine("5. Quitter");
            while (question)
            {
                Console.WriteLine("Choisissez une option : ");
                int option;
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            BookTools.ShowBooks();
                            break;
                        case 2:
                            BookTools.AddBooks();
                            break;
                        case 3:
                            BookTools.SearchBooks();
                            break;
                        case 4:
                            BookTools.DeleteBooks();
                            break;
                        case 5:
                            question = false;
                            break;
                        default:
                            Console.WriteLine("Option invalide");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un nombre valide.");
                }
            }
        }
    }
}