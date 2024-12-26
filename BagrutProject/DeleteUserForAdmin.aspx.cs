using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteUserForAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["isAdmin"] == false)
        {
            Session["message"] = "דף למנהלים בלבד";
            Response.Redirect("Message.aspx");
        }
        string UserPassword = Request.QueryString["userPassword"];
        string sql = string.Format("DELETE * FROM BagrutDatabase WHERE userPassword = '{0}'", UserPassword);
        MyAdoHelperAccess.DoQuery(sql);
        Session["message"] = "המשתמש נמחק בהצלחה";
        Response.Redirect("Message.aspx");
    }
}