using BusinessLogicLayer.Mapper;
using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.ViewModel;
using RealtorsPortal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorsPortal.Controllers
{
    public class HomeController : Controller
    {
        private Respository<Category> resCat;
        private Respository<Country> resCountry;
        private Respository<Ads> resAds;

        public HomeController()
        {
            resCat = new Respository<Category>();
            resCountry = new Respository<Country>();
            resAds = new Respository<Ads>();
        }

        public ActionResult Index()
        {
            ViewBag.countries = resCountry.GetAll();
            ViewBag.categories = resCat.GetList(x => x.Active == true);
            ViewBag.latestAds = resAds.GetList(x => x.Status == SystemConstant.APPROVED)
                                        .OrderByDescending(x => x.CreatedAt)
                                        .Take(10)
                                        .Select(x => new AdsMapper().Mapping(x)); 
            return View();
        }

        [HttpGet]
        public ActionResult Calculator()
        {
            return View("MortgageCalculator");
        }

        [HttpPost]
        public JsonResult Calculator(double loanAmount, double rateInterest, int loanTerm)
        {

            double totalInterest = 0;
            double totalMonthlyPaid = 0;
            double initalMoney = loanAmount;
            double intialMoneyPaidByMonth = 0;
            double payment = initalMoney / (loanTerm * 12);
            double monthlyRate = rateInterest/ 12;
            List<MortgageCalculator> result = new List<MortgageCalculator>();
            for (int i = 1; i <= loanTerm*12; i++)
            {
                double interest = (loanAmount - intialMoneyPaidByMonth) * (monthlyRate / 100);
                intialMoneyPaidByMonth = interest;
                double balance = loanAmount + intialMoneyPaidByMonth - payment;
                loanAmount = Math.Ceiling(balance);
                totalMonthlyPaid += payment;
                totalInterest += interest;
                result.Add(new MortgageCalculator(i, payment, intialMoneyPaidByMonth, balance));
            }

            double totalInitalMoneyAndInterest = Math.Ceiling(totalInterest + initalMoney);

            return Json(new {
                totalInterest = Math.Ceiling(totalInterest),
                totalMonthlyPaid = Math.Ceiling(totalMonthlyPaid),
                totalInitalMoneyAndInterest = Math.Ceiling(totalInitalMoneyAndInterest),
                data = result,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}