using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Activities.Expressions;

public partial class UserForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["submit"] != null)
        {

            string fileName = "BagrutDatabase.accdb";
            string path = HttpContext.Current.Server.MapPath("App_Data/");//מיקום מסד בפורוייקט
            path += fileName;
            string connString = "Provider = Microsoft.ACE.OLEDB.12.0;Data source=" + path;//נתוני ההתחברות הכוללים מיקום וסוג המסד

            OleDbConnection conn = new OleDbConnection(connString);

            string fname_u;
            string lname_u;
            string userName_u;
            int userId_u = 0;
            string userEmail_u;
            string userGender_u;
            int newComer_u;
            int userBirthYear_u = 0;
            string userProfession_u;
            string userTarget_u;
            string userPassword_u;
            string userDonation_u;
            string userAdmin_u = "";
            fname_u = Request.Form["fname"];
            lname_u = Request.Form["lname"];
            userName_u = Request.Form["userName"];
            userPassword_u = Request.Form["userPassword"];
            userEmail_u = Request.Form["userEmail"];
            userGender_u = Request.Form["gender"];
            userDonation_u = Request.Form["userDonation"];
            int i = 0;
            bool result;
            if (Request.Form["NewComer"] == "True")
            {
                newComer_u = 1;
            }
            else
            {
                newComer_u = 0;
            }
            result = int.TryParse(Request.Form["birthYear"], out i);
            if (Request.Form["birthYear"] == "" || Request.Form["birthYear"] == " " || !result)
            {
                Session["message"] = "יש בעיה בהזנת שנת לידה";
                Response.Redirect("Message.aspx");
            }
            else
            {
                userBirthYear_u = int.Parse(Request.Form["birthYear"]);
            }
            result = int.TryParse(Request.Form["userId"], out i);
            if (Request.Form["userId"] == "" || Request.Form["userId"] == " " || !result)
            {
                Session["message"] = "יש בעיה בהזנת תעודת זהות";
                Response.Redirect("Message.aspx");
            }
            else
            {
                userId_u = int.Parse(Request.Form["userId"]);
            }
            if (Request.Form["userPassword"] == "" || Request.Form["userPassword"] == " ")
            {
                Session["message"] = "יש בעיה בהזנת סיסמה";
                Response.Redirect("Message.aspx");
            }
            userProfession_u = Request.Form["profession"];
            userTarget_u = Request.Form["target"];
            string TableName = "BagrutDatabase";
            string sql = string.Format("SELECT userPassword, userName FROM BagrutDatabase WHERE (userName = '{0}') OR (userPassword = '{1}')", userName_u, userPassword_u);
            
            if (MyAdoHelperAccess.IsExist(sql))
            {
                Session["message"] = "שם משתמש או סיסמה קיימים";
                Response.Redirect("Message.aspx");
            }
            else
            {
                sql = string.Format("INSERT INTO {0} (fname, lname, gender, userDonation, birthYear, profession, target, userName, userPassword, userEmail, userId, NewComer) VALUES ('{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}','{9}','{10}',{11},'{12}')", TableName, fname_u, lname_u, userGender_u, userDonation_u, userBirthYear_u, userProfession_u, userTarget_u, userName_u, userPassword_u, userEmail_u, userId_u, newComer_u);
                conn.Open();
                OleDbCommand com = new OleDbCommand(sql, conn);
                com.ExecuteNonQuery();
                com.Dispose();
                conn.Close();
                Session["message"] = "נרשמת בהצלחה";
                Session["isUser"] = userName_u;
                Session["isAdmin"] = false;
                Response.Redirect("Message.aspx");
            }
            
            
        }

    }
}