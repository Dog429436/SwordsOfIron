using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminSearch : System.Web.UI.Page
{
    public string userList = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["isAdmin"] == false)
        {
            Session["message"] = "דף למנהלים בלבד";
            Response.Redirect("Message.aspx");
        }
        string HeadLines = "";
        HeadLines += "<tr>";
        HeadLines += "<td>פעולות</td>";
        HeadLines += "<td>שם משתמש</td>";
        HeadLines += "<td>סיסמה</td>";
        HeadLines += "<td>תעודת זהות</td>";
        HeadLines += "<td>מנהל</td>";
        HeadLines += "<td>אימייל</td>";
        HeadLines += "<td>שם פרטי ושם משפחה</td>";
        HeadLines += "<td>מין</td>";
        HeadLines += "<td>שנת לידה</td>";
        HeadLines += "<td>תחום עיסוק</td>";
        HeadLines += "<td>מטרות באתר</td>";
        HeadLines += "<td>סכום תרומה</td>";
        HeadLines += "<td>עולה חדש</td>";
        HeadLines += "<td>מנהל</td>";
        if (Request.Form["PrintAll"] != null)
        {

            string TableName = "BagrutDatabase";
            string selectQuery = "SELECT * FROM " + TableName;
            userList = HeadLines + MyAdoHelperAccess.PrintDataTableForAdmin(selectQuery).ToString();
        }
        if (Request.Form["Fsubmit"] != null)
        {
            string selectQuery = string.Format("SELECT BagrutDatabase.*, fname AS Expr1 FROM BagrutDatabase WHERE (fname = '{0}')", Request.Form["FName"]);
            if (MyAdoHelperAccess.IsExist(selectQuery))
            {
                userList = HeadLines + MyAdoHelperAccess.PrintDataTableForAdmin(selectQuery).ToString();
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
                userList = HeadLines + MyAdoHelperAccess.PrintDataTableForAdmin(selectQuery).ToString();
            }
            else
            {
                Session["message"] = "לא נמצאו רשומות";
                Response.Redirect("Message.aspx");
            }
        }
        if (Request.Form["UserNameANdPAssWordSubmit"] != null)
        {
            string selectQuery = string.Format("SELECT BagrutDatabase.*, userName AS Expr1, userPassword AS Expr2 FROM BagrutDatabase WHERE (userName = '{0}') AND (userPassword = '{1}')", Request.Form["UserName"], Request.Form["UserPassword"]);
            if (MyAdoHelperAccess.IsExist(selectQuery))
            {
                userList = HeadLines + MyAdoHelperAccess.PrintDataTableForAdmin(selectQuery).ToString();
            }
            else
            {
                Session["message"] = "לא נמצאו רשומות";
                Response.Redirect("Message.aspx");
            }
        }

    }
}