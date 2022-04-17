using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CafeProject.Models;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace CafeProject.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-LITKJC6;database=aysegul;Integrated Security=true;";
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from User_table where Username='"+acc.Name+"' and Hashpassword='"+acc.Password+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("~/Views/Anasayfa.cshtml");

            }
            else
            {
                con.Close();
                return View();
            }
           
            
        }
    }
}