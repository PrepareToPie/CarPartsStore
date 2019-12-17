namespace CarPartsStore.Data.Models
{
    public class OrderDetail
    {
        public int OrderDetailid { get; set; }
        public int OrderId { get; set; }
        public int CarpartId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Carpart Carpart { get; set; }
        public virtual Order Order { get; set; }
    }
}