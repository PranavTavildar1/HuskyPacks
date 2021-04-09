<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="HuskyPacks.Signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="form-group">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Login</h3>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <asp:Label ID="Label1" AssociatedControlID="txtName" runat="server" CssClass="text-primary" Text="Name"></asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="txtName" placeholder="Email" runat="server"  CssClass="form-control is-invalid" required Width="300px"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" AssociatedControlID="txtPassword" runat="server" CssClass="text-primary" Text="Password"></asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control is-invalid" required Width="300px"></asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <div class="input-group">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click"  />&nbsp;
                    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />
                </div>
            </div>

        </div>
    </div>
</div>

<asp:Panel ID="panelError" Visible="false" runat="server">
    <div ID="divErrorMessage" class="alert alert-danger alert-dismissible" runat="server">
    <strong>Error!</strong> User ID or password is incorrect.
</div>
</asp:Panel>


</asp:Content>
