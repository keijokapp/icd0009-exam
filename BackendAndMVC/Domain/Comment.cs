namespace Domain
{
    public class Comment : BaseEntity
    {
        public string CommentBody { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}