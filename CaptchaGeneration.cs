using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace studentcarrierguidence.Models
{
    public class CaptchaGeneration : Controller
    {
        //
        // GET: /CaptchaGeneration/


        Random rm = new Random();
        public string CaptchaCode()
        {
            char ch1, ch2, ch3, ch4, ch5;
            ch1 = Convert.ToChar(rm.Next(65, 92)); //A-Z
            ch2 = Convert.ToChar(rm.Next(49, 55)); //0-9
            ch3 = Convert.ToChar(rm.Next(97, 122)); //a-z
            ch4 = Convert.ToChar(rm.Next(65, 92)); //A-Z
            ch5 = Convert.ToChar(rm.Next(49, 55)); //0-9
            string Captcha = ch1 + "" + ch2 + "" + ch3 + "" + ch4 + "" + ch5 + "";
            return Captcha;

        }

    }
}
