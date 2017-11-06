<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="_1201ThirdTenants.building_directory._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Building Directory</h1>
    <p>Please click on the column heading to search by that particular category.</p>
    <table border="1" class="table">
        <thead>
            <tr>
                <th scope="col" class="header">Tenant</th>
                <th scope="col" class="header headerSortDown">Suite</th>
                <th scope="col" class="header">Website</th>
                <th scope="col" class="header">Phone</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="Directory_Tenant">Diamond Parking</td>
                <td class="Directory_Suite"></td>
                <td><a href="http://www.diamondparking.com" target="_blank">www.diamondparking.com</a></td>
                <td class="Directory_Phone">206-805-6034</td>
            </tr>
            <tr>
                <td class="Directory_Tenant">Security</td>
                <td class="Directory_Suite"></td>
                <td></td>
                <td class="Directory_Phone">206-224-1203</td>
            </tr>
            <tr>
                <td class="Directory_Tenant">Wright Runstad &amp; Company, Property Management</td>
                <td class="Directory_Suite">520</td>
                <td><a href="http://www.1201ThirdTenants.com" target="_blank">www.1201ThirdTenants.com</a></td>
                <td class="Directory_Phone">206-224-1201</td>
            </tr>
        </tbody>
        <tfoot></tfoot>
    </table>

</asp:Content>
