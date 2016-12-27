using System;

namespace RaysHotDogs.Core
{
	public class CartDataService
	{
		private static CartRepository cartRepository = new CartRepository();

		public CartDataService ()
		{
		}

		public void AddCartItem(HotDog hotDog, int amount)
		{
			cartRepository.AddCartItem (hotDog, amount);
		}

		public Cart GetCart()
		{
			return cartRepository.GetCart ();
		}

	}
}

