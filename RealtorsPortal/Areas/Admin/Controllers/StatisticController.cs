using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.ViewModel;
using Newtonsoft.Json;
using RealtorsPortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Areas.Admin.Controllers
{
    public class StatisticController : Controller
    {
        private Respository<User> resUser;
        private Respository<Ads> resAds;

        public StatisticController ()
        {
            resUser = new Respository<User>();
            resAds = new Respository<Ads>();
        }

        // GET: Admin/Statistic
        public ActionResult Category()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public JsonResult ChartUsers(int month, int year)
        {
            var users = resUser.GetList(x => x.CreatedAt.Month == month && x.CreatedAt.Year == year);
            var totalVistor = users.Where((x => x.RoleId == SystemConstant.VISITOR)).Count();
            var totalPrivateSeller = users.Where((x => x.RoleId == SystemConstant.PRIVATE_SELLER)).Count();
            var totalAgent = users.Where((x => x.RoleId == SystemConstant.AGENT)).Count();

            List<DataPoint> dataPoints = new List<DataPoint>();
            dataPoints.Add(new DataPoint(totalVistor, "Vistor"));
            dataPoints.Add(new DataPoint(totalPrivateSeller, "Private Seller"));
            dataPoints.Add(new DataPoint(totalAgent, "Agent"));

            return Json(new { 
                title = "Statistics Of The Number Of Users",
                data = dataPoints,
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChartAds(int month, int year)
        {
            var ads = resAds.GetList(x => x.CreatedAt.Month == month && x.CreatedAt.Year == year);
            var approvedAds = ads.Where((x => x.Status == SystemConstant.APPROVED)).Count();
            var unapprovedAds = ads.Where((x => x.Status == SystemConstant.UNAPPROVED)).Count();
            var unverified = ads.Where((x => x.Status == SystemConstant.UNVERIFIED)).Count();

            List<DataPoint> dataPoints = new List<DataPoint>();
            dataPoints.Add(new DataPoint(approvedAds, "Approved Ads"));
            dataPoints.Add(new DataPoint(unapprovedAds, "Unapproved Ads"));
            dataPoints.Add(new DataPoint(unverified, "Unverified Ads"));

            return Json(new
            {
                title = "Statistic Of Advertisements",
                data = dataPoints,
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Ads()
        {
            return View();
        }
    }
}