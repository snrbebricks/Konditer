using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Konditer.Model;
using static Xamarin.Essentials.Permissions;
using System.Data;
using System.Xml.Linq;
using Xamarin.Essentials;
using System.Windows;

namespace Konditer.Model
{
    public class DB
    {
        public const string connString = @"Data Source = konditer.db; Version=3;";
        private static User ReadUser(SQLiteDataReader reader)
        {
            int id = Convert.ToInt32(reader["id"]);
            string username = (string)reader["username"];
            string password = (string)reader["password"];
            string role = (string)reader["role"];
            string first_name = (string)reader["first_name"];
            string name = (string)reader["name"];
            string last_name = (string)reader["last_name"];
            string mail = (string)reader["mail"];
            string number = (string)reader["number"];

            User user = new User
            {
                ID = id,
                Username = username,
                Password = password,
                Role = role,
                First_name = first_name,
                Name = name,
                Last_name = last_name,
                Email = mail,
                Number = number,
            };
            return user;
        }
        public async Task<User> GetUser(string username)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from users where username = @username";

                    cmd.Parameters.AddWithValue("username", username);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            User user = ReadUser(reader);
                            conn.Close();
                            return user;
                        }
                    }
                }
                conn.Close();
                return null;
            }
        }
        public async Task<User> GetUserFromNumber(string phone)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from users where number = @number";

                    cmd.Parameters.AddWithValue("number", phone);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            User user = ReadUser(reader);
                            conn.Close();
                            return user;
                        }
                    }
                }
                conn.Close();
                return null;
            }
        }
        public async Task<User> GetUserFromID(string id)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from users where id = @id";

                    cmd.Parameters.AddWithValue("id", id);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            User user = ReadUser(reader);
                            conn.Close();
                            return user;
                        }
                    }
                }
                conn.Close();
                return null;
            }
        }
        public async Task<User> GetUserFromMail(string mail)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from users where mail = @mail";

                    cmd.Parameters.AddWithValue("mail", mail);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            User user = ReadUser(reader);
                            conn.Close();
                            return user;
                        }
                    }
                }
                conn.Close();
                return null;
            }
        }
        public async Task<User> GetUserFromFirstName(string first_name)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from users where first_name = @first_name";

                    cmd.Parameters.AddWithValue("first_name", first_name);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            User user = ReadUser(reader);
                            conn.Close();
                            return user;
                        }
                    }
                }
                conn.Close();
                return null;
            }
        }
        public async Task<User> GetAllUser(int id_user)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from users where id = @id_user";

                    cmd.Parameters.AddWithValue("id_user", id_user);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            User user = ReadUser(reader);
                            conn.Close();
                            return user;
                        }
                    }
                }
                conn.Close();
                return null;
            }
        }
        public async Task<double> GetCountAllUser()
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) AS 'count' FROM users";

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            int count = Convert.ToInt32(reader["count"]);
                            conn.Close();
                            return count;
                        }
                    }
                }
                conn.Close();
                return 0;
            }
        }
        public async Task Add_User(User user)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO users (username, password, role, first_name, name, last_name, mail, number) VALUES (@username, @password, @role, @first_name, @name, @last_name, @mail, @number)";

                    cmd.Parameters.AddWithValue("username", user.Username);
                    cmd.Parameters.AddWithValue("password", user.Password);
                    cmd.Parameters.AddWithValue("role", user.Role);
                    cmd.Parameters.AddWithValue("first_name", user.First_name);
                    cmd.Parameters.AddWithValue("name", user.Name);
                    cmd.Parameters.AddWithValue("last_name", user.Last_name);
                    cmd.Parameters.AddWithValue("mail", user.Email);
                    cmd.Parameters.AddWithValue("number", user.Number);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public async Task UpdateUser(string username, string first_name, string name, string last_name, string email, string phone, string password, string role)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE users SET first_name = @first_name, name = @name, last_name = @last_name, mail = @mail, number = @number, password = @password, role = @role WHERE username = @username";

                    cmd.Parameters.AddWithValue("first_name", first_name);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("last_name", last_name);
                    cmd.Parameters.AddWithValue("mail", email);
                    cmd.Parameters.AddWithValue("number", phone);
                    cmd.Parameters.AddWithValue("password", password);
                    cmd.Parameters.AddWithValue("role", role);
                    cmd.Parameters.AddWithValue("username", username);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public async Task AddBasketItem(int id_item, int count, float start_price, float end_price, string username)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO basket (id_product, count, username, start_price, end_price) VALUES (@id_item, @count, @username, @start_price, @end_price)";

                    cmd.Parameters.AddWithValue("id_item", id_item);
                    cmd.Parameters.AddWithValue("count", count);
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("start_price", start_price);
                    cmd.Parameters.AddWithValue("end_price", end_price);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public async Task AddMoreBasketItem(int count, float end_price, int id_item)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE basket SET count = @count, end_price = @end_price WHERE id_product = @id_item";

                    cmd.Parameters.AddWithValue("id_item", id_item);
                    cmd.Parameters.AddWithValue("count", count);
                    cmd.Parameters.AddWithValue("end_price", end_price);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public async Task<Basket_Item> GetBasketItem(int id, string username)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT basket.id, basket.id_product, basket.count, product.image, product.name, basket.start_price, basket.end_price FROM basket, product WHERE basket.id_product = @id_item and basket.id_product = product.id and basket.username = @username";

                    cmd.Parameters.AddWithValue("id_item", id);
                    cmd.Parameters.AddWithValue("username", username);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            Basket_Item basket_item = ReadBasketItem(reader);
                            return basket_item;
                        }
                    }
                }
                conn.Close();
                return null;
            }
        }
        private static Basket_Item ReadBasketItem(SQLiteDataReader reader)
        {
            int id = Convert.ToInt32(reader["id"]);
            int id_item = Convert.ToInt32(reader["id_product"]);
            string image = reader["image"] as string;
            string name = reader["name"] as string;
            int count = Convert.ToInt32(reader["count"]);
            float price = Convert.ToSingle(reader["start_price"]);
            float end_price = Convert.ToSingle(reader["end_price"]);

            Basket_Item basket_item = new Basket_Item
            {
                Id = id,
                Id_Item = id_item,
                Image = image,
                Name = name,
                Start_Price = price,
                End_Price = end_price,
                Count = count
            };
            return basket_item;
        }
        public async Task<double> GetCountBasket(string username)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(DISTINCT id_item) AS count FROM basket WHERE username = @username";

                    cmd.Parameters.AddWithValue("username", username);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            int count = Convert.ToInt32(reader["count"]);
                            conn.Close();
                            return count;
                        }
                    }
                }
                conn.Close();
                return 0;
            }
        }
        public async Task<int> GetCountBasketItem(string username)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT MAX(id_product) AS 'max' FROM basket WHERE username = @username";

                    cmd.Parameters.AddWithValue("username", username);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            int count = Convert.ToInt32(reader["max"]);
                            conn.Close();
                            return count;
                        }
                    }
                }
                conn.Close();
                return 0;
            }
        }
        public async Task ClearBasket(string username)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM basket WHERE username = @username";

                    cmd.Parameters.AddWithValue("username", username);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public async Task AddOrder(float summ, string id_items, string username)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO orders (summ, id_items, username) values (@summ, @id_items, @username)";

                    cmd.Parameters.AddWithValue("summ", summ);
                    cmd.Parameters.AddWithValue("id_items", id_items);
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public async Task<float> GetPriceBasketItems(string username)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT SUM(end_price) AS sum from basket where username = @username";

                    cmd.Parameters.AddWithValue("username", username);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            int count = Convert.ToInt32(reader["sum"]);
                            conn.Close();
                            return count;
                        }
                    }
                }
                conn.Close();
                return 0;
            }
        }
        public async Task<int> GetCountOrderItem(string username)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT MAX(id) AS 'max' FROM orders WHERE username = @username";

                    cmd.Parameters.AddWithValue("username", username);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            int count = Convert.ToInt32(reader["max"]);
                            conn.Close();
                            return count;
                        }
                    }
                }
                conn.Close();
                return 0;
            }
        }
        public async Task<Order> GetOrderItem(int id, string username)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM orders WHERE id = @id and username = @username";

                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("username", username);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            Order order_item = ReadOrderItem(reader);
                            return order_item;
                        }
                    }
                }
                conn.Close();
                return null;
            }
        }
        private static Order ReadOrderItem(SQLiteDataReader reader)
        {
            int id = Convert.ToInt32(reader["id"]);
            float summ = Convert.ToSingle(reader["summ"]);
            string date = reader["date_order"].ToString();
            string id_items = reader["id_items"].ToString();
            string count_items = reader["count_items"].ToString();

            Order order_item = new Order
            {
                Id = id,
                Summ = summ,
                Date = date,
                Id_items = id_items,
                Count_items = count_items
            };
            return order_item;
        }
        public async Task DeleteOrder(int id, string username)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM orders WHERE id = @id AND username = @username";

                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public async Task<Basket_Item> GetOrderContentItem(int id)
        {
            using(var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, image, name FROM product WHERE id = @id";

                    cmd.Parameters.AddWithValue("id", id);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            Basket_Item basket_item = ReadOrderContentItem(reader);
                            return basket_item;
                        }
                    }
                }
                conn.Close();
                return null;
            }
        }
        private static Basket_Item ReadOrderContentItem(SQLiteDataReader reader)
        {
            int id = Convert.ToInt32(reader["id"]);
            string image = reader["image"] as string;
            string name = reader["name"] as string;

            Basket_Item basket_item = new Basket_Item
            {
                Id = id,
                Image = image,
                Name = name,
            };
            return basket_item;
        }
    }
}
