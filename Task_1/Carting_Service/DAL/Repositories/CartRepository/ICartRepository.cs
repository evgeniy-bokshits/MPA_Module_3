using System.Collections.Generic;

using DAL.Models;
using DAL.Models.Cart;

namespace DAL.Repositories.CartRepository
{
    interface ICartRepository
    {
        IEnumerable<Item> GetCartItems(string id);
        void AddCartItem(string id, Item item);
        void RemoveCartItem(string id, Item item);
    }
}

