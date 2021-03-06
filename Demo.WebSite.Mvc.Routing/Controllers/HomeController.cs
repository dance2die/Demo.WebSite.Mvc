﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Demo.WebSite.Mvc.Routing.Dal;
using Demo.WebSite.Mvc.Routing.Models;
using PagedList;

namespace Demo.WebSite.Mvc.Routing.Controllers
{
    public class HomeController : Controller
    {
	    private const int PAGE_SIZE = 10;

		private readonly CertifiedRepository _repository = new CertifiedRepository();

		public ActionResult Index(int page = 1)
        {
			var certifiedBatches = GetCertifiedBatches(page);

	        if (Request.IsAjaxRequest())
	        {
		        return PartialView("_Batches", certifiedBatches);
	        }

            return View(certifiedBatches);
        }

	    public ActionResult Detail(int certifiedBatchId)
	    {
		    var certifiedItems = GetCertifiedItems(certifiedBatchId).ToList();

		    return View(certifiedItems);
	    }

	    private IPagedList<CertifiedBatch> GetCertifiedBatches(int page)
	    {
			return _repository.GetCertifiedBatches().ToPagedList(page, PAGE_SIZE);
		}

	    private IEnumerable<CertifiedItem> GetCertifiedItems(int certifiedBatchId)
	    {
		    return _repository.GetCertifiedItems(certifiedBatchId);
	    }

		[HttpPost]
	    public ActionResult VoidSubmit(IEnumerable<CertifiedItem> certifiedItems)
	    //public ActionResult VoidSubmit(object items)
	    {
		    Console.WriteLine(certifiedItems);

		    return View("Detail", certifiedItems);
	    }
    }
}