<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HuskyPacks._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Husky Packs</h1>
                
                
        <p class="lead"><img src="Images/HuskyPacksLogo.jpg" width="150px" />Welcome to Husky Packs, a simple club experience for UConn Students!</p>
        <p></p>
    </div>

    <h2>Featured Clubs</h2>

    <div id="panelFeaturedClubs" runat="server"></div>


    <h2>Featured Events</h2>
    <div id="panelFeaturedEvents" runat="server"></div>

</asp:Content>
