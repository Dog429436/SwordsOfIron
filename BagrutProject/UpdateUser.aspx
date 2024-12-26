<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateUser.aspx.cs" Inherits="UpdateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageName" Runat="Server">
    דף עדכון נתונים
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="info" Runat="Server">
    <table border="1">
        <tr>
            <td>
                <input type="text" id="UserName" name="UserName"/>
            </td>
            <td>
                הכנס שם משתמש
            </td>
        </tr>
        <tr>
            <td>
                <input type="text" id="UserPassword" name="UserPassword" />
            </td>
            <td>
                הכנס סיסמה
            </td>
        </tr>
        <tr>
            <td>
                <input type="text" id="NewPassword" name="NewPassword" />
            </td>
            <td>
                הכנס סיסמה חדשה
            </td>
        </tr>
        <tr>
            <td>
                <input type="submit" id="submit" name="submit" value="שלח" />
            </td>
            <td>
                פעולות
            </td>
        </tr>
    </table>
</asp:Content>

