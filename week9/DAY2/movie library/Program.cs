using System;
using System.Collections.Generic;
using System.Linq;

public interface IFilm
{
    string Title { get; set; }
    string Director { get; set; }
    int Year { get; set; }
}

public class Film : IFilm
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }

    public override string ToString()
    {
        return Title + " (" + Director + ", " + Year + ")";
    }
}

public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}

public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> films=new List<IFilm>();
    public void AddFilm(IFilm film)
    {
        films.Add(film);
    }
    public void RemoveFilm(string title)
    {
        films.RemoveAll(f => f.Title == title);
    }
    public List<IFilm> GetFilms()
    {
        return films;
    }
    public List<IFilm> SearchFilms(string query)
    {
        return films.Where(f=>f.Title.Contains(query)||f.Director.Contains(query)).ToList();
    }
    public int GetTotalFilmCount()
    {
       return films.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        FilmLibrary library = new FilmLibrary();

        IFilm film1 = new Film { Title = "Harry Potter", Director = "David Yates", Year = 2007 };
        IFilm film2 = new Film { Title = "TheLordOfTheRings", Director = "Peter Jackson", Year = 2001 };

        library.AddFilm(film1);
        library.AddFilm(film2);

        Console.WriteLine("Total Film Count: " + library.GetTotalFilmCount());
        Console.WriteLine();

        string searchQuery = "DavidYates";
        var results = library.SearchFilms(searchQuery);

        Console.WriteLine("Search Results for " + searchQuery + ":");
        foreach (var film in results)
        {
            Console.WriteLine(film);
        }

        Console.WriteLine();

        library.RemoveFilm("TheLordOfTheRings");

        Console.WriteLine();
        Console.WriteLine("All Films:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine(film);
        }
    }
}