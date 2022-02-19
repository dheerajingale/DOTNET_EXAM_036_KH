using ProductMVCExam.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVCExam.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<ProductModel> products = new List<ProductModel>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True";
            con.Open();
            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Products";

                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ProductModel pro = new ProductModel();
                    pro.ProductId = (int)read["ProductId"];
                    pro.ProductName = (string)read["ProductName"];
                    pro.Rate = (decimal)read["Rate"];
                    pro.Description = (string)read["Description"];
                    pro.CategoryName = (string)read["CategoryName"];

                    products.Add(pro);
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }

            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            ProductModel product = new ProductModel();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True";
            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Products where ProductId = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader read = cmd.ExecuteReader();
                read.Read();
                product.ProductId = (int)read["ProductId"];
                product.ProductName = (string)read["ProductName"];
                product.Rate = (decimal)read["Rate"];
                product.Description = (string)read["Description"];
                product.CategoryName = (string)read["CategoryName"];
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductModel product)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True";
            con.Open();
            try
            {
                // TODO: Add update logic here
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateProduct";

                cmd.Parameters.AddWithValue("@ProductId", id);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Rate", product.Rate);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@CategoryName", product.CategoryName);

                cmd.ExecuteNonQuery();

                con.Close();

                return RedirectToAction("Index");
            }
            catch
            {
                con.Close();
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
