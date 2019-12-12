using System.Collections.Generic;
using System.Linq;
using CarPartsStore.Data.Interfaces;
using CarPartsStore.Data.Models;

/*namespace CarPartsStore.Data.Mocks
{
    public class MockCarpartRepository:ICarpartRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Carpart> Carparts
        {
            get
            {
                return new List<Carpart>
                {
                    new Carpart
                    {
                        Name = "Name",
                        Price = 12003,
                        Car = new Car
                        {
                            Mark = "Mark",
                            Model = "Model",
                            Vin = "Vin"
                        },
                        Category = _categoryRepository.Categories.First(),
                        CarpartId = 1,
                        ImageThumbnailUrl = "ImageThumbUrl",
                        ImageUrl = "ImageUrl",
                        InStock = 123,
                        LongDescription = "LongDescript",
                        Manufacturer = "Manufacturer"
                    }
                };
            }
            set => throw new System.NotImplementedException();
        }

        public Carpart GetCarpartById(int carpartId)
        {
            throw new System.NotImplementedException();
        }
    }
}*/