# BankAccount

A C# `BankAccount` class with an NUnit test suite, built for a Test-Driven Development activity.

## What it does

- `Deposit(decimal amount)` — add money
- `Withdraw(decimal amount)` — take money out
- `GetBalance()` — read the balance

Rules: no zero/negative amounts (`ArgumentException`), and no overdrafts (`InvalidOperationException`).

## Structure

- `bankcore/` — the `BankAccount` class (a library; not meant to be run directly)
- `bankcore.test/` — the NUnit tests

## Run the tests

From the repo root:

```bash
dotnet test
```

Expected: `Passed! - Failed: 0, Passed: 11`