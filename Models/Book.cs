namespace BookApi.Models;
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public short Pages { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishedAt { get; set; }
    public int AuthorId { get; set; }
}
