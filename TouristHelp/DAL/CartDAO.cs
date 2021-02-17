using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TouristHelp.BLL;

namespace TouristHelp.DAL
{
    public class CartDAO
    {
        public void InsertTicket(Cart cart)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Cart (productName, productPrice, productQuantity, user_id, productDesc, active, itemType, cartImage) " +
                             "VALUES (@paraProductName, @paraProductPrice, @paraProductQuantity, @paraUserId, @paraProductDesc, 'active', 'Ticket', @paraProductImage)";


            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraProductName", cart.productName);
            sqlCmd.Parameters.AddWithValue("@paraProductPrice", cart.productPrice);
            sqlCmd.Parameters.AddWithValue("@paraProductQuantity", cart.productQuantity);
            sqlCmd.Parameters.AddWithValue("@paraProductDesc", cart.productDesc);
            sqlCmd.Parameters.AddWithValue("@paraUserId", cart.userId);
            sqlCmd.Parameters.AddWithValue("@paraProductImage", cart.productImage);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();
        }

        public void InsertHotel(Cart cart)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Cart (productName, productPrice, productQuantity, user_id, productDesc, active, itemType, cartImage) " +
                             "VALUES (@paraProductName, @paraProductPrice, @paraProductQuantity, @paraUserId, @paraProductDesc, 'active', 'Hotel', @paraProductImage) ";


            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraProductName", cart.productName);
            sqlCmd.Parameters.AddWithValue("@paraProductPrice", cart.productPrice);
            sqlCmd.Parameters.AddWithValue("@paraProductQuantity", cart.productQuantity);
            sqlCmd.Parameters.AddWithValue("@paraProductDesc", cart.productDesc);
            sqlCmd.Parameters.AddWithValue("@paraUserId", cart.userId);
            sqlCmd.Parameters.AddWithValue("@paraProductImage", cart.productImage);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();
        }

        public List<Cart> SelectCartById(int userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            String sqlstmt = "SELECT * From Cart " +
                             "where user_id = @paraUserId AND active = 'active'";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userId);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Cart> cartList = new List<Cart>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                cartList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int productId = Convert.ToInt32(row["cartId"].ToString());
                    string productName = row["productName"].ToString();
                    double productPrice = Convert.ToDouble(row["productPrice"].ToString());
                    int productQuantity = Convert.ToInt32(row["productQuantity"].ToString());
                    string productDesc = row["productDesc"].ToString();
                    double productTotalPrice = productPrice * productQuantity;
                    string productImage = row["cartImage"].ToString();
                    Cart obj = new Cart(productId, productName, productDesc, productPrice, productQuantity, productTotalPrice, productImage);
                    cartList.Add(obj);
                }
            }
            return cartList;
        }

        public void UpdateItem(int prodId, int prodQuantity)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Cart SET productQuantity = @paraProductQuantity where active =  'active' AND cartId = @paraProdId ";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraProductQuantity", prodQuantity);
            sqlCmd.Parameters.AddWithValue("@paraProdId", prodId);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();


        }

        public void ItemPay(int userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "DELETE FROM Cart where user_id = @paraUserId";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraUserId", userId);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();


        }

        public void DeleteItem(int productId, int userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "DELETE FROM Cart where cartId = @paraProdId AND user_id = @paraUserId";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraProdId", productId);
            sqlCmd.Parameters.AddWithValue("@paraUserId", userId);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();


        }

        public Cart GetCartId(string attName, int userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT cartId, itemType From Cart where user_id = @paraUserId " +
                            "and productName = @paraAttName";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userId);
            da.SelectCommand.Parameters.AddWithValue("@paraAttName", attName);

            DataSet ds = new DataSet();
            da.Fill(ds);

            Cart cart = null;

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int cartId = Convert.ToInt32(row["cartId"].ToString());
                string itemType = row["itemType"].ToString();
                cart = new Cart(cartId, itemType);
            }
            return cart;
        }

    }

}