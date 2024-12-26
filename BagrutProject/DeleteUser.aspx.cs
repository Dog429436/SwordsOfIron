using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isUser"] == null)
        {
            Session["message"] = "דף למשתמשים רשומים בלבד";
            Response.Redirect("Message.aspx");
        }
        if (Request.Form["submit"] != null)
        {

            string UserNameforDelete;
            string PassWordForDelete;
            UserNameforDelete = Request.Form["UserNameforDelete"];
            PassWordForDelete = Request.Form["PassWordForDelete"];
            string TableName = "BagrutDatabase";
            string selectForDelete = string.Format("SELECT userName AS Expr1, userPassword AS Expr2 FROM BagrutDatabase WHERE (userName = '{0}') AND (userPassword = '{1}')", UserNameforDelete, PassWordForDelete);
            if (MyAdoHelperAccess.IsExist(selectForDelete))
            {
                string sql = string.Format("DELETE FROM {0} WHERE userPassword = '{1}'", TableName, PassWordForDelete);
                //string Message = MyAdoHelperAccess.RowsAffected(sql).ToString();
                MyAdoHelperAccess.DoQuery(sql);
                Session["message"] = "נמחקת בהצלחה";
                Response.Redirect("Message.aspx");
            }
            else
            {
                Session["message"] = "שם משתמש או סיסמה לא נמצאו";
                Response.Redirect("Message.aspx");
            }
            
        }

    }
}