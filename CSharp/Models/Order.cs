using System;

namespace CSharp.Models
{
    public class Order
    {
        public int id { get; set; }
        public int customerId { get; set;}
        public int age { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string address { get; set;}
        public string phoneNumber { get; set; }
    
        public Order()
        {

        }

        public Order(int id, int customerId, string firstName, string lastName, string address, int age, string phoneNumber)
            {
                this.id = id;
                this.customerId = customerId;
                this.firstName = firstName;
                this.lastName = lastName;
                this.address = address;
                this.age = age;
                this.phoneNumber = phoneNumber;
            }

        public int getCustomerId(Order order){
            int custId = order.customerId;
            return custId;
        }
    }

}