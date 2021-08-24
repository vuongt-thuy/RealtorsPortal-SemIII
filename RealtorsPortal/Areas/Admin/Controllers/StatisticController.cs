using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;

namespace RealtorsPortal.Areas.Admin.Controllers
{
    public class StatisticController : Controller
    {

        private Respository<Transaction> transactionRespository;

        public StatisticController()
        {
            transactionRespository = new Respository<Transaction>();
        }

        // GET: Admin/Statistic
        public ActionResult Category()
        {
            return View();
        }

        public ActionResult User()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Ads()
        {
            return View();
        }
        public ActionResult GetTransaction(String startDate, String endDate)
        {
            var data = transactionRespository.GetAll().ToList().Where(item => item.CreatedAt >= DateTime.Parse(startDate) && item.CreatedAt <= DateTime.Parse(endDate));
            var result = data.Select(S => new {
                Id = S.Id,
                UserName = S.User.Username,
                TotalMoney = S.TotalMoney,
                CreatedAt = S.CreatedAt.ToString()
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}