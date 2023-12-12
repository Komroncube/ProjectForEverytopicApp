namespace ProjectForEveryTopic.Domain;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Book()
    {
        
    }
    public Book(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
