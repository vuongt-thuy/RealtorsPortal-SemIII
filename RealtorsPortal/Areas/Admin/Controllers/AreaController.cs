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
    public class AreaController : Controller
    {

        private Respository<Country> countryRespository;

        private Respository<City> cityRespository;

        private Respository<District> districtRespository;

        private Respository<Ward> wardRespository;

        public AreaController()
        {
            countryRespository = new Respository<Country>();
            cityRespository = new Respository<City>();
            districtRespository = new Respository<District>();
            wardRespository = new Respository<Ward>();
        }

        // GET: Admin/Area
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllCountry()
        {
            var data = countryRespository.GetAll().ToList();
            var result = data.Select(S => new {
                Id = S.Id,
                Name = S.Name,
                Parent = ""
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCountryById(int id)
        {
            var country = countryRespository.FindById(id);
            var result = new {
                Id = country.Id,
                Name = country.Name,
                Parent = ""
            };
            return Json(new ResponeJSON<Object>
            {
                statusCode = 200,
                msg = "Successfully!",
                data = result
            }, JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        public JsonResult CreateCountry([Bind(Exclude = "Id")] Country country)
        {
            if (ModelState.IsValid)
            {
                if (countryRespository.Create(country))
                {
                    return Json(new ResponeJSON<Country>
                    {
                        statusCode = 200,
                        msg = "Create Country Successfully!",
                        data = country
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
                msg = "Create Error!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                if (countryRespository.Update(country))
                {
                    return Json(new ResponeJSON<Country>
                    {
                        statusCode = 200,
                        msg = "Update Country Successfully!",
                        data = country
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
                msg = "Update Error!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCountryById(int id)
        {
            if (countryRespository.Delete(id))
            {
                return Json(new ResponeJSON<Country>
                {
                    statusCode = 200,
                    msg = "Delete Succesfully!",
                    data = null
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new ResponeJSON<Country>
            {
                statusCode = 201,
                msg = "Delete Fail!",
                data = null
            }, JsonRequestBehavior.AllowGet); ;
        }

        public ActionResult GetAllCity()
        {
            var data = cityRespository.GetAll().ToList();
            var result = data.Select(S => new {
                Id = S.Id,
                Name = S.Name,
                Parent = S.Country.Name
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCityById(int id)
        {
            var city = cityRespository.FindById(id);
            var result = new
            {
                Id = city.Id,
                Name = city.Name,
                Parent = city.Country.Id
            };
            return Json(new ResponeJSON<Object>
            {
                statusCode = 200,
                msg = "Successfully!",
                data = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateCity([Bind(Exclude = "Id")] City city)
        {
            if (ModelState.IsValid)
            {
                if (cityRespository.Create(city))
                {
                    return Json(new ResponeJSON<City>
                    {
                        statusCode = 200,
                        msg = "Create City Successfully!",
                        data = city
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
                msg = "Create Error!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCity(City city)
        {
            if (ModelState.IsValid)
            {
                if (cityRespository.Update(city))
                {
                    return Json(new ResponeJSON<City>
                    {
                        statusCode = 200,
                        msg = "Update City Successfully!",
                        data = city
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
                msg = "Update Error!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCityById(int id)
        {
            if (cityRespository.Delete(id))
            {
                return Json(new ResponeJSON<City>
                {
                    statusCode = 200,
                    msg = "Delete Succesfully!",
                    data = null
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new ResponeJSON<City>
            {
                statusCode = 201,
                msg = "Delete Fail!",
                data = null
            }, JsonRequestBehavior.AllowGet); ;
        }

        public ActionResult GetAllDistrict()
        {
            var data = districtRespository.GetAll().ToList();
            var result = data.Select(S => new {
                Id = S.Id,
                Name = S.Name,
                Parent = S.City.Name
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistrictById(int id)
        {
            var district = districtRespository.FindById(id);
            var result = new
            {
                Id = district.Id,
                Name = district.Name,
                Parent = district.City.Id
            };
            return Json(new ResponeJSON<Object>
            {
                statusCode = 200,
                msg = "Successfully!",
                data = result
            }, JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        public JsonResult CreateDistrict([Bind(Exclude = "Id")] District district)
        {
            if (ModelState.IsValid)
            {
                if (districtRespository.Create(district))
                {
                    return Json(new ResponeJSON<District>
                    {
                        statusCode = 200,
                        msg = "Create Country Successfully!",
                        data = district
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
                msg = "Create Error!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateDistrict(District district)
        {
            if (ModelState.IsValid)
            {
                if (districtRespository.Update(district))
                {
                    return Json(new ResponeJSON<District>
                    {
                        statusCode = 200,
                        msg = "Update Country Successfully!",
                        data = district
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
                msg = "Update Error!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteDistrictById(int id)
        {
            if (districtRespository.Delete(id))
            {
                return Json(new ResponeJSON<District>
                {
                    statusCode = 200,
                    msg = "Delete Succesfully!",
                    data = null
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new ResponeJSON<District>
            {
                statusCode = 201,
                msg = "Delete Fail!",
                data = null
            }, JsonRequestBehavior.AllowGet); ;
        }

        public ActionResult GetAllWard()
        {
            var data = wardRespository.GetAll().ToList();
            var result = data.Select(S => new {
                Id = S.Id,
                Name = S.Name,
                Parent = S.District.Name
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWardById(int id)
        {
            var ward = wardRespository.FindById(id);
            var result = new
            {
                Id = ward.Id,
                Name = ward.Name,
                Parent = ward.District.Id
            };
            return Json(new ResponeJSON<Object>
            {
                statusCode = 200,
                msg = "Successfully!",
                data = result
            }, JsonRequestBehavior.AllowGet); ;
        }

        [HttpPost]
        public JsonResult CreateWard([Bind(Exclude = "Id")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                if (wardRespository.Create(ward))
                {
                    return Json(new ResponeJSON<Ward>
                    {
                        statusCode = 200,
                        msg = "Create Country Successfully!",
                        data = ward
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
                msg = "Create Error!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateWard(Ward ward)
        {
            if (ModelState.IsValid)
            {
                if (wardRespository.Update(ward))
                {
                    return Json(new ResponeJSON<Ward>
                    {
                        statusCode = 200,
                        msg = "Update Country Successfully!",
                        data = ward
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
                msg = "Update Error!",
                data = errors
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteWardById(int id)
        {
            if (wardRespository.Delete(id))
            {
                return Json(new ResponeJSON<Ward>
                {
                    statusCode = 200,
                    msg = "Delete Succesfully!",
                    data = null
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new ResponeJSON<Ward>
            {
                statusCode = 201,
                msg = "Delete Fail!",
                data = null
            }, JsonRequestBehavior.AllowGet); ;
        }
    }
}