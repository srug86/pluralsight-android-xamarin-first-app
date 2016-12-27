using System;
using System.Collections.Generic;

namespace RaysHotDogs.Core
{
	public class CartRepository
	{
		public CartRepository ()
		{
		}

		static Cart MainCart = new Cart() { CartItems = new List<CartItem>() };

		public void AddCartItem(HotDog hotDog, int amount)
		{
			//TODO: add check if already added
			MainCart.CartItems.Add(new CartItem(){HotDog = hotDog, Amount = amount});
		}

		public Cart GetCart()
		{
			return MainCart;
		}
	}
}

