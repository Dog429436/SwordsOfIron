using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["submit"] != null)
        {
            string uName_r;
            string uPAss_r;
            uName_r = Request.Form["Uname"];
            uPAss_r = Request.Form["Upass"];
            string TableName = "BagrutDatabase";
            string selectForLogIn;
            selectForLogIn = string.Format("SELECT * FROM BagrutDatabase WHERE (userName = '{0}') AND (userPassword = '{1}') AND (userAdmin = true)", uName_r, uPAss_r);
            if (MyAdoHelperAccess.IsExist(selectForLogIn))
            {
                Session["isUser"] = uName_r;
                Session["isAdmin"] = true;
                Session["message"] = "התחברת בהצלחה כמנהל";
                Response.Redirect("Message.aspx");
            }
            else
            {
                selectForLogIn = string.Format("SELECT userName AS Expr1, userPassword AS Expr2 FROM BagrutDatabase WHERE (userName = '{0}') AND (userPassword = '{1}')", uName_r, uPAss_r);
                if (MyAdoHelperAccess.IsExist(selectForLogIn))
                {
                    Session["isAdmin"] = false;
                    Session["isUser"] = uName_r;
                    Session["message"] = "התחברת בהצלחה";
                    Response.Redirect("Message.aspx");
                }
                else
                {
                    Session["message"] = "יש בעיה באחד הפרטים";
                    Response.Redirect("Message.aspx");
                }
            }
        }


    }
}