using BankAccountApp;

namespace bankcore.test;

/// <summary>
/// Unit tests for the BankAccount class.
/// </summary>
public class BankAccountTests
{
    private BankAccount _account = null!;

    // Runs before EVERY test, giving each test a fresh, zero-balance account
    // so no test can be polluted by another test's deposits or withdrawals.
    [SetUp]
    public void Setup()
    {
        _account = new BankAccount();
    }

    //  Starting state 

    [Test]
    public void NewAccount_HasZeroBalance()
    {
        Assert.That(_account.GetBalance(), Is.EqualTo(0m));
    }

    // Deposit: happy path 

    [Test]
    public void Deposit_PositiveAmount_IncreasesBalance()
    {
        _account.Deposit(100m);

        Assert.That(_account.GetBalance(), Is.EqualTo(100m));
    }

    [Test]
    public void Deposit_MultipleTimes_AccumulatesBalance()
    {
        _account.Deposit(100m);
        _account.Deposit(50m);

        Assert.That(_account.GetBalance(), Is.EqualTo(150m));
    }

    //  Deposit: guard clauses
     // zero AND a negative amount without copy-pasting the test.

    [TestCase(0)]
    [TestCase(-50)]
    public void Deposit_ZeroOrNegativeAmount_ThrowsArgumentException(decimal amount)
    {
        Assert.Throws<ArgumentException>(() => _account.Deposit(amount));
    }

    // Withdraw: happy path

    [Test]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        _account.Deposit(100m);
        _account.Withdraw(40m);

        Assert.That(_account.GetBalance(), Is.EqualTo(60m));
    }

    [Test]
    public void Withdraw_EntireBalance_LeavesZero()
    {
        _account.Deposit(100m);
        _account.Withdraw(100m);

        Assert.That(_account.GetBalance(), Is.EqualTo(0m));
    }

    //  Withdraw: guard clauses 

    [TestCase(0)]
    [TestCase(-10)]
    public void Withdraw_ZeroOrNegativeAmount_ThrowsArgumentException(decimal amount)
    {
        _account.Deposit(100m);

        Assert.Throws<ArgumentException>(() => _account.Withdraw(amount));
    }

    //  Withdraw: overdraft protection 

    [Test]
    public void Withdraw_MoreThanBalance_ThrowsInvalidOperationException()
    {
        _account.Deposit(50m);

        Assert.Throws<InvalidOperationException>(() => _account.Withdraw(80m));
    }

    [Test]
    public void Withdraw_FromEmptyAccount_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => _account.Withdraw(10m));
    }
}
