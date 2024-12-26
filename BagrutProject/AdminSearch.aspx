<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminSearch.aspx.cs" Inherits="AdminSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageName" runat="Server">
    חיפוש משתמשים למנהלים
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="info" runat="Server">
    :הצגת כל המשתמשים   
    <br />
    <input type="submit" id="PrintAll" name="PrintAll" value="כל המשתמשים" />
    <br />
    :חיפוש לפי שם פרטי   
    <br />
    <input type="text" id="FName" name="FName" />
    <br />
    <input type="submit" id="Fsubmit" name="Fsubmit" value="חפש" />
    <br />
    :חיפוש לפי תעסוקה
    <br />
    <select id="profession" name="profession">
        <option>תלמיד
        </option>
        <option>עובד
        </option>
        <option>אחר
        </option>
    </select>
    <br />
    <input type="submit" id="ProfessionSubmit" name="ProfessionSubmit" value="חפש" />
    <br />
    :חיפוש לפי שם משתמש וסיסמה
    <br />
    :הכנס שם משתמש
    <br />
    <input type="text" id="UserName" name="UserName" />
    <br />
    :הכנס סיסמה
    <br />
    <input type="text" id="UserPassword" name="UserPassword" />
    <br />
    <input type="submit" id="UserNameANdPAssWordSubmit" name="UserNameANdPAssWordSubmit" value="חפש" />
    <br />
    <br />
    <table border="1" style="background-color: lightgrey; width: 80%; margin-left: auto; margin-right: auto; table-layout: fixed">
        <tr>
            <%= userList%>
        </tr>
    </table>
</asp:Content>

