using System;
using System.Collections.Generic;
using System.Text;

namespace SolChargeMeraki.Core.Domain.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
