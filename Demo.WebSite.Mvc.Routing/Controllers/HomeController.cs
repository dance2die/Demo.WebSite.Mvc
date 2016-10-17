using System.Web.Mvc;
using Demo.WebSite.Mvc.Routing.Dal;
using Demo.WebSite.Mvc.Routing.Models;
using PagedList;

namespace Demo.WebSite.Mvc.Routing.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int page = 1)
        {
	        var certifiedItems = GetCertifiedItems(page);

            return View(certifiedItems);
        }

	    private IPagedList<CertifiedItem> GetCertifiedItems(int page)
	    {
		    CertifiedRepository repository = new CertifiedRepository();
		    const int pageSize = 5;
		    return repository.GetCertifiedItems().ToPagedList(page, pageSize);
	    }
    }
}