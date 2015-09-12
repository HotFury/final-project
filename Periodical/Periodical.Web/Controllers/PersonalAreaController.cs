using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Periodical.Web.Models.PersonalArea;
using Periodical.BusinessLogic.Repositories;
using Periodical.Infrastructure;
using Periodical.Web.Filters;


namespace Periodical.Web.Controllers
{
    [ForCurrentUser]
    public class PersonalAreaController : Controller
    {
        //
        // GET: /PersonalArea/
        private UserRequisitiesRepository requisitiesRepository = new UserRequisitiesRepository();
        public ActionResult ShowRequisites(string id)
        {
            var user = User.Identity.Name;
            UserRequsitiesModel result = new UserRequsitiesModel(requisitiesRepository.GetUserRequisites(id), id);
            if (result.exist)
                return View(result);
            else
                return RedirectToRoute(new { controller = "PersonalArea", action = "ManageRequisities", id = id });
        }
        public ActionResult ManageRequisities(string id)
        {
            UserRequsitiesModel result = new UserRequsitiesModel(requisitiesRepository.GetUserRequisites(id), id);
            return View(result);
        }
        [HttpPost]
        public ActionResult ManageRequisities(UserRequsitiesModel model)
        {
            requisitiesRepository.ManageRequisities(model);
            return RedirectToRoute(new { controller = "PersonalArea", action = "ShowRequisites", id =  model.Nick});
        }
    }
}
