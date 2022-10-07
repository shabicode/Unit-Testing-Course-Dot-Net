using Moq;
using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class BankAccountUNitTests
    {
        private BankAccount account;
        [SetUp]
        public void Setup()
        {
            
        }
        [Test]
        public void BankDepositLogFakker_Add100_ReturnTrue()
        {
            BankAccount bankAccount = new(new LogFakker());
            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }
        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message("Deposit Invoked"));

            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }
        [Test]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(200);
            var result = bankAccount.Withdraw(100);
            Assert.IsTrue(result);
            
        }
        [Test]
        [TestCase (200,100)]
        [TestCase (200,150)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x=>x>0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);
            Assert.IsTrue(result);

        }
        [Test]
        [TestCase(200, 300)]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);
            Assert.IsFalse(result);

        }
        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desireOutput = "hello";

            logMock.Setup(x => x.MessageWithReturnStr(It.IsAny<string>())).Returns((string str)=> str.ToLower());

            Assert.That(logMock.Object.MessageWithReturnStr("Hello"),Is.EqualTo(desireOutput));
        }
        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desireOutput = "Hello";

            logMock.Setup(x => x.LogWithOutputResult(It.IsAny<string>(),out desireOutput)).Returns(true);
            string result = "";
            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben",out result));
            Assert.That(result, Is.EqualTo(desireOutput));
        }
        [Test]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

            logMock.Setup(x => x.LogWithRefObj(ref customer)).Returns(true);

            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
            Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
        }
        [Test]
        public void BankLogDummy_SetAndGetLogTypeAndSeverityMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogSeverity).Returns(10);
            logMock.Setup(u => u.LogType).Returns("Warning");

            
            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
            Assert.That(logMock.Object.LogType,Is.EqualTo("Warning"));

            //Callback
            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
                .Returns(true).Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("Ben");
            Assert.That(logTemp, Is.EqualTo("Hello, Ben")); 
            
            int counter = 5;
            logMock.Setup(u => u.LogToDb(It.IsAny<string>()))
                .Callback(() => counter++)
                .Returns(true)
                .Callback(() => counter++);                           
            logMock.Object.LogToDb("Ben");
            logMock.Object.LogToDb("Ben");
            Assert.That(counter, Is.EqualTo(9));


        }
        [Test]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(100);
            
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

            //Verification
            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.LogSeverity, Times.Once);
        }
    }
}
