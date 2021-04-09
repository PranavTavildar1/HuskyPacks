<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clubs.aspx.cs" Inherits="HuskyPacks.Clubs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script src="Scripts/jquery-3.4.1.min.js"></script>
<script src="Scripts/jquery.validate.min.js"></script>
<script src="Scripts/WebForms/bootstrap-datepicker.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script> 

<h3>Clubs</h3>

<div class="search-container">
    <div class="form-group">
       
    </div>
    <div class="form-group">
        <table class="nav-justified">
            <tr>
                <td>&nbsp;<asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" CssClass="btn btn-primary"  Text="+New" /></td>
                <td style="text-align:right">&nbsp;
                    <div class = "col-sm-4" >
                        <div class="input-group">
                            <asp:TextBox ID="txtSearchClubs" CssClass="form-control" placeholder="Search..."  runat="server"></asp:TextBox>
                            <span class="input-group-addon"><asp:LinkButton ID="btnSearchClubs"  runat="server"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                </span>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id = "panelClubList" runat="server" />
    <asp:PlaceHolder ID="phClubList" runat="server"></asp:PlaceHolder>






</div>
</asp:Content>
