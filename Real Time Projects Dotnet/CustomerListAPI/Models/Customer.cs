using System.ComponentModel.DataAnnotations;

namespace CustomerListAPI.Models
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }
        public string? customerName { get; set; }
        public string? country { get; set; }
        public string? city { get; set; }
        
        public int orderId { get; set; }
        public string? orderName { get; set;}
        public int totalAmount { get; set;}

        


    }
}
