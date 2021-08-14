using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculation.Controllers
{
    public class CalculationController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult calculate(FormCollection fc)
        {
            
            int fnum, snum;
            try
            {
                if(fc[0] != "" && fc[1] != "")
                {
                    fnum = Int32.Parse(fc[0]);
                    snum = Int32.Parse(fc[1]);
                    int sum = getASum(fnum, snum);
                    int product = getAProduct(sum);
                    int power = getAPower(product);
                    ViewData["Answer"] = power;
                }
                
            }
            catch
            {
                Console.WriteLine("Error");
            }

            return View("calculate");
        }

        private int getAPower(int product)
        {
            int value = (int)Math.Pow(product, 2);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=.\\sqlexpress;Integrated Security=SSPI;Initial Catalog=DB";
            try
            {
                string create = "IF NOT EXISTS( SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Power') " +
                    "CREATE TABLE Power (value int)";
                string query = "insert into POWER(value) values(" + value + ")";
                SqlCommand cmd = new SqlCommand(create, con);
                SqlCommand cmd1 = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                Console.WriteLine("Error");
            }
            return value;
        }

        private int getAProduct(int sum)
        {
            int value = sum * 2;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=.\\sqlexpress;Integrated Security=SSPI;Initial Catalog=DB";
            try
            {
                string create = "IF NOT EXISTS( SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Product') " +
                    "CREATE TABLE Product (value int)";
                string query = "insert into PRODUCT(value) values(" + value + ")";
                SqlCommand cmd = new SqlCommand(create, con);
                SqlCommand cmd1 = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error");
            }
            return value;
        }

        private int getASum(int fnum, int snum)
        {
            int value = fnum + snum;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=.\\sqlexpress;Integrated Security=SSPI;Initial Catalog=DB";
            try
            {
                string create = "IF NOT EXISTS( SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Sum') " +
                    "CREATE TABLE Sum (value int)";
                string query = "insert into SUM(value) values(" + value + ")";
                SqlCommand cmd = new SqlCommand(create, con);
                SqlCommand cmd1 = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                Console.WriteLine("Error");
            }
            return value;
        }
    }
}