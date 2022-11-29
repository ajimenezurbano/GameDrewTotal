using System.Collections.Generic;
using GameDrewTotal.Data.Entities;

namespace GameDrewTotal.Data
{
  public interface IGameRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetOrdersByUser(string username, bool includeItems);
        Order GetOrderById(string username, int id);

        void AddEntity(object entity);
    }
}