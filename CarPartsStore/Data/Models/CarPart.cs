namespace CarPartsStore.Data.Models
{
    //Модель для автозапчасти (подправишь что будет надо)
    public class CarPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Vin { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public string ImageThumbnailURL { get; set; }
        public int InStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}