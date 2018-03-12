<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TravelExperts_ASP.Home" MasterPageFile="TESite.Master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="homediv">
        <h1 class="greeting" style="position:fixed; margin-top:70px; width:100%">Welcome,<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>!</h1>
        <br />
    </div>

</asp:Content>

