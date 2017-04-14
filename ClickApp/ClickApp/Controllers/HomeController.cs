using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClickApp.Models;
using ClickApp.Entities;

namespace ClickApp.Controllers
{

    public class HomeController : Controller
    {
  
        private BankAccount _bankAccount = new BankAccount();

        // GET: Home
        public ActionResult Index()
        {

            Account _account = _bankAccount.GetAccount();

            return View(_account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string submit, [Bind(Include = "Id,Balance,Interest,Deposit,Withdraw,Initial,DisplayBalance")] Account _account)
        {
            //var _account = (from c in _entities.Accounts
            //                select c).First();

            switch (submit)
            {
                case "Create Account":
                    _bankAccount.CreateAccount(_account);
                    break;
                case "Deposit":
                    _bankAccount.Deposit(_account);
                    break;
                case "Add Interest":
                    _bankAccount.AddInterest(_account);
                    break;
                case "Withdraw":
                    _bankAccount.Withdraw(_account);
                    break;
                case "Get Balance":
                    Account _displayAccount = _bankAccount.GetBalance(_account);
                    return View(_displayAccount);
            }

            return RedirectToAction("Index", "Home");
        }


    }
}