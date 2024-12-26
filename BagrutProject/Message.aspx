<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="ErrorMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageName" Runat="Server">
    <%=Session["message"].ToString()%>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="info" Runat="Server">
</asp:Content>

