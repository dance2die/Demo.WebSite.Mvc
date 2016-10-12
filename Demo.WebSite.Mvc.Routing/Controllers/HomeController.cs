using System.Collections.Generic;
using System.Web.Mvc;
using Demo.WebSite.Mvc.Routing.Dal;
using Demo.WebSite.Mvc.Routing.Models;

namespace Demo.WebSite.Mvc.Routing.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
	        var certifiedItems = GetCertifiedItems();

            return View(certifiedItems);
        }

	    private IEnumerable<CertifiedItem> GetCertifiedItems()
	    {
		    CertifiedRepository repository = new CertifiedRepository();
		    return repository.GetCertifiedItems();
	    }
    }
}