using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core;
using RaysHotDogs.Adapters;

namespace RaysHotDogs
{
    [Activity(Label = "Welcome to Ray's Hot Dogs", Icon = "@drawable/smallicon")]
    public class CartActivity: Activity
    {
        private CartDataService cartDataService;
        private List<CartItem> cartItems;
        private ListView cartListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CartView);

            cartDataService = new CartDataService();

            cartListView = FindViewById<ListView>(Resource.Id.cartListView);

            cartItems = cartDataService.GetCart().CartItems;
            cartListView.Adapter = new CartAdapter(this, cartItems);
        }
    }
}