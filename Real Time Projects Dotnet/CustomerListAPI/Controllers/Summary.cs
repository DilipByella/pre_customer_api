namespace CustomerApi.Controllers
{
    internal class Summary
    {
        public int CustomerId { get; set; }
        public string Country { get; set; }
        public int TotalOrders { get; set; }
        public int TotalAmount { get; set; }
    }
}