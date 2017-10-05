using System.Collections.Generic;

namespace AngularWithMVC.Domain
{
    public class Reader
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public List<BlogPostRead> BlogPostReads { get; set; }
    }
}