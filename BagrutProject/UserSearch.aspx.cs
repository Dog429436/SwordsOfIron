using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserSearch : System.Web.UI.Page
{
    public string userList = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isUser"] == null)
        {
            Session["message"] = "דף למשתמשים רשומים בלבד";
            Response.Redirect("Message.aspx");
        }
        if (Request.Form["PrintAll"] != null)
        {

            string TableName = "BagrutDatabase";
            string selectQuery = "SELECT * FROM " + TableName;
            userList += "<tr>";
            userList += "<td>שם משתמש</td>";
            userList += "<td>סיסמה</td>";
            userList += "<td>תעודת זהות</td>";
            userList += "<td>מנהל</td>";
            userList += "<td>אימייל</td>";
            userList += "<td>שם פרטי ושם משפחה</td>";
            userList += "<td>מין</td>";
            userList += "<td>שנת לידה</td>";
            userList += "<td>תחום עיסוק</td>";
            userList += "<td>מטרות באתר</td>";
            userList += "<td>סכום תרומה</td>";
            userList += "<td>עולה חדש</td>";
            userList += "<td>מנהל</td>";
            userList += MyAdoHelperAccess.PrintDataTableForNonAdmin(selectQuery).ToString();
        }
        if (Request.Form["Fsubmit"] != null)
        {
            string selectQuery = string.Format("SELECT BagrutDatabase.*, fname AS Expr1 FROM BagrutDatabase WHERE (fname = '{0}')", Request.Form["FName"]);
            if (MyAdoHelperAccess.IsExist(selectQuery))
            {
                userList += "<tr>";
                userList += "<td>שם משתמש</td>";
                userList += "<td>סיסמה</td>";
                userList += "<td>תעודת זהות</td>";
                userList += "<td>מנהל</td>";
                userList += "<td>אימייל</td>";
                userList += "<td>שם פרטי</td>";
                userList += "<td>מין</td>";
                userList += "<td>שנת לידה</td>";
                userList += "<td>תחום עיסוק</td>";
                userList += "<td>מטרות באתר</td>";
                userList += "<td>סכום תרומה</td>";
                userList += "<td>עולה חדש</td>";
                userList += "<td>מנהל</td>";
                userList += MyAdoHelperAccess.PrintDataTableForNonAdmin(selectQuery).ToString();
            }
            else
            {
                Session["message"] = "לא נמצאו רשומות";
                Response.Redirect("Message.aspx");
            }
        }
        if (Request.Form["ProfessionSubmit"] != null)
        {
            string selectQuery = string.Format("SELECT BagrutDatabase.*, profession AS Expr1 FROM BagrutDatabase WHERE (profession = '{0}')", Request.Form["profession"]);
            if (MyAdoHelperAccess.IsExist(selectQuery))
            {
                userList += "<tr>";
                userList += "<td>שם משתמש</td>";
                userList += "<td>סיסמה</td>";
                userList += "<td>תעודת זהות</td>";
                userList += "<td>מנהל</td>";
                userList += "<td>אימייל</td>";
                userList += "<td>שם פרטי</td>";
                userList += "<td>מין</td>";
                userList += "<td>שנת לידה</td>";
                userList += "<td>תחום עיסוק</td>";
                userList += "<td>מטרות באתר</td>";
                userList += "<td>סכום תרומה</td>";
                userList += "<td>עולה חדש</td>";
                userList += "<td>מנהל</td>";
                userList += MyAdoHelperAccess.PrintDataTableForNonAdmin(selectQuery).ToString();
            }
            else
            {
                Session["message"] = "לא נמצאו רשומות";
                Response.Redirect("Message.aspx");
            }
        }
        if (Request.Form["UserNameANdIdSubmit"] != null)
        {
            if (Request.Form["UserName"] == "" || Request.Form["UserId"] == "" || Request.Form["UserName"] == "" && Request.Form["UserId"] == "" || Request.Form["UserId"] == " ")
            {
                Session["message"] = "יש בעיה באחד הפרטים";
                Response.Redirect("Message.aspx");
            }
            else
            {
                string selectQuery = string.Format("SELECT BagrutDatabase.*, userName AS Expr1, userId AS Expr2 FROM BagrutDatabase WHERE (userName = '{0}') AND (userId = {1})", Request.Form["UserName"], Request.Form["UserId"]);
                if (MyAdoHelperAccess.IsExist(selectQuery))
                {
                    userList += "<tr>";
                    userList += "<td>שם משתמש</td>";
                    userList += "<td>סיסמה</td>";
                    userList += "<td>תעודת זהות</td>";
                    userList += "<td>מנהל</td>";
                    userList += "<td>אימייל</td>";
                    userList += "<td>שם פרטי</td>";
                    userList += "<td>מין</td>";
                    userList += "<td>שנת לידה</td>";
                    userList += "<td>תחום עיסוק</td>";
                    userList += "<td>מטרות באתר</td>";
                    userList += "<td>סכום תרומה</td>";
                    userList += "<td>עולה חדש</td>";
                    userList += "<td>מנהל</td>";
                    userList += MyAdoHelperAccess.PrintDataTableForNonAdmin(selectQuery).ToString();
                }
                else
                {
                    Session["message"] = "לא נמצאו רשומות";
                    Response.Redirect("Message.aspx");
                }
            }
        }
            
    }
}