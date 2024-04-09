using School_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scool_API.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void Deposit_GiventDecimal_DepositsMoney()
        {
            BankAccount bankAc = new();
            decimal balance = bankAc.Balance;
            bankAc.Deposit(100);
            Assert.Equal(balance+100, bankAc.Balance);
        }

        [Fact]
        public void Withdraw_GivenDecimal_WithdrawsMoney()
        {
            BankAccount bankAc = new();
            decimal balance = bankAc.Balance;
            bankAc.Withdraw(20);
            Assert.Equal(balance - 20, bankAc.Balance);
        }

        [Fact]
        public void Withdraw_InsufficinetFunds_ThrowException()
        {
            BankAccount bankAc = new();
            decimal balance = bankAc.Balance;

            Assert.Throws<ArgumentException>(() => bankAc.Withdraw(120));
        }
    }
}
