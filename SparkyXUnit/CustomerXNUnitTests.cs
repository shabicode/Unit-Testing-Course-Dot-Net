using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyNUnitTest
{ 
    public class CustomerXNUnitTests
    {
        private Customer? _customer;
        public CustomerXNUnitTests()
        {
            _customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            _customer = new Customer();
            string fullName = _customer.CombineNames("Mini", "Andrea");

            Assert.Equal("Mini Andrea", _customer.GreetMessage); 
            Assert.Contains("i", _customer.GreetMessage);
            Assert.StartsWith("M",_customer.GreetMessage);
            Assert.EndsWith("Andrea", _customer.GreetMessage);

        }

        [Fact]
        public void CombineName_NotGreeted_ReturnNull()
        {
            _customer = new Customer();

            Assert.Null(_customer.GreetMessage);
        }

        [Fact]
        public void GreetMessage_EmptyFirstName_ThrowsException()
        {
            _customer = new Customer();

            var exceptionDetails = Assert.Throws<ArgumentException>(() => _customer.CombineNames("", "Andrea"));
            Assert.Equal("Error", exceptionDetails.Message);             

            Assert.Throws<ArgumentException>(() => _customer.CombineNames("", "Andrea"));


        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            _customer.OrderTotal = 10;
            var result = _customer.GetCustomerType();
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnBasicCustomer()
        {
            _customer.OrderTotal = 200;
            var result = _customer.GetCustomerType();
            Assert.IsType<PlatinumCustomer>(result); 
        }
    }
}

