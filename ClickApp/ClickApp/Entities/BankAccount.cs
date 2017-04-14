using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClickApp.Models;
using System.Data.Entity;

namespace ClickApp.Entities
{
    public class BankAccount
    {

        public ClickAppDBEntities _entities = new ClickAppDBEntities();


        public Account GetAccount()
        { 
            Account _account = (from a in _entities.Accounts
                      select a).First();
            return _account;

        }

        public void CreateAccount(Account _account)
        {
             
            _account.Balance = _account.Initial;
            _entities.Entry(_account).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public void Deposit(Account _account)
        {
            _account.Balance = _account.Balance + _account.Deposit;
            _entities.Entry(_account).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public void AddInterest(Account _account)
        {
            _account.Balance = _account.Balance + (_account.Balance * (_account.Interest / 100));
            _entities.Entry(_account).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public void Withdraw(Account _account)
        {
            _account.Balance = _account.Balance - _account.Withdraw;
            _entities.Entry(_account).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        public Account GetBalance(Account _account)
        {
            _account.DisplayBalance = _account.Balance;
            return _account;
        }

  


    }
}