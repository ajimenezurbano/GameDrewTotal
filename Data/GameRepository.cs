using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameDrewTotal.Data.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace GameDrewTotal.Data
{
  public class GameRepository : IGameRepository
  {
        private readonly GameDrewDbContext _context;
        private readonly ILogger _logger;

        public GameRepository(GameDrewDbContext gameDrewDbContext, ILogger<GameRepository> logger) 
        { 
            _context = gameDrewDbContext; 
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called...");

                return _context.Products
                           .OrderBy(p => p.Title)
                           .ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _context.Orders
                  .Include(o => o.Items)
                  .ThenInclude(i => i.Product)
                  .ToList();
            }
            else
            {
                return _context.Orders
                  .ToList();
            }


        }

        public Order GetOrderById(string username, int id)
        {
            return _context.Orders
            .Include(o => o.Items)
            .ThenInclude(i => i.Product)
            .Where(o => o.Id == id && o.User.UserName == username)
            .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _context.Products
                       .Where(p => p.Category == category)
                       .ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void AddEntity(object entity)
        {
            _context.Add(entity);
        }

        public IEnumerable<Order> GetOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {
                return _context.Orders
                  .Include(o => o.Items)
                  .Where(o => o.User.UserName == username)
                  .ToList();
            }
            else
            {
                return _context.Orders
                  .Where(o => o.User.UserName == username)
                  .ToList();
            }
        }
    }
}
