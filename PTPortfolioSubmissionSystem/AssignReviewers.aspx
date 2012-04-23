<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AssignReviewers.aspx.vb" Inherits="PTPortfolioSubmissionSystem.AssignReviewers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table ID="tblMain" runat="server" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0" >
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" Text="Assign Reviewers" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
        <asp:Label runat="server" ForeColor="Black" Font-Bold="true" Text="Reviewers:"></asp:Label>&nbsp;
        <asp:DropDownList runat="server" ID="ddlReviewers" DataSourceID="sqlReviewers" DataTextField="Reviewer" DataValueField="UserID" ></asp:DropDownList>&nbsp;
        <asp:SqlDataSource ID="SqlReviewers" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select UserID, FirstName + ' ' + MiddleInitial + '. ' + LastName + ' (' + Type + ')' as Reviewer From [User] Where (Type='Peer Reviewer' OR Type='Classroom Observer') And UserID NOT IN (Select UserID from Review where PortfolioID=@PID ) order by Reviewer">
        <SelectParameters>
                <asp:ControlParameter ControlID="lblPID" Name="PID" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button runat="server" ID="btnAssignReviewer" Text="Assign Selected Reviewer" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
     <asp:TableRow>
        <asp:TableCell>
            <asp:GridView ID="grdAssignedReviewers" runat="server" DataSourceID="SqlAssignedReviewers" Width="100%" AlternatingRowStyle-BackColor="#EAE4D0" AllowSorting="true" AllowPaging="true" PageSize="20" AutoGenerateColumns="false" GridLines="None" >
                <HeaderStyle BackColor="Silver" Font-Bold="true" />
                <PagerStyle BackColor="Silver" Font-Bold="true" HorizontalAlign="Center" />
                <PagerSettings Mode="Numeric" Position="Bottom" />
                <Columns>
                    <asp:TemplateField ItemStyle-Width="1%"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>
                    <asp:HyperLinkField ItemStyle-Width="5%" ItemStyle-Font-Bold="true" Text="Delete" DataNavigateUrlFields="PortfolioID, UserID" DataNavigateUrlFormatString="AssignmentDelete.aspx?PortfolioID={0}&UserID={1}" />
                    <asp:BoundField HeaderText="Reviewer" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="Reviewer" SortExpression="Reviwer" />
                    <asp:BoundField HeaderText="Review Type" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="Type" SortExpression="Type" />
                    </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlAssignedReviewers" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select u.UserID, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName as Reviewer, u.Type, r.PortfolioID, r.UserID From [User] u inner join Review r on u.UserID=r.UserID Where r.PortfolioID=@PID order by Reviewer" >
            <SelectParameters>
                <asp:ControlParameter ControlID="lblPID" Name="PID" />
            </SelectParameters>
            </asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnBack" Text="Back" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:Label runat="server" ID="lblPID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUserID" Visible="false"></asp:Label>
<asp:Label runat="server" ID="lblUsername" Visible="False"></asp:Label>
</asp:Content>
