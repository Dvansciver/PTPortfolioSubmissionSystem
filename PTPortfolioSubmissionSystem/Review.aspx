<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Review.aspx.vb" Inherits="PTPortfolioSubmissionSystem.Review" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Table runat="server" ID="tblMain" Width="100%" HorizontalAlign="Center" CellPadding="1" CellSpacing="0" >
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" Text="Reviews" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Button runat="server" ID="btnAdd" Text="Add Review" />&nbsp;
            <asp:Label runat="server" Font-Bold="true" Text="Search by Portfolio Year..."></asp:Label>&nbsp;
            <asp:TextBox runat="server" ID="txtYearSearch" ></asp:TextBox>&nbsp;
            <asp:Button runat="server" ID="btnYearSearch" Text="Search" />&nbsp;
            <asp:Label runat="server" Font-Bold="true" Text="Search by Reviewer Last Name..."></asp:Label>&nbsp;
            <asp:TextBox runat="server" ID="txtLastNameSearch" ></asp:TextBox>&nbsp;
            <asp:Button runat="server" ID="btnLastNameSearch" Text="Search" />&nbsp;
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow><asp:TableCell>&nbsp;</asp:TableCell></asp:TableRow>
     <asp:TableRow>
        <asp:TableCell>
            <asp:GridView ID="grdReviews" runat="server" DataSourceID="SqlReviews" Width="100%" AlternatingRowStyle-BackColor="#EAE4D0" AllowSorting="true" AllowPaging="true" PageSize="20" AutoGenerateColumns="false" GridLines="None" >
                <HeaderStyle BackColor="Silver" Font-Bold="true" />
                <PagerStyle BackColor="Silver" Font-Bold="true" HorizontalAlign="Center" />
                <PagerSettings Mode="Numeric" Position="Bottom" />
                <Columns>
                    <asp:TemplateField ItemStyle-Width="1%"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>
                    <asp:HyperLinkField ItemStyle-Width="5%" ItemStyle-Font-Bold="true" Text="Modify" DataNavigateUrlFields="ReviewID" DataNavigateUrlFormatString="ReviewModify.aspx?ReviewID={0}" />
                    <asp:HyperLinkField ItemStyle-Width="5%" ItemStyle-Font-Bold="true" Text="Delete" DataNavigateUrlFields="ReviewID" DataNavigateUrlFormatString="ReviewDelete.aspx?ReviewID={0}" />
                    <asp:BoundField HeaderText="Reviewer" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="14%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" SortExpression="Reviewer" DataField="Reviewer" />
                    <asp:BoundField HeaderText="Review Type" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="Type" SortExpression="Type"/>
                    <asp:BoundField HeaderText="Candidate" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="14%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="Candidate" SortExpression="Candidate"/>
                    <asp:BoundField HeaderText="ReviewStage" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" ItemStyle-Width="12%" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" DataField="ReviewStage" SortExpression="ReviewStage"/>
                    <asp:TemplateField HeaderText="Portfolio Submitted" SortExpression="PortfolioDate" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:Label ID="lblPortfolioDate" Text='<%# Eval("PortfolioDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Review Submitted" SortExpression="ReviewDate" ItemStyle-Font-Size="Large" ItemStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:Label ID="lblReviewDate" Text='<%# Eval("ReviewDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField ItemStyle-Width="8%" ItemStyle-Font-Bold="true" Text="View Review" DataNavigateUrlFields="ReviewID" DataNavigateUrlFormatString="ReviewView.aspx?ReviewID={0}" />
                    </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlReviews" runat="server" ConnectionString="<%$ connectionstrings:PT %>" SelectCommand="Select r.ReviewID, r.UserID, r.PortfolioID, r.PostDate as ReviewDate, u.UserID, u.Type, u.FirstName + ' ' + u.MiddleInitial + '. ' + u.LastName as Reviewer, p.PortfolioID, p.UserID, p.ReviewStage, p.PostDate as PortfolioDate, (Select c.Firstname + ' ' + c.MiddleInitial + '. ' + c.Lastname from [User] c where c.UserID=p.UserID) as Candidate From (Review r inner join [User] u on r.UserID=u.UserID) inner join Portfolio p on r.PortfolioID=p.PortfolioID order by Reviewer" >
            </asp:SqlDataSource>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
</asp:Content>
