using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparky;
using Moq;
using Xunit;

namespace SparkyNUnitTest
{
    public class ProductXUNitTests
    {
        [Fact]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            Product product = new Product() { Price = 50 };
            var result = product.GetPrice(new Customer() { IsPlatinum = true });
            Assert.Equal(40,result);
        }
        [Fact]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            var customer = new Mock<ICustomer>();
            customer.SetupGet(x => x.IsPlatinum).Returns(true);

            Product product = new Product() { Price = 50 };
            var result = product.GetPrice(customer.Object);
            Assert.Equal(40, result);
        }
    }
}
