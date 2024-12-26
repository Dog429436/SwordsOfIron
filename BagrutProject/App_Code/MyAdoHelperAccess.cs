﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;
using System.Xml;
using System.IO; //XML - רישום נתונים בקובץ

/// <summary>
/// Summary description for MyAdoHelper
/// פעולות עזר לשימוש במסד נתונים מסוג אקסס
///  App_Data המסד ממוקם בתקיה 
/// </summary>

public class MyAdoHelperAccess
{
    public MyAdoHelperAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static OleDbConnection ConnectToDb()
    {
        //string fileName = "xxx/mdf"; //שם הקובץ
        //string fileName = "DB.mdb";   //שם הקובץ
        string fileName = "BagrutDatabase.accdb";   //שם הקובץ

        string path = HttpContext.Current.Server.MapPath("App_Data/");//מיקום מסד בפורוייקט
        path += fileName;
        //string path = HttpContext.Current.Server.MapPath("App_Data/" + fileName);//מאתר את מיקום מסד הנתונים מהשורש ועד התקייה בה ממוקם המסד
        //string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + path;//נתוני ההתחברות הכוללים מיקום וסוג המסד
        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" + path;//נתוני ההתחברות הכוללים מיקום וסוג המסד

        OleDbConnection conn = new OleDbConnection(connString);
        return conn;
    }

    /// <summary>
    /// To Execute update / insert / delete queries
    ///  הפעולה מקבלת שם קובץ ומשפט לביצוע ומבצעת את הפעולה על המסד
    /// </summary>

    public static void DoQuery(string sql)//הפעולה מקבלת שם מסד נתונים ומחרוזת מחיקה/ הוספה/ עדכון
    //ומבצעת את הפקודה על המסד הפיזי
    {
        OleDbConnection conn = ConnectToDb();
        conn.Open();  //פתיחת קישור
        OleDbCommand com = new OleDbCommand(sql, conn);
        com.ExecuteNonQuery();  //ביצוע פעולת עדכון שהוגדרה
        com.Dispose();      //שחרור משאבים
        conn.Close();       //סגירת קישור
    }

    /// <summary>
    /// To Execute update / insert / delete queries
    ///  הפעולה מקבלת שם קובץ ומשפט לביצוע ומחזירה את מספר השורות שהושפעו מביצוע הפעולה
    /// </summary>
    public static int RowsAffected(string sql)
    //הפעולה מקבלת מסלול מסד נתונים ופקודת עדכון
    //ומבצעת את הפקודה על המסד הפיזי
    {
        OleDbConnection conn = ConnectToDb();
        conn.Open();
        OleDbCommand com = new OleDbCommand(sql, conn);
        int rowsA = com.ExecuteNonQuery();
        conn.Close();
        return rowsA;
    }


    /// <summary>
    /// הפעולה מקבלת שם קובץ ומשפט לחיפוש ערך - מחזירה אמת אם הערך נמצא ושקר אחרת
    /// </summary>
    public static bool IsExist(string sql)
    //הפעולה מקבלת שם קובץ ומשפט בחירת נתון ומחזירה אמת אם הנתונים קיימים ושקר אחרת
    {
        //ConnectToDb - שיטת חיבור למאגר נתונים
        OleDbConnection conn = ConnectToDb();
        conn.Open();
        OleDbCommand com = new OleDbCommand(sql, conn);
        OleDbDataReader data = com.ExecuteReader(); //ביצוע אחזור
        bool found;
        // אם יש נתונים לקריאה יושם אמת אחרת שקר - הערך קיים במסד הנתונים
        found = (bool)data.Read();
        conn.Close();
        return found;
    }


    public static DataTable ExecuteDataTable(string sql)
    {
        OleDbConnection conn = ConnectToDb();
        conn.Open();

        //DataTable -יצירת אובייקט
        //sql -שמכיל עותק נתונים מאוחזרים מפעולת
        //המאפשר - DataAdapter
        //1. גישה למסד פיזי
        //2. בנתונים המאוחזרים DataTable של Fill מילוי
        //3. סגירת הקישור למסד בסיומה של הפעולה
        OleDbDataAdapter tableAdapter = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable(); //DataTable- יצירת מופע של אובייקט
        tableAdapter.Fill(dt);
        return dt; //DataTable - החזרת עותק הנתונים
    }

    public void ExecuteNonQuery(string sql)
    {
        OleDbConnection conn = ConnectToDb();
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    //הפעולה מקבלת משפט בחירת נתון ומחזירה 
    //מחרוזת המכילה טבלה עם כל המידע שבמאגר נתונים    
    //public static string PrintDataTable(string sql)
    //{
    //    //הנוצר מהפעולה הנ"ל DataTable אחזור נתונים ל
    //    DataTable dt = ExecuteDataTable(sql);

    //    string printStr = "<table border='1'>"; //HTML יצירת טבלה במחרוזת

    //    foreach (DataRow row in dt.Rows) //dt סריקת שורות בטבלה
    //    {
    //        printStr += "<tr>";
    //        //foreach שימוש בלולאה
    //        //מאפשרת סריקת אוספים של האובייקט
    //        //על כל ערך באוסף נבצע המרה למחרוזת
    //        //HTML -ונשרשר להוראה היוצרת טבלה ב
    //        foreach (object myItemArray in row.ItemArray)
    //        {
    //            //אוסף הערכים בשורה - ItemArray  סריקת
    //            printStr += "<td>" + myItemArray.ToString() +"</td>";
    //        }
    //        printStr += "</tr>";
    //    }
    //    printStr += "</table>";
    //    return printStr;
    //}

    public static string PrintDataTable(string sql)
    {
        //הנוצר מהפעולה הנ"ל DataTable אחזור נתונים ל
        DataTable dt = ExecuteDataTable(sql);
        string bgcolor;
        string manager_m;
        string newComer_m;
        bool color = false;
        string str = "";
        foreach (DataRow row in dt.Rows)
        {
            if (color)
                bgcolor = " bgcolor='#d3d3d3'";
            else
                bgcolor = " bgcolor='#d3d3d3'";

            if ((bool)row["userAdmin"])
                manager_m = "כן";
            else
                manager_m = "לא";

            if ((bool)row["newComer"])
                newComer_m = "כן";
            else
                newComer_m = "לא";

            str += "<tr" + bgcolor + ">";
            str += "<td>" + row["userName"] + "</td>";
            str += "<td>" + row["userPassword"] + "</td>";
            str += "<td>" + row["userId"] + "</td>";
            str += "<td>" + row["userAdmin"] + "</td>";
            str += "<td>" + row["userEmail"] + "</td>";
            str += "<td>" + row["fname"] + " " + row["lname"] + "</td>";
            str += "<td>" + row["gender"] + "</td>";
            str += "<td>" + row["birthYear"] + "</td>";
            str += "<td>" + row["profession"] + "</td>";
            str += "<td>" + row["target"] + "</td>";
            str += "<td>" + row["userDonation"] + "</td>";
            str += "<td>" + newComer_m + "</td>";
            str += "<td>" + manager_m + "</td>";
            str += "</tr>";
            color = !color;
        }
        return str;
    }
    public static string PrintDataTableForNonAdmin(string sql)
    {
        //למשתמשים שהם לא מנהלים הנוצר מהפעולה הנ"ל DataTable אחזור נתונים ל
        DataTable dt = ExecuteDataTable(sql);
        string bgcolor;
        string manager_m;
        string newComer_m;
        bool color = false;
        string str = "";
        foreach (DataRow row in dt.Rows)
        {
            if (color)
                bgcolor = " bgcolor='#d3d3d3'";
            else
                bgcolor = " bgcolor='#d3d3d3'";

            if ((bool)row["userAdmin"])
                manager_m = "כן";
            else
                manager_m = "לא";
            if ((bool)row["newComer"])
                newComer_m = "כן";
            else
                newComer_m = "לא";

            str += "<tr" + bgcolor + ">";
            str += "<td>" + row["userName"] + "</td>";
            str += "<td>" + "***" + "</td>";
            str += "<td>" + row["userId"] + "</td>";
            str += "<td>" + row["userAdmin"] + "</td>";
            str += "<td>" + row["userEmail"] + "</td>";
            str += "<td>" + row["fname"] + " " + row["lname"] + "</td>";
            str += "<td>" + row["gender"] + "</td>";
            str += "<td>" + row["birthYear"] + "</td>";
            str += "<td>" + row["profession"] + "</td>";
            str += "<td>" + row["target"] + "</td>";
            str += "<td>" + row["userDonation"] + "</td>";
            str += "<td>" + newComer_m + "</td>";
            str += "<td>" + manager_m + "</td>";
            str += "</tr>";
            color = !color;
        }
        return str;
    }
    public static string GetSql(string sql, string column) // המחזירה את ערכי המשתמש הרצוי בעמודה הרצויה אבל בסוף הפעולה החיבור נסגר ExecuteDataTableפעולה הדומה ל
    {
        string get = "";

        OleDbConnection conn = ConnectToDb();

        conn.Open(); //פתיחת חיבור

        DataTable dt = new DataTable(); // יצירת אובייקט מסוג datatable 


        OleDbDataAdapter tableAdapter = new OleDbDataAdapter(sql, conn); //OleDbDataAdapter יצירת אובייקט מסוג 
        tableAdapter.Fill(dt); //dt הכנסת המידע לאובייקט     
        foreach (DataRow row in dt.Rows) //הכנסת המידע מהמבנה נתונים בהתאם לעמודה הרצוייה
        {
            get += row[column];
        }
        conn.Close(); //סגירת החיבור
        conn.Dispose(); //שחרור החומרים ששומשו בחיבור
        return get; //החזרת הנתונים
    }
    //public static string GetSql(string sql, string column) // המחזירה את ערכי המשתמש הרצוי בעמודה הרצויה אבל בסוף הפעולה החיבור נסגר ExecuteDataTableפעולה הדומה ל
    //{
    //    string get = "";

    //    using (OleDbConnection conn = ConnectToDb())
    //    {
    //        conn.Open(); // פתיחת חיבור שמתנקה בסוף הפעולה בעקבות using

    //        using (DataTable dt = new DataTable()) // יצירת אובייקט מסוג datatable 
    //        {
    //            using (OleDbDataAdapter tableAdapter = new OleDbDataAdapter(sql, conn)) 
    //            {
    //                tableAdapter.Fill(dt);
    //            }

    //            // Process the DataTable
    //            foreach (DataRow row in dt.Rows)
    //            {
    //                get += row[column];
    //            }
    //        } 
    //    } 

    //    return get;
    //}
    public static string PrintDataTableForAdmin(string sql)
    {
        //למשתמשים שהם לא מנהלים הנוצר מהפעולה הנ"ל DataTable אחזור נתונים ל
        DataTable dt = ExecuteDataTable(sql);
        string bgcolor;
        string manager_m;
        string newComer_m;
        bool color = false;
        string str = "";
        foreach (DataRow row in dt.Rows)
        {
            if (color)
                bgcolor = " bgcolor='#d3d3d3'";
            else
                bgcolor = " bgcolor='#d3d3d3'";

            if ((bool)row["userAdmin"])
                manager_m = "כן";
            else
                manager_m = "לא";
            if ((bool)row["newComer"])
                newComer_m = "כן";
            else
                newComer_m = "לא";

            str += "<tr" + bgcolor + ">";
            //str += "<td> <a href='UpdateUserAdmin.aspx?userName=" + row["userName"] + "&lname=" + row["lname"] + "&userPassword=" + row["userPassword"] + "&userId=" + row["userId"] + "&userAdmin=" + row["userAdmin"] + "&userEmail=" + row["userEmail"] + "&fname=" + row["fname"] + "&gender=" + row["gender"] + "&birthYear=" + row["birthYear"] + "&profession=" + row["profession"] + "&target=" + row["target"] + "&userDonation=" + row["userDonation"] + "&newComer_m=" + row["newComer"] + "&manager_m=" + row["userAdmin"] + "'> <img src='Pictures/edit_profile.png' border='0' /> </a> <a href='DeleteUserForAdmin.aspx?userPassword=" + row["userPassword"] + "'> <img src='Pictures/delete_user.png' border='0' onclick='return confirm(\"delete?\")' /> </a> </td>";
            str += "<td> <a href='UpdateUserAdmin.aspx?userPassword=" + row["userPassword"] + "'> <img src='Pictures/edit_profile.png' border='0' /> </a> <a href='DeleteUserForAdmin.aspx?userPassword=" + row["userPassword"] + "'> <img src='Pictures/delete_user.png' border='0' onclick='return confirm(\"delete?\")' /> </a> </td>";
            str += "<td>" + row["userName"] + "</td>";
            str += "<td>" + row["userPassword"] + "</td>";
            str += "<td>" + row["userId"] + "</td>";
            str += "<td>" + row["userAdmin"] + "</td>";
            str += "<td>" + row["userEmail"] + "</td>";
            str += "<td>" + row["fname"] + " " + row["lname"] + "</td>";
            str += "<td>" + row["gender"] + "</td>";
            str += "<td>" + row["birthYear"] + "</td>";
            str += "<td>" + row["profession"] + "</td>";
            str += "<td>" + row["target"] + "</td>";
            str += "<td>" + row["userDonation"] + "</td>";
            str += "<td>" + newComer_m + "</td>";
            str += "<td>" + manager_m + "</td>";
            str += "</tr>";
            color = !color;
        }
        return str;
    }

    public static DataTable GetFullTable(string tbl)
    {

        return GetTable("select * from " + tbl);
    }

    public static DataTable GetTable(string sqlStr)
    {
        OleDbConnection con = MyAdoHelperAccess.ConnectToDb();
        OleDbCommand cmd = new OleDbCommand(sqlStr, con);

        DataTable dt = new DataTable();
        OleDbDataAdapter adp = new OleDbDataAdapter();
        adp.SelectCommand = cmd;

        adp.Fill(dt);
        return dt;
    }




    //XML - חיבור לקובץ
    //והחזרת כל הנתונים
    public static XmlDocument XmlDocumentReturn(string xmlFile)
    {
        string path = HttpContext.Current.Server.MapPath("App_Data/");// מיקום קובץ החדשות
        path += xmlFile;

        XmlDocument doc = new XmlDocument(); // יצירת אובייקט XML
        doc.Load(path); // טעינת קובץ החדשות
        return doc;
    }

    //XML - הכנסת חדשות לקובץ 
    public static bool InsertReport(string xmlFile, string user, string date, string content)
    { // הפעולה מקבלת שם משתמש, תאריך ותוכן חדשה ומוסיפה אותה

        XmlElement reportEle, userEle, dateEle, contentEle;
        XmlDocument doc = new XmlDocument(); // יצירת אובייקט XML

        string path = HttpContext.Current.Server.MapPath("App_Data/");// מיקום קובץ החדשות
        path += xmlFile;

        doc.Load(path); // טעינת קובץ החדשות
        userEle = doc.CreateElement("user"); // אלמנט חדש למשתמש
        dateEle = doc.CreateElement("date"); // אלמנט חדש לתאריך
        contentEle = doc.CreateElement("content"); // אלמנט חדש לתוכן
        reportEle = doc.CreateElement("report"); // אלמנט חדש לדיווח
        userEle.InnerText = user; // הכנסת טקסט לאלמנט המשתמש
        dateEle.InnerText = date; // הכנסת טקסט לאלמנט התאריך
        contentEle.InnerText = content; // הכנסת טקסט לאלמנט התוכן
        reportEle.AppendChild(userEle); // צירוף אלמנט המשתמש לחדשה
        reportEle.AppendChild(dateEle); // צירוף אלמנט התאריך לחדשה
        reportEle.AppendChild(contentEle); // צירוף אלמנט התוכן לחדשה
        doc.DocumentElement.InsertBefore(reportEle, doc.DocumentElement.FirstChild); // הוספת החדשה לתחילת הקובץ
        FileStream fsxml = new FileStream(path, FileMode.Truncate,
                                  FileAccess.Write,
                                  FileShare.ReadWrite);
        doc.Save(fsxml);
        fsxml.Close();//חובה לסגור את הקובץ 
        return true;
    }


}