<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClubDetail.aspx.cs" Inherits="HuskyPacks.ClubDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script src="Scripts/jquery-3.4.1.min.js"></script>
<script src="Scripts/jquery.validate.min.js"></script>
<script src="Scripts/WebForms/bootstrap-datepicker.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script> 

<h3></h3>
<div class="container">
    <div class="container-fluid">
	    <div class="row">
		    <div class="col-md-6"><asp:Image ID="imgClub" runat="server"  Width="500px" class="img-rounded"/>
		    </div>
		    <div class="col-md-6">    
                <div id="lblClubName" class="display-4" runat="server"></div>
                <div id="lblFoundedOn" runat="server"></div>
                <div id="lblMemberCount" runat="server"></div>
                <div id="lblClubDescription" class="lead" runat="server"></div>
		    </div>
	    </div>
        <div class="row">
            <br />
            <!-- Trigger the modal with a button -->
            <div class="col-md-6">
                <asp:Button ID="btnNewMember" class="btn btn-info" data-toggle="modal" data-target="#myModal" OnClientClick="return false;" UseSubmitBehavior="false" runat="server" Text="+ Members" CausesValidation="False" />
                &nbsp;
                <asp:Button ID="btnJoin" class="btn btn-info" runat="server" Text="Join" OnClick="btnJoin_Click" /></div>
            <div class="col-md-6"><div id="lblCategory" runat="server"></div></div>
        </div>
    </div>
    <br/>
    <div id="panelExecs" runat="server"></div>
    <br/>
    <div class="row">
        <div class="col-md-6">
            <asp:Button ID="btnAddNewEvent" runat="server" OnClientClick="return false;"  CausesValidation="false" UseSubmitBehavior="false" Text="+ Events" class="btn btn-info" data-toggle="modal" data-target="#addEventModal"/>
        </div>
    </div>
    <br/>
    <div id="panelEventList" runat="server"></div>

</div>


                
<!-- Modal -->
<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Club Members</h4>
            </div>
            <div class="modal-body">
                <div class="form-row">
                    <asp:Label ID="Label4" AssociatedControlID="ddlStudents" runat="server" CssClass="text-primary" Text="Student"></asp:Label>
                    <div class="input-group">
                        <asp:DropDownList ID="ddlStudents" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">
                    <asp:Label ID="Label1" AssociatedControlID="ddlRoles" runat="server" CssClass="text-primary" Text="Role"></asp:Label>
                    <div class="input-group">
                        <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnAddMember" class="btn btn-default" data-dismiss="modal" runat="server" Text="Submit" OnClick="btnAddMember_Click" UseSubmitBehavior="False" />
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>

<!-- Modal -->
<div class="modal fade" id="addEventModal" role="dialog">
    <div class="modal-dialog">
    
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">New Event</h4>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <asp:Label ID="Label2" AssociatedControlID="txtName" runat="server" CssClass="text-primary" Text="Event Name"></asp:Label>
                    <div class="input-group">
                        <asp:TextBox ID="txtName" placeholder="Enter Event name" runat="server" CssClass="form-control is-invalid" required Width="300px"></asp:TextBox>
                    </div>
                </div>
    
                <div class="form-group">
                    <asp:Label ID="Label3" AssociatedControlID="txtDescription" runat="server" CssClass="text-primary" Text="Event Description"></asp:Label>
                    <div class="input-group">
                        <asp:TextBox ID="txtDescription" placeholder="Enter Description" runat="server" CssClass="form-control is-invalid" required Width="300px"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <asp:Label ID="Label6" AssociatedControlID="txtDateTime" runat="server" CssClass="text-primary" Text="Event Date"></asp:Label>
                    <div class="input-group">
                        <span class="input-group-addon"><span class="glyphicon glyphicon-th"></span></span>
                
                        <asp:TextBox ID="txtDateTime" runat="server" CssClass="form-control" required Width="100px"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label7" AssociatedControlID="ddlBuilding" runat="server" CssClass="text-primary" Text="Building"></asp:Label>
                    <div class="input-group">
                       <asp:DropDownList ID="ddlBuilding" runat="server" CssClass="form-control is-invalid" required Width="300px"></asp:DropDownList> 
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label8" AssociatedControlID="txtRoomNo" runat="server" CssClass="text-primary" Text="Room"></asp:Label>
                    <div class="input-group">
                        <asp:TextBox ID="txtRoomNo" placeholder="Room Number" runat="server" CssClass="form-control is-invalid" required Width="300px"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label9" AssociatedControlID="ddlRSVP" runat="server" CssClass="text-primary" Text="RSVP Required"></asp:Label>
                    <div class="input-group">
                       <asp:DropDownList ID="ddlRSVP" runat="server" CssClass="form-control is-invalid" required="" Width="300px">
                           <asp:ListItem Value="Y">Required</asp:ListItem>
                           <asp:ListItem Value="N">Not Required</asp:ListItem>
                       </asp:DropDownList> 
                    </div>
                </div>

                <div class="form-row">
                    <asp:Label ID="Label10" AssociatedControlID="txtBudget" runat="server" CssClass="text-primary" Text="Initial budget amount"></asp:Label>
                    <div class="input-group">
                        <span class="input-group-addon">$</span>
                        <asp:TextBox ID="txtBudget" runat="server" CssClass="form-control" Width="100px"  required></asp:TextBox>
                    </div>
                </div>
            </div>
          <div class="form-row">
                <asp:Label ID="Label5" AssociatedControlID="imgFile" runat="server" CssClass="text-primary" Text="Event Image"></asp:Label>
                <div class="input-group">
                    <asp:FileUpload ID="imgFile" runat="server" />
                </div>
            <div class="modal-footer">
                <asp:Button ID="btnAddEvent" class="btn btn-default" data-dismiss="modal" runat="server" Text="Submit" UseSubmitBehavior="False" OnClick="btnAddEvent_Click" />
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>
    </div>
</div>
            
<asp:TextBox ID="hdnClubID" Visible="false" runat="server"></asp:TextBox>
    </div>
</asp:Content>
