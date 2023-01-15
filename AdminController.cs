using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using studentcarrierguidence.Models;
using System.Data;
using System.Data.SqlClient;

namespace studentcarrierguidence.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            string aid = Session["aid"] + "";
            if (aid != "" && aid != null)
            {
               
               
            }
            else
            {
                Response.Redirect("/Home/Login");
            }
            return View();
        }
        public ActionResult ViewContactus()
        {
            return View();
        }
         public ActionResult ViewRegistration()
        {
            return View();

        }
        [HttpGet]
        public ActionResult Editregistration(string up)
         {
             DatabaseManager db = new DatabaseManager();
             string cmd = " select * from tbl_registration where email='" + up + "' ";
             DataTable dt = db.GetAllRecord(cmd);
            if(dt.Rows.Count>0)
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
        public ActionResult Editregistration(string txtname, string txtfname, string txtemail, string txtmobile,string txtpass)
        {

            string cmd = "update tbl_registration set name='" + txtname + "',fname='" + txtfname + "',email='" + txtemail + "',pass='" + txtpass + "'";
            DatabaseManager db = new DatabaseManager();
            if(db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('update Record successfully');window.location.href='/Admin/ViewRegistration';</script>");
            else
                Response.Write("<script>alert('server error')>/script>");

            return View();
        }
        public ActionResult deleteregistration(string Del)
        {

            string cmd = "delete from tbl_registration where email='" + Del + "'";
            DatabaseManager db = new DatabaseManager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('deleted ');window.location.href='/Admin/ViewRegistration';</script>");
            else
                Response.Write("error");
            return View();

        }
        [HttpGet]
        public ActionResult EditContact ( string up)
        {
            DatabaseManager db = new DatabaseManager();
            string cmd = "select* from tbl_conatct where email='" + up + "'";
            DataTable dt= db.GetAllRecord(cmd);
            if(dt.Rows.Count>0)
            {
                ViewBag.email=dt.Rows[0]["email"];
                ViewBag.contact=dt.Rows[0]["contact"];
                ViewBag.location=dt.Rows[0]["location"];
            }
            return View();

        }
        [HttpPost]
        public ActionResult EditContact(string txtemail,string txtcontact,string txtlocation)
         {
             string cmd = "update tbl_conatct set email='"+txtemail+"',contact='"+txtcontact+"',location='"+txtlocation+"'";
            DatabaseManager db = new DatabaseManager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('update Record successfully');window.location.href='/Admin/ViewContactUs';</script>");
            else
                Response.Write("<script>alert('server error')>/script>");
            return View();

        }
        public ActionResult deletecontact(string Del)
        {
            
            string cmd = "delete from tbl_conatct where email='" + Del + "'";
            DatabaseManager db = new DatabaseManager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('deleted ');window.location.href='/Admin/ViewContactus';</script>");
            else
                Response.Write("error");
            return View();

        }

        [HttpGet]
        public ActionResult notification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult notification(string txtnoti)
        {
            try
            {
                string cmd = "insert into tbl_notification values('" + txtnoti + "','"+DateTime.Now.ToString()+"')";
                DatabaseManager db = new DatabaseManager();
                if (db.MyInsertUpdateDelete(cmd))
                    Response.Write("<script>alert('add notification successfully')</script>");
                else
                    Response.Write("<script>alert('server error')>/script>");
            }
            catch(Exception ex)
            {

            }
            return View();
        }
        public ActionResult deletenotification(string Del)
        {

            string cmd = "delete from tbl_notification where notification='" + Del + "'";
            DatabaseManager db = new DatabaseManager();
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('deleted ');window.location.href='/Admin/notification';</script>");
            else
                Response.Write("error");
            return View();

        }
        public ActionResult logout()
        {
            string aid = Session["aid"] + "";
            if (aid != "" && aid != null)
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
        [HttpGet]
        public ActionResult Editnotification(string up)
        {
            DatabaseManager db = new DatabaseManager();
            string cmd = "select*from tbl_notification where notification='"+up+"'";
                DataTable dt=db.GetAllRecord(cmd);

            if(dt.Rows.Count>0)
            {
                ViewBag.notification=dt.Rows[0]["notification"];
            }
            return View();
        }
        [HttpPost]
        public ActionResult Editnotification(string txtnoti,string txtid)
        {
            DatabaseManager db = new DatabaseManager();
           

            string cmd = "update tbl_notification set notification='" + txtnoti + "'";
            if(db.MyInsertUpdateDelete(cmd))
            {
                Response.Write("<script>alert('updated')</script>");
                Response.Redirect("/Admin/notification");
              
            }

            else
            {
                Response.Write("<script>alert('not updated')</script>");
            }
            return View();

        }
        public ActionResult viewenquiry()
        {
            return View();
        }
        
    }
}
