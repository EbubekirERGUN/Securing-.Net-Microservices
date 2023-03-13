namespace Movie.Client.Models;

public class Movies
{
    public int Id { get; set; }
    public string Title { get; set; }

    public string Genre { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string ImageUrl { get; set; }
    public string Rating { get; set; }
    public string Owner { get; set; }
}
