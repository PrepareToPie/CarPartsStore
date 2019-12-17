using CarPartsStore.Data.Models;

namespace CarPartsStore.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}