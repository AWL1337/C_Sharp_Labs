using System.Collections.Generic;
using Domain.DLA;
using Domain.DomainModels;
using Domain.Exceptions;
using NSubstitute;
using Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankTests
{
    [Fact]
    public void TakeMoneyTestCorrect()
    {
        var user = new User(1, "1", UserRole.User);
        var bankAccount = new BankAccount(0, 1, 500);
        var transaction = new Transaction(0, 0, TransactionType.Withdraw, 300);
        IEnumerable<BankAccount> accList = new List<BankAccount>() { bankAccount };
        IBankAccountRepo? bankRepoMock = Substitute.For<IBankAccountRepo>();
        bankRepoMock.FindBankAccountsByUserId(1).Returns(accList);
        bankRepoMock.FindBankAccountByAccountId(0).Returns(bankAccount);
        IHistoryRepo? historyRepo = Substitute.For<IHistoryRepo>();
        historyRepo.GetAllId().Returns(new List<int>());

        var accountServ = new AccountServices(bankRepoMock);
        var actionServ = new ActionServices(accountServ, historyRepo);

        actionServ.UpdateBankAccount(user, 0, 200);

        historyRepo.Received().AddTransaction(transaction);
    }

    [Fact]
    public void TakeMoneyTestFalse()
    {
        var user = new User(1, "1", UserRole.User);
        var bankAccount = new BankAccount(0, 1, 500);
        IEnumerable<BankAccount> accList = new List<BankAccount>() { bankAccount };
        IBankAccountRepo? bankRepoMock = Substitute.For<IBankAccountRepo>();
        bankRepoMock.FindBankAccountsByUserId(1).Returns(accList);
        bankRepoMock.FindBankAccountByAccountId(0).Returns(bankAccount);
        IHistoryRepo? historyRepo = Substitute.For<IHistoryRepo>();
        historyRepo.GetAllId().Returns(new List<int>());

        var accountServ = new AccountServices(bankRepoMock);
        var actionServ = new ActionServices(accountServ, historyRepo);

        Assert.Throws<OperationException>(() => actionServ.UpdateBankAccount(user, 0, -1));
    }

    [Fact]
    public void PutMoneyTestCorrect()
    {
        var user = new User(1, "1", UserRole.User);
        var bankAccount = new BankAccount(0, 1, 500);
        var transaction = new Transaction(0, 0, TransactionType.Replenishment, 200);
        IEnumerable<BankAccount> accList = new List<BankAccount>() { bankAccount };
        IBankAccountRepo? bankRepoMock = Substitute.For<IBankAccountRepo>();
        bankRepoMock.FindBankAccountsByUserId(1).Returns(accList);
        bankRepoMock.FindBankAccountByAccountId(0).Returns(bankAccount);
        IHistoryRepo? historyRepo = Substitute.For<IHistoryRepo>();
        historyRepo.GetAllId().Returns(new List<int>());

        var accountServ = new AccountServices(bankRepoMock);
        var actionServ = new ActionServices(accountServ, historyRepo);

        actionServ.UpdateBankAccount(user, 0, 700);

        historyRepo.Received().AddTransaction(transaction);
    }
}