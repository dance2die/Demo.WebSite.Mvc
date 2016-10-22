using System.Collections.Generic;
using System.Web.Mvc;

namespace Demo.WebSite.Mvc.Routing.Controllers
{
	public class TestController : Controller
	{
		/// <remarks>
		/// http://stackoverflow.com/a/15375949/4035
		/// </remarks>
		public ActionResult Index()
		{
			var initialData = new[] {
				new Person { PersonId = 1, FirstName = "Sung1", LastName = "Meister1" },
				new Person { PersonId = 2, FirstName = "Sung2", LastName = "Meister2" },
				new Person { PersonId = 3, FirstName = "Sung3", LastName = "Meister3" },
			};
			return View(initialData);
		}

		public ViewResult Submit(IEnumerable<Person> persons)
		{
			
			return View("Index", persons);
		}
	}

	public class Person
	{
		public int PersonId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}