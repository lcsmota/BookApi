namespace BookApi.Models;
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nationality { get; set; }
    public string Occupation { get; set; }
    public List<Book> Books { get; set; } = new();
}
