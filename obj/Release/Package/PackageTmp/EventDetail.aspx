<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventDetail.aspx.cs" Inherits="HuskyPacks.EventDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script src="Scripts/jquery-3.4.1.min.js"></script>
<script src="Scripts/jquery.validate.min.js"></script>
<script src="Scripts/WebForms/bootstrap-datepicker.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script> 

<h3></h3>
<div class="container">
    <div class="container-fluid">
	    <div class="row">
		    <div class="col-md-6"><asp:Image ID="imgEvent" runat="server"  Width="500px" class="img-rounded"/>
		    </div>
		    <div class="col-md-6">    
                <div id="lblEventName" class="display-4" runat="server"></div>
                <div id="lblEventDate" runat="server"></div>
                <div id="lblAttendees" runat="server"></div>
                <div id="lblEventDescription" class="lead" runat="server"></div>
				<div id="lblEventBuilding" runat="server"></div>
				<div id="lblAddress1" runat="server"></div>
				<div id="lblAddress2" runat="server"></div>
				<br/>
                <asp:Button ID="btnRSVP" runat="server" class="btn btn-primary" Text="RSVP" OnClick="btnRSVP_Click" />
				<asp:Button ID="btnCancelRSVP" runat="server" class="btn btn-primary" Text="Cancel RSVP" OnClick="btnCancelRSVP_Click" />
		    </div>
	    </div>
		<br/>
		<div id="panelAttendeeList" runat="server"></div>
	</div>
</div>

    <asp:HiddenField ID="hdnEventId" runat="server" />
</asp:Content>
