using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDrewTotal.Data.Entities
{
  public class Product
  {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string GameDescription { get; set; }
        public string GameId { get; set; }
        public string Platform { get; set; }
        public DateTime GameReleaseDate { get; set; }
      }
}
