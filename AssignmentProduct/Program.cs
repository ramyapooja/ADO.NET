using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AssignmentProduct
{
    class Program
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CHU7B0H\SQLEXPRESS;Initial Catalog=PracticeDB;User ID=sa;Password=pass@word1");
        SqlCommand cmd = null;
        public void Add(string id,string name,int price,int stock)
        {
            try
            {
                cmd = new SqlCommand("insert into product values(@id,@name,@price,@stock)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@stock", stock);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void Get(string id)
        {
            try
            {
                cmd = new SqlCommand("select * from product where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    dr.Read();
                    Console.WriteLine("ID:{0} Name:{1} Price:{2} Stock:{3}", dr["id"], dr["name"], dr["price"], dr["stock"]);
                }
                else
                {
                    Console.WriteLine("No products found");
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void GetAll()
        {
            try
            {
                cmd = new SqlCommand("select * from product", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("ID:{0} Name:{1} Price:{2} Stock:{3}", dr["id"], dr["name"], dr["price"], dr["stock"]);
                    }
                }
                else
                {
                    Console.WriteLine("Table empty");
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void Delete(string id)
        {
            try
            {
                cmd = new SqlCommand("delete  from product where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void Update(string id,int price,int stock)
        {
            try
            {
                cmd = new SqlCommand("update product set price=@price,stock=@stock where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@stock", stock);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            //obj.Add("P2","AC",70000,1);
            //obj.Get("P1");
            //obj.GetAll();
            //obj.Delete("P2");
            obj.Update("P1", 50000, 1);
            Console.ReadKey();
        }
    }
}
