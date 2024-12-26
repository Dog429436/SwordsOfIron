<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageName" Runat="Server">
    התחברות
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="info" Runat="Server">
    <table border="1">
        <tr>
            <td>
                <input type="text" id="Uname" name="Uname" />
            </td>
            <td>
                הכנס שם משתמש
            </td>
        </tr>
        <tr>
            <td>
                 <input type="text" id="Upass" name="Upass" />
            </td>
            <td>
                הכנס סיסמה
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

