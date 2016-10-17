using System.Web.Mvc;
using Demo.WebSite.Mvc.Routing.Dal;
using Demo.WebSite.Mvc.Routing.Models;
using PagedList;

namespace Demo.WebSite.Mvc.Routing.Controllers
{
    public class HomeController : Controller
    {
	    private const int PAGE_SIZE = 5;

		private readonly CertifiedRepository _repository = new CertifiedRepository();

		public ActionResult Index(int page = 1)
        {
			//var certifiedItems = GetCertifiedItems(page);
			//return View(certifiedItems);
			var certifiedBatches = GetCertifiedBatches(page);

            return View(certifiedBatches);
        }

	    private IPagedList<CertifiedBatch> GetCertifiedBatches(int page)
	    {
			return _repository.GetCertifiedBatches().ToPagedList(page, PAGE_SIZE);
		}

		private IPagedList<CertifiedItem> GetCertifiedItems(int page)
	    {
		    return _repository.GetCertifiedItems().ToPagedList(page, PAGE_SIZE);
	    }
    }
}