using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Periodical.Web.Models;
using Periodical.Web.Models.Shared;
using Periodical.Infrastructure;
using Periodical.BusinessLogic.Repositories;

namespace Periodical.Web.Controllers
{
    public class HomeController : Controller
    {
        PublicationRepository publicationRepository = new PublicationRepository();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            List<PublicationModel> model = new List<PublicationModel>();
            List<IPublication> allPublications = publicationRepository.AllPublication;
            foreach (IPublication publication in allPublications)
            {
                model.Add(new PublicationModel(publication, publicationRepository.GetTopicsToPublication(publication.PublicationId)));
            }
            return View(model);
        }

    }
}
