using System;
using System.Collections.Generic;
using LiteDB;

using Persistence.Models.Cart;

namespace Persistence.DBContexts.CartingDBContext
{
    public class CartingDbContext
    {
        private const string DbPath = @"C:\MPA\DBs\CartingService\CartingService.db";
        private const string CollectionName = "carts";

        public IEnumerable<Item> GetCartItems(string id)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var collection = db.GetCollection<Cart>(CollectionName);

                var cart = collection.FindById(id);

                if (cart is null) return null;

                return cart.Items;
            }
        }
        public void AddCartItem(string id, Item item)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var collection = db.GetCollection<Cart>(CollectionName);

                var cart = collection.FindById(id);

                if (cart is null)
                {
                    throw new Exception($"Cart was not found: id: {id}");
                }

                cart.Items.Add(item);
                collection.Update(cart);
            }
        }

        public void RemoveCartItem(string id, Item item)
        {
            using (var db = new LiteDatabase(DbPath))
            {
                var collection = db.GetCollection<Cart>(CollectionName);

                var cart = collection.FindById(id);

                if (cart is null)
                {
                    throw new Exception($"Cart was not found: id: {id}");
                }

                cart.Items.Remove(item);
                collection.Update(cart);
            }
        }
    }
}

