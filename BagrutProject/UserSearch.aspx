<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserSearch.aspx.cs" Inherits="UserSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageName" Runat="Server">
    דף חיפוש למשתמשים מחוברים
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="info" Runat="Server">
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
:חיפוש לפי שם משתמש ותעודת זהות 
<br />
:הכנס שם משתמש
<br />
<input type="text" id="UserName" name="UserName" />
<br />
:הכנס תעודת זהות
<br />
<input type="text" id="UserId" name="UserId" />
<br />
<input type="submit" id="UserNameAndIdSubmit" name="UserNameAndIdSubmit" value="חפש" />
<br />
<table border="1" style="background-color: lightgrey; width: 80%; margin-left: auto; margin-right: auto; table-layout: fixed">
  <tr>
    <tr>
        <%= userList%>
    </tr>
</table>

</asp:Content>

