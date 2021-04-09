<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HuskyPacks.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script src="Scripts/jquery-3.4.1.min.js"></script>
<script src="Scripts/jquery.validate.min.js"></script>
<script src="Scripts/WebForms/bootstrap-datepicker.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script> 
<br />

<div class="form-group">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Register</h3>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <asp:Label ID="Label1" AssociatedControlID="txtName" runat="server" CssClass="text-primary" Text="Name"></asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="txtName" placeholder="Enter your name" runat="server" CssClass="form-control is-invalid" required Width="300px"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label4" AssociatedControlID="txtName" runat="server" CssClass="text-primary" Text="Email ID"></asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="txtEmail" placeholder="Enter your name" runat="server" CssClass="form-control is-invalid" required Width="300px" TextMode="Email"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" AssociatedControlID="txtName" runat="server" CssClass="text-primary" Text="Password"></asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="txtPassword" placeholder="Enter your name" runat="server" CssClass="form-control is-invalid" required Width="300px" TextMode="Password"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label3" AssociatedControlID="txtName" runat="server" CssClass="text-primary" Text="Confirm Password"></asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="txtConfirm" placeholder="Enter your name" runat="server" CssClass="form-control is-invalid" required Width="300px" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="form-row">
                <div class="input-group">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
</div>

<asp:Panel ID="panelSuccessAlert" Visible="false" runat="server">
<div class="alert alert-warning alert-dismissible">
    <strong>Success!</strong> User successfully registered.
</div>
</asp:Panel>

<asp:Panel ID="panelError" Visible="false" runat="server">
    <div ID="divErrorMessage" class="alert alert-danger alert-dismissible" runat="server">
    <strong>Success!</strong> Club has been added.
</div>
</asp:Panel>

</asp:Content>
