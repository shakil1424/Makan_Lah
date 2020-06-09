using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class Db
    {
        //Connection String
        private static string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";
        public static void AddUser(string userId, string password, int roleId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"insert into AppUser (userId,password,roleId) 
                                        values ('{0}','{1}','{2}')";
                    cmd.CommandText = string.Format(cmd.CommandText, userId, password, roleId.ToString());
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void DeleteUser(string userId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"delete from [dbo].[Appuser] where userId = '{0}'";
                    cmd.CommandText = string.Format(cmd.CommandText, userId);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static List<AppUser> ShowUser()
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";
            List<AppUser> userList = null;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {

                    cmd.CommandText = @"select * from [dbo].[Appuser]";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        userList = new List<AppUser>();
                        while (dr.Read())
                        {
                            AppUser u = new AppUser();
                            u.UserId = Convert.ToString(dr["userId"]);
                            u.Password = Convert.ToString(dr["password"]);
                            u.RoleId = Convert.ToInt16(dr["roleId"]);
                            userList.Add(u);
                        }
                        userList.TrimExcess();
                    }

                }
                con.Close();
            }
            return userList;

        }

        public static List<Item> ShowItem(int restaurantId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";
            List<Item> itemList = null;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {

                    cmd.CommandText = @"select * from [dbo].[Item] where restaurantId = '{0}'";
                    cmd.CommandText = string.Format(cmd.CommandText, restaurantId.ToString());
                    SqlDataReader dr = cmd.ExecuteReader();
                    itemList = new List<Item>();
                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            Item i = new Item();
                            i.Id = Convert.ToInt16(dr["itemId"]);
                            i.Title = Convert.ToString(dr["itemTitle"]);
                            i.Description = Convert.ToString(dr["itemDescription"]);
                            i.Price = (float)Convert.ToDouble(dr["itemPrice"]);
                            i.Discount = (float)Convert.ToDouble(dr["itemDiscount"]);
                            i.IsAvailable = Convert.ToByte(dr["itemStatus"]);
                            i.Url = Convert.ToString(dr["itemUrl"]);
                            i.RestaurantId = Convert.ToInt16(dr["restaurantId"]);
                            itemList.Add(i);
                        }
                        itemList.TrimExcess();
                    }

                }
                con.Close();
            }
            return itemList;

        }

        public static List<Restaurant> ShowRestaurant()
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";
            List<Restaurant> restaurantList = null;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {

                    cmd.CommandText = @"select * from [dbo].[Restaurant]";
                    SqlDataReader dr = cmd.ExecuteReader();
                    restaurantList = new List<Restaurant>();
                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            Restaurant r = new Restaurant();
                            r.Id = Convert.ToInt16(dr["restaurantId"]);
                            r.Title = Convert.ToString(dr["restaurantTitle"]);
                            r.userId = Convert.ToString(dr["userId"]);
                            r.Url = Convert.ToString(dr["restaurantUrl"]);
                            r.Items = new List<Item>();
                            r.Items = ShowItem(r.Id);

                            restaurantList.Add(r);
                        }
                        restaurantList.TrimExcess();
                    }

                }
                con.Close();
            }
            return restaurantList;

        }

        public static void UpdateUser(string oldUserId, string newUserId, string password, int roleId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"update [dbo].[Appuser] set userId='{0}',password = '{1}', roleId = '{2}' where userId = '{3}'";
                    cmd.CommandText = string.Format(cmd.CommandText, newUserId, password, roleId, oldUserId);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

        }

        public static void AddRestaurant(string restaurantTitle, string userId, string restaurantUrl)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"insert into Restaurant (restaurantTitle,userId,restaurantUrl) 
                                        values ('{0}','{1}','{2}')";
                    cmd.CommandText = string.Format(cmd.CommandText, restaurantTitle, userId, restaurantUrl);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

        }

        public static void DeleteRestaurant(int restaurantId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"delete from [dbo].[Restaurant] where restaurantId = '{0}'";
                    cmd.CommandText = string.Format(cmd.CommandText, restaurantId.ToString());
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void UpdateRestaurant(int restaurantId, string restaurantTitle, string restaurantUrl)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"update [dbo].[Restaurant] set restaurantTitle='{0}', restaurantUrl = '{1}' where restaurantId = '{2}'";
                    cmd.CommandText = string.Format(cmd.CommandText, restaurantTitle, restaurantUrl, restaurantId.ToString());
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

        }

        public static void AddItem(string itemTitle, string itemDescription, float itemprice, float itemDiscount, string itemUrl, int restaurantid)
        {
           // string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"insert into Item (itemTitle,itemDescription,itemprice,itemDiscount, itemUrl, restaurantId) 
                                        values ('{0}','{1}','{2}','{3}','{4}','{5}')";
                    cmd.CommandText = string.Format(cmd.CommandText, itemTitle, itemDescription,
                                                    itemprice.ToString(), itemDiscount.ToString(),
                                                    itemUrl, restaurantid.ToString());
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

        }

        public static void DeleteItem(int itemId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"delete from [dbo].[Item] where itemId = '{0}'";
                    cmd.CommandText = string.Format(cmd.CommandText, itemId.ToString());
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void UpdateItem(int itemId, string itemTitle, string itemDescription, float itemPrice, float itemDiscount, string itemUrl)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"update [dbo].[Item] set itemTitle='{0}',itemDescription = '{1}',
                                        itemPrice='{2}',itemDiscount = '{3}', 
                                        itemUrl='{4}' where itemId = '{5}'";
                    cmd.CommandText = string.Format(cmd.CommandText, itemTitle, itemDescription,
                                                    itemPrice.ToString(), itemDiscount.ToString(),
                                                    itemUrl, itemId.ToString());

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

        }

        public static void AddOrder(DateTime orderDate, float orderTotalPrice, float orderPromotion, float orderFinalPrice, string userId, int restaurantid)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"insert into Order (orderDate,orderTotalPrice,orderPromotion,orderFinalPrice, userId, restaurantId) 
                                        values ('{0}','{1}','{2}','{3}','{4}','{5}')";
                    cmd.CommandText = string.Format(cmd.CommandText, orderDate.ToString(), orderTotalPrice.ToString(),
                                                    orderPromotion.ToString(), orderFinalPrice.ToString(),
                                                    userId, restaurantid.ToString());
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

        }

        public static void DeleteOrder(int orderId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"delete from [dbo].[Order] where orderId = '{0}'";
                    cmd.CommandText = string.Format(cmd.CommandText, orderId.ToString());
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void ChangeStatus(int itemId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";
            int itemStatus = 0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {

                    cmd.CommandText = @"select itemStatus from [dbo].[Item] where itemId = '{0}'";
                    cmd.CommandText = string.Format(cmd.CommandText, itemId.ToString());
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {

                            itemStatus = Convert.ToInt16(dr["itemStatus"]);

                        }

                    }

                }
                con.Close();
            }
            if (itemStatus == 1)
            {
                itemStatus = 0;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {

                        cmd.CommandText = @"update [dbo].[Item] set itemStatus='{0}' where itemId = '{1}'";
                        cmd.CommandText = string.Format(cmd.CommandText, itemStatus.ToString(), itemId.ToString());

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                

            }
            else
            {
                itemStatus = 1;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {

                        cmd.CommandText = @"update [dbo].[Item] set itemStatus='{0}' where itemId = '{1}'";

                        cmd.CommandText = string.Format(cmd.CommandText, itemStatus.ToString(), itemId.ToString());

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }

            }


        }

        public static AppUser CheckUser(string userId)
        {
           // string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";
            AppUser user = new AppUser();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {

                    cmd.CommandText = @"select * from [dbo].[Appuser] where userId = '{0}'";
                    cmd.CommandText = string.Format(cmd.CommandText, userId);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            user.UserId = Convert.ToString(dr["userId"]);
                            user.Password = Convert.ToString(dr["password"]);
                            user.RoleId = Convert.ToInt16(dr["roleId"]);
                            con.Close();
                            return user;
                            
                        }
                    }
                    con.Close();
                    return null;
                    

                }
                



            }
        }

        public static Item GetItem(int itemId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";
            Item i = new Item();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {

                    cmd.CommandText = @"select * from [dbo].[Item] where itemId = '{0}'";
                    cmd.CommandText = string.Format(cmd.CommandText, itemId.ToString());
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            i.Id = Convert.ToInt16(dr["itemId"]);
                            i.Title = Convert.ToString(dr["itemTitle"]);
                            i.Description = Convert.ToString(dr["itemDescription"]);
                            i.Price = (float)Convert.ToDouble(dr["itemPrice"]);
                            i.Discount = (float)Convert.ToDouble(dr["itemDiscount"]);
                            i.IsAvailable = Convert.ToByte(dr["itemStatus"]);
                            i.Url = Convert.ToString(dr["itemUrl"]);
                            i.RestaurantId = Convert.ToInt16(dr["restaurantId"]);
                            con.Close();
                            return i;

                        }
                    }
                    con.Close();
                    return null;

                }
                
            }
        }

        public static int AddOrder(Order order)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";
            int orderId = 0;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"insert into [dbo].[Order] (orderTotalPrice,userId,restaurantId,description) 
                                        values ('{0}','{1}','{2}','{3}') select SCOPE_IDENTITY()";
                    cmd.CommandText = string.Format(cmd.CommandText, order.TotalPrice.ToString(),
                                                    order.UserId, order.RestaurantId.ToString(),
                                                    order.Description);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    orderId = Convert.ToInt16(dr[0]);

                }
                con.Close();
            }
            
            return orderId;


        }

        public static void AddOrderItem(OrderItem orderItem)
        {
           // string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"insert into [dbo].[OrderItem] (orderId, itemid) 
                                        values ('{0}','{1}')";
                    cmd.CommandText = string.Format(cmd.CommandText, orderItem.OrderId.ToString(), orderItem.ItemId.ToString());
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void AddDiscount(float itemDiscount, int itemId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {

                    cmd.CommandText = @"update [dbo].[Item] set itemDiscount='{0}' where itemId = '{1}'";
                    cmd.CommandText = string.Format(cmd.CommandText, itemDiscount.ToString(), itemId.ToString());

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

        }

        public static List<Order> ShowRestaurantOrder(int restaurantId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";
            List<Order> orderList = new List<Order>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {

                    cmd.CommandText = @"select * from [dbo].[Order] where restaurantId = '{0}'";
                    cmd.CommandText = string.Format(cmd.CommandText, restaurantId.ToString());
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            Order o = new Order();
                            o.Id = Convert.ToInt16(dr["orderId"]);
                            o.Date = Convert.ToDateTime(dr["orderDate"]);
                            o.TotalPrice = (float)Convert.ToDouble(dr["orderTotalPrice"]);
                            o.UserId = Convert.ToString(dr["userId"]);
                            o.Description = Convert.ToString(dr["description"]);
                            o.OrderStatus = Convert.ToByte(dr["orderStatus"]);
                            o.RestaurantId = Convert.ToInt16(dr["restaurantId"]);



                            orderList.Add(o);
                        }
                        orderList.TrimExcess();
                    }

                }
                con.Close();
            }
            return orderList;

        }

        public static int ChangeOrderStatus(int orderId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";
            int orderStatus = 1;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {

                    cmd.CommandText = @"update [dbo].[Order] set orderStatus='{0}' where orderId = '{1}'";
                    cmd.CommandText = string.Format(cmd.CommandText, orderStatus.ToString(), orderId.ToString());

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

            int restaurantId = 0;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {

                    cmd.CommandText = @"select restaurantId from [dbo].[Order] where orderId = '{0}'";
                    cmd.CommandText = string.Format(cmd.CommandText, orderId.ToString());
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {

                            restaurantId = Convert.ToInt16(dr["restaurantId"]);

                        }

                    }

                }
                con.Close();
            }


            return restaurantId;


        }

        public static List<Order> ShowCustomerOrder(string userId)
        {
            //string cs = "Server=SCORPIO\\SQLEXPRESS;Database=Makan_lah;Trusted_Connection=True;MultipleActiveResultSets=true";
            List<Order> orderList = new List<Order>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {

                    cmd.CommandText = @"SELECT [Order].[orderId]
                                      ,[Order].[orderDate] 
                                      ,[Order].[orderTotalPrice]
                                      ,[Order].[description]
                                      ,[Order].[orderStatus]
	                                  ,[Restaurant].[restaurantTitle]
                                      FROM [dbo].[Order] INNER JOIN [dbo].[Restaurant] 
                                      ON [Order].[restaurantId] = [Restaurant].[restaurantId] 
                                      where [Order].[userId]='{0}'";
                    cmd.CommandText = string.Format(cmd.CommandText, userId);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            Order o = new Order();
                            o.Id = Convert.ToInt16(dr["orderId"]);
                            o.Date = Convert.ToDateTime(dr["orderDate"]);
                            o.TotalPrice = (float)Convert.ToDouble(dr["orderTotalPrice"]);
                            o.Description = Convert.ToString(dr["description"]);
                            o.OrderStatus = Convert.ToByte(dr["orderStatus"]);
                            o.restaurantTitle = Convert.ToString(dr["restaurantTitle"]);



                            orderList.Add(o);
                        }
                        orderList.TrimExcess();
                    }

                }
                con.Close();
            }
            return orderList;

        }




    }
}
