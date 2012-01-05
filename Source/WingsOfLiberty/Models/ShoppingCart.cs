using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AckBack3.Models
{
    public class ShoppingCart
    {
        TShirtEntities storeDB = new TShirtEntities();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        //
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.getCartId(context);
            return cart;
        }

        //Simplify Shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }


        // Add garment to cart 
        public void AddToCart(Garment garment)
        {
            //Check if garment exists in cart
            var cartItem = storeDB.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.GarmentId == garment.GarmentID);

            if (cartItem == null)
            {
                //No garment in cart create new and add
                Cart cart = new Cart
                {
                    CartId = ShoppingCartId,
                    GarmentId = garment.GarmentID,
                    DateCreated = System.DateTime.Now,
                    Count = 1
                };
                storeDB.Carts.Add(cart);
            }
            else
            {
                //Garment in cart increase count
                cartItem.Count++;
            }
            storeDB.SaveChanges();
        }

        // Remove a single garment of a type
        public int RemoveFromCart(int id)
        {
            int count = 0;

            var cart = storeDB.Carts.Single(c => c.CartId == ShoppingCartId && c.GarmentId == id);

            if (cart != null)
            {
                if (cart.Count > 1)
                {
                    cart.Count--;
                    count = cart.Count;
                }
                else
                {
                    storeDB.Carts.Remove(cart);
                }
            }
            storeDB.SaveChanges();
            return count;
        }

        //Remove all garments of a type
        public void RemoveFullFromCart(int id)
        {
            var cart = storeDB.Carts.Single(c => c.CartId == ShoppingCartId && c.GarmentId == id);

            if (cart != null)
            {
                storeDB.Carts.Remove(cart);
            }
            storeDB.SaveChanges();
        }

        public void EmptyCart()
        {
            var carts = storeDB.Carts.Where(c => c.CartId == ShoppingCartId);

            foreach (var cart in carts)
            {
                storeDB.Carts.Remove(cart);
            }
            storeDB.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            var cartItems = storeDB.Carts.Where(c => c.CartId == ShoppingCartId).ToList();
            return cartItems;
        }

        public int GetCount()
        {
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }


        public decimal GetTotal()
        {
            decimal? total = (from cartItems in storeDB.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count * cartItems.Garment.Price).Sum();

            return total ?? decimal.Zero;
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            //Iterate over the cart items adding order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    GarmentId = item.GarmentId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Garment.Price,
                    Quantity = item.Count
                };

                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Garment.Price);

                storeDB.OrderDetails.Add(orderDetail);
            }

            //Set the orders total to the orderTotal count
            order.Total = orderTotal;

            //Save the order
            storeDB.SaveChanges();
            //Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderId;
        }




        // If session has not already been given a cartId set it as either logged in users name or guid if logged out
        public string getCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if(!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }else{
                    Guid guid = new Guid();
                    context.Session[CartSessionKey] = guid.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string UserName)
        {
            var shoppingCart = storeDB.Carts.Where(c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = UserName;
            }
            storeDB.SaveChanges();
        }
    }
}