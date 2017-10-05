using System.Collections.Generic;

namespace AngularWithMVC.Domain
{
	public class Writer
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string FullName => $"{FirstName} {LastName}";

		//public List<BlogPost> BlogPosts { get; set; }
	}
}