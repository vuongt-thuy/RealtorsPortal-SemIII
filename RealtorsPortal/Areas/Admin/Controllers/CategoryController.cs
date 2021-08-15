using RealtorsPortal.Areas.Admin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using System.Text.RegularExpressions;

namespace RealtorsPortal.Areas.Admin.Controllers
{
    [CustomeAuthentication]
    public class CategoryController : Controller
    {
        private Respository<Category> resCategory;

        public CategoryController()
        {
            resCategory = new Respository<Category>();
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadCategories()
        {
            var data = resCategory.GetAll().ToList();
            return Json(resCategory.GetAll(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AdminCategoriesCreate([Bind(Exclude = "Id")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (!resCategory.CheckDuplicate(x => x.Name.Equals(category.Name)))
                {
                    category.CreatedAt = DateTime.Now;
                    category.UpdatedAt = DateTime.Now;
                    if (resCategory.Create(category))
                    {
                        return Json(new ResponeJSON<Category>
                        {
                            statusCode = 200,
                            msg = "Create Admin User Successfully!",
                            data = category
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
                        msg = "Create Category Fail!",
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
                msg = "Create Category Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AdminCategoriesDelete(int id)
        {
            if (resCategory.Delete(id))
            {
                return Json(new ResponeJSON<User>
                {
                    statusCode = 200,
                    msg = "Delete Succesfully!",
                    data = null
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new ResponeJSON<Category>
            {
                statusCode = 201,
                msg = "Delete Fail!",
                data = null
            }, JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult Get(int id)
        {
            return Json(new ResponeJSON<Category>
            {
                statusCode = 200,
                msg = "Successfully!",
                data = resCategory.FindById(id)
            }, JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult AdminCategoriesEdit(Category category)
        {
            if (ModelState.IsValid)
            {
                if (!resCategory.CheckDuplicate(x => x.Name.Equals(category.Name) && x.Id != category.Id))
                {
                    category.CreatedAt = DateTime.Now;
                    category.UpdatedAt = DateTime.Now;
                    if (resCategory.Update(category))
                    {
                        return Json(new ResponeJSON<Category>
                        {
                            statusCode = 200,
                            msg = "Update Category Successfully!",
                            data = category
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
                        msg = "Create Category Fail!",
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
                msg = "Create Category Fail!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }
    }
}