using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateUserAdmin : System.Web.UI.Page
{
    public string userName = "", lname = "", userPassword = "", gender = "", userEmail = "", fname = "", profession = "", target = "", userDonation = "", newComer_m = "", userOldPassword = "", tempPassword = "", birthYear = "";
    public string userId = "";
    public int newComer_u, admin_u;
    public bool userAdmin = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["isAdmin"] == false)
        {
            Session["message"] = "דף למנהלים בלבד";
            Response.Redirect("Message.aspx");
        }
        if (Request.Form["submit"] != null)
        {
            string username_u;
            string lname_u;
            string userNewPassword_u = "";
            string gender_u;
            string userEmail_u;
            string fname_u;
            string profession_u;
            string target_u;
            string userDonation_u;
            int newComer_u = 0;
            int userId_u = 0;
            int birthYear_u = 0;
            int admin_u;
            username_u = Request.Form["userName"];
            lname_u = Request.Form["lname"];
            gender_u = Request.Form["gender"];
            userEmail_u = Request.Form["userEmail"];
            fname_u = Request.Form["fname"];
            profession_u = Request.Form["profession"];
            target_u = Request.Form["target"];
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
                birthYear_u = int.Parse(Request.Form["birthYear"]);
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
            else
            {
                userNewPassword_u = Request.Form["userPassword"];
            }
            if (Request.Form["admin"] == "True")
            {
                admin_u = 1;
            }
            else
            {
                admin_u = 0;
            }
            string sql = "";
            if (Session["OldPassword"].ToString() == userNewPassword_u)
            {
                sql = string.Format("UPDATE BagrutDatabase SET fname = '{0}', lname = '{1}', gender = '{2}', userDonation = '{3}', birthYear = {4}, profession = '{5}', target = '{6}', userName = '{7}', userAdmin = {8}, userEmail = '{9}', userId = {10}, newComer = {11} WHERE        (BagrutDatabase.userPassword = '{12}')", fname_u, lname_u, gender_u, userDonation_u, birthYear_u, profession_u, target_u, username_u, admin_u, userEmail_u, userId_u, newComer_u, Session["OldPassword"].ToString());
                MyAdoHelperAccess.DoQuery(sql);
                Session["message"] = "פרטיך עודכנה בהצלחה";
                Response.Redirect("Message.aspx");
            }
            else
            {
                sql = string.Format("SELECT * FROM BagrutDatabase WHERE (userPassword = '{0}')", userNewPassword_u);
                if (MyAdoHelperAccess.IsExist(sql))
                {
                    Session["message"] = "סיסמה קיימת";
                    Response.Redirect("Message.aspx");
                }
                sql = string.Format("UPDATE BagrutDatabase SET fname = '{0}', lname = '{1}', gender = '{2}', userDonation = '{3}', birthYear = {4}, profession = '{5}', target = '{6}', userName = '{7}', userPassword = '{8}', userAdmin = {9}, userEmail = '{10}', userId = {11}, newComer = {12} WHERE        (BagrutDatabase.userPassword = '{13}')", fname_u, lname_u, gender_u, userDonation_u, birthYear_u, profession_u, target_u, username_u, userNewPassword_u, admin_u, userEmail_u, userId_u, newComer_u, Session["OldPassword"].ToString());
                MyAdoHelperAccess.DoQuery(sql);
                Session["message"] = "פרטיך עודכנה בהצלחה";
                Response.Redirect("Message.aspx");
            }


        }
        else
        {
            Session["OldPassword"] = Request.QueryString["userPassword"];
            userPassword = Request.QueryString["userPassword"];
            userOldPassword = Request.QueryString["userPassword"];
            string sql = String.Format("SELECT * FROM BagrutDatabase WHERE (userPassword = '{0}')", userPassword);
            userName = MyAdoHelperAccess.GetSql(sql, "userName");
            lname = MyAdoHelperAccess.GetSql(sql, "lname");
            gender = MyAdoHelperAccess.GetSql(sql, "gender");
            userEmail = MyAdoHelperAccess.GetSql(sql, "userEmail");
            fname = MyAdoHelperAccess.GetSql(sql, "fname");
            profession = MyAdoHelperAccess.GetSql(sql, "profession");
            target = MyAdoHelperAccess.GetSql(sql, "target");
            userDonation = MyAdoHelperAccess.GetSql(sql, "userDonation");
            newComer_m = MyAdoHelperAccess.GetSql(sql, "newComer");
            if (MyAdoHelperAccess.GetSql(sql, "userAdmin") == "True")
            {
                userAdmin = true;
            }
            birthYear = MyAdoHelperAccess.GetSql(sql, "birthYear");
            userId = MyAdoHelperAccess.GetSql(sql, "userId");


        }

    }
}
