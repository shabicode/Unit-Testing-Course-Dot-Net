using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ICustomer
    {
        int Discount { get; set; }
        int OrderTotal { get; set; }
        string GreetMessage { get; set; }
        bool IsPlatinum { get; set; }
        string CombineNames(string firstName, string lastName);
        public CustomerType GetCustomerType();
    }
    public class Customer : ICustomer
    {
        public int Discount { get; set; }
        public int OrderTotal { get; set; }
        public string? GreetMessage { get; set; }
        public bool IsPlatinum { get; set; }
        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;
        }
        public string CombineNames(string firstName , string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Error");
            }
            GreetMessage =  $"{firstName} {lastName}";
            Discount = 20;
            return GreetMessage;
        }
        public CustomerType GetCustomerType()
        {
            if(OrderTotal < 100)
            {
                return new BasicCustomer();
            }
            else
            {
                return new PlatinumCustomer();
            }
        }
    }
    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PlatinumCustomer : CustomerType { }

}
