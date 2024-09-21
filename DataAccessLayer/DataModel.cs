using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Admin Metot
        public Admin AdminLogin(string username, string password)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Admin WHERE Username = @username AND Password = @password";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                con.Open();
                int number = Convert.ToInt32(cmd.ExecuteScalar());

                if (number > 0)
                {
                    cmd.CommandText = "SELECT ID, UserName, Image FROM Admin WHERE UserName = @username AND Password = @password";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    Admin a = new Admin();
                    while (reader.Read())
                    {
                        a.ID = reader.GetInt32(0);
                        a.Username = reader.GetString(1);
                        a.Image = reader.GetString(2);
                    }
                    return a;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        #endregion

        #region Category Metot

        public List<Category> CategoryList()
        {
            List<Category> cat = new List<Category>();
            try
            {
                cmd.CommandText = "SELECT * FROM Category";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category c = new Category();
                    c.ID = reader.GetInt32(0);
                    c.Name = reader.GetString(1);
                    cat.Add(c);
                }
                reader.Close();
                return cat;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool CreateCategory(Category cat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Category(Name) VALUES(@name)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", cat.Name);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
            finally { con.Close(); }
        }

        #endregion

        #region Product Metot
        public List<Product> ProductList()
        {
            List<Product> pro = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT p.ID, p.Name, p.Description, c.Name, p.Price, p.Width, p.Length, p.Height, p.Weight, p.Barcode, p.Image1, f.Name FROM Product AS p\r\nJOIN Category AS c ON c.ID = p.CategoryID\r\nJOIN Filament AS f ON f.ID = p.FilamentID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Category = reader.GetString(3);
                    p.Price = reader.GetDecimal(4);
                    p.Width = reader.GetString(5);
                    p.Length = reader.GetString(6);
                    p.Height = reader.GetString(7);
                    p.Weight = reader.GetDecimal(8);
                    p.Barcode = reader.GetString(9);
                    p.Image1 = reader.GetString(10);
                    p.Filament = reader.GetString(11);
                    pro.Add(p);
                }
                return pro;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                cmd.CommandText = "DELETE Product WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Product> ListProductsByCategory(int categoryID)
        {
            List<Product> pro = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT * FROM Product WHERE CategoryID = @CategoryID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Category = reader.GetString(3);
                    p.Price = reader.GetDecimal(4);
                    p.Width = reader.GetString(5);
                    p.Length = reader.GetString(6);
                    p.Height = reader.GetString(7);
                    p.Weight = reader.GetDecimal(8);
                    p.Barcode = reader.GetString(9);
                    p.Image1 = reader.GetString(10);
                    p.Filament = reader.GetString(11);
                    p.ProfitMargin = reader.GetDecimal(12);
                    pro.Add(p);
                }
            }
            finally
            {
                con.Close();
            }
            return pro;
        }

        public Product GetProduct(int id)
        {
            try
            {
                cmd.CommandText = @"SELECT p.ID, p.Name, p.Description, p.CategoryID, c.Name AS CategoryName, p.Price, 
                            p.Width, p.Length, p.Height, p.Weight, p.Barcode, 
                            p.Image1, p.Image2, p.Image3, p.Image4, p.Image5, 
                            p.FilamentID, f.Name, p.ProfitMargin, p.TotalPrice AS FilamentName
                            FROM Product AS p
                            JOIN Category AS c ON c.ID = p.CategoryID
                            JOIN Filament AS f ON f.ID = p.FilamentID
                            WHERE p.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                Product p = new Product();
                if (reader.Read())
                {
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.CategoryID = reader.GetInt32(3);  // CategoryID atandı
                    p.Category = reader.GetString(4);   // CategoryName atandı
                    p.Price = reader.GetDecimal(5);
                    p.Width = reader.GetString(6);
                    p.Length = reader.GetString(7);
                    p.Height = reader.GetString(8);
                    p.Weight = reader.GetDecimal(9);
                    p.Barcode = reader.GetString(10);
                    p.Image1 = reader.GetString(11);
                    p.Image2 = reader.GetString(12);
                    p.Image3 = reader.GetString(13);
                    p.Image4 = reader.GetString(14);
                    p.Image5 = reader.GetString(15);
                    p.FilamentID = reader.GetInt32(16); // FilamentID atandı
                    p.Filament = reader.GetString(17);  // FilamentName atandı
                    p.ProfitMargin = reader.GetDecimal(18);
                    p.TotalPrice = reader.GetDecimal(19);
                }
                return p;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UpdateProduct(Product pro)
        {
            try
            {
                cmd.CommandText = "UPDATE Product SET Name = @name, Description=@desc, CategoryID = @catid, Width = @width, Length = @length, Height = @height, Weight = @weight, Barcode = @barcode, Image1 = @image1, Image2 = @image2, Image3 = @image3, Image4 = @image4, Image5 = @image5, ProfitMargin = @margin WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", pro.ID);
                cmd.Parameters.AddWithValue("@name", pro.Name);
                cmd.Parameters.AddWithValue("@desc", pro.Description);
                cmd.Parameters.AddWithValue("@catid", pro.CategoryID);
                cmd.Parameters.AddWithValue("@width", pro.Width);
                cmd.Parameters.AddWithValue("@length", pro.Length);
                cmd.Parameters.AddWithValue("@height", pro.Height);
                cmd.Parameters.AddWithValue("@weight", pro.Weight);
                cmd.Parameters.AddWithValue("@barcode", pro.Barcode);
                cmd.Parameters.AddWithValue("@image1", pro.Image1);
                cmd.Parameters.AddWithValue("@image2", pro.Image2);
                cmd.Parameters.AddWithValue("@image3", pro.Image3);
                cmd.Parameters.AddWithValue("@image4", pro.Image4);
                cmd.Parameters.AddWithValue("@image5", pro.Image5);
                cmd.Parameters.AddWithValue("@margin", pro.ProfitMargin);

                con.Open();

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool CreateProduct(Product pro)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Product(Name, Description, CategoryID, Width, Length, Height, Weight, Barcode, Image1, Image2, Image3, Image4, Image5, FilamentID, ProfitMargin) VALUES (@name, @desc, @catid, @width, @length, @height, @weight, @barcode, @image1, @image2, @image3, @image4, @image5, @filid, @promar)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", pro.Name);
                cmd.Parameters.AddWithValue("@desc", pro.Description);
                cmd.Parameters.AddWithValue("@catid", pro.CategoryID);
                cmd.Parameters.AddWithValue("@width", pro.Width);
                cmd.Parameters.AddWithValue("@length", pro.Length);
                cmd.Parameters.AddWithValue("@height", pro.Height);
                cmd.Parameters.AddWithValue("@weight", pro.Weight);
                cmd.Parameters.AddWithValue("@barcode", pro.Barcode);
                cmd.Parameters.AddWithValue("@image1", pro.Image1);
                cmd.Parameters.AddWithValue("@image2", pro.Image2);
                cmd.Parameters.AddWithValue("@image3", pro.Image3);
                cmd.Parameters.AddWithValue("@image4", pro.Image4);
                cmd.Parameters.AddWithValue("@image5", pro.Image5);
                cmd.Parameters.AddWithValue("@filid", pro.FilamentID);
                cmd.Parameters.AddWithValue("@promar", pro.ProfitMargin);
                con.Open();
                cmd.ExecuteReader();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Product> ProductListKeychain()
        {
            List<Product> pro = new List<Product>();
            try
            {
                cmd.CommandText = @"SELECT p.ID, p.Name, p.Description, c.Name, p.Price, 
                                   p.Width, p.Length, p.Height, p.Weight, p.Barcode, 
                                   p.Image1, f.Name, p.TotalPrice 
                            FROM Product AS p
                            JOIN Category AS c ON c.ID = p.CategoryID
                            JOIN Filament AS f ON f.ID = p.FilamentID 
                            WHERE c.ID = 1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();

                    // Assigning values with explicit checks
                    p.ID = reader.GetInt32(0); // Assuming ID is an int
                    p.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    p.Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    p.Category = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    p.Price = reader.IsDBNull(4) ? 0M : reader.GetDecimal(4); // Assuming Price is decimal
                    p.Width = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                    p.Length = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                    p.Height = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                    p.Weight = reader.IsDBNull(8) ? 0M : reader.GetDecimal(8); // Assuming Weight is decimal
                    p.Barcode = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                    p.Image1 = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                    p.Filament = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                    p.TotalPrice = reader.IsDBNull(12) ? 0M : reader.GetDecimal(12); // Assuming TotalPrice is decimal

                    pro.Add(p);
                }
                return pro;
            }
            catch (InvalidCastException ex)
            {
                // Log exception details
                Console.WriteLine("InvalidCastException: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Product> ProductListTrinket()
        {
            List<Product> pro = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT p.ID, p.Name, p.Description, c.Name, p.Price, p.Width, p.Length, p.Height, p.Weight, p.Barcode, p.Image1, f.Name, p.TotalPrice FROM Product AS p\r\nJOIN Category AS c ON c.ID = p.CategoryID\r\nJOIN Filament AS f ON f.ID = p.FilamentID WHERE c.ID = 2";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Category = reader.GetString(3);
                    p.Price = reader.GetDecimal(4);
                    p.Width = reader.GetString(5);
                    p.Length = reader.GetString(6);
                    p.Height = reader.GetString(7);
                    p.Weight = reader.GetDecimal(8);
                    p.Barcode = reader.GetString(9);
                    p.Image1 = reader.GetString(10);
                    p.Filament = reader.GetString(11);
                    p.TotalPrice = reader.GetDecimal(12);
                    pro.Add(p);
                }
                return pro;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Product> ProductListKitchen()
        {
            List<Product> pro = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT p.ID, p.Name, p.Description, c.Name, p.Price, p.Width, p.Length, p.Height, p.Weight, p.Barcode, p.Image1, f.Name, p.TotalPrice FROM Product AS p\r\nJOIN Category AS c ON c.ID = p.CategoryID\r\nJOIN Filament AS f ON f.ID = p.FilamentID WHERE c.ID = 3";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Category = reader.GetString(3);
                    p.Price = reader.GetDecimal(4);
                    p.Width = reader.GetString(5);
                    p.Length = reader.GetString(6);
                    p.Height = reader.GetString(7);
                    p.Weight = reader.GetDecimal(8);
                    p.Barcode = reader.GetString(9);
                    p.Image1 = reader.GetString(10);
                    p.Filament = reader.GetString(11);
                    p.TotalPrice = reader.GetDecimal(12);
                    pro.Add(p);
                }
                return pro;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Product> ProductListStationary()
        {
            List<Product> pro = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT p.ID, p.Name, p.Description, c.Name, p.Price, p.Width, p.Length, p.Height, p.Weight, p.Barcode, p.Image1, f.Name, p.TotalPrice FROM Product AS p\r\nJOIN Category AS c ON c.ID = p.CategoryID\r\nJOIN Filament AS f ON f.ID = p.FilamentID WHERE c.ID = 4";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Category = reader.GetString(3);
                    p.Price = reader.GetDecimal(4);
                    p.Width = reader.GetString(5);
                    p.Length = reader.GetString(6);
                    p.Height = reader.GetString(7);
                    p.Weight = reader.GetDecimal(8);
                    p.Barcode = reader.GetString(9);
                    p.Image1 = reader.GetString(10);
                    p.Filament = reader.GetString(11);
                    p.TotalPrice = reader.GetDecimal(12);
                    pro.Add(p);
                }
                return pro;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Product> ProductListDecoration()
        {
            List<Product> pro = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT p.ID, p.Name, p.Description, c.Name, p.Price, p.Width, p.Length, p.Height, p.Weight, p.Barcode, p.Image1, f.Name, p.TotalPrice FROM Product AS p\r\nJOIN Category AS c ON c.ID = p.CategoryID\r\nJOIN Filament AS f ON f.ID = p.FilamentID WHERE c.ID = 5";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Category = reader.GetString(3);
                    p.Price = reader.GetDecimal(4);
                    p.Width = reader.GetString(5);
                    p.Length = reader.GetString(6);
                    p.Height = reader.GetString(7);
                    p.Weight = reader.GetDecimal(8);
                    p.Barcode = reader.GetString(9);
                    p.Image1 = reader.GetString(10);
                    p.Filament = reader.GetString(11);
                    p.TotalPrice = reader.GetDecimal(12);
                    pro.Add(p);
                }
                return pro;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Product> ProductListSpecial()
        {
            List<Product> pro = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT p.ID, p.Name, p.Description, c.Name, p.Price, p.Width, p.Length, p.Height, p.Weight, p.Barcode, p.Image1, f.Name, p.TotalPrice FROM Product AS p\r\nJOIN Category AS c ON c.ID = p.CategoryID\r\nJOIN Filament AS f ON f.ID = p.FilamentID WHERE c.ID = 6";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Category = reader.GetString(3);
                    p.Price = reader.GetDecimal(4);
                    p.Width = reader.GetString(5);
                    p.Length = reader.GetString(6);
                    p.Height = reader.GetString(7);
                    p.Weight = reader.GetDecimal(8);
                    p.Barcode = reader.GetString(9);
                    p.Image1 = reader.GetString(10);
                    p.Filament = reader.GetString(11);
                    p.TotalPrice = reader.GetDecimal(12);
                    pro.Add(p);
                }
                return pro;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Product> ProductListGarden()
        {
            List<Product> pro = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT p.ID, p.Name, p.Description, c.Name, p.Price, p.Width, p.Length, p.Height, p.Weight, p.Barcode, p.Image1, f.Name, p.TotalPrice FROM Product AS p\r\nJOIN Category AS c ON c.ID = p.CategoryID\r\nJOIN Filament AS f ON f.ID = p.FilamentID WHERE c.ID = 7";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Category = reader.GetString(3);
                    p.Price = reader.GetDecimal(4);
                    p.Width = reader.GetString(5);
                    p.Length = reader.GetString(6);
                    p.Height = reader.GetString(7);
                    p.Weight = reader.GetDecimal(8);
                    p.Barcode = reader.GetString(9);
                    p.Image1 = reader.GetString(10);
                    p.Filament = reader.GetString(11);
                    p.TotalPrice = reader.GetDecimal(12);
                    pro.Add(p);
                }
                return pro;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }


        public List<Product> ProductListPhoneStand()
        {
            List<Product> pro = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT p.ID, p.Name, p.Description, c.Name, p.Price, p.Width, p.Length, p.Height, p.Weight, p.Barcode, p.Image1, f.Name, p.TotalPrice FROM Product AS p\r\nJOIN Category AS c ON c.ID = p.CategoryID\r\nJOIN Filament AS f ON f.ID = p.FilamentID WHERE c.ID = 9";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.ID = reader.GetInt32(0);
                    p.Name = reader.GetString(1);
                    p.Description = reader.GetString(2);
                    p.Category = reader.GetString(3);
                    p.Price = reader.GetDecimal(4);
                    p.Width = reader.GetString(5);
                    p.Length = reader.GetString(6);
                    p.Height = reader.GetString(7);
                    p.Weight = reader.GetDecimal(8);
                    p.Barcode = reader.GetString(9);
                    p.Image1 = reader.GetString(10);
                    p.Filament = reader.GetString(11);
                    p.TotalPrice = reader.GetDecimal(12);
                    pro.Add(p);
                }
                return pro;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Filament Metot

        public List<Filament> ListFilament()
        {
            List<Filament> filament = new List<Filament>();
            try
            {
                cmd.CommandText = "SELECT * FROM Filament";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Filament f = new Filament();
                    f.ID = reader.GetInt32(0);
                    f.Name = reader.GetString(1);
                    f.Color = reader.GetString(2);
                    f.Price = reader.GetDecimal(3);
                    f.Weight = reader.GetDecimal(4);
                    filament.Add(f);
                }
                reader.Close();
                return filament;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Newsletter Metot
        public bool CreateNewsletter(Newsletter news)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Newsletter(Mail) VALUES(@mail)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", news.Mail).ToString();
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
            finally { con.Close(); }
        }

        #endregion

    }
}
