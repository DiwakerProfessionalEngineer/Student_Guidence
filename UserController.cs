using studentcarrierguidence.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studentcarrierguidence.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        DatabaseManager db = new DatabaseManager();
        public ActionResult Index()
        {
            string uid = Session["uid"] + "";
            if(uid !="" && uid !=null)
            {
                
            }
            else
            {
                Response.Redirect("/Home/Login");
            }

            return View();
        }
        public ActionResult ViewRegistration()
        {
            return View();

        }
         
       [HttpGet]
        public ActionResult ChangePassword()
        {
           
            return View();
        }
        [HttpPost]
       public ActionResult ChangePassword(string txtopass, string npass, string cpass)
       {
           try
           {
               string id = Session["uid"] + "";
               if (cpass == npass)
               {
                   string cmd = "update tbl_login set passwd='" +npass + "'where userid='" + id + "'";

                   if (db.MyInsertUpdateDelete(cmd))
                       Response.Write("<script>alert('Password change successfull');window.location.href='/Home/Login';</script>");
               }
               else
                   Response.Write("<script>alert('unable to change password');window.location.href='/Home/Login';</script>");
               {
                   Response.Write("<script>alert('New password and confirm password not match')</script>");

               }
           }
           catch (Exception ex)
           {

           }
           return View();
       }
        [HttpGet]
        public ActionResult profile(string up)
        {
            string id = Session["uid"] + "";
            DatabaseManager db = new DatabaseManager();


            string cmd = "select * from tbl_Registration where email='" + id + "'";
            DataTable dt = db.GetAllRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                ViewBag.Name = dt.Rows[0]["name"];
                ViewBag.fname = dt.Rows[0]["fname"];
                ViewBag.email = dt.Rows[0]["Email"];
                ViewBag.mobile = dt.Rows[0]["mobile"];
             
            }

            return View();
        }
        [HttpGet]
        public ActionResult Editregistration(string up)
        {
            DatabaseManager db = new DatabaseManager();
            string cmd = " select * from tbl_registration where email='" + up + "' ";
            DataTable dt = db.GetAllRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                ViewBag.name = dt.Rows[0]["name"];
                ViewBag.fname = dt.Rows[0]["fname"];
                ViewBag.email = dt.Rows[0]["Email"];
                ViewBag.mobile = dt.Rows[0]["mobile"];
                ViewBag.pass = dt.Rows[0]["pass"];
            }
            return View();
        }
        [HttpPost]
        public ActionResult Editregistration(string txtname, string txtfname, string txtemail, string txtmobile, string txtpass)
        {

            string cmd = "update tbl_registration set name='" + txtname + "',fname='" + txtfname + "',email='" + txtemail + "',pass='" + txtpass + "'";
            DatabaseManager db = new DatabaseManager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('update Record successfully');window.location.href='/User/ViewRegistration';</script>");
            else
                Response.Write("<script>alert('server error')>/script>");

            return View();
        }
        public ActionResult deleteregistration(string Del)
        {

            string cmd = "delete from tbl_registration where email='" + Del + "'";
            DatabaseManager db = new DatabaseManager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('deleted ');window.location.href='/User/ViewRegistration';</script>");
            else
                Response.Write("error");
            return View();

        }
        public ActionResult logout()
        {
            string uid = Session["uid"] + "";
            if(uid !="" && uid !=null)
            {
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                Response.Redirect("/Home/Login");
            }
            else
            {
                Response.Redirect("/Home/Login");
            }
            return View();
        }
        public ActionResult feedback()
        {
            return View();
        }


        [HttpPost]
        public ActionResult feedback(string txtreview)
        {
            string query = "insert into tbl_feedback values('" + txtreview + "','" + DateTime.Now.ToString() + "')";
            if (db.MyInsertUpdateDelete(query))
            {
                Response.Write("<script>alert('successfull.....')</script>");
            }
            else
            {
                Response.Write("<script>alert('Unsuccessfull......'(</script>");
            }
            return View();
        }

    }
}
