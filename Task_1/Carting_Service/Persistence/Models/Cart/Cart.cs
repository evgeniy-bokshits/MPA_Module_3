using System.Collections.Generic;

namespace Persistence.Models.Cart
{
    public class Cart
    {
        public string Id { get; set; }
        public IList<Item> Items { get; set; } = new List<Item>();
    }
}

