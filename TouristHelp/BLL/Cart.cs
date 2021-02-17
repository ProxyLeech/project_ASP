using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristHelp.DAL;

namespace TouristHelp.BLL
{
    public class Cart
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productDesc { get; set; }
        public double productPrice { get; set; }
        public int productQuantity { get; set; }
        public double productTotalPrice { get; set; }
        public int userId { get; set; }
        public string itemType { get; set; }
        public string productImage { get; set; }

        public Cart()
        {

        }

        public Cart(int productid, string productname, string productdesc, double productprice, int productquantity, double producttotalprice, string cartImg)
        {
            productId = productid;
            productName = productname;
            productDesc = productdesc;
            productPrice = productprice;
            productQuantity = productquantity;
            productTotalPrice = producttotalprice;
            productImage = cartImg;
        }

        public Cart(string productname, string productdesc, double productprice, int productquantity, int user_Id, string cartImg)
        {
            productName = productname;
            productDesc = productdesc;
            productPrice = productprice;
            productQuantity = productquantity;
            userId = user_Id;
            productImage = cartImg;
        }

        public Cart(int productid, string itemtype)
        {
            productId = productid;
            itemType = itemtype;
        }

        public Cart(int productid, int productquantity)
        {
            productId = productid;
            productQuantity = productquantity;
        }
        
        public List<Cart> GetAllItems(int userid)
        {
            CartDAO dao = new CartDAO();
            return dao.SelectCartById(userid);
        }

        public void UpdateCart(int productId, int productQuantity)
        {
            CartDAO dao = new CartDAO();
            dao.UpdateItem(productId, productQuantity);
        }

        public void InsertCartTicket()
        {
            CartDAO cart = new CartDAO();
            cart.InsertTicket(this);
        }

        public void InsertCartReservation()
        {
            CartDAO cart = new CartDAO();
            cart.InsertTicket(this);
        }



        public void InsertHotel()
        {
            CartDAO cart = new CartDAO();
            cart.InsertHotel(this);
        }

        public void InsertHotelReservation()
        {
            CartDAO cart = new CartDAO();
            cart.InsertHotel(this);
        }

        public void ItemPay(int userId)
        {
            CartDAO cart = new CartDAO();
            cart.ItemPay(userId);
        }

        public void DeleteItem(int productId, int userId)
        {
            CartDAO cart = new CartDAO();
            cart.DeleteItem(productId, userId);
        }

        public Cart GetCartId(string attName, int userId)
        {
            CartDAO cart = new CartDAO();
            return cart.GetCartId(attName, userId);
        }
    }
}