using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using RealtorsPortal.Areas.Admin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.Admin.Controllers
{
    [CustomeAuthentication]
    public class PackageController : Controller
    {
        private Respository<Package> resPackage;
        
        // GET: Admin/Package
        public ActionResult Index()
        {
            return View();
        }

        public PackageController()
        {
            resPackage = new Respository<Package>();
        }

        public ActionResult LoadPackages()
        {
            var data = resPackage.GetAll().ToList();
            return Json(resPackage.GetAll(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AdminPackagesCreate([Bind(Exclude = "Id")] Package package)
        {
            if (ModelState.IsValid)
            {
                if (!resPackage.CheckDuplicate(x => x.Name.Equals(package.Name)))
                {
                    package.CreatedAt = DateTime.Now;
                    package.UpdatedAt = DateTime.Now;
                    if (resPackage.Create(package))
                    {
                        return Json(new ResponeJSON<Package>
                        {
                            statusCode = 200,
                            msg = "Create Package Successfully!",
                            data = package
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var error = new Dictionary<string, string>(){
                        {"Name", "Name is duplicated!"},
                    };
                    return Json(new ResponeJSON<Dictionary<string, string>>
                    {
                        statusCode = 201,
                        msg = "Create Package Fail!",
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
                msg = "Create Package Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AdminPackagesDelete(int id)
        {
            if (resPackage.Delete(id))
            {
                return Json(new ResponeJSON<Package>
                {
                    statusCode = 200,
                    msg = "Delete Succesfully!",
                    data = null
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new ResponeJSON<Package>
            {
                statusCode = 201,
                msg = "Delete Fail!",
                data = null
            }, JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult Get(int id)
        {
            return Json(new ResponeJSON<Package>
            {
                statusCode = 200,
                msg = "Successfully!",
                data = resPackage.FindById(id)
            }, JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult AdminPackagesEdit(Package package)
        {
            if (ModelState.IsValid)
            {
                if (!resPackage.CheckDuplicate(x => x.Name.Equals(package.Name) && x.Id != package.Id))
                {
                    package.CreatedAt = DateTime.Now;
                    package.UpdatedAt = DateTime.Now;
                    if (resPackage.Update(package))
                    {
                        return Json(new ResponeJSON<Package>
                        {
                            statusCode = 200,
                            msg = "Update Package Successfully!",
                            data = package
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var error = new Dictionary<string, string>(){
                        {"Name", "Name is duplicated!"},
                    };
                    return Json(new ResponeJSON<Dictionary<string, string>>
                    {
                        statusCode = 201,
                        msg = "Create Package Fail!",
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
                msg = "Create Package Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        public PackageController()
        {
            resPackage = new Respository<Package>();
        }

        public ActionResult LoadPackages()
        {
            var data = resPackage.GetAll().ToList();
            return Json(resPackage.GetAll(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AdminPackagesCreate([Bind(Exclude = "Id")] Package package)
        {
            if (ModelState.IsValid)
            {
                if (!resPackage.CheckDuplicate(x => x.Name.Equals(package.Name)))
                {
                    package.CreatedAt = DateTime.Now;
                    package.UpdatedAt = DateTime.Now;
                    if (resPackage.Create(package))
                    {
                        return Json(new ResponeJSON<Package>
                        {
                            statusCode = 200,
                            msg = "Create Package Successfully!",
                            data = package
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var error = new Dictionary<string, string>(){
                        {"Name", "Name is duplicated!"},
                    };
                    return Json(new ResponeJSON<Dictionary<string, string>>
                    {
                        statusCode = 201,
                        msg = "Create Package Fail!",
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
                msg = "Create Package Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AdminPackagesDelete(int id)
        {
            if (resPackage.Delete(id))
            {
                return Json(new ResponeJSON<Package>
                {
                    statusCode = 200,
                    msg = "Delete Succesfully!",
                    data = null
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new ResponeJSON<Package>
            {
                statusCode = 201,
                msg = "Delete Fail!",
                data = null
            }, JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult Get(int id)
        {
            return Json(new ResponeJSON<Package>
            {
                statusCode = 200,
                msg = "Successfully!",
                data = resPackage.FindById(id)
            }, JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult AdminPackagesEdit(Package package)
        {
            if (ModelState.IsValid)
            {
                if (!resPackage.CheckDuplicate(x => x.Name.Equals(package.Name) && x.Id != package.Id))
                {
                    package.CreatedAt = DateTime.Now;
                    package.UpdatedAt = DateTime.Now;
                    if (resPackage.Update(package))
                    {
                        return Json(new ResponeJSON<Package>
                        {
                            statusCode = 200,
                            msg = "Update Package Successfully!",
                            data = package
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var error = new Dictionary<string, string>(){
                        {"Name", "Name is duplicated!"},
                    };
                    return Json(new ResponeJSON<Dictionary<string, string>>
                    {
                        statusCode = 201,
                        msg = "Create Package Fail!",
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
                msg = "Create Package Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }
    }
}