<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="User.aspx.vb" Inherits="PTPortfolioSubmissionSystem.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table ID="tblMain" runat="server" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0" >
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" Text="Users" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnAdd" Text="Add User" />&nbsp;&nbsp;
            <asp:Label runat="server" Font-Bold="true" Text="Search by Last Name..."></asp:Label>&nbsp;
            <asp:TextBox runat="server" ID="txtSearchLastName"></asp:TextBox>&nbsp;
            <asp:Button runat="server" ID="btnSearchLastName" Text="Search" />&nbsp;
            <asp:Label runat="server" Font-Bold="true" Text="Search by User Type..."></asp:Label>&nbsp;
            <asp:DropDownList runat="server" ID="ddlUserType">
            <asp:ListItem Value="Administrator" Text="Administrator" Selected="true" />
            <asp:ListItem Value="Candidate" Text="Candidate"/>
            <asp:ListItem Value="Classroom Observer" Text="Classroom Observer"/>
            <asp:ListItem Value="Peer Reviewer" Text="Peer Reviewer"/>
            </asp:DropDownList>&nbsp;
            <asp:Button runat="server" ID="btnSearchUserType" Text="Search" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:GridView ID="grdUsers" runat="server" DataSourceID="SqlUsers" Width="100%" AlternatingRowStyle-BackColor="#EAE4D0" AllowSorting="true" AllowPaging="true" PageSize="20" AutoGenerateColumns="false" GridLines="None" >
                <HeaderStyle BackColor="Silver" Font-Bold="true" />
                <PagerStyle BackColor="Silver" Font-Bold="true" HorizontalAlign="Center" />
                <PagerSettings Mode="Numeric" Position="Bottom" />
                <Columns>
                    <asp:TemplateField ItemStyle-Width="1%"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>
                    <asp:HyperLinkField ItemStyle-Width="5%" ItemStyle-Font-Bold="true" Text="Modify" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="UserModify.aspx?UserID={0}" />
                    <asp:HyperLinkField ItemStyle-Width="10%" ItemStyle-Font-Bold="true" Text="Delete" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="UserDelete.aspx?UserID={0}" />
                    <asp:BoundField HeaderText="First Name" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" SortExpression="FirstName" DataField="FirstName" />
                    <asp:BoundField HeaderText="Middle Initial" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="MiddleInitial" SortExpression="MiddleInitial"/>
                    <asp:BoundField HeaderText="Last Name" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="LastName" SortExpression="LastName"/>
                    <asp:BoundField HeaderText="Username" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="Username" SortExpression="Username" />
                    <asp:BoundField HeaderText="Type" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="Type" SortExpression="Type" />
                    </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlUsers" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select UserID, FirstName, LastName, MiddleInitial, Username, Type From [User] order by LastName" >
            </asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
</asp:Content>
