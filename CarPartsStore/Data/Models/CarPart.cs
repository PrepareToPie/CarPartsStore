using System.ComponentModel.DataAnnotations.Schema;

namespace CarPartsStore.Data.Models
{
    //Модель для автозапчасти (подправишь что будет надо)
    public class CarPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Manufacturer { get; set; }
        //public string LongDescription { get; set; }
        //public string ShortDescription { get; set; }
        public int Price { get; set; }
        //public string ImageURL { get; set; }
        //public string ImageThumbnailURL { get; set; }
        //public int InStock { get; set; }
        //public string VIN { get; set; }
        //[ForeignKey("VIN")]
        //public Car Car { get; set; }
        //public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        //public virtual Category Category { get; set; }
    }
}