namespace AngularWithMVC.Domain
{
    public class BlogPostRead
    {
        public int BlogPostId { get; set; }
        public int ReaderId { get; set; }

        public BlogPost BlogPost { get; set; }
        public Reader Reader { get; set; }

    }
}