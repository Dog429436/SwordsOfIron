<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserForm.aspx.cs" Inherits="UserForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageName" runat="Server">
    טופס הרשמה
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="info" runat="Server">
    <table border="1">
        <tr>
            <td>
                <input type="text" id="fname" name="fname" />
            </td>
            <td>
                הכנס שם פרטי
            </td>

        </tr>
        <tr>
            <td>
                <input type="text" id="lname" name="lname" />

            </td>
            <td>
                הכנס שם משפחה
            </td>

        </tr>
        <tr>
            <td>
                <input type="text" id="userId" name="userId" />              

            </td>
            <td>
                הכנס תעודת זהות
            </td>

        </tr>
        <tr>
            <td>
                <input type="text" id="userName" name="userName" />
                
            </td>
            <td>
                הכנס שם משתמש 
            </td>
        </tr>

        <tr>
            <td>
                <input type="password" id="userPassword" name="userPassword" />
                
            </td>
            <td>
                הכנס סיסמה
            </td>
        </tr>

        <tr>
            <td>
                <input type="text" id="userEmail" name="userEmail" />
               
            </td>
            <td>
                 הכנס כתובת אימייל
            </td>
        </tr>
        <tr>
            <td>
                <input type="radio" id="male" name="gender" value="male" />   
                זכר
                <br />
                <input type="radio" id="female" name="gender" value="female" />
                נקבה
            </td>
            <td>
                 מין
            </td>
        </tr>
        <tr>
            <td>
                <input type="text" id="userDonation" name="userDonation" />
            </td>
            <td>
                 הכנס סכום תרומה 
            </td>
        </tr>
        <tr>
            <td>
                <input type="radio" id="True" name="NewComer" value="True" />
                עולה חדש
                <br />
                <input type="radio" id="False" name="NewComer" value="False" />
                 לא עולה חדש
                
            </td>
            <td>
                 עולה חדש
            </td>
        </tr>
        <tr>
            <td>
                <input type="text" id="birthYear" name="birthYear" />
            </td>
            <td>
                שנת לידה
            </td>
        </tr>
        <tr>
            <td>
                <select id="profession" name="profession">
                    <option id="student" name="student" value="תלמיד">אני תלמיד
                    </option>
                    <option id="worker" name="worker" value="עובד">אני עובד
                    </option>
                    <option id="other" name="other" value="אחר">אחר
                    </option>
                </select>
            </td>
            <td>
                מקצוע שלי
            </td>
        </tr>
        <tr>
            <td>
                    <br />
                <input type="checkbox" id="know" name="target" value="לדעת" />
                לדעת יותר על המלחמה
                    <br />
                <input type="checkbox" id="support" name="target" value="לתמוך" />
                לתמוך במשפחות החטופים ובארגונים
                    <br />
            </td>
            <td>
                : מה המטרה שלך באתר זה
            </td>
        </tr>
        <tr>
            <td>
                <a href="mailto:roy429436@gmail.com">כתובת אימייל שלי</a>
            </td>
            <td>
                כתובת אימייל
            </td>
        </tr>
        <tr>
            <td>
                <input type="submit" id="submit" name="submit" value="שלח" />
                <input type="reset" id="reset" name="reset" value="מחק" />
            </td>
            <td>
                פעולות
            </td>
        </tr>
    </table>
</asp:Content>

