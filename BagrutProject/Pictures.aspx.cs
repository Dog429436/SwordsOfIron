﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pictures : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isUser"] == null)
        {
            Session["message"] = "דף למשתמשים רשומים בלבד";
            Response.Redirect("Message.aspx");
        }
    }
}