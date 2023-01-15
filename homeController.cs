using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studentcarrierguidence.Models
{
    public class homeController : Controller
    {
        //
        // GET: /home/
        DatabaseManager db = new DatabaseManager();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AboutUs()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registation()
        {
            CaptchaGeneration cg = new CaptchaGeneration();
            ViewBag.cph = cg.CaptchaCode();
            return View();
        }
        [HttpPost]
        public ActionResult Registation(string txtname, string txtfname, string txtemail, string txtpass, string txtmob, string txtgender, string txtq, HttpPostedFileBase fupic, string txtcaptcha, string txtcph)
        {

            try
            {
                    if (txtcaptcha == txtcph)
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/profile"), fupic.FileName);
                        fupic.SaveAs(path);
                        string cmd = "insert into tbl_Registration values('" + txtname + "','" + txtfname + "','" + txtemail + "','" + txtpass + "','" + txtmob + "','" + txtgender + "','" + txtq + "','" + fupic.FileName + "','" + DateTime.Now.ToString() + "')";

                        string cmd1 = "insert into tbl_login values('" + txtemail + "','" + txtpass + "','user')";
                           if (db.MyInsertUpdateDelete(cmd) && db.MyInsertUpdateDelete(cmd1))
                            Response.Write("<script>alert('Registration Completed.')</script>");
                        else
                            Response.Write("<script>alert('server error.')</script>");
  

                    }
                    else
                    {
                        Response.Write("<script>alert('please enter valid captcha code.')</script>");

                    }
               
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('already submited.')</script>");
            }
            return View();
        }
     
        [HttpGet]
        public ActionResult Login()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtuserid, string txtpass)
        {
            string cmd = "select * from tbl_login where userid='" + txtuserid + "'and passwd='" + txtpass + "'";
            DatabaseManager db = new DatabaseManager();
            DataTable dt = db.GetAllRecord(cmd);
            if (dt.Rows.Count > 0)
            {
                string utype = dt.Rows[0]["utype"] + "";
                if (utype == "user")
                {
                    Session["uid"] = txtuserid;
                    Response.Redirect("/User/Index");
                }
                else if (utype == "admin")
                {
                    Session["aid"] = txtuserid;
                    Response.Redirect("/Admin/Index");
                }
                else
                {
                    Response.Write("<script>alert('Invalid user type.')</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Invalid userid and password.')</script>");
            }
            return View();
        }
      



        [HttpGet]
        public ActionResult Notification()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(string email, string contact, string location)
        {

            string cmd = "insert into tbl_conatct values('" + email + "','" + contact + "','" + location + "')";
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Contact Save successfully')</script>");
            else
                Response.Write("<script>alert('unable to save data')</script>");

            return View();
        }

        [HttpGet]
        public ActionResult Enquiry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enquiry(String txtusername, String txtemail, String txtsubject, String txtequery)
        {
            String cmd = "insert into tbl_enquiry values('" + txtusername + "','" + txtemail + "','" + txtsubject + "','" + txtequery + "')";
            if (db.MyInsertUpdateDelete(cmd))
                Response.Write("<script>alert('Enquiry Save successfully')</script>");
            else
                Response.Write("<script>alert('Unable to save enquiry')</script>");
            
            return View();
        }
        public ActionResult Event()
        {
            return View();
        }
    }

}

