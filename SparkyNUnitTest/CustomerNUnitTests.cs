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
    public class CustomerNUnitTests
    {
        private Customer? _customer;
        [SetUp]
        public void Setup()
        {
            _customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            _customer = new Customer();
            string fullName = _customer.CombineNames("Mini", "Andrea");

            Assert.Multiple(() =>
            {
                Assert.That(fullName, Is.EqualTo("Mini Andrea"));
                Assert.AreEqual(fullName, "Mini Andrea");
                Assert.That(fullName, Does.Contain("i").IgnoreCase);
                Assert.That(fullName, Does.StartWith("M"));
                Assert.That(fullName, Does.EndWith("Andrea"));
            });
            
        }

        [Test]
        public void CombineName_NotGreeted_ReturnNull()
        {
            _customer = new Customer();
            
            Assert.IsNull(_customer.GreetMessage);
        } 

        [Test]
        public void GreetMessage_EmptyFirstName_ThrowsException()
        {
            _customer = new Customer();

            var exceptionDetails = Assert.Throws<ArgumentException>(() => _customer.CombineNames("", "Andrea"));
            Assert.AreEqual("Error", exceptionDetails.Message);

            Assert.That(() => _customer.CombineNames("", "moni"),
                Throws.ArgumentException.With.Message.EqualTo("Error"));

            Assert.Throws<ArgumentException>(() => _customer.CombineNames("", "Andrea"));
            

        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            _customer.OrderTotal = 10;
            var result = _customer.GetCustomerType();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            _customer.OrderTotal = 200;
            var result = _customer.GetCustomerType();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}

