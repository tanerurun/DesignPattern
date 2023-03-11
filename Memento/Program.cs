internal class Program
{
    private static void Main(string[] args)
    {
        Book book = new Book();
        book.Isbn = "1232";
        book.Title = "Title";
        book.Author = "Taner";
        book.ShowBook();
        CareTaker history = new CareTaker();
        history.Memento = book.CreateUndo();
        book.Isbn = "44444";
        book.Title = "taner urun";
        book.ShowBook();

        book.RestoreFromUndo(history.Memento);
        book.ShowBook();

    }
}

class Book
{
    private string _author;
    private string _title;
    private string _isbin;
    private DateTime _date;
    public string Title
    {
        get { return _title; }//value read
        set { _title = value; } //value write
    }
    public string Author
    {
        get { return _author; }
        set { _author = value; SetLestEdited(); }
    }
    public string Isbn
    {
        get { return _isbin; }
        set { _isbin = value; SetLestEdited(); }
    }
    private void SetLestEdited()
    {
        _date = DateTime.UtcNow;
    }

    public Memento CreateUndo()
    {
        return new Memento(_isbin, _title, _date, _author);
    }

    public void RestoreFromUndo(Memento memento)
    {
        _title = memento.Title;
        _author = memento.Author;
        _isbin = memento.Isbn;
        _date = memento.LastEdited;

    }

    public void ShowBook()
    {
        Console.WriteLine("{0},{1},{2} edited :{3}", Isbn, Author, Title, _date);
    }

}

public class Memento
{
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime LastEdited { get; set; }
    public Memento(string _isbn, string _title, DateTime _lastEdit, string _author)
    {
        Isbn = _isbn;
        Title = _title;
        Author = _author;
        LastEdited = _lastEdit;
    }

}


class CareTaker
{
    public Memento Memento { get; set; }
}