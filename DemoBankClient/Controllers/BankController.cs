using DemoBankClient.BankService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoBankClient.Controllers
{
    public class BankController : Controller
    {
        BankService.ServiceClient serviceClient = new BankService.ServiceClient();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Account account)
        {
            serviceClient.Register(account);
            return View("Successful");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string phone, string password)
        {
            if (ModelState.IsValid)
            {
                serviceClient.Login(phone, password);
                return View("Successful");
            }
            else
            {
                return View("Fail");
            }
        }
        public ActionResult AccountBalance()
        {
            ViewBag.Balance = "10000";
            return View();
        }
        [HttpGet]
        public ActionResult Deposit()
        {
            return View("Transaction");
        }
        [HttpPost]
        public ActionResult Deposit(double amount)
        {
            if (ModelState.IsValid)
            {
                ViewBag.NewBalance = serviceClient.Deposit(amount);
                return View("AccountBalance");
            }
            else {
                return View("Fail");
            }
        }
        [HttpGet]
        public ActionResult WithDrawal()
        {
            return View("Transaction");
        }
        [HttpPost]
        public ActionResult WithDrawal(double amount)
        {
            if (ModelState.IsValid)
            {
                ViewBag.NewBalance2 = serviceClient.Withdrawal(amount);
                return View("AccountBalance");
            }
            else
            {
                return View("Fail");
            }   
        }
        public ActionResult Tranfer()
        {

            return View();
        }
        public ActionResult TransactionHistory()
        {
            return View();
        }
        public ActionResult Successful()
        {
            return View();
        }
        public ActionResult Fail()
        {
            return View();
        }
    }
}