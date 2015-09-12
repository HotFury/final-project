using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Periodical.Web.Models.Shared;
using Periodical.BusinessLogic.Repositories;
using Periodical.Infrastructure;
using Periodical.Web.Filters;
using System.IO;
using System.Text.RegularExpressions;
using Periodical.Web.Models.Admin;

namespace Periodical.Web.Controllers
{
    [ForAdmin]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        UserControlRepository userControlRepository = new UserControlRepository();
        PublicationRepository publicationRepository = new PublicationRepository();
        private string GetSafePath(string path)
        {
            if (System.IO.File.Exists(path))
            {
                Regex regex = new Regex(@"\.[a-zA-Z]+$");
                Match match = regex.Match(path);
                string fileExtention = match.Value;
                string newPath = path.Replace(fileExtention, String.Empty);
                newPath += "copy" + fileExtention;
                return GetSafePath(newPath);
            }
            else
            {
                return path;
            }
        }
        public ActionResult Manage()
        {
            return View();
        }
        public ActionResult UsersControl()
        {
            
            List<UserControlModel> model = new List<UserControlModel>();
            List<IUser> allUsers = userControlRepository.AllUsers;
            foreach(IUser user in allUsers)
            {
                model.Add(new UserControlModel(user, userControlRepository.GetUserDetails(user.UserId), userControlRepository.GetUserRoles(user.UserId)));
            }
            return View(model);
        }
        public ActionResult ToggleActive(int id)
        {
            userControlRepository.ToggleActive(id);
            return RedirectToAction("UsersControl");
        }
        public ActionResult DeleteUser(int id)
        {
            userControlRepository.DeleteUser(id);
            return RedirectToAction("UsersControl");
        }
        public ActionResult RolesControl(int id)
        {
            UserControlModel result = new UserControlModel(userControlRepository.GetUser(id), userControlRepository.GetUserDetails(id), userControlRepository.GetUserRoles(id));
            return View(result);
        }
        public ActionResult AttachAdminRole(string id)
        {
            userControlRepository.AttachRole(id, "Admin");
            return RedirectToRoute(new { controller = "Admin", action = "RolesControl", id = userControlRepository.GetUserId(id) });
        }
        public ActionResult AttachFinanceRole(string id)
        {
            userControlRepository.AttachRole(id, "Finance");
            return RedirectToRoute(new { controller = "Admin", action = "RolesControl", id = userControlRepository.GetUserId(id) });
        }
        public ActionResult DeAttachAdminRole(string id)
        {
            userControlRepository.DeAttachRole(id, "Admin");
            return RedirectToRoute(new { controller = "Admin", action = "RolesControl", id = userControlRepository.GetUserId(id) });
        }
        public ActionResult DeAttachFinanceRole(string id)
        {
            userControlRepository.DeAttachRole(id, "Finance");
            return RedirectToRoute(new { controller = "Admin", action = "RolesControl", id = userControlRepository.GetUserId(id) });
        }
        public ActionResult PublicationsControl()
        {
            List<PublicationControlModel> model = new List<PublicationControlModel>();
            List<IPublication> allPublications = publicationRepository.AllPublication;
            foreach(IPublication publication in allPublications)
            {
                model.Add(new PublicationControlModel(publication));
            }
            return View(model);
        }
        public ActionResult EditPublication(int? id)
        {
            ViewBag.ImagePath = "/Images/No-Image.png";
            if (id == null)
            {
                return View();
            }
            else
            {
                PublicationModel model = new PublicationModel(publicationRepository.GetPublicationById((int)id), publicationRepository.GetTopicsToPublication((int)id));
                if (model.LinkToCover != null)
                    ViewBag.ImagePath = model.LinkToCover;
                return View(model);
            }
        }
        public ActionResult AttachImage(HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                string loadedFileName = System.IO.Path.GetFileName(image.FileName);
                byte[] Content;
                using (var reader = new System.IO.BinaryReader(image.InputStream))
                {
                    Content = reader.ReadBytes(image.ContentLength);
                }
                string appPath = HttpContext.Request.PhysicalApplicationPath;
                string path = appPath + "Images\\covers\\" + loadedFileName;
                string safePath = GetSafePath(path);

                Regex getFileNameRegex = new Regex(@"[^\\]*$");
                Match match = getFileNameRegex.Match(safePath);
                string saveFileName = match.Value;

                ViewBag.ImagePath = "/Images/covers/" + saveFileName;
                System.IO.File.WriteAllBytes(safePath, Content);
            }
            return PartialView();
        }
        [HttpPost]
        public ActionResult UpdatePublications(PublicationModel model)
        {
            string[] topics = model.Topics.Split(',');
            List<string> topicsList = new List<string>();
            foreach(string item in topics)
            {
                if (item.Trim() != String.Empty)
                {
                    topicsList.Add(item.Trim());
                }
            }
            publicationRepository.SavePublication(model, topicsList.ToArray());
            return RedirectToAction("PublicationsControl");
        }
        public ActionResult DeletePublication(int id)
        {
            string returnUrl = Request.UrlReferrer.ToString();
            publicationRepository.DeletePublication(id);
            return Redirect(returnUrl);
        }
    }
}