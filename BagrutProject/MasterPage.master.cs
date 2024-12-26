using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string Counter = "";
    public string ProtectedLink = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Application["Count"] == null)
        {
            Application["Count"] = 0;
        }
        if (Session["firstTimeLog"] == null)
        {
            Application.Lock();
            Application["Count"] = (int)Application["Count"] + 1;
            Application.UnLock();
            Session["firstTimeLog"] = 1;

        }
        Counter = Application["Count"].ToString();
        if (Session["isUser"] == null)
        {
            ProtectedLink += ("| <a href=\"UserLogin.aspx\">דף התחברות</a>");
            ProtectedLink += ("| <a href=\"UserForm.aspx\">טופס הרשמה</a> ");

        }
        else
        {
            if ((bool)Session["isAdmin"] == true)
            {
                ProtectedLink += ("| <a href=\"AdminSearch.aspx\">חיפוש משתמשים למנהלים</a>");
            }
            ProtectedLink += ("| <a href=\"UpdateUser.aspx\">דף עדכון נתונים</a>");
            ProtectedLink += ("| <a href=\"DeleteUser.aspx\">דף מחיקה</a>");
            ProtectedLink += ("| <a href=\"UserLogOut.aspx\">התנתקות</a>");
            ProtectedLink += ("| <a href=\"UserSearch.aspx\">חיפוש למשתמשים</a>");
            ProtectedLink += ("| <a href=\"Pictures.aspx\">אלבום תמונות</a>");

        }



    }
}
