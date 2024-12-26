using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateUser : System.Web.UI.Page
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

            string UserName;
            string UserPassword;
            string UserNewPassword;
            UserName = Request.Form["UserName"];
            UserPassword = Request.Form["UserPassword"];
            UserNewPassword = Request.Form["NewPassword"];
            string selectForUpdate = string.Format("SELECT userName AS Expr1, userPassword AS Expr2 FROM BagrutDatabase WHERE (userName = '{0}') AND (userPassword = '{1}')", UserName, UserPassword);
            string checkIfExist;
            if (MyAdoHelperAccess.IsExist(selectForUpdate))
            {
                checkIfExist = string.Format("SELECT * FROM BagrutDatabase WHERE (userPassword = '{0}')", UserNewPassword);
                if (MyAdoHelperAccess.IsExist(checkIfExist))
                {
                    Session["message"] = "הסיסמה החדשה קיימת";
                    Response.Redirect("Message.aspx");
                }
                else
                {
                    string sql = string.Format("UPDATE BagrutDatabase SET userPassword = '{0}' WHERE (BagrutDatabase.userName = '{1}') AND (BagrutDatabase.userPassword = '{2}')", UserNewPassword, UserName, UserPassword);
                    //string Message = MyAdoHelperAccess.RowsAffected(sql).ToString();
                    MyAdoHelperAccess.DoQuery(sql);
                    Session["message"] = "סיסמתך עודכנה בהצלחה";
                    Response.Redirect("Message.aspx");
                }
                
            }
            else
            {
                Session["message"] = "שם משתמש או סיסמה לא נמצאו";
                Response.Redirect("Message.aspx");
            }
        }
    }
}