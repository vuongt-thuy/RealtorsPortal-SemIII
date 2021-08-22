using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using RealtorsPortal.Areas.UserBackend.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.UserBackend.Controllers
{
    [CustomeAuthentication]
    public class UserController : Controller
    {
        private Respository<UserRole> resUserRole;
        private Respository<User> resUser;

        public UserController()
        {
            resUserRole = new Respository<UserRole>();
            resUser = new Respository<User>();
        }

        // GET: UserBackend/User
        public ActionResult Information()
        {
            ViewBag.role = resUserRole.GetAll().Where(x => x.Active == true);
            return View();
        }

        [HttpPost]
        public JsonResult UpdateProfile(User user)
        {
            if (ModelState.IsValid)
            {
                if (!resUser.CheckDuplicate(x => x.Email.Equals(user.Email) && x.Id != user.Id))
                {
                    if (user.Avt != null)
                    {
                        user.Avt = "/Uploads/" + user.Avt;
                    }
                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;
                    if (resUser.Update(user))
                    {
                        return Json(new ResponeJSON<User>
                        {
                            statusCode = 200,
                            msg = "Profile update successful, please wait for account verification!",
                            data = user
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var error = new Dictionary<string, string>(){
                        {"Email", "Email is duplicated!"},
                    };
                    return Json(new ResponeJSON<Dictionary<string, string>>
                    {
                        statusCode = 201,
                        msg = "Email is duplicated!",
                        data = error
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            Dictionary<string, string> errors = new Dictionary<string, string>();
            foreach (var k in ModelState.Keys)
            {
                foreach (var err in ModelState[k].Errors)
                {
                    string key = Regex.Replace(k, @"(\w+)\.(\w+)", @"$2");
                    if (!errors.ContainsKey(key))
                    {
                        errors.Add(key, err.ErrorMessage);
                    }
                }
            }
            return Json(new ResponeJSON<Dictionary<string, string>>
            {
                statusCode = 201,
                msg = "Profile update failed!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCurrentUser()
        {
            var user = (User)Session["user"];
            return Json(new ResponeJSON<User>() {
                statusCode = 200,
                msg = "Oke",
                data = user
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool UploadImage()
        {
            if (HttpContext.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Request.Files["image"];
                var fileName = httpPostedFile.FileName;

                if (httpPostedFile != null)
                {
                    // OBtient le path du fichier 
                    var fileSavePath = Path.Combine(HttpContext.Server.MapPath("~/Uploads/Users/"), httpPostedFile.FileName);

                    // Sauvegarde du fichier dans UploadedFiles sur le serveur
                    httpPostedFile.SaveAs(fileSavePath);
                }
                return true;
            }
            return false;
        }
    }
}