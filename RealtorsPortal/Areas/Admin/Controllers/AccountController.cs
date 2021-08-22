using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using RealtorsPortal.Areas.Admin.Utils;
using RealtorsPortal.Controllers;
using RealtorsPortal.Utils;
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
            var res = resUser.FindById(id);
            return Json(new ResponeJSON<object>
            {
                statusCode = 200,
                msg = "Successfully!",
                data = new
                {
                    Id = res.Id,
                    Username = res.Username,
                    Fullname = res.Fullname,
                    Phone = res.Phone,
                    Email = res.Email,
                    Birthday = String.Format("{0:yyyy-MM-dd}", res.Birthday),
                    Address = res.Address,
                    Avt = res.Avt,
                    Company = res.Company,
                    Gender = res.Gender,
                    Password = res.Password,
                    RoleId = res.RoleId,
                }
            }, JsonRequestBehavior.AllowGet);
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
                if (!resUser.CheckDuplicate(x => x.Email.Equals(user.Email)))
                {
                    if (user.Avt != null)
                    {
                        user.Avt = "/Uploads/" + user.Avt;
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
                        {"Email", "Email is duplicated!"},
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
                            msg = "Update Admin User Successfully!",
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

        public JsonResult Delete(int id)
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
            return Json(resUser.GetList(x => x.RoleId == SystemConstant.ADMIN), JsonRequestBehavior.AllowGet);
        }

        // Private Sellers

        public ActionResult PrivateSellers()
        {
            ViewBag.Roles = resUserRole.GetAll();
            return View("PrivateSellers/Index");
        }

        [HttpPost]
        public ActionResult PrivateSellerCreate([Bind(Exclude = "Id")] User user)
        {
            if (ModelState.IsValid)
            {
                if (!resUser.CheckDuplicate(x => x.Email.Equals(user.Email)))
                {
                    if (user.Avt != null)
                    {
                        user.Avt = "/Uploads/" + user.Avt;
                    }
                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;
                    if (resUser.Create(user))
                    {
                        return Json(new ResponeJSON<User>
                        {
                            statusCode = 200,
                            msg = "Create Private Seller Successfully!",
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
                        msg = "Create Private Seller Fail!",
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
                msg = "Create Private Seller Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PrivateSellerEdit(User user)
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
                            msg = "Update Private Seller Successfully!",
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
                msg = "Update Private Seller Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadPrivateSellers()
        {
            return Json(resUser.GetList(x => x.RoleId == SystemConstant.PRIVATE_SELLER), JsonRequestBehavior.AllowGet);
        }

        // Agentss

        public ActionResult Agents()
        {
            ViewBag.Roles = resUserRole.GetAll();
            return View("Agents/Index");
        }

        [HttpPost]
        public ActionResult AgentCreate([Bind(Exclude = "Id")] User user)
        {
            if (ModelState.IsValid)
            {
                if (!resUser.CheckDuplicate(x => x.Email.Equals(user.Email)))
                {
                    if (user.Avt != null)
                    {
                        user.Avt = "/Uploads/" + user.Avt;
                    }
                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;
                    if (resUser.Create(user))
                    {
                        return Json(new ResponeJSON<User>
                        {
                            statusCode = 200,
                            msg = "Create Agent Successfully!",
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
                        msg = "Create Agent Fail!",
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
                msg = "Create Agent Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AgentEdit(User user)
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
                            msg = "Update Agent Successfully!",
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
                        msg = "Create Agent Fail!",
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
                msg = "Update Agent Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult LoadAgents()
        {
            return Json(resUser.GetList(x => x.RoleId == SystemConstant.AGENT), JsonRequestBehavior.AllowGet);
        }


        // Vistor
        public ActionResult Vistors()
        {
            ViewBag.Roles = resUserRole.GetAll();
            return View("Vistors/Index");
        }

        [HttpPost]
        public ActionResult VistorCreate([Bind(Exclude = "Id")] User user)
        {
            if (ModelState.IsValid)
            {
                if (!resUser.CheckDuplicate(x => x.Email.Equals(user.Email)))
                {
                    if (user.Avt != null)
                    {
                        user.Avt = "/Uploads/" + user.Avt;
                    }
                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;
                    if (resUser.Create(user))
                    {
                        return Json(new ResponeJSON<User>
                        {
                            statusCode = 200,
                            msg = "Create Vistor Successfully!",
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
                        msg = "Create Vistor Fail!",
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
                msg = "Create Vistor Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult VistorEdit(User user)
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
                            msg = "Update Vistor Successfully!",
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
                        msg = "Create Vistor Fail!",
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
                msg = "Update Vistor Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult LoadVistors()
        {
            return Json(resUser.GetList(x => x.RoleId == SystemConstant.VISITOR), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(int id)
        {
            return PartialView("~/Areas/Admin/Views/Account/_Detail.cshtml", resUser.FindById(id));
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