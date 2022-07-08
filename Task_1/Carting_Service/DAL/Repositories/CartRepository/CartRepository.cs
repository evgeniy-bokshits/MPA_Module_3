using System.Collections.Generic;
using AutoMapper;

using DAL.Models;
using DAL.Models.Cart;
using Persistence.DBContexts.CartingDBContext;

namespace DAL.Repositories.CartRepository
{
    class CartRepository : ICartRepository
    {
        private readonly CartingDbContext _cartingDbContext;
        private readonly IMapper _mapper;

        public CartRepository(CartingDbContext cartingDbContext, IMapper mapper)
        {
            _cartingDbContext = cartingDbContext;
            _mapper = mapper;
        }

        public void AddCartItem(string id, Item item)
        {
            var item1 = _mapper.Map<Persistence.Models.Cart.Item>(item);
            _cartingDbContext.AddCartItem(id, item1);
        }

        public IEnumerable<Item> GetCartItems(string id)
        {
            var items = _cartingDbContext.GetCartItems(id);
            var itemsToReturn = _mapper.Map<List<Item>>(items);
            return itemsToReturn;
        }

        public void RemoveCartItem(string id, Item item)
        {
            var item1 = _mapper.Map<Persistence.Models.Cart.Item>(item);
            _cartingDbContext.RemoveCartItem(id, item1);
        }
    }
}

