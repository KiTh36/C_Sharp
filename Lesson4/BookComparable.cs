
   
using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    public string BookName { get; set; }
    public string AuthorName { get; set; }
    public int YearRelease { get; set; }

    public Book(string title, string author, int year)
    {
        BookName = title;
        AuthorName = author;
        YearRelease = year;
    }

    public override string ToString()
    {
        return $"[Title: '{BookName}', Author: '{AuthorName}', Year: {YearRelease}]";
    }

    public int CompareTo(Book other)
    {
        if (other == null) return 1;

        int authorComparison = string.Compare(this.AuthorName, other.AuthorName, StringComparison.Ordinal);
        if (authorComparison != 0)
        {
            return authorComparison;
        }

        int nameComparison = string.Compare(this.BookName, other.BookName, StringComparison.Ordinal);
        if (nameComparison != 0)
        {
            return nameComparison;
        }

        return this.YearRelease.CompareTo(other.YearRelease);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        Book other = (Book)obj;

        bool namesEqual = string.Equals(this.BookName, other.BookName, StringComparison.Ordinal);
        bool authorsEqual = string.Equals(this.AuthorName, other.AuthorName, StringComparison.Ordinal);

        return namesEqual && authorsEqual;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + (BookName?.GetHashCode() ?? 0);
            hash = hash * 23 + (AuthorName?.GetHashCode() ?? 0);
            return hash;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Book> books = new List<Book>
        {
            new Book("1984", "Orwell", 1949),
            new Book("Animal Farm", "Orwell", 1945),
            new Book("Dune", "Herbert", 1965),
            new Book("The Lord of the Rings", "Tolkien", 1954)
        };

        books.Sort();

        Console.WriteLine("--- Sorted List of Books ---");
        foreach (var book in books) 
        {
            Console.WriteLine(book);
        }
        Console.WriteLine(new string('-', 40));

        
        Book searchTargetPresent = new Book("Animal Farm", "Orwell", 1945); 
        int presentIndex = books.BinarySearch(searchTargetPresent);

        Console.WriteLine("--- BinarySearch for Present Element ---");
        if (presentIndex >= 0)
        {
            Console.WriteLine($"Found at index {presentIndex}: {books[presentIndex]}");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
        Console.WriteLine("Note: BinarySearch uses IComparable (Author, Title, Year).");
        Console.WriteLine(new string('-', 40));

       
        Book searchTargetAbsent = new Book("Foundation", "Asimov", 1951);  // Renamed for clarity
        int absentIndex = books.BinarySearch(searchTargetAbsent);

        Console.WriteLine("--- BinarySearch for Absent Element ---");
        Console.WriteLine($"Searching for: {searchTargetAbsent}");
        Console.WriteLine($"Index: {absentIndex}");
        Console.WriteLine($"Expected insertion point: {~absentIndex}");
        Console.WriteLine(new string('-', 40));

        Console.WriteLine("--- Demonstration of Equals/GetHashCode (by Title + Author) ---");
        Book bookA = new Book("Foundation", "Asimov", 1951);
        Book bookB = new Book("Foundation", "Asimov", 1960);
        Book bookC = new Book("Foundation and Empire", "Asimov", 1952);

        Console.WriteLine($"Book A: {bookA}");
        Console.WriteLine($"Book B: {bookB}");
        Console.WriteLine($"Book C: {bookC}");

        Console.WriteLine($"A.Equals(B): {bookA.Equals(bookB)} (same Title+Author, different Year)");
        Console.WriteLine($"A.GetHashCode() == B.GetHashCode(): {bookA.GetHashCode() == bookB.GetHashCode()} (consistent)");

        Console.WriteLine($"A.Equals(C): {bookA.Equals(bookC)} (different Title)");
        Console.WriteLine($"A.GetHashCode() == C.GetHashCode(): {bookA.GetHashCode() == bookC.GetHashCode()}");
    }
}
