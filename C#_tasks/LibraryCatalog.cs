using System;
using System.Collections.Generic;
using System.Numerics;

class Library{

    public string Name {get; set;}
    public string Address {get; set;}

    public List<Book> Books {get; set;}
    public List<MediaItem> MediaItems {get; set;}

    public Library(string name, string address){
        Name = name;
        Address = address;
        Books = new List<Book>();
        MediaItems = new List<MediaItem>();
    }

    public void AddBook (Book book){
        Books.Add(book);
    }

    public void RemoveBook (Book book){
        Books.Remove(book);
    }

    public void AddMediaItem (MediaItem mediaItem){
        MediaItems.Add(mediaItem);
    }

    public void RemoveMediaItem (MediaItem mediaItem){
        MediaItems.Remove(mediaItem);
    }

    public void PrintCatalog(){
        Console.WriteLine($"Library: {Name} - {Address}");

        Console.WriteLine("\nBooks:");
        foreach (var book in Books){
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Publication Year: {book.PublicationYear}");
        }

        Console.WriteLine("\nMediaItems:");
        foreach (var mediaItem in MediaItems){
            Console.WriteLine($"Title: {mediaItem.Title}, Media Type: {mediaItem.MediaType}, Duration: {mediaItem.Duration}");
        }
    }
}

class Book{
    public string Title {get; set;}
    public string Author {get; set;}
    public string ISBN {get; set;}
    public int PublicationYear {get; set;}

    public Book(string title, string author, string isbn, int publicationYear){
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }
}

class MediaItem{
    public string Title {get; set;}
    public string MediaType {get; set;}
    public int Duration {get; set;}

    public MediaItem(string title, string mediaType, int duration){
        Title = title;
        MediaType = mediaType;
        Duration = duration;
    }
}

class LibraryCatalog{

    public static void Main(string[] args){
        Console.WriteLine("Welcome! Enter The Name of your library and the Address:");
        
        Library library = new Library(Console.ReadLine(), Console.ReadLine());

        Console.Write("Enter the number of books: ");
        int numberOfBooks = ReadIntegerInput();

        for (int i = 0; i < numberOfBooks; i++)
        {
            Console.WriteLine($"Book {i + 1}:");
            Book book = ReadBookDetails();
            library.AddBook(book);
        }

        Console.Write("Enter the number of media items: ");
        int numberOfMediaItems = ReadIntegerInput();

        for (int i = 0; i < numberOfMediaItems; i++)
        {
            Console.WriteLine($"Media Item {i + 1}:");
            MediaItem mediaItem = ReadMediaItemDetails();
            library.AddMediaItem(mediaItem);
        }

        library.PrintCatalog();
    }

    static int ReadIntegerInput()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
        {
            Console.Write("Invalid input. Please enter a non-negative integer: ");
        }
        return value;
    }

    static Book ReadBookDetails()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Author: ");
        string author = Console.ReadLine();

        Console.Write("ISBN: ");
        string isbn = Console.ReadLine();

        Console.Write("Publication Year: ");
        int publicationYear = ReadIntegerInput();

        return new Book(title, author, isbn, publicationYear);
    }

    static MediaItem ReadMediaItemDetails()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Media Type (DVD/CD): ");
        string mediaType = Console.ReadLine();

        Console.Write("Duration (minutes): ");
        int duration = ReadIntegerInput();

        return new MediaItem(title, mediaType, duration);
    }
}
