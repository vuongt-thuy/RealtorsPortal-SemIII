using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using RealtorsPortal.Areas.Admin.Utils;
using RealtorsPortal.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.Admin.Controllers
{
    [CustomeAuthentication]
    public class AccountController : Controller
    {
        private Respository<User> resUser;
        private Respository<UserRole> resUserRole;

        public AccountController()
        {
            resUser = new Respository<User>();
            resUserRole = new Respository<UserRole>();
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        public JsonResult Get(int id)
        {
            return Json(new ResponeJSON<User>
            {
                statusCode = 200,
                msg = "Successfully!",
                data = resUser.FindById(id)
            }, JsonRequestBehavior.AllowGet); ;
        }

        // Admin User
        public ActionResult AdminUsers()
        {
            ViewBag.Roles = resUserRole.GetAll();
            return View("AdminUsers/Index");
        }

        [HttpPost]
        public JsonResult AdminUsersCreate([Bind(Exclude = "Id")] User user)
        {
            if (ModelState.IsValid)
            {
                if (!resUser.CheckDuplicate(x => x.Username.Equals(user.Username)))
                {
                    if (user.Avt != null)
                    {
                        user.Avt = "/Uploads/Users/" + user.Avt;
                    }
                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;
                    if (resUser.Create(user))
                    {
                        return Json(new ResponeJSON<User>
                        {
                            statusCode = 200,
                            msg = "Create Admin User Successfully!",
                            data = user
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var error = new Dictionary<string, string>(){
                        {"Username", "Username is duplicated!"},
                    };
                    return Json(new ResponeJSON<Dictionary<string, string>>
                    {
                        statusCode = 201,
                        msg = "Create Admin User Fail!",
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
                msg = "Create Admin User Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AdminUsersEdit(User user)
        {
            if (ModelState.IsValid)
            {
                if (!resUser.CheckDuplicate(x => x.Username.Equals(user.Username) && x.Id != user.Id))
                {
                    if (user.Avt != null)
                    {
                        user.Avt = "/Uploads/Users/" + user.Avt;
                    }
                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;
                    if (resUser.Update(user))
                    {
                        return Json(new ResponeJSON<User>
                        {
                            statusCode = 200,
                            msg = "Update Admin User Successfully!",
                            data = user
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var error = new Dictionary<string, string>(){
                        {"Username", "Username is duplicated!"},
                    };
                    return Json(new ResponeJSON<Dictionary<string, string>>
                    {
                        statusCode = 201,
                        msg = "Create Admin User Fail!",
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
                msg = "Update Admin User Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AdminUsersDelete(int id)
        {
            if (resUser.Delete(id))
            {
                return Json(new ResponeJSON<User>
                {
                    statusCode = 200,
                    msg = "Delete Succesfully!",
                    data = null
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new ResponeJSON<User>
            {
                statusCode = 201,
                msg = "Delete Fail!",
                data = null
            }, JsonRequestBehavior.AllowGet); ;
        }

        public ActionResult LoadAdminUsers()
        {
            var data = resUser.GetAll().ToList();
            return Json(resUser.GetAll(), JsonRequestBehavior.AllowGet);
        }

        // Private Sellers

        public ActionResult PrivateSellers()
        {
            return View("PrivateSellers/Index");
        }

        // Agentss

        public ActionResult Agents()
        {
            return View("Agents/Index");
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