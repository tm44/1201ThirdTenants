<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="topnav.ascx.cs" Inherits="_1201ThirdTenants.Controls.topnav" %>
<div class="rowXXX">
    <input id="main-menu-state" type="checkbox" />
    <label class="main-menu-btn" for="main-menu-state">
        <span class="main-menu-btn-icon"></span>Toggle main menu visibility
    </label>
    <asp:PlaceHolder ID="MenuPlaceholder" runat="server" Visible="true">
        </asp:PlaceHolder>
<%--    <ul class="sm sm-clean" id="main-menu">
        <li><a href="#">Home</a></li>
        <li><a href="#">Building Directory</a></li>
        <li><a href="#">Building Info</a>
            <ul>
                <li><a href="#">Building History</a></li>
                <li><a href="#">Space Available</a></li>
            </ul>
        </li>
        <li><a href="#">Security</a></li>
        <li><a href="#">Your Safety</a></li>
        <li><a href="#">Tenant Services</a></li>
        <li><a href="#">Contact</a></li>
    </ul>--%>
</div>

