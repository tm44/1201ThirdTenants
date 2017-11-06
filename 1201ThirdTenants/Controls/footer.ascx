<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footer.ascx.cs" Inherits="_1201ThirdTenants.Controls.footer" %>
<%@ Register Src="~/Controls/breadcrumb.ascx" TagPrefix="uc1" TagName="breadcrumb" %>

<div id="footer" class="row hidden-xs">
    <uc1:breadcrumb runat="server" id="breadcrumb" />
    <div class="pull-right">
        <a href="http://www.wrightrunstad.com" target="_blank">
            <img src="/images/wrc_logo.jpg" width="214" height="13" alt="Wright Runstad &amp; Company" id="wrc_logo"></a>
        Copyright &copy; <%=System.DateTime.Now.Year %>
    </div>
</div>
