<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateUserAdmin.aspx.cs" Inherits="UpdateUserAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageName" runat="Server">
    עדכון משתמשים לאדמין
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="info" runat="Server">
    <table border="1">
        <tr>
            <td>
                <input type="text" id="fname" name="fname" value="<%=fname%>" />
            </td>
            <td>הכנס שם פרטי
            </td>

        </tr>
        <tr>
            <td>
                <input type="text" id="lname" name="lname" value="<%=lname %>" />

            </td>
            <td>הכנס שם משפחה
            </td>

        </tr>
        <tr>
            <td>
                <input type="text" id="userId" name="userId" value="<%=userId%>" />

            </td>
            <td>הכנס תעודת זהות
            </td>

        </tr>
        <tr>
            <td>
                <input type="text" id="userName" name="userName" value="<%=userName%>" />

            </td>
            <td>הכנס שם משתמש 
            </td>
        </tr>

        <tr>
            <td>
                <input type="password" id="userPassword" name="userPassword" value="<%=Request.QueryString["userPassword"] %>" />

            </td>
            <td>הכנס סיסמה
            </td>
        </tr>

        <tr>
            <td>
                <input type="text" id="userEmail" name="userEmail" value="<%=userEmail%>" />

            </td>
            <td>הכנס כתובת אימייל
            </td>
        </tr>
        <tr>
            <td>
                <input type="radio" id="male" name="gender" value="male" <%
                    if (gender == "male")
                    {
                        Response.Write("checked");
                    }%> />
               זכר
                <br />
        <input type="radio" id="female" name="gender" value="female" <%
            if (gender == "female")
            {
                Response.Write("checked");
            }%> />
                נקבה
            </td>
            <td>מין
            </td>
        </tr>

        <tr>
            <td>
                <input type="text" id="userDonation" name="userDonation" value="<%=userDonation%>" />
            </td>
            <td>הכנס סכום תרומה 
            </td>
        </tr>
        <tr>
            <td>
                <input type="radio" id="True" name="NewComer" value="True" <%
                    if (newComer_m == "True")
                    {
                        Response.Write("checked");
                    }%> />
                עולה חדש
            <br />
                <input type="radio" id="False" name="NewComer" value="False" <%
                    if (newComer_m == "False")
                    {
                        Response.Write("checked");
                    }%> />
                לא עולה חדש
            
            </td>
            <td>עולה חדש
            </td>
        </tr>
        <tr>
            <td>
                <input type="text" id="birthYear" name="birthYear" value="<%=birthYear%>" />
            </td>
            <td>שנת לידה
            </td>
        </tr>
        <tr>
            <td>
                <select id="profession" name="profession">
                    <option id="student" name="student" value="תלמיד" <%if (profession == "תלמיד")
                        {
                            { %>selected<% };
                        }%>>אני תלמיד
                    </option>
                    <option id="worker" name="worker" value="עובד" <%if (profession == "עובד")
                        {
                            { %>selected<% };
                        }%>>אני עובד
                    </option>
                    <option id="other" name="other" value="אחר" <%if (profession == "אחר")
                        {
                            { %>selected<% };
                        }%>>אחר
                    </option>
                </select>
            </td>
            <td>מקצוע שלי
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <input type="checkbox" id="know" name="target" value="לדעת" <%if (target.Contains("לדעת"))
                    {
                        { %>
                    checked <% }
                    } %> />
                לדעת יותר על המלחמה
                <br />
                <input type="checkbox" id="support" name="target" value="לתמוך" <%if (target.Contains("לתמוך"))
                    {
                        { %>
                    checked <% }
                    } %> />
                לתמוך במשפחות החטופים ובארגונים
                <br />
            </td>
            <td>: מה המטרה שלך באתר זה
            </td>
        </tr>
        <tr>
            <td>
                <input type="radio" id="AdminTrue" name="Admin" value="True" <%
                    if (userAdmin == true)
                    {
                        Response.Write("checked");
                    }%> />
                אדמין
            <br />
                <input type="radio" id="AdminFalse" name="Admin" value="False" <%
                    if (userAdmin == false)
                    {
                        Response.Write("checked");
                    }%> />
                לא אדמין
            
            </td>
            <td>אדמין
            </td>
        </tr>
        <tr>
            <td>
                <a href="mailto:roy429436@gmail.com">כתובת אימייל שלי</a>
            </td>
            <td>כתובת אימייל
            </td>
        </tr>
        <tr>
            <td>
                <input type="submit" id="submit" name="submit" value="שלח" />
                <input type="reset" id="reset" name="reset" value="מחק" />
            </td>
            <td>פעולות
            </td>
        </tr>

    </table>
</asp:Content>

