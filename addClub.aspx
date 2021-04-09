<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addClub.aspx.cs" Inherits="HuskyPacks.addClub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script src="Scripts/jquery-3.4.1.min.js"></script>
<script src="Scripts/jquery.validate.min.js"></script>
<script src="Scripts/WebForms/bootstrap-datepicker.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script> 
<br />

<div class="form-group">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">New Club</h3>
        </div>
        <div class="panel-body">

            <div class="form-group">
                <asp:Label ID="Label1" AssociatedControlID="txtClubName" runat="server" CssClass="text-primary" Text="Club Name"></asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="txtClubName" placeholder="Enter club name" runat="server" CssClass="form-control is-invalid" required Width="300px"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" AssociatedControlID="txtDescription" runat="server" CssClass="text-primary"  Text="Club description"></asp:Label>
                <div class="input-group">
                    <asp:TextBox ID="txtDescription" runat="server" Rows="4" TextMode="MultiLine" Width="300px" CssClass="form-control" required></asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <asp:Label ID="Label3" AssociatedControlID="txtFoundingDate" runat="server" CssClass="text-primary" Text="Founding date"></asp:Label>
                <div class="input-group">
                    <span class="input-group-addon"><span class="glyphicon glyphicon-th"></span></span>
                
                    <asp:TextBox ID="txtFoundingDate" runat="server" CssClass="form-control" required Width="100px"></asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <asp:Label ID="Label4" AssociatedControlID="ddlCategory" runat="server" CssClass="text-primary" Text="Category"></asp:Label>
                <div class="input-group">
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-row">
                <asp:Label ID="Label5" AssociatedControlID="txtBudget" runat="server" CssClass="text-primary" Text="Initial budget amount"></asp:Label>
                <div class="input-group">
                    <span class="input-group-addon">$</span>
                    <asp:TextBox ID="txtBudget" runat="server" CssClass="form-control" Width="100px"  required></asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <asp:Label ID="Label6" AssociatedControlID="ddlStatus" runat="server"  CssClass="text-primary"  Text="Status"></asp:Label>
                <div class="input-group">
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                        <asp:ListItem Value="A">Active</asp:ListItem>
                        <asp:ListItem Value="I">Inactive</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-row">
                <asp:Label ID="Label7" AssociatedControlID="imgFile" runat="server" CssClass="text-primary" Text="Club Image"></asp:Label>
                <div class="input-group">
                    <asp:FileUpload ID="imgFile" runat="server" />
                </div>


            </div>
            <br />
            <div class="form-row">
                <div class="input-group">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="btn btn-primary" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" />
                </div>
            </div>
      </div>
    </div>
</div>
<asp:Panel ID="panelSuccessAlert" Visible="false" runat="server">
    <div class="alert alert-success alert-dismissible">
        <strong>Success!</strong> Club has been added.
    </div>
</asp:Panel>
<script>
    $(document).ready(function () {
        var date_input = $('input[name="<%=txtFoundingDate.UniqueID %>"]'); //our date input has the name "date"
        var container = $('.bootstrap-iso form').length > 0 ? $('.bootstrap-iso form').parent() : "body";
        var options = {
            format: 'mm/dd/yyyy',
            container: container,
            todayHighlight: true,
            autoclose: true,
        };
        date_input.datepicker(options);
    })
</script>


</asp:Content>
