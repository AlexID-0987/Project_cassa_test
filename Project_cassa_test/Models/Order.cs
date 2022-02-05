namespace Project_cassa_test.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
    }
}
