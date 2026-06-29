using System;

namespace BankAccountApp
{
    public class BankAccount
    {
        private decimal _balance;

        public BankAccount()
        {
            _balance = 0m;
        }

        /// <summary>
        /// Deposits the specified amount into the account.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when amount is zero or negative.</exception>
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be greater than zero.", nameof(amount));

            _balance += amount;
        }

        /// <summary>
        /// Withdraws the specified amount from the account.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when amount is zero or negative.</exception>
        /// <exception cref="InvalidOperationException">Thrown when amount exceeds current balance (overdraft).</exception>
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be greater than zero.", nameof(amount));

            if (amount > _balance)
                throw new InvalidOperationException(
                    string.Format("Insufficient funds. Cannot withdraw {0}; current balance is {1}.", amount, _balance));

            _balance -= amount;
        }

        /// <summary>
        /// Returns the current account balance.
        /// </summary>
        public decimal GetBalance()
        {
            return _balance;
        }
    }
}
