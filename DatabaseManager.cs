using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace studentcarrierguidence.Models
{
    public class DatabaseManager : Controller
    {
        //s
        // GET: /DatabaseManager/

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GCBO65O\SQLEXPRESS;Initial Catalog=student;Integrated Security=True");
        public bool MyInsertUpdateDelete(string commond)
        {
            SqlCommand cmd = new SqlCommand(commond, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
                return true;
            else
                return false;
        }
        public DataTable GetAllRecord(string command)
        {
            SqlDataAdapter sa = new SqlDataAdapter(command, con);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            return dt;
        }

    }
}
