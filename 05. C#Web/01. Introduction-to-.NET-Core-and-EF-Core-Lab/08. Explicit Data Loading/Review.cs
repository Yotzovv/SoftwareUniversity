public class Review
{
    public Review(int id, Item subjectItem)
    {
        Id = id;
        SubjectItem = subjectItem;
    }

    public int Id { get; set; }

    public Item SubjectItem { get; set; }
}
