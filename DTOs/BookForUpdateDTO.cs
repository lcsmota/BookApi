namespace BookApi.DTOs;

public class BookForUpdateDTO
{
    public string Title { get; set; }
    public string Publisher { get; set; }
    public short Pages { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishedAt { get; set; }
    public int AuthorId { get; set; }
}
