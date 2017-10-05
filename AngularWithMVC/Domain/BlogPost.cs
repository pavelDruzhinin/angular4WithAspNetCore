using System;
using System.Collections.Generic;

namespace AngularWithMVC.Domain
{
    public class BlogPost
    {
        public int Id { get; set; }
        public int WriterId { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
        public int ReadCounts { get; set; }
        
        public List<BlogPostRead> BlogPostReads { get; set; }
        public Writer Writer { get; set; }
    }
}