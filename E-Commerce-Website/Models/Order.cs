namespace E_Commerce_Website.Models
{
    public class Order
    {
        public int order_id { get; set; }
        public int cart_id { get; set; }
        public int status { get; set; }
    }
}
